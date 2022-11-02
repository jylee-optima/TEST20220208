using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {

            while(true)
            {
                break;
            }

            while(true)
            {
                try
                {
                    throw new TimeoutException();

                }
                catch (OperationCanceledException e)
                {
                    continue;
                }
                catch (Exception)
                {

                    continue;
                }

            }


            return;



            ClientEventPoolHandler();


            Console.ReadLine();

            return;


            Console.WriteLine(Thread.CurrentThread.ManagedThreadId.ToString());

            Task eventPoolTask = null;


            eventPoolTask = new Task(() =>
            {
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId.ToString());
            },TaskCreationOptions.LongRunning );


            eventPoolTask.Start();

            Console.ReadLine();






        }


        static async void ClientEventPoolHandler()
        {

            Task tt = Task.Run(() => 
            {
                Thread.Sleep(3000);
                Console.WriteLine("1End");
            });



            if (tt == await Task.WhenAny(tt, Task.Delay(100000)))
            {
                Console.WriteLine("true");
            }
            else
                Console.WriteLine("false");

        }
    }
}
