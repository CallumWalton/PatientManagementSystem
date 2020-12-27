using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace PatientManagementSystem.Classes
{
    class ThreadManager
    {
        public void NewWorkerThread(string executionString)
        {
            Worker worker = new Worker();
            Thread thread = new Thread(new ThreadStart(worker.SyncTCPClient));
            thread.Start();
        }
    }
}
