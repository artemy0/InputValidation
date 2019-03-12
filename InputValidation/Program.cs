using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace InputValidation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello!");

            //A variable is assigned data that passes validation;
            //"email address" - information displayed in the console, 
            //ValidateEmailAdresses - The method checks whether the data is validated and returns a boolean value.
            string emailAdresses = EnterAndReturnValidateData("email address", ValidateEmailAdresses);

            string URL = EnterAndReturnValidateData("URL", ValidateURL);

            string filePath = EnterAndReturnValidateData("file path", ValidateFilePath);

            //information output
            Console.WriteLine($"\tAll info:\nEmail adresses: {emailAdresses}\nURL: {URL}\nPath to file: {filePath}");

            Console.ReadKey();
        }




        //validation method for typed data using a specific method
        static string EnterAndReturnValidateData(string dataName, Func<string, bool> validationMethod)
        {
            while (true)
            {
                Console.Write("Pleas enter your {0}: ", dataName);
                string data = Console.ReadLine();

                //Validation of entered data.
                if (validationMethod(data))
                {
                    Console.WriteLine("{0} entered correctly.\n", dataName);
                    return data;
                }
                else
                {
                    Console.WriteLine("{0} entered incorrectly. Try again!", dataName);
                }
            }
        }

        //all regular expressions taken from http://regexlib.com/

        static bool ValidateEmailAdresses(string emailAdresses)
        {
            //this expression will match the string: asmith@mactec.com | foo12@foo.edu | bob.smith@foo.tv
            Match match = Regex.Match(emailAdresses, @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                RegexOptions.Singleline);

            return match.Success;
        }

        static bool ValidateURL(string URL)
        {
            //this expression will match the string: hTtP://3iem.net/ | http://3iem.museum:1337/ | plik.co.uk
            Match match = Regex.Match(URL, @"^((((H|h)(T|t)|(F|f))(T|t)(P|p)((S|s)?))\://)?(www.|[a-zA-Z0-9].)[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,6}(\:[0-9]{1,5})*(/($|[a-zA-Z0-9\.\,\;\?\'\\\+&amp;%\$#\=~_\-]+))*$",
                RegexOptions.Singleline | RegexOptions.Compiled);

            return match.Success;
        }

        static bool ValidateFilePath(string filePath)
        {
            //this expression will match the string: /asdjd/jhsdh.ajsd | E:\drive.txt | \\usr\home\docs.jpg | \users\assassin\home/yp.r15
            Match match = Regex.Match(filePath, @"^(([a-zA-Z]:)|((\\|/){1,2}\w+)\$?)((\\|/)(\w[\w ]*.*))+\.([a-zA-Z0-9]+)$",
                RegexOptions.Singleline);

            return match.Success;
        }
    }
}
