using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
   public class clsApplicationType
    {
        public enum enApplicationType { NewLocalDrivingLicense=1,RenewDrivingLicense=2,ReplacmentForLost=3,
                ReplacmentForDamaged=4,ReleaseDetainedLicense=5,NewInternationalLicense=6,RetakeTest=7};
        public int ApplicationTypeID { get; set; }
        public string Title { get; set; }
        public decimal Fees { get; set; }

        public static DataTable GetAllApplicationTypes()
        {
            return (clsDataAccessLayerForApplicationTypes.GetAllApplicationTypes());
        }

       
       private clsApplicationType(int ApplicationTypeID,string Title,decimal Fees)
        {
            this.ApplicationTypeID = ApplicationTypeID;
            this.Title = Title;
            this.Fees = Fees;

        }

        public clsApplicationType()
        {
            this. ApplicationTypeID = -1;
            this. Title = "";
            this. Fees = 0;

        }

        public static clsApplicationType FindApplicationTypeByID(int ApplicationTypeID)
        {
            string Title = "";
            decimal Fees = 0;

            if(clsDataAccessLayerForApplicationTypes.FindApplicationTypeByID(ApplicationTypeID,ref Title,ref Fees))
            {
                return new clsApplicationType(ApplicationTypeID, Title, Fees); 
            }
            else
            {
                return null;
            }
           
        }

        private bool _UpdateApplicationTypeInfo()
        {
            return (clsDataAccessLayerForApplicationTypes.UpdateApplicationTypeInfo(ApplicationTypeID, Title, Fees)); 
        }
        public bool Save()
        {
            if(_UpdateApplicationTypeInfo())
            {
                return true;
            }
            return false;
        }

    }
}
