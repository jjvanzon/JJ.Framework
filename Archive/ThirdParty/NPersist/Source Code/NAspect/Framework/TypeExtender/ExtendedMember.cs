using System;
using System.Text;
using System.Reflection.Emit;

namespace Puzzle.NAspect.Framework
{
	public abstract class ExtendedMember
    {
        #region Name
        private string name;
        /// <summary>
        /// Property Name (string)
        /// </summary>        
        public string Name
        {
            get => this.name;
            set => this.name = value;
        }
        #endregion

        public abstract void Extend(Type baseType, TypeBuilder typeBuilder);
        
    }
}
