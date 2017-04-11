using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;


namespace ProcessManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** ProcessManipulator *****\n");
            ListAllRunningProcesses();
            Console.WriteLine("***** Enter PID to diagnose *****");
            Console.Write("PID: ");
            string pidstr = Console.ReadLine();
            int pid = int.Parse(pidstr);
            EnumThreadsForPid(pid);
            EnumModsForPid(pid);
            StartAndKillProcess();
            Console.ReadLine();
        }

        static void ListAllRunningProcesses()
        {
            // Get all the processes running on the local machine,
            // ordered by PID
            var runningProcs = from proc in Process.GetProcesses(".")
                               orderby proc.Id
                               select proc;
            foreach(var p in runningProcs)
            {
                string info = string.Format("-> PID: {0}\tName: {1}",
                    p.Id, p.ProcessName);
                Console.WriteLine(info);
            }
            Console.WriteLine("***************************************************\n");
        }

        static void EnumThreadsForPid(int pid)
        {
            Process proc = null;
            try
            {
                proc = Process.GetProcessById(pid);
            }catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            // List out stats for the process
            Console.WriteLine("Threads used by the {0} process:", proc.ProcessName);
            ProcessThreadCollection pthreads = proc.Threads;
            foreach (ProcessThread pt in pthreads) {
                string info =
                    string.Format("-> Thread ID: {0}\tStart Time: {1}\tPriority{2}",
                        pt.Id, pt.StartTime.ToShortTimeString(), pt.PriorityLevel);
                Console.WriteLine(info);
            }
            Console.WriteLine("****************************************************\n");
        }

        static void EnumModsForPid(int pid)
        {
            Process proc = null;
            try
            {
                proc = Process.GetProcessById(pid);
            }catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            Console.WriteLine("Modules loaded for process {0}", proc.ProcessName);
            ProcessModuleCollection mods = proc.Modules;
            foreach(ProcessModule pm in mods)
            {
                string info = string.Format("-> Mod Name: {0}", pm.ModuleName);
                Console.WriteLine(info);
            }
            Console.WriteLine("****************************************************\n");
        }

        static void StartAndKillProcess()
        {
            Process proc = null;
            try
            {
                ProcessStartInfo pstartinfo = new
                    ProcessStartInfo("IExplore.exe", "www.facebook.com");
                pstartinfo.WindowStyle = ProcessWindowStyle.Maximized;
                proc = Process.Start(pstartinfo);
            }catch(InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("--> Hit enter to kill {0}...", proc.ProcessName);

            Console.ReadLine();
            try
            {
                proc.Kill();
            }catch(InvalidCastException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
