using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsLicenseClass
    {
        public enum enLicenseClasses { SmallMotorcycle=1,HeavyMotorcycle=2,Ordiniry=3,Commerical=4,Agricultural=5,SmallAndMediumBus=6,TruckAndHeavyVehicle=7 }
        public int LicenceClassID { set; get; }

        public string ClassName { set; get; }

        public string ClassDescription { set; get; }

        public byte MinAge { set; get; }

        public byte DefaultVaildityLength { set; get; }

        public decimal ClassFess { set; get; }

        public static DataTable GetNameForAllLicenseClass()
        {
            return (clsDataAccessLayerForLicenseClass.GetNameForAllLicenseClasses());
        }
        public clsLicenseClass()
        {

        }

        private clsLicenseClass(int licenceClassID, string className, string classDescription, byte minAge, byte defaultVaildityLength, decimal classFess)
        {
            LicenceClassID = licenceClassID;
            ClassName = className;
            ClassDescription = classDescription;
            MinAge = minAge;
            DefaultVaildityLength = defaultVaildityLength;
            ClassFess = classFess;
        }
        public static clsLicenseClass FindLicenseClassByID(int LicenseClassID)
        {
            string ClassName = "", ClassDescription = "";
            byte DefaultVaildityLength = 0, MinAge = 0;
            decimal ClassFees = 0;
            if(clsDataAccessLayerForLicenseClass.FindLicenseClassByID(LicenseClassID,ref ClassDescription,ref ClassName,ref DefaultVaildityLength ,ref MinAge,ref ClassFees))
            {
                return new clsLicenseClass(LicenseClassID, ClassName, ClassDescription, MinAge, DefaultVaildityLength, ClassFees);
            }
            else
            {
                return null;
            }
        }

    }
}
