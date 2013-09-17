using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Persistence.Tests.Model
{
    public class Thing
    {
        private int _iD;
        private string _name;

        public virtual int ID 
        {
            get { return _iD; }
            set { _iD = value; }
        }

        public virtual string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}
