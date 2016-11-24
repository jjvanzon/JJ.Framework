using System;
using System.Collections.Generic;
using System.Text;

namespace InMemFilter
{
    public class Address
    {
        #region Property StreetName 
        private string streetName;
        public string StreetName
        {
            get
            {
                return this.streetName;
            }
            set
            {
                this.streetName = value;
            }
        }                        
        #endregion

        #region Property City 
        private string city;
        public string City
        {
            get
            {
                return this.city;
            }
            set
            {
                this.city = value;
            }
        }                        
        #endregion

        #region Property ZipCode 
        private int zipCode;
        public int ZipCode
        {
            get
            {
                return this.zipCode;
            }
            set
            {
                this.zipCode = value;
            }
        }                        
        #endregion

        public string MyMethod()
        {
            return city.ToLower();
        }
    }
}
