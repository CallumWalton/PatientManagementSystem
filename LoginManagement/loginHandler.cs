using PatientManagementSystem.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PatientManagementSystem
{
    public class loginHandler
    {
        public string Login(string username, string password)
        {
            Worker worker = new Worker();
            worker.ExecuteFunction("1x2");
            string dbCheckChar = worker.ExecuteSingleResultQuery($"1x1 1 {username} {password}");
            if (dbCheckChar == "Admin"){
                
                return "Admin";
            }
            else if(dbCheckChar == "Staff")
            {
                return "Staff";
            }
            else if(dbCheckChar == "Patient")
            {
                return "Patient";
            }
            return null;
        }
    }
}
