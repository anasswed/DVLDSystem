using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsDrivers
    {
        private enum enMode { AddNewDriver,UpdateDriverInfo}

        private enMode _Mode;
        public int DriverID { set; get; }

        public int PersonID { set; get; }

        public clsPeople Person { set; get; }

        public int CreatedByUserID { set; get; }

        public clsUsers User { set; get; }

        public DateTime CreatedDate { set; get; }

        public clsDrivers()
        {
            DriverID = -1;
            PersonID = -1;
            CreatedByUserID = 1;
            CreatedDate = DateTime.Now;
            _Mode = enMode.AddNewDriver;
        }

        public clsDrivers(int DriverID,int PersonID,int CreatedByUserID,DateTime CreatedDate)
        {
            this.DriverID = DriverID;
            this.PersonID = PersonID;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedDate = CreatedDate;
            _Mode = enMode.UpdateDriverInfo;
        }
        public bool AddNewDriver()
        {
            int DriverID = clsDataAccessLayerForDrivers.AddNewDriver(PersonID, CreatedByUserID, CreatedDate);
            if(DriverID!=-1)
            {
                this.DriverID = DriverID;
                return true;
            }
            else
            {
                return false;
            }
        }

        public static clsDrivers FindDriverByPersonID(int PersonID)
        {
            int DriverID = -1;
            int CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.Now;
            if(clsDataAccessLayerForDrivers.FindDriverByPersonID(PersonID,ref DriverID,ref CreatedByUserID,ref CreatedDate))
            {
                return new clsDrivers(DriverID, PersonID, CreatedByUserID, CreatedDate);
            }
            else
            {
                return null;
            }
        }

      
        public static DataTable GetListAllDrivers()
        {
            return (clsDataAccessLayerForDrivers.GetListAllDrivers());
        }
        public static int GetPersonIDOfDriver(int DriverID)
        {
            return (clsDataAccessLayerForDrivers.GetPersonIDOfPerson(DriverID));
        }
    }
}
