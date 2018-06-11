using JetBrains.Annotations;
// ReSharper disable ClassWithVirtualMembersNeverInherited.Global
// ReSharper disable ConvertToAutoProperty

namespace JJ.Framework.Data.Tests.Model
{
    [UsedImplicitly]
    public class Thing
    {
        private int _iD;
        public virtual int ID
        {
            get => _iD;
            set => _iD = value;
        }
        private string _name;
        public virtual string Name
        {
            get => _name;
            set => _name = value;
        }
    }
}