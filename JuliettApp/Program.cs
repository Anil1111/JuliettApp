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

            //displaying menu
            Menu();            
        }


        static int _numberOfCycles;
        static char _switchNumber;

        //displaying a menu + its funcionality
        public static void Menu()
        {
            MainMenu:
            Console.WriteLine("  ------------------------------------------ ");
            Console.WriteLine(" |  MAIN MENU                               |");
            Console.WriteLine(" | ------------------------------------     |");
            Console.WriteLine(" | 1. Open exercises website                |");
            Console.WriteLine(" | 2. Open random music website             |");
            Console.WriteLine(" | 3. Nine intervals 30-10s                 |");
            Console.WriteLine(" | 4. 45 intervals 30-10s                   |");
            Console.WriteLine(" | 5. Choose own number of intervals 30-10s |");
            Console.WriteLine(" | ------------------------------------     |");
            Console.WriteLine(" | 6. Credits                               |");
            Console.WriteLine(" | 7. Exit program                          |");
            Console.WriteLine("  ------------------------------------------ ");

            
            //Read Char for no enter switch menu
            _switchNumber = Console.ReadKey().KeyChar; 

            //creating new object to use class methods
            Exercises basicIntervals = new Exercises();

            //switch menu
            switch (_switchNumber)
            {
                case '1':
                    OpenWebSite("https://www.youtube.com/watch?v=3inY0h526cI&t=2s");                    
                    Console.Clear();
                    goto MainMenu;
                case '2':
                    //creating new object to use method from Contact class - sending random yt link from lists
                    Contact link = new Contact();
                    OpenWebSite(link.MusicLinks());

                    Console.Clear();
                    goto MainMenu;

                case '3': 
                    //y can use parallelThreads
                    basicIntervals.ParallelThreads(9);
                        //basicIntervals.Intervals(9);
                    
                    goto MainMenu;
                case '4':                    
                    //Console.Clear();
                    basicIntervals.Intervals(45);
                    //Console.Clear();
                    goto MainMenu;
                case '5':
                    Console.Clear();
                    Console.WriteLine("How much intervals do you whant to deal with? Tap a number and press ENTER key.");
                    _numberOfCycles = Convert.ToInt32(Console.ReadLine());                    
                    Console.Clear();
                    basicIntervals.Intervals(_numberOfCycles);
                    Console.Clear();
                    goto MainMenu;
                case '6':
                    Credits();
                    goto MainMenu;
                case '7':
                case '8':
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("  UNREACHABLE COMMAND(!). Please use numbers from keyboard: 1, 2, 3, 4, 5 or 6");
                    Console.WriteLine(); Console.WriteLine();
                    goto MainMenu;
            }
        }



        public static void Credits()
        {
            Console.WriteLine();
            Console.WriteLine("CREDITS");
            Console.WriteLine();
            Console.WriteLine("Julietta Mąderek - concept & ideaa");
            Console.WriteLine("Jakub Puszynski - programing");
            Console.WriteLine();
            Console.WriteLine("Born from love & lack of coding");
            Console.WriteLine("version alfa 1.2");
            Console.ReadKey();
            Console.Clear();
        }


        public static void OpenWebSite(string URL)
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
            randomLinks.Add("https://www.youtube.com/watch?v=yGiWGoIV-0Q&list=RDyGiWGoIV-0Q");
            randomLinks.Add("https://www.youtube.com/watch?v=lt-udg9zQSE&list=RDGMEMJQXQAmqrnmK1SEjY_rKBGAVMlt-udg9zQSE");
            randomLinks.Add("https://www.youtube.com/watch?v=BZt7PPjpKuA");
            randomLinks.Add("https://www.youtube.com/watch?v=2s3iGpDqQpQ");
            randomLinks.Add("https://www.youtube.com/watch?v=JCDjP4JnpGU");
            randomLinks.Add("https://www.youtube.com/watch?v=F8laMm-YyLY");
            randomLinks.Add("https://www.youtube.com/results?search_query=ramstein");

            return randomLinks[_rand.Next(randomLinks.Count())];
        }

    }

    //excercises methods
    class Exercises
    {
        //method to count to three before intervals
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
                Console.Clear();
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
                Console.Clear();
            }
        }
    }
}
