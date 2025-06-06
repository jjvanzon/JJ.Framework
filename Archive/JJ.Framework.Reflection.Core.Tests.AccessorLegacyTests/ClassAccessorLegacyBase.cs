﻿using System;

namespace JJ.Framework.Reflection.Core.Tests.AccessorLegacyTests
{
    internal abstract class ClassAccessorLegacyBase : IClassAccessorLegacy
    {
        protected readonly AccessorLegacy _accessor;

        public ClassAccessorLegacyBase(ClassLegacy obj) => _accessor = new AccessorLegacy(obj);

        public ClassAccessorLegacyBase(ClassLegacy obj, Type type) => _accessor = new AccessorLegacy(obj, type);

        public int this[int index]
        {
            get => (int)_accessor.GetIndexerValue(index);
            set => _accessor.SetIndexerValue(index, value);
        }

        public string this[string key]
        {
            get => (string)_accessor.GetIndexerValue(key);
            set => _accessor.SetIndexerValue(key, value);
        }

        public abstract int _field { get; set; }
        public abstract int Property { get; set; }
        public abstract void VoidMethod();
        public abstract void VoidMethodInt(int parameter);
        public abstract void VoidMethodIntInt(int parameter1, int parameter2);
        public abstract int IntMethod();
        public abstract int IntMethodInt(int parameter);
        public abstract int IntMethodIntInt(int parameter1, int parameter2);
    }
}