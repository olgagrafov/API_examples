using System;


namespace ShowImageFromJason
{
    
    class Program
    {
        private static string  URL = @"https://yesno.wtf/api";
        static void Main(string[] args)
        {
            APIHelper cr = new APIHelper();            
            FileHelper fl = new FileHelper();

           
            ConsoleKey cK;
            PrintRules();
            cK = Console.ReadKey().Key;
            if (cK != ConsoleKey.Escape)
            {
                do
                {
                    Console.Clear();

                    switch (cK)
                    {
                        case ConsoleKey.D1:
                        case ConsoleKey.NumPad1:
                            ImgModel model = cr.DownloadAPIjson<ImgModel>(URL);
                            fl.FileWriter(model);
                            break;
                        case ConsoleKey.D2:
                        case ConsoleKey.NumPad2:
                            fl.FileReader(true);
                            break;
                        case ConsoleKey.D3:
                        case ConsoleKey.NumPad3:
                            fl.RemoveDuplicate();
                            break;
                        case ConsoleKey.D4:
                        case ConsoleKey.NumPad4:
                            fl.ShowHtmlFile();                           
                            break;
                    }
                    PrintRules();
                    cK = Console.ReadKey().Key;
                } while (cK != ConsoleKey.Escape);
            }
        }

        static void PrintRules()
        {
            Console.WriteLine("\n Press 1: take a data from API \n" +
                                "          and write the data to a file \n" +
                                " Press 2: print the data from a file on the screen \n" +
                                " Press 3: delete a duplicate data of images \n" +
                                " Press 4: show the result as a HTML \n\n" +
                                " Press Escape for exit \n");
        }
    }
}
