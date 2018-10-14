namespace NCoreMain.Data
{
    public class SomeClass
    {
        #region Property Name

        private string name;

        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }

        #endregion

        #region Property Age

        private int age;

        public virtual int Age
        {
            get { return age; }
            set { age = value; }
        }

        #endregion

        #region Property Parent

        private SomeClass parent;

        public virtual SomeClass Parent
        {
            get { return parent; }
            set { parent = value; }
        }

        #endregion
    }
}