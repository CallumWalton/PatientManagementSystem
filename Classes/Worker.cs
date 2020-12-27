using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PatientManagementSystem.Classes
{
    class Worker
    {
        /*
         * This class is designed to communicate and recieve information from the worker program
         * WorkerPMS.exe is a program designed to run single line queries and handle database communication 
         */
        /// <summary>
        /// Executes Query on the Worker Application in order to recieve information for multiple uses such as encryption/decryption/synchronization/database communication
        /// </summary>
        /// <param name="applicationReq">
        /// Please refeer to WorkerPMS code in regards to execution (e.g 0x0 string)
        /// </param>
        /// <returns>
        /// Returns single resulting string from request, e.g password hash
        /// </returns>
        public string ExecuteSingleResultQuery(string applicationReq)
        {
            /*
             * On Execution of this method this launches the program, the worker program writes bytes to a file that is then read and deleted.
             */
            ProcessStartInfo startInfo = new ProcessStartInfo(@"Worker\WorkerPMS.exe");
            startInfo.CreateNoWindow = true;
            startInfo.Arguments = $"{applicationReq}";
            startInfo.RedirectStandardOutput = true;
            startInfo.UseShellExecute = false;
            Process P = Process.Start(startInfo);
            StreamReader procRead = P.StandardOutput;
            string result = procRead.ReadLine();
            P.WaitForExit();
            System.Windows.MessageBox.Show(result);
            return result;
            
        }
        public bool PermissionCheck(string usrName, string permissionReq)
        {
            /*
             * This functions as intended but I would prefer to complete this differently but due to the potential scope of the project I have to step back from attempting to adjust this section of things
             * In simplistic terms, if a person uses a piece of software like cheat engine they are able to jump over this function and continue like normal (and the Worker Application would allow that)
             * I could have the Permissions locked to the WorkerPMS for each request but that requires a larger workflow for adding and removing permissions.
             * For now this is functioning and the security risk is small as each access screen is determined on login, if somebody is purposefully manipulating memory, anything I throw at it could be bypassed. 
             */
            ProcessStartInfo startInfo = new ProcessStartInfo(@"Worker\WorkerPMS.exe");
            startInfo.CreateNoWindow = true;
            startInfo.Arguments = $"0x2 {usrName} {permissionReq}";
            startInfo.RedirectStandardOutput = true;
            startInfo.UseShellExecute = false;
            Process P = Process.Start(startInfo);
            StreamReader procRead = P.StandardOutput;
            string result = procRead.ReadLine();
            P.WaitForExit();
            if(result == "FALSE")
            {
                return false;
            }
            else if(result == "TRUE")
            {
                return true;
            }
            return false;
        }
        public List<string> ExecuteMultiResultDatabaseQuery(string applicationReq)
        {
            /*
             * On Execution of this method this launches the program, the worker program writes bytes to a file that is then read and deleted.
             */
            List<string> result = new List<string>();
            ProcessStartInfo startInfo = new ProcessStartInfo(@"Worker\WorkerPMS.exe");
            startInfo.CreateNoWindow = true;
            startInfo.Arguments = $"{applicationReq}";
            startInfo.RedirectStandardOutput = true;
            startInfo.UseShellExecute = false;
            Process P = Process.Start(startInfo);
            StreamReader procRead = P.StandardOutput;
            while (!P.HasExited)
            {
                string currLine = procRead.ReadLine();
                if(currLine != null) { 
                    result.Add(currLine);
                }
            }
            
            return result;

        }
        public void ExecuteFunction(string applicationReq)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo(@"Worker\WorkerPMS.exe");
            startInfo.CreateNoWindow = true;
            startInfo.Arguments = $"{applicationReq}";
            startInfo.RedirectStandardOutput = true;
            startInfo.UseShellExecute = false;
            Process P = Process.Start(startInfo);
            StreamReader procRead = P.StandardOutput;
            string result = procRead.ReadToEnd();
            P.WaitForExit();
        }
        public void SyncTCPClient()
        {

        }
        public void InitalizeProcessOnNewThread()
        {

        }
    }
}
