// *
// * Copyright (C) 2005 Roger Alsing : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

using System;
using System.Collections;
using System.Xml;
using Puzzle.NAspect.Framework.Aop;

namespace Puzzle.NAspect.Framework
{
    /// <summary>
    /// Class that deserializes engine configurations from xml
    /// </summary>
    public class ConfigurationDeserializer
    {
        private bool useTypePlaceHolders;
        public bool UseTypePlaceHolders
        {
            get => useTypePlaceHolders;
            set => useTypePlaceHolders = value;
        }
	
        /// <summary>
        /// return a configured <c>IEngine</c> from an xml element.
        /// </summary>
        /// <param name="xmlRoot">xml node to deserialize</param>
        /// <returns>a configured <c>IEngine</c></returns>
        public IEngine Configure(XmlElement xmlRoot) => Configure(xmlRoot, "App.config");

        public IEngine Configure(XmlElement xmlRoot, string configName)
        {
            Engine engine = new Engine(configName);

            XmlElement o = xmlRoot;

            if (o == null)
                return engine;


            foreach (XmlNode settingsNode in o)
            {
                if (settingsNode.Name == "aspect")
                {
                    IGenericAspect aspect = Configure(settingsNode, useTypePlaceHolders);

                    engine.Configuration.Aspects.Add(aspect);
                }
            }


            return engine;
        }

        public IEngine Configure(XmlNode xmlRoot, string configName) => Configure(xmlRoot, configName, false);

        public IEngine Configure(XmlNode xmlRoot, string configName, bool useTypePlaceHolders)
        {
            Engine engine = new Engine(configName);

            if (xmlRoot == null)
                return engine;


            foreach (XmlNode settingsNode in xmlRoot.SelectNodes("aspect"))
            {
                IGenericAspect aspect = Configure(settingsNode, useTypePlaceHolders);

                engine.Configuration.Aspects.Add(aspect);
            }

            return engine;
        }

