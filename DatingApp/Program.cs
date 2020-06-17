using System;
using System.Threading;
using System.Diagnostics;

namespace DatingApp
{
    class Program
    {
        public static int choice;
        static void Main(string[] args)
        {

            DB_Helper helperref = new DB_Helper();

            string tempuser;
            string temppass;

            bool isAlive = true;

            do
            {

                //******************************** -Første Menu- *************************************
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                Console.Clear();

                Tools.app_Banner();

                Console.WriteLine();
                Console.WriteLine("(1) Login");
                Console.WriteLine("(2) Register Account");
                Console.WriteLine("(3) Exit DatingApp");
                ConsoleKeyInfo UserInput = Console.ReadKey();

                choice = Tools.validatechoice(UserInput);

                switch (choice)
                {
                    case 1:

                        Console.Clear();

                        Tools.app_Banner();

                        Console.WriteLine("Please enter your Username");
                        tempuser = Console.ReadLine();
                        Console.WriteLine("Please Enter your Password");
                        temppass = Console.ReadLine();

                        UserModel userLogged = helperref.select_stuff(tempuser, temppass);


                        do
                        {

                            if (userLogged.loggedIn == true && userLogged.isAdmin == false)
                            {
                                //************************* -Logget ind som User- ****************************
                                Console.BackgroundColor = ConsoleColor.Magenta;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.Clear();

                                Tools.app_Banner(userLogged.Brugernavn);

                            }
                            else if (userLogged.loggedIn == true && userLogged.isAdmin == true)
                            {
                                //************************* -Logget ind some Admin- ****************************
                                Console.BackgroundColor = ConsoleColor.Magenta;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.Clear();

                                Tools.app_Banner(userLogged.Brugernavn, userLogged.isAdmin);

                            }
                            else
                            {
                                //************************ -Login Failed- ********************************
                                Console.Clear();

                                Console.WriteLine("False login Credentials. Program terminating.");
                                Console.ReadKey();
                            }

                            // ****************************** -Logget ind Menu- **********************

                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine("\n\n");
                            Console.WriteLine("What do you want to do?");
                            Console.WriteLine("(1) Edit User Profile");
                            Console.WriteLine("(2) Access and edit your Search Options");
                            Console.WriteLine("(3) Enter Matchmaking");
                            Console.WriteLine("(4) Access Current Matches");
                            Console.WriteLine("(5) Logout");
                            Console.WriteLine("(6) Logout and Exit");

                            Console.SetCursorPosition((Console.WindowWidth - 10) / 2, 6);
                            string profiletekst = helperref.select_stuff(userLogged.ID);
                            Console.WriteLine("Nuværende Profiltekst: " + profiletekst);
                            Console.WriteLine();

                            Console.SetCursorPosition(1, 15);

                            UserInput = Console.ReadKey();

                            choice = Tools.validatechoice(UserInput);

                            switch (choice)
                            {
                                case 1:
                                    Console.Clear();

                                    Console.WriteLine("Edit your Profile Text: ");

                                    profiletekst = Tools.ReadLine(profiletekst);

                                    Console.WriteLine("(1) Save");
                                    Console.WriteLine("(2) Cancel");

                                    UserInput = Console.ReadKey(true);

                                    choice = Tools.validatechoice(UserInput);

                                    switch (choice)
                                    {
                                        case 1:

                                            string updateanswer = helperref.Update_stuff(profiletekst, userLogged.ID);

                                            Console.WriteLine(updateanswer);
                                            Console.ReadKey();

                                            break;

                                        case 2:
                                            Console.WriteLine("Profiletext not updated. Press any key...");
                                            Console.ReadKey();
                                            break;

                                        default:
                                            Console.WriteLine("Hitting 1 or 2 is hard. Press any key...");
                                            break;
                                    }


                                    break;

                                case 2:
                                    Console.Clear();

                                    spModel userSearchOptions = helperref.select_SearchProfile(userLogged.ID);

                                    string[] searchParams = Tools.SearchParameters(userSearchOptions.Smoker.ToString(), userSearchOptions.Gender.ToString(), userSearchOptions.minBday.ToString(), userSearchOptions.maxBday.ToString());

                                    Console.WriteLine("Did this work lol?.........");
                                    Console.ReadKey();

                                    Console.WriteLine("Search Options");
                                    break;

                                case 3:
                                    Console.Clear();
                                    Console.WriteLine("Matchmaking");
                                    break;

                                case 4:
                                    Console.Clear();
                                    Console.WriteLine("Current Matches");
                                    break;

                                case 5:
                                    Console.Clear();
                                    Console.WriteLine("Logging out");
                                    Thread.Sleep(200);
                                    userLogged.loggedIn = false;
                                    break;

                                case 6:
                                    Console.Clear();
                                    Console.WriteLine("Program Terminating");
                                    isAlive = false;
                                    int countdown = 0;

                                    do
                                    {
                                        Console.WriteLine(".");
                                        Thread.Sleep(50);
                                        countdown += 1;

                                    } while (countdown < 10);

                                    Thread.Sleep(500);
                                    break;

                                default:
                                    Console.WriteLine("You failed to pick one of the predetermined responses. Try again.");
                                    break;
                            }

                        } while (userLogged.loggedIn == true && isAlive == true);//-<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                        //********************************* -Login menu- *****************************

                   

                        break;
                    case 2:

                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;

                        Console.Clear();

                        Console.SetCursorPosition((Console.WindowWidth - 86) / 2, Console.CursorTop);
                        Console.WriteLine("*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+**+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*");
                        Console.SetCursorPosition((Console.WindowWidth - 30) / 2, Console.CursorTop);
                        Console.WriteLine("Hello and welcome to DatingApp");
                        Console.SetCursorPosition((Console.WindowWidth - 86) / 2, Console.CursorTop);
                        Console.WriteLine("*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+**+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*");
                        Console.WriteLine();

                        Console.WriteLine("Indtast venligst de ønskede kontooplysninger");







                        break;

                    case 3:
                        Console.WriteLine("Something else entirely");
                        break;

                    default:
                        Console.WriteLine("You made an invalid choice. Exiting program.");
                        break;
                }

            } while (isAlive == true);


            Console.Clear();
            Console.WriteLine("Goodnight");
            Thread.Sleep(200);
            Environment.Exit(0);





        }
    }
}
