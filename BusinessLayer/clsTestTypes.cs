using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsTestTypes
    {
        public int TestTypeID { get; set; }

        public string Title { get; set; }

        public string Description { set; get; }

        public decimal Fees { set; get; }

        public clsTestTypes(int TestTypeID,string Title,string Description,decimal Fees)
        {
            this.TestTypeID = TestTypeID;
            this.Title = Title;
            this.Description = Description;
            this.Fees = Fees;
        }

        public static clsTestTypes FindTestTypeByID(int TestTypeID)
        {
            string Title = "", Description = "";
            decimal Fees = 0;

            if(clsDataAccessLayerForTestTypes.FindTestTypeByID(TestTypeID,ref Title,ref Description,ref Fees))
            {
                return new clsTestTypes(TestTypeID, Title, Description, Fees);
            }
            else
            {
                return null;
            }

        }

        public static DataTable GetAllTestTypes()
        {
            return (clsDataAccessLayerForTestTypes.GetAllTestTypes());
        }

        public static int GetNumberOfTestType()
        {
            return (clsDataAccessLayerForTestTypes.GetNumberOfTestType());
        }
        private bool _UpdateTestTypeInfo()
        {
            return (clsDataAccessLayerForTestTypes.UpdateTestTypeInfo(TestTypeID, Title, Description, Fees));
        }
        public bool Save()
        {
            if(_UpdateTestTypeInfo())
            {
                return true;

            }
            return false;
        }
    }
}
