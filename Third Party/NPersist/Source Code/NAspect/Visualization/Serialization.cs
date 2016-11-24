using System;
using System.Collections.Generic;
using System.Text;
using Puzzle.NAspect.Visualization.Presentation;
using System.Xml;
using System.Reflection;
using System.Collections;
using System.Windows.Forms;

namespace Puzzle.NAspect.Visualization
{
    public class Serialization
    {
        #region Configuration

        public static string SerializeConfiguration(PresentationModel model)
        {
            XmlDocument xmlDoc = new XmlDocument();

            XmlNode rootNode = xmlDoc.CreateElement("naspect");
            xmlDoc.AppendChild(rootNode);

            XmlNode configNode = xmlDoc.CreateElement("configuration");
            rootNode.AppendChild(configNode);

            foreach (PresentationAspect aspect in model.Aspects)
                SerializeAspect(aspect, xmlDoc, configNode);

            StringBuilder stringBuilder = new StringBuilder();
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            using (XmlWriter xmlWriter = XmlWriter.Create(stringBuilder, settings))
            {
                xmlDoc.WriteContentTo(xmlWriter);
                xmlWriter.Flush();
                return stringBuilder.ToString() ;
            }
        }

        private static void SerializeAspect(PresentationAspect aspect, XmlDocument xmlDoc, XmlNode configNode)
        {
            XmlNode aspectNode = xmlDoc.CreateElement("aspect");

            if (aspect.Name != "")
            {
                XmlAttribute nameAttrib = xmlDoc.CreateAttribute("name");
                nameAttrib.Value = aspect.Name;
                aspectNode.Attributes.Append(nameAttrib);
            }

            configNode.AppendChild(aspectNode);

            foreach (PresentationAspectTarget target in aspect.Targets)
                SerializeAspectTarget(target, xmlDoc, aspectNode);

            foreach (PresentationMixin mixin in aspect.Mixins)
                SerializeMixin(mixin, xmlDoc, aspectNode);

            foreach (PresentationPointcut pointcut in aspect.Pointcuts)
                SerializePointcut(pointcut, xmlDoc, aspectNode);
        }

        private static void SerializeAspectTarget(PresentationAspectTarget target, XmlDocument xmlDoc, XmlNode aspectNode)
        {
            XmlNode targetNode = xmlDoc.CreateElement("target");

            XmlAttribute sigAttrib = xmlDoc.CreateAttribute("signature");
            sigAttrib.Value = target.Signature;
            targetNode.Attributes.Append(sigAttrib);

            XmlAttribute typeAttrib = xmlDoc.CreateAttribute("type");
            typeAttrib.Value = target.TargetType.ToString().ToLower();
            targetNode.Attributes.Append(typeAttrib);

            if (target.Exclude)
            {
                XmlAttribute exAttrib = xmlDoc.CreateAttribute("exclude");
                exAttrib.Value = "true";
                targetNode.Attributes.Append(exAttrib);
            }

            aspectNode.AppendChild(targetNode);
        }


        private static void SerializeMixin(PresentationMixin mixin, XmlDocument xmlDoc, XmlNode aspectNode)
        {
            XmlNode mixinNode = xmlDoc.CreateElement("mixin");

            XmlAttribute typeAttrib = xmlDoc.CreateAttribute("type");
            typeAttrib.Value = mixin.TypeName;
            mixinNode.Attributes.Append(typeAttrib);

            aspectNode.AppendChild(mixinNode);
        }


        private static void SerializePointcut(PresentationPointcut pointcut, XmlDocument xmlDoc, XmlNode aspectNode)
        {
            XmlNode pointcutNode = xmlDoc.CreateElement("pointcut");

            if (pointcut.Name != "")
            {
                XmlAttribute nameAttrib = xmlDoc.CreateAttribute("name");
                nameAttrib.Value = pointcut.Name;
                pointcutNode.Attributes.Append(nameAttrib);
            }

            aspectNode.AppendChild(pointcutNode);

            foreach (PresentationPointcutTarget target in pointcut.Targets)
                SerializePointcutTarget(target, xmlDoc, pointcutNode);

            foreach (PresentationInterceptor interceptor in pointcut.Interceptors)
                SerializeInterceptor(interceptor, xmlDoc, pointcutNode);
        }


