using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// record the sounds "start!", "go go go!!" etc like from the goforce; use it randomly - sometimes during the exercises - "Go on, you can do it!"
/// </summary>

namespace JuliettApp
{
 
    class Contact
    {
        public void Welcome()
        {
            //string quotes = "Hello, Juliette!  Hi there!  It NEVER gets easier. You just get STRONG!  Sweat. Smile. Repeat!  Just Do It!  Sore Today, Strong Tomorrow!  No Pain. No Gain.  Push Yourself!";
            //string[] stringSeparators = new string[] { "  " };
            //string[] result;


            Random numberGenerator = new Random();
            int randomCaseNumber = numberGenerator.Next(1, 4);

            switch (randomCaseNumber)
            {
                case 1: Console.Write(" Sweat. Smile. Repeat!"); break;
                case 2: Console.Write(" Hi there!"); break;
                case 3: Console.Write(" It NEVER gets easier. You just get STRONG!"); break;
                default:    Console.Write(" Hello, Juliette!!"); break;
            }

            DateTime curTime = DateTime.Now;
            Console.WriteLine();
            Console.WriteLine(" It is: " + curTime);
            
        }
    }


    class Exercises
    {
        public void GetReady()
        {
            Console.WriteLine();
            Console.Write(" Get ready in: three"); Console.Beep();
            System.Threading.Thread.Sleep(1000);
            Console.Write(", two"); Console.Beep();
            System.Threading.Thread.Sleep(1000);
            Console.Write(", one"); Console.Beep();
            System.Threading.Thread.Sleep(1000);
            Console.Write(", Start!"); Console.Beep(1000, 750);
            
        }



        public void Intervals(int x)
        {
            for(int i=1; i <= x; i++)
            {
                Console.WriteLine();
                Console.WriteLine( " " + i + " interval of the 30 second cycle" );
                Console.WriteLine();

                Console.WriteLine("............................................................");
                for(int j=0; j < 30; j++)
                {
                    if (j >= 27)
                    {
                        Console.Write("|"); Console.Beep();
                        System.Threading.Thread.Sleep(300);
                        Console.Write("|");
                        System.Threading.Thread.Sleep(500);
                    }
                    else
                    { 
                        Console.Write("|");
                        System.Threading.Thread.Sleep(500);
                        Console.Write("|");
                        System.Threading.Thread.Sleep(500);
                    }
                }
                Console.WriteLine();

                Console.WriteLine();
                Console.WriteLine(" " + i + " interval of the 10 second cycle");
                Console.WriteLine();

                Console.WriteLine("....................");
                for (int j = 0; j < 10; j++)
                {
                    if(j>=7)
                    {
                        Console.Write("|"); Console.Beep();
                        System.Threading.Thread.Sleep(300);
                        Console.Write("|");
                        System.Threading.Thread.Sleep(500);
                    }
                    else
                    {
                        Console.Write("|");
                        System.Threading.Thread.Sleep(500);
                        Console.Write("|");
                        System.Threading.Thread.Sleep(500);
                    }
                    
                }
                Console.WriteLine();
                Console.WriteLine();
            }                        
        }
    }


    class Program
    {
         

        static void Main(string[] args)
        {
            int numberOfCycles;
            int switchNumber;

            Console.WriteLine();
            Contact hello = new Contact();
            hello.Welcome(); Console.WriteLine();

            

            MainMenu:
            Console.WriteLine("  -------------------------------------- ");
            Console.WriteLine(" |  MAIN MENU                           |");
            Console.WriteLine(" | ------------------------------------ |");
            Console.WriteLine(" | 1. One interval 30-10s               |");
            Console.WriteLine(" | 2. Five intervals 30-10s             |");
            Console.WriteLine(" | 3. Ten intervals 30-10s              |");
            Console.WriteLine(" | 4. Choose number of intervals 30-10s |");
            Console.WriteLine(" | ------------------------------------ |");
            Console.WriteLine(" | 5. Credits                           |");
            Console.WriteLine(" | 6. Exit program                      |");
            Console.WriteLine("  -------------------------------------- ");

            switchNumber = Convert.ToInt32(Console.ReadLine());

            Exercises basicIntervals = new Exercises();


            switch (switchNumber)
            {
                case 1:
                    Console.Clear();
                    basicIntervals.GetReady();
                    Console.Clear();
                    basicIntervals.Intervals(1);
                    Console.Clear();
                    goto MainMenu;
                case 2:
                    Console.Clear();
                    basicIntervals.GetReady();
                    Console.Clear();
                    basicIntervals.Intervals(5);
                    Console.Clear();
                    goto MainMenu;
                case 3:
                    Console.Clear();
                    basicIntervals.GetReady();
                    Console.Clear();
                    basicIntervals.Intervals(10);
                    Console.Clear();
                    goto MainMenu;
                case 4:
                    Console.Clear();
                    Console.WriteLine("How much intervals do you whant to deal with? Tap a number and press ENTER key.");
                    numberOfCycles = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    basicIntervals.GetReady();
                    Console.Clear();
                    basicIntervals.Intervals(numberOfCycles);
                    Console.Clear();
                    goto MainMenu;
                case 5:
                    Console.WriteLine();
                    Console.WriteLine("CREDITS");
                    Console.WriteLine();
                    Console.WriteLine("Julietta Mąderek - concept & ideaa");
                    Console.WriteLine("Jakub Puszynski - programing");
                    Console.WriteLine();
                    Console.WriteLine("Born from love & lack of coding");
                    Console.WriteLine("version alfa 1.0");
                    Console.ReadKey();
                    Console.Clear();
                    goto MainMenu;
                case 6:
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("  UNREACHABLE COMMAND(!). Please use 1, 2, 3, 4, 5 or 6 and press ENTER.");
                    Console.WriteLine(); Console.WriteLine();
                    goto MainMenu;
            }
               
        }
    }
}
