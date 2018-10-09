// *
// * Copyright (C) 2005 Mats Helander : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

using System;
using System.Text;
using System.Reflection;
using Puzzle.NAspect.Framework.Utils;
using Puzzle.NAspect.Framework.Tools;
using System.Reflection.Emit;

namespace Puzzle.NAspect.Framework.Aop
{
    /// <summary>
    /// The target description for a pointcut
    /// </summary>
	public class PointcutTarget : IPointcutTarget
	{
        public PointcutTarget()
        {
        }

        public PointcutTarget(string signature, PointcutTargetType targetType)
        {
            this.signature = signature;
            this.targetType = targetType;
        }

        public PointcutTarget(Type signatureType, PointcutTargetType targetType)
        {
            this.signatureType = signatureType;
            this.targetType = targetType;
        }

        public PointcutTarget(string signature, PointcutTargetType targetType, bool exclude)
        {
            this.signature = signature;
            this.targetType = targetType;
            this.exclude = exclude;
        }

        public PointcutTarget(Type signatureType, PointcutTargetType targetType, bool exclude)
        {
            this.signatureType = signatureType;
            this.targetType = targetType;
            this.exclude = exclude;
        }

        private bool exclude;
        public virtual bool Exclude
        {
            get => exclude;
            set => exclude = value;
        }

        private string signature = "";
        public virtual string Signature
        {
            get 
            {
                if (signature == "")
                    if (signatureType != null)
                        return signatureType.FullName;
                return signature;
            }
            set => signature = value;
        }

        private PointcutTargetType targetType = PointcutTargetType.Signature;
        public virtual PointcutTargetType TargetType
        {
            get => targetType;
            set => targetType = value;
        }

        private Type signatureType = null;
        private Type GetSignatureType()
        {
            if (signatureType == null)
            {
                if (signature != "")
                {
                    signatureType = Type.GetType(signature);
                    if (signatureType == null)
                        throw new Exception(
                            string.Format("Type '{0}' was not found!", signature));
                }
            }
            return signatureType;
        }


        public bool IsMatch(MethodBase method, Type type)
        {
            switch (this.targetType)
            {
                case PointcutTargetType.Signature:
                    return IsSignatureMatch(method, type);
                case PointcutTargetType.FullSignature:
                    return IsFullSignatureMatch(method, type);
                case PointcutTargetType.Attribute:
                    return IsAttributeMatch(method, type);
                default:
                    throw new Exception(String.Format("Unknown pointcut target type {0}", targetType.ToString()));
            }
        }

        /// <summary>
        /// Matches a method with the pointuct
        /// </summary>
        /// <param name="method">The method to match</param>
        /// <returns>True if the pointcut matched the method, otherwise false</returns>
        public bool IsSignatureMatch(MethodBase method, Type type)
        {
            string methodsignature = AopTools.GetMethodSignature(method);
            if (Text.IsMatch(methodsignature, signature))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Matches a type plus method with the pointuct
        /// </summary>
        /// <param name="method">The method to match</param>
        /// <returns>True if the pointcut matched the type plus method, otherwise false</returns>
        public bool IsFullSignatureMatch(MethodBase method, Type type)
        {
            if (type == null)
                return false;

            Type tmp = type;
            //traverse back in inheritance hierarchy to first non runtime emitted type 
            while (tmp.Assembly is AssemblyBuilder)
                tmp = tmp.BaseType;

            string typename = tmp.FullName;
            string methodsignature = AopTools.GetMethodSignature(method);
            string fullsignature = typename + "." + methodsignature;
            if (Text.IsMatch(fullsignature, signature))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Matches a method with the pointuct
        /// </summary>
        /// <param name="method">The method to match</param>
        /// <param name="type"></param>
        /// <returns>True if the pointcut matched the method, otherwise false</returns>
        public bool IsAttributeMatch(MethodBase method, Type type)
        {
            Type signatureType = GetSignatureType();
            if (signatureType == null)
                return false;

            if (method.GetCustomAttributes(signatureType, true).Length > 0)
                return true;
            else
                return false;
        }
	}
}