        private static void SerializePointcutTarget(PresentationPointcutTarget target, XmlDocument xmlDoc, XmlNode pointcutNode)
        {
            XmlNode targetNode = xmlDoc.CreateElement("target");

            XmlAttribute sigAttrib = xmlDoc.CreateAttribute("signature");
            sigAttrib.Value = target.Signature;
            targetNode.Attributes.Append(sigAttrib);

            XmlAttribute typeAttrib = xmlDoc.CreateAttribute("type");
            typeAttrib.Value = target.TargetType.ToString().ToLower();
            targetNode.Attributes.Append(typeAttrib);

            if (target.Exclude)
            {
                XmlAttribute exAttrib = xmlDoc.CreateAttribute("exclude");
                exAttrib.Value = "true";
                targetNode.Attributes.Append(exAttrib);
            }

            pointcutNode.AppendChild(targetNode);
        }

        private static void SerializeInterceptor(PresentationInterceptor interceptor, XmlDocument xmlDoc, XmlNode pointcutNode)
        {
            XmlNode interceptorNode = xmlDoc.CreateElement("interceptor");

            XmlAttribute typeAttrib = xmlDoc.CreateAttribute("type");
            typeAttrib.Value = interceptor.TypeName;
            interceptorNode.Attributes.Append(typeAttrib);

            pointcutNode.AppendChild(interceptorNode);
        }

        #endregion

        #region Project

        public static string SerializeProject(IList assemblies, string configFileName)
        {
            XmlDocument xmlDoc = new XmlDocument();

            XmlNode rootNode = xmlDoc.CreateElement("project");
            xmlDoc.AppendChild(rootNode);

            SerializeConfig(configFileName, xmlDoc, rootNode);

            foreach (Assembly asm in assemblies)
                SerializeAssembly(asm, xmlDoc, rootNode);

            StringBuilder stringBuilder = new StringBuilder();
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            using (XmlWriter xmlWriter = XmlWriter.Create(stringBuilder, settings))
            {
                xmlDoc.WriteContentTo(xmlWriter);
                xmlWriter.Flush();
                return stringBuilder.ToString();
            }
        }

        private static void SerializeConfig(string configFileName, XmlDocument xmlDoc, XmlNode rootNode)
        {
            if (configFileName == "")
                return;

            XmlNode configNode = xmlDoc.CreateElement("config");

            XmlAttribute fileAttrib = xmlDoc.CreateAttribute("file");
            fileAttrib.Value = configFileName;
            configNode.Attributes.Append(fileAttrib);

            rootNode.AppendChild(configNode);
        }

        private static void SerializeAssembly(Assembly asm, XmlDocument xmlDoc, XmlNode rootNode)
        {
            XmlNode asmNode = xmlDoc.CreateElement("assembly");

            XmlAttribute fileAttrib = xmlDoc.CreateAttribute("file");
            fileAttrib.Value = asm.Location;
            asmNode.Attributes.Append(fileAttrib);

            rootNode.AppendChild(asmNode);
        }

        public static void DeserializeProject(string xml, IList assemblies, ref string configFileName)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);

            foreach (XmlNode xmlNode in xmlDoc.ChildNodes)
            {
                if (xmlNode.Name == "project")
                {
                    DeserializeProject(xmlNode, assemblies, ref configFileName);
                    return;
                }
            }
        }

        private static void DeserializeProject(XmlNode projectNode, IList assemblies, ref string configFileName)
        {
            foreach (XmlNode xmlNode in projectNode.ChildNodes)
            {
                if (xmlNode.Name == "config")
                    DeserializeConfig(xmlNode, ref configFileName);
                else if (xmlNode.Name == "assembly")
                    DeserializeAssembly(xmlNode, assemblies);
            }
        }

        private static void DeserializeConfig(XmlNode xmlNode, ref string configFileName)
        {
            configFileName = xmlNode.Attributes["file"].Value;
        }

        private static void DeserializeAssembly(XmlNode xmlNode, IList assemblies)
        {
            string fileName = xmlNode.Attributes["file"].Value;
            try
            {
                Assembly asm = Assembly.LoadFile(fileName);
                assemblies.Add(asm);
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Could not load assembly {0}. {1}", fileName, ex.Message)); 
            }
        }

        #endregion


    }
}
