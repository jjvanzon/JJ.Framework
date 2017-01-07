namespace JJ.Framework.Data.Tests.Model
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
