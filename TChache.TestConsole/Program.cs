using System;
using System.Threading.Tasks;
using TCache.Communication;

namespace TChache.TestConsole
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string address = @"http://localhost:6234/";
            Write("Authenticating....");
            UserCommunication ucom = new UserCommunication("Default", "admin", "123qwe", address);


            var co = await ucom.GetUsersToTestCache(new TCache.Communication.Dtos.cm_GetUsersToTestCacheInput());

            Write("call 1: from " + (co.LoadedFromCache ? "cache" : "DB"));

            Write("slepping " + 50 + " second...");
            System.Threading.Thread.Sleep(50000);
            co = await ucom.GetUsersToTestCache(new TCache.Communication.Dtos.cm_GetUsersToTestCacheInput());
            Write("call 2: from " + (co.LoadedFromCache ? "cache" : "DB"));

            Write("slepping " + 10 + " second...");
            System.Threading.Thread.Sleep(10000);
            co = await ucom.GetUsersToTestCache(new TCache.Communication.Dtos.cm_GetUsersToTestCacheInput());
            Write("call 3: from " + (co.LoadedFromCache ? "cache" : "DB"));

            for (int i = 4; i <= 8; i++)
            {
                Write("slepping " + 5 + " second...");
                System.Threading.Thread.Sleep(5000);
                co = await ucom.GetUsersToTestCache(new TCache.Communication.Dtos.cm_GetUsersToTestCacheInput());
                Write("call " + i + ": from " + (co.LoadedFromCache ? "cache" : "DB"));
            }

            Console.WriteLine("Press any key to end....");

        }

        static void Write(string text)
        {
            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " | " + text);
        }
    }
}