using System;
using System.Collections.Generic;
using System.Text;

namespace InMemFilter
{
    public class Person
    {
        #region Property FirstName 
        private string firstName;
        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                this.firstName = value;
            }
        }                        
        #endregion

        #region Property LastName 
        private string lastName;
        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                this.lastName = value;
            }
        }                        
        #endregion

        #region Property Age 
        private int age;
        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                this.age = value;
            }
        }                        
        #endregion

        #region Property Address 
        private Address address = new Address ();
        public Address Address
        {
            get
            {
                return this.address;
            }
            set
            {
                this.address = value;
            }
        }                        
        #endregion

        public int SomeMethod(int param)
        {
            return param * 2;
        }
    }
}