        private static IGenericAspect Configure(XmlNode settingsNode, bool useTypePlaceHolders)
        {
            IList pointcuts = new ArrayList();
            IList mixins = new ArrayList();
            IList targets = new ArrayList();

            string aspectName = settingsNode.Attributes["name"].Value;

            foreach (XmlNode aspectNode in settingsNode)
            {
                if (aspectNode.Name == "pointcut")
                {
                    string name = "Pointcut";
                    if (aspectNode.Attributes["name"] != null)
                        name = aspectNode.Attributes["name"].Value;

                    IList interceptors = new ArrayList();
                    IList pointcutTargets = new ArrayList();

                    foreach (XmlNode pointcutNode in aspectNode)
                    {
                        if (pointcutNode.Name == "interceptor")
                        {
                            string typeString = pointcutNode.Attributes["type"].Value;
                            Type interceptorType = Type.GetType(typeString);
                            if (interceptorType == null)
                            {
                                if (useTypePlaceHolders)
                                    interceptors.Add(typeString);
                                else
                                {
                                    throw new Exception(
                                        string.Format("Interceptor type '{0}' was not found!", typeString));
                                }
                            }
                            else
                            {
                                object interceptor = Activator.CreateInstance(interceptorType);
                                interceptors.Add(interceptor);
                            }
                        }

                        if (pointcutNode.Name == "target")
                        {
                            string signature = null;
                            if (pointcutNode.Attributes["signature"] != null)
                                signature = pointcutNode.Attributes["signature"].Value;

                            string targetTypeString = null;
                            if (pointcutNode.Attributes["type"] != null)
                                targetTypeString = pointcutNode.Attributes["type"].Value;

                            if (signature == null)
                                signature = "";

                            string excludeString = null;
                            if (pointcutNode.Attributes["exclude"] != null)
                                excludeString = pointcutNode.Attributes["exclude"].Value;
                            bool exclude = false;
                            if (excludeString != null)
                                exclude = FromBool(excludeString);

                            PointcutTargetType targetType = PointcutTargetType.Signature;
                            if (targetTypeString != null)
                            {
                                switch (targetTypeString.ToLower())
                                {
                                    case "signature":
                                        targetType = PointcutTargetType.Signature;
                                        break;
                                    case "fullsignature":
                                        targetType = PointcutTargetType.FullSignature;
                                        break;
                                    case "attribute":
                                        targetType = PointcutTargetType.Attribute;
                                        break;
                                    default:
                                        throw new Exception(String.Format("Unknown pointcut target type {0}", targetTypeString));
                                }
                            }

                            PointcutTarget target = null;
                            if (targetType == PointcutTargetType.Signature)
                            {
                                target = new PointcutTarget(signature, targetType, exclude);
                            }
                            else
                            {
                                Type signatureType = Type.GetType(signature);
                                if (signatureType == null)
                                {
                                    if (useTypePlaceHolders)
                                        target = new PointcutTarget(signature, targetType, exclude);
                                    else
                                    {
                                        throw new Exception(
                                            string.Format("Type '{0}' was not found!", signatureType));
                                    }
                                }
                                else
                                    target = new PointcutTarget(signatureType, targetType, exclude);
                            }

                            pointcutTargets.Add(target);
                        }
                    }

                    IPointcut pointcut = null;
                    if (aspectNode.Attributes["target-signature"] != null)
                    {
                        string targetMethodSignature = aspectNode.Attributes["target-signature"].Value;
                        pointcut = new Pointcut(interceptors);
                        pointcut.Targets.Add(new PointcutTarget(targetMethodSignature, PointcutTargetType.Signature));

                    }

                    if (aspectNode.Attributes["target-attribute"] != null)
                    {
                        string attributeTypeString = aspectNode.Attributes["target-attribute"].Value;
                        pointcut = new Pointcut(interceptors);

                        Type attributeType = Type.GetType(attributeTypeString);
                        if (attributeType == null)
                        {
                            if (useTypePlaceHolders)
                                pointcut.Targets.Add(new PointcutTarget(attributeTypeString, PointcutTargetType.Attribute));
                            else
                            {
                                throw new Exception(
                                    string.Format("Attribute type '{0}' was not found!", attributeTypeString));
                            }
                        }
                        else
                            pointcut.Targets.Add(new PointcutTarget(attributeType, PointcutTargetType.Attribute));
                    }

                    foreach (PointcutTarget target in pointcutTargets)
                        pointcut.Targets.Add(target);

                    pointcut.Name = name;

                    pointcuts.Add(pointcut);
                }

                if (aspectNode.Name == "mixin")
                {
                    string typeString = aspectNode.Attributes["type"].Value;
                    Type mixinType = Type.GetType(typeString);
                    if (mixinType == null)
                    {
                        if (useTypePlaceHolders)
                            mixins.Add(typeString);
                        else
                            throw new Exception(string.Format("Mixin type '{0}' was not found!", typeString));

                    }
                    else
                        mixins.Add(mixinType);
                }

                if (aspectNode.Name == "target")
                {
                    string signature = null;
                    if (aspectNode.Attributes["signature"] != null)
                        signature = aspectNode.Attributes["signature"].Value;

                    string targetTypeString = null;
                    if (aspectNode.Attributes["type"] != null)
                        targetTypeString = aspectNode.Attributes["type"].Value;

                    if (signature == null)
                        signature = "";

                    string excludeString = null;
                    if (aspectNode.Attributes["exclude"] != null)
                        excludeString = aspectNode.Attributes["exclude"].Value;
                    bool exclude = false;
                    if (excludeString != null)
                        exclude = FromBool(excludeString);

                    AspectTargetType targetType = AspectTargetType.Signature;
                    if (targetTypeString != null)
                    {
                        switch (targetTypeString.ToLower())
                        {
                            case "signature":
                                targetType = AspectTargetType.Signature;
                                break;
                            case "attribute":
                                targetType = AspectTargetType.Attribute;
                                break;
                            case "interface":
                                targetType = AspectTargetType.Interface;
                                break;
                            default:
                                throw new Exception(String.Format("Unknown aspect target type {0}", targetTypeString));
                        }
                    }
                    AspectTarget target = null;
                    if (targetType == AspectTargetType.Signature)
                    {
                        target = new AspectTarget(signature, targetType, exclude);
                    }
                    else
                    {
                        Type signatureType = Type.GetType(signature);
                        if (signatureType == null)
                        {
                            if (useTypePlaceHolders)
                                target = new AspectTarget(signature, targetType, exclude);
                            else
                            {
                                throw new Exception(
                                    string.Format("Type '{0}' was not found!", signatureType));
                            }
                        }
                        else
                            target = new AspectTarget(signatureType, targetType, exclude);
                    }

                    targets.Add(target);
                }

            }

            IGenericAspect aspect = null;

            if (settingsNode.Attributes["target-signature"] != null)
            {
                string targetTypeSignature = settingsNode.Attributes["target-signature"].Value;
                //aspect = new SignatureAspect(aspectName, targetTypeSignature, mixins, pointcuts);
                aspect = new GenericAspect(aspectName, mixins, pointcuts);
                aspect.Targets.Add(new AspectTarget(targetTypeSignature, AspectTargetType.Signature));
            }

            if (settingsNode.Attributes["target-attribute"] != null)
            {
                string attributeTypeString = settingsNode.Attributes["target-attribute"].Value;
                aspect = new GenericAspect(aspectName, mixins, pointcuts);

                Type attributeType = Type.GetType(attributeTypeString);
                if (attributeType == null)
                {
                    if (useTypePlaceHolders)
                        aspect.Targets.Add(new AspectTarget(attributeTypeString, AspectTargetType.Attribute));
                    else
                    {
                        throw new Exception(
                            string.Format("Attribute type '{0}' was not found!", attributeTypeString));

                    }
                }
                else
                    aspect.Targets.Add(new AspectTarget(attributeType, AspectTargetType.Attribute));
            }

            if (settingsNode.Attributes["target-interface"] != null)
            {
                string interfaceTypeString = settingsNode.Attributes["target-interface"].Value;
                aspect = new GenericAspect(aspectName, mixins, pointcuts);

                Type interfaceType = Type.GetType(interfaceTypeString);
                if (interfaceType == null)
                {
                    if (useTypePlaceHolders)
                        aspect.Targets.Add(new AspectTarget(interfaceTypeString, AspectTargetType.Interface));
                    else
                    {
                        throw new Exception(
                            string.Format("Type '{0}' was not found!", interfaceTypeString));

                    }
                }
                else
                    aspect.Targets.Add(new AspectTarget(interfaceType, AspectTargetType.Interface));
            }

            foreach (AspectTarget target in targets)
                aspect.Targets.Add(target);

            return aspect;
        }

        private static bool FromBool(string boolString)
        {
            boolString = boolString.ToLower();
            if (boolString == "true" || boolString == "yes" || boolString == "1")
                return true;
            return false;
        }
    }
}