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
using System.Reflection.Emit;
using Puzzle.NAspect.Framework.Tools;

namespace Puzzle.NAspect.Framework.Aop
{
	public class AspectTarget : IAspectTarget
	{
        public AspectTarget()
        {
        }

        public AspectTarget(string signature, AspectTargetType targetType)
        {
            this.signature = signature;
            this.targetType = targetType;
        }

        public AspectTarget(Type signatureType, AspectTargetType targetType)
        {
            this.signatureType = signatureType;
            this.targetType = targetType;
        }

        public AspectTarget(string signature, AspectTargetType targetType, bool exclude)
        {
            this.signature = signature;
            this.targetType = targetType;
            this.exclude = exclude;
        }

        public AspectTarget(Type signatureType, AspectTargetType targetType, bool exclude)
        {
            this.signatureType = signatureType;
            this.targetType = targetType;
            this.exclude = exclude;
        }

        private bool exclude;
        public virtual bool Exclude
        {
            get { return exclude; }
            set { exclude = value; }
        }
	

        private string signature;
        public virtual string Signature
        {
            get 
            {
                if (signature == "")
                    if (signatureType != null)
                        return signatureType.FullName;
                return signature;
            }
            set { signature = value; }
        }

        private AspectTargetType targetType = AspectTargetType.Signature;
        public virtual AspectTargetType TargetType
        {
            get { return targetType ; }
            set { targetType = value; }
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

        public bool IsMatch(Type type)
        {
            switch (this.targetType)
            {
                case AspectTargetType.Signature:
                    return IsSignatureMatch(type);
                case AspectTargetType.Attribute:
                    return IsAttributeMatch(type);
                case AspectTargetType.Interface:
                    return IsInterfaceMatch(type);
                default:
                    throw new Exception(String.Format("Unknown aspect target type {0}", targetType.ToString()));
            }
        }


        public bool IsSignatureMatch(Type type)
        {
            Type tmp = type;
            //traverse back in inheritance hierarchy to first non runtime emitted type 
            while (tmp.Assembly is AssemblyBuilder)
                tmp = tmp.BaseType;


            if (Text.IsMatch(tmp.FullName, signature))
                return true;
            else
                return false;
        }

        public bool IsAttributeMatch(Type type)
        {
            Type tmp = type;
            while (tmp.Assembly is AssemblyBuilder)
                tmp = tmp.BaseType;
            Type signatureType = GetSignatureType();
            if (signatureType == null)
                return false;

            if (tmp.GetCustomAttributes(signatureType, true).Length > 0)
                return true;
            else
                return false;
        }

        public bool IsInterfaceMatch(Type type)
        {
            Type tmp = type;
            while (tmp.Assembly is AssemblyBuilder)
                tmp = tmp.BaseType;
            Type signatureType = GetSignatureType();
            if (signatureType == null)
                return false;

            if (signatureType.IsAssignableFrom(tmp))
                return true;
            else
                return false;
        }

	}
}
