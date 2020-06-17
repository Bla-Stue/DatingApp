using System;
using System.Collections.Generic;
using System.Text;

namespace DatingApp
{
    public static class Tools
    {


        // --------------------------------- DatingApp Bannere med Overload----------------------------
        public static void app_Banner()
        {
            Console.SetCursorPosition((Console.WindowWidth - 86) / 2, Console.CursorTop);
            Console.WriteLine("*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+**+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*");
            Console.SetCursorPosition((Console.WindowWidth - 30) / 2, Console.CursorTop);
            Console.WriteLine("Hello and welcome to DatingApp");
            Console.SetCursorPosition((Console.WindowWidth - 86) / 2, Console.CursorTop);
            Console.WriteLine("*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+**+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*");
            Console.WriteLine();
        }

        public static void app_Banner(string logged)
        {
            Console.SetCursorPosition((Console.WindowWidth - 86) / 2, Console.CursorTop);
            Console.WriteLine("*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+**+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*");
            Console.SetCursorPosition((Console.WindowWidth - (67 + logged.Length)) / 2, Console.CursorTop);
            Console.WriteLine("Welcome to the super awesome DatingApp. You are logged in as User: {0}", logged);
            Console.SetCursorPosition((Console.WindowWidth - 86) / 2, Console.CursorTop);
            Console.WriteLine("*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+**+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*");

        }

        public static void app_Banner(string logged, bool admin)
        {
            Console.SetCursorPosition((Console.WindowWidth - 86) / 2, Console.CursorTop);
            Console.WriteLine("*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+**+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*");
            Console.SetCursorPosition((Console.WindowWidth - (68 + logged.Length)) / 2, Console.CursorTop);
            Console.WriteLine("Welcome to the super awesome DatingApp. You are logged in as Admin: {0}", logged);
            Console.WriteLine("*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+**+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*+*");

        }


        //validering på choice variablen. Ser efter om UserInput er et tal. Hvis ja, returnerer den tallet. Hvis nej returnerer den -1.
        public static int validatechoice(ConsoleKeyInfo UserInput)
        {
            int chkchoice;

            if (char.IsDigit(UserInput.KeyChar))
            {
                chkchoice = int.Parse(UserInput.KeyChar.ToString());
            }
            else
            {
                chkchoice = -1;
            }
            return chkchoice;

        }

        //Min version af ReadLine. Man kan bruge tal, bogstaver, symboler og mellemrum. Man kan navigere med piltasterne.
        public static string ReadLine(string Default)
        {
            int pos = Console.CursorLeft;
            Console.Write(Default);
            ConsoleKeyInfo info;
            List<char> chars = new List<char>();
            if (string.IsNullOrEmpty(Default) == false)
            {
                chars.AddRange(Default.ToCharArray());
            }

            while (true)
            {
                info = Console.ReadKey(true);
                if (info.Key == ConsoleKey.Backspace && Console.CursorLeft > pos)
                {
                    chars.RemoveAt(chars.Count - 1);
                    Console.CursorLeft -= 1;
                    Console.Write(' ');
                    Console.CursorLeft -= 1;

                }
                else if (info.Key == ConsoleKey.Enter) 
                {
                    Console.Write(Environment.NewLine); break; 
                }
                else if(info.Key == ConsoleKey.LeftArrow)
                {
                    Console.CursorLeft -= 1;
                }
                else if(info.Key == ConsoleKey.RightArrow)
                {
                    Console.CursorLeft += 1;
                }
                else if (char.IsPunctuation(info.KeyChar))
                {
                    Console.Write(info.KeyChar);
                    chars.Add(info.KeyChar);

                }
                else if(char.IsWhiteSpace(info.KeyChar))
                {
                    Console.Write(info.KeyChar);
                    chars.Add(info.KeyChar);
                }
                else if (char.IsLetterOrDigit(info.KeyChar))
                {
                    Console.Write(info.KeyChar);
                    chars.Add(info.KeyChar);
                }
            }
            return new string(chars.ToArray());
        }


        // --------------------- Ændre Søge Parametre----------------------
        public static string[] SearchParameters(string smoker, string gender, string minbday, string maxbday)
        {
            int choice;
            bool editDone = false;

            do
            {
                Console.Clear();

                Console.WriteLine("What do you want to change?");
                Console.WriteLine("(1) Smoke");
                Console.WriteLine("(2) Gender");
                Console.WriteLine("(3) Minimum Age");
                Console.WriteLine("(4) Maximum Age");
                Console.WriteLine("(5) Save and Exit");
                ConsoleKeyInfo UserInput = Console.ReadKey();

                choice = validatechoice(UserInput);
                switch (choice)
                {
                    case 1:
                        Console.WriteLine();
                        Console.WriteLine("Are you looking for a smoker? Enter 1 for True and 0 for False");
                        smoker = ReadLine(smoker);

                        break;

                    case 2:
                        Console.WriteLine();
                        Console.WriteLine("What Gender are you looking for? (1) Male\n(2) Female\n(3)Tranns Male\n(4)Trans Female\n(5)Gender Liquid\n(6)No gender\n(7)Space Rocket");
                        gender = ReadLine(gender);
                        break;

                    case 3:
                        Console.WriteLine();
                        Console.WriteLine("Enter minimum birthday by: DD/MM/YYYY. Ignore the remaining 0's.");
                        minbday = ReadLine(minbday);
                        break;

                    case 4:
                        Console.WriteLine();
                        Console.WriteLine("Enter maximum Birthday by: DD/MM/YYYY. ignore the remaining 0's");
                        maxbday = ReadLine(maxbday);
                        break;

                    case 5:
                        Console.WriteLine("Exit and save");
                        editDone = true;
                        break;

                    default:
                        break;
                }

            } while (editDone == false);



            string[] returnThis = { smoker, gender, minbday, maxbday };

            return returnThis;

        }

        



    } //class
}
