using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;



namespace JuliettApp
{

    

    class Program
    {
        
        
        
        static void Main(string[] args)
        {
            Console.WriteLine();

            //welcome message
            Contact hello = new Contact();
            hello.Welcome(); Console.WriteLine();

            Menu();            
        }



        


        //displaying a menu and its funcionality
        public static void Menu()
        {
            MainMenu:
            Console.WriteLine("  ------------------------------------------ ");
            Console.WriteLine(" |  MAIN MENU                               |");
            Console.WriteLine(" | ------------------------------------     |");
            Console.WriteLine(" | 1. Open websites (exercises + music)     |");
            Console.WriteLine(" | 2. Nine intervals 30-10s                 |");
            Console.WriteLine(" | 3. 45 intervals 30-10s                   |");
            Console.WriteLine(" | 4. Choose own number of intervals 30-10s |");
            Console.WriteLine(" | ------------------------------------     |");
            Console.WriteLine(" | 5. Credits                               |");
            Console.WriteLine(" | 6. Exit program                          |");
            Console.WriteLine("  ------------------------------------------ ");

            int numberOfCycles;
            char switchNumber;
            //No enter needed
            switchNumber = Console.ReadKey().KeyChar; 

            //creating new object
            Exercises basicIntervals = new Exercises();

            //switch menu
            switch (switchNumber)
            {
                case '1':
                    OpenWebsite("https://www.youtube.com/watch?v=3inY0h526cI&t=2s");
                    //creating new object to use method from Contact class - sending random yt link from lists
                        //Contact link = new Contact();                   
                        //OpenWebsite(link.MusicLinks());
                    Console.Clear();
                    goto MainMenu;
                case '2':
                    //Console.Clear();
                    //basicIntervals.GetReady();
                    Console.Clear();
                    //y can use parallelThreads
                    basicIntervals.ParallelThreads(9);
                        //basicIntervals.Intervals(9);
                    Console.Clear();
                    goto MainMenu;
                case '3':
                    //Console.Clear();
                    //basicIntervals.GetReady();
                    Console.Clear();
                    basicIntervals.Intervals(45);
                    Console.Clear();
                    goto MainMenu;
                case '4':
                    Console.Clear();
                    Console.WriteLine("How much intervals do you whant to deal with? Tap a number and press ENTER key.");
                    numberOfCycles = Convert.ToInt32(Console.ReadLine());
                    //Console.Clear();
                    //basicIntervals.GetReady();
                    Console.Clear();
                    basicIntervals.Intervals(numberOfCycles);
                    Console.Clear();
                    goto MainMenu;
                case '5':
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
                case '6':
                case '7':
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("  UNREACHABLE COMMAND(!). Please use numbers from keyboard: 1, 2, 3, 4, 5 or 6");
                    Console.WriteLine(); Console.WriteLine();
                    goto MainMenu;
            }
        }


        


        public static void OpenWebsite(string URL)
        {
            //creating process 
            Process p1 = new Process();
            p1.StartInfo.FileName = "chrome.exe";
            p1.StartInfo.Arguments = URL;
            p1.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            p1.Start();
        }
    }





    //welcome + date info
    class Contact
    {
        public Random _rand = new Random();

        public void Welcome()
        {
            //list<> of messages that will be display randomly during the start
            List<string> welcomeMassages = new List<string>();
            welcomeMassages.Add(" Sweat. Smile. Repeat!");
            welcomeMassages.Add(" Hi there!");
            welcomeMassages.Add(" It NEVER gets easier. You just get STRONG!");
            welcomeMassages.Add(" Hello, Juliette!");
            welcomeMassages.Add(" Welcome back!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(welcomeMassages[_rand.Next(welcomeMassages.Count())]);

                //displaying time
                DateTime curTime = DateTime.Now;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(" Date: " + curTime);
                Console.ForegroundColor = ConsoleColor.White;

        }


        public string MusicLinks()
        {
            List<string> randomLinks = new List<string>();
            randomLinks.Add("http://youtube.com/1");
            randomLinks.Add("http://youtube.com/2");
            randomLinks.Add("http://youtube.com/3");
            randomLinks.Add("http://youtube.com/4");
            randomLinks.Add("http://youtube.com/5");
            randomLinks.Add("http://youtube.com/6");
            randomLinks.Add("http://youtube.com/7");

            return randomLinks[_rand.Next(randomLinks.Count())];
        }

    }

    //excercises methods
    class Exercises
    {
        public void GetReady()
        {
            //counting down before cycles
            Console.WriteLine();
            Console.Write(" Get ready in: three"); Console.Beep();
            System.Threading.Thread.Sleep(1000);
            Console.Write(", two"); Console.Beep();
            System.Threading.Thread.Sleep(1000);
            Console.Write(", one"); Console.Beep();
            System.Threading.Thread.Sleep(1000);
            Console.Write(", Start!"); Console.Beep(1000, 750);

        }
        
        public void ParallelThreads(int x)
        {
            Thread exercisesThread = new Thread( () =>  Intervals(x) ); //can be used with method containg multiple properies 
            //more threads can be used
            //Thread pauseThread = new Thread( new ThreadStart(Pause) );

            exercisesThread.Start();
            Console.ReadKey();    
            exercisesThread.Abort();
        }


        
        //intervals cycles
        public void Intervals(int x)
        {


            for (int i = 1; i <= x; i++)
            {

                Console.WriteLine();
                Console.WriteLine(" " + i + " interval of the 30 second cycle");
                Console.WriteLine();

                Console.WriteLine("............................................................");
                for (int j = 0; j < 30; j++)
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
                    if (j >= 7)
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
}
