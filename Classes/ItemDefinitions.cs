using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagementSystem.Classes
{
    class ItemDefinitions
    {
    }
    public class PatientListItems
    {
        public string id { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string dob { get; set; }
        public string house { get; set; }
        public string adr1 { get; set; }
        public string postcode { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
    }
    public class AppointmentDisplayID
    {
       // Each column assigns to each relevant column, they can be null but when null will be stored as "" since null is an object and "" is a string.
       public string Date { get; set; }
       public string Column_1 { get; set; }
       public string Column_2 { get; set; }
       public string Column_3 { get; set; }
       public string Column_4 { get; set; }
       public string Column_5 { get; set; }
       public string Column_6 { get; set; }
       public string Column_7 { get; set; }
       public string Column_8 { get; set; }
       public string Column_9 { get; set; }
       public string Column_10 { get; set; }
       public string Column_11 { get; set; }
       public string Column_12 { get; set; }
       public string Column_13 { get; set; }
       public string Column_14 { get; set; }
       public string Column_15 { get; set; }
       public string Column_16 { get; set; }
       public string Column_17 { get; set; }
       public string Column_18 { get; set; }
       public string Column_19 { get; set; }
       public string Column_20 { get; set; }
       public string Column_21 { get; set; }

    }
}
