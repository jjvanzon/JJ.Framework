using System;
using Puzzle.NPersist.Framework.Attributes;
using Puzzle.NPersist.Framework.Enumerations;

namespace Puzzle.NPersist.Samples.Northwind.Domain
{

	[ClassMap(Table="Employees")]
    public class Employee
    {
        private System.Int32 m_Id;
        private System.String m_Address;
        private System.DateTime m_BirthDate;
        private System.String m_City;
        private System.String m_Country;
        private System.Collections.IList m_Employees;
        private System.String m_Extension;
        private System.String m_FirstName;
        private System.DateTime m_HireDate;
        private System.String m_HomePhone;
        private System.String m_LastName;
        private System.String m_Notes;
        private System.Collections.IList m_Orders;
        private System.Byte[] m_Photo;
        private System.String m_PhotoPath;
        private System.String m_PostalCode;
        private System.String m_Region;
        private Employee m_ReportsTo;
        private System.Collections.IList m_Territories;
        private System.String m_Title;
        private System.String m_TitleOfCourtesy;

		public override string ToString()
		{
			return this.FirstName + " " + this.LastName;
		}

		[PropertyMap(IsIdentity=true, Columns="EmployeeID", IsAssignedBySource=true)]
        public virtual System.Int32 Id
        {
            get
            {
                return m_Id;
            }
        }

		[PropertyMap(IsNullable=true)]
        public virtual System.String Address
        {
            get
            {
                return m_Address;
            }
            set
            {
                m_Address = value;
            }
        }

		[PropertyMap(Columns="BirthDate", IsNullable=true)]
		public virtual System.DateTime BirthDate
        {
            get
            {
                return m_BirthDate;
            }
            set
            {
                m_BirthDate = value;
            }
        }

		[PropertyMap(Columns="City", IsNullable=true)]
		public virtual System.String City
        {
            get
            {
                return m_City;
            }
            set
            {
                m_City = value;
            }
        }

		[PropertyMap(Columns="Country", IsNullable=true)]
		public virtual System.String Country
        {
            get
            {
                return m_Country;
            }
            set
            {
                m_Country = value;
            }
        }

//		[PropertyMap(Table="Employees", IdColumns="ReportsTo", IsCollection=true, ItemType="Employee", 
//			 IsSlave=true, ReferenceType=ReferenceType.ManyToOne, Inverse="ReportsTo", InheritInverseMappings=true)]
		[PropertyMap(IsCollection=true, ReferenceType=ReferenceType.ManyToOne, ItemType="Employee", Inverse="ReportsTo", InheritInverseMappings=true)]
		public virtual System.Collections.IList Employees
        {
            get
            {
                return m_Employees;
            }
            set
            {
                m_Employees = value;
            }
        }

		[PropertyMap(Columns="Extension", IsNullable=true)]
		public virtual System.String Extension
        {
            get
            {
                return m_Extension;
            }
            set
            {
                m_Extension = value;
            }
        }

		[PropertyMap(Columns="FirstName")]
		public virtual System.String FirstName
        {
            get
            {
                return m_FirstName;
            }
            set
            {
                m_FirstName = value;
            }
        }

		[PropertyMap(Columns="HireDate", IsNullable=true)]
		public virtual System.DateTime HireDate
        {
            get
            {
                return m_HireDate;
            }
            set
            {
                m_HireDate = value;
            }
        }

		[PropertyMap(Columns="HomePhone", IsNullable=true)]
		public virtual System.String HomePhone
        {
            get
            {
                return m_HomePhone;
            }
            set
            {
                m_HomePhone = value;
            }
        }

		[PropertyMap(Columns="LastName")]
		public virtual System.String LastName
        {
            get
            {
                return m_LastName;
            }
            set
            {
                m_LastName = value;
            }
        }

		[PropertyMap(Columns="Notes", IsNullable=true)]
		public virtual System.String Notes
        {
            get
            {
                return m_Notes;
            }
            set
            {
                m_Notes = value;
            }
        }

		public virtual System.Collections.IList Orders
        {
            get
            {
                return m_Orders;
            }
            set
            {
                m_Orders = value;
            }
        }

        public virtual System.Byte[] Photo
        {
            get
            {
                return m_Photo;
            }
            set
            {
                m_Photo = value;
            }
        }

		[PropertyMap(Columns="PhotoPath", IsNullable=true)]
		public virtual System.String PhotoPath
        {
            get
            {
                return m_PhotoPath;
            }
            set
            {
                m_PhotoPath = value;
            }
        }

		[PropertyMap(Columns="PostalCode", IsNullable=true)]
		public virtual System.String PostalCode
        {
            get
            {
                return m_PostalCode;
            }
            set
            {
                m_PostalCode = value;
            }
        }

		[PropertyMap(Columns="Region", IsNullable=true)]
		public virtual System.String Region
        {
            get
            {
                return m_Region;
            }
            set
            {
                m_Region = value;
            }
        }

		[PropertyMap(Columns="ReportsTo", IsNullable=true, ReferenceType=ReferenceType.OneToMany, Inverse="Employees")]
		public virtual Employee ReportsTo
        {
            get
            {
                return m_ReportsTo;
            }
            set
            {
                m_ReportsTo = value;
            }
        }

		public virtual System.Collections.IList Territories
        {
            get
            {
                return m_Territories;
            }
            set
            {
                m_Territories = value;
            }
        }

		[PropertyMap(Columns="Title", IsNullable=true)]
		public virtual System.String Title
        {
            get
            {
                return m_Title;
            }
            set
            {
                m_Title = value;
            }
        }

		[PropertyMap(Columns="TitleOfCourtesy", IsNullable=true)]
		public virtual System.String TitleOfCourtesy
        {
            get
            {
                return m_TitleOfCourtesy;
            }
            set
            {
                m_TitleOfCourtesy = value;
            }
        }






    }
}
