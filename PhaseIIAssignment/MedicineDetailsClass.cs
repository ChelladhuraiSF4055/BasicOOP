using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhaseIIAssignment
{
    /// <summary>
    /// MedicineClass provides class for medicine objects
    /// </summary>
    public class MedicineDetailsClass
    {
        public static int s_medicineID =100;
        public string MedicineID { get; }
        public string MedicineName { get; set; }
        public int AvailableCount { get; set; }
        public int Price { get; set; }
        public DateTime DateOfExpiry { get; set; }
        
        public MedicineDetailsClass()
        {
            MedicineName="Enter medicine name";
        }
        //create instance of Medicine 
        public MedicineDetailsClass(string medicineID, string medicineName, int availableCount, int price, DateTime dateOfExpiry)
        {
            s_medicineID++;
            MedicineID=medicineID;
            MedicineName=medicineName;
            AvailableCount=availableCount;
            Price=price;
            DateOfExpiry=dateOfExpiry;
        }
        public void DeductCount(int count)
        {
            AvailableCount-=count;
        }

    }
}