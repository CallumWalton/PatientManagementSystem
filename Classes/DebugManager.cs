using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PatientManagementSystem.Classes
{
    class DebugManager
    {
        /*
         * This class maintains any errors or issues that arrise
         */
        public static void WriteLog(string toLog)
        {
            MessageBox.Show(DateTime.Now + " " + toLog);
        }
        public static void Error(string ErrorToShow)
        {

        }
    }
}
