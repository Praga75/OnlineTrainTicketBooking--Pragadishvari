using System;
using System.Text.RegularExpressions;

namespace OnlineTrainTicketBooking
{
    public class Validate
    {
        //Validates Integer Value
        public static int ValidateInteger(string input)
        {
            int result;
            bool status;
            do
            {
                status = int.TryParse(input, out result);
                if (!status)
                {
                    Console.WriteLine("Enter a valid  Input");
                    input = Console.ReadLine();
                }
            } while (!status);
            return result;
        }
        //Validate Double Value
        public static double ValidateDoubleValue(string input)
        {
            double result;
            bool status;
            do
            {
                status = double.TryParse(input, out result);
                if (!status)
                {
                    Console.WriteLine("Enter a valid  Input");
                    input = Console.ReadLine();
                }
            } while (!status);
            return result;
        }


        // Validates Mobile Number
        public static long ValidateMobileNumber(string input)
        {
            long result;
            bool status;
            do
            {
                Regex phoneNumberValidator = new Regex("^[0-9]{10}$");
                status = long.TryParse(input, out result);
                if (!status || phoneNumberValidator.IsMatch(input))
                {
                    Console.WriteLine("Enter a valid  Mobile Number");
                    input = Console.ReadLine();
                }
            } while (!status);
            return result;
        }

        //Validates Date Of Birth
        public static DateTime ValidateDob(string input)
        {
            DateTime result;
            bool status;
            do
            {
                status = DateTime.TryParse(input, out result);
                if (!status)
                {
                    Console.WriteLine("Enter a valid  Date Of Birth");
                    input = Console.ReadLine();
                }
            } while (!status);
            return result;
        }

        //Validates Mail Id
        public static string ValidateMailId(string input)
        {
            // This Pattern is use to verify the email 
            Regex emailIdValidator = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

            if (emailIdValidator.IsMatch(input))
                return input;
            else
            {
                Console.WriteLine("enter correct Email");
                input = Console.ReadLine();
                ValidateMailId(input);
            }

            return input;
        }

        //Checks for Mail Id Already Exist or not.Since it is the Unique Key
        public static bool CheckMailIdExistorNot(string userId)
        {
            if (UserRepository.userCredential.ContainsKey(userId))
            {
                Console.WriteLine("Mail Id Already Exist!!! Try Again\n");
                return false;
            }
            else
            {
                return true;
            }
        }

        //Method Verifies the Train Number
        public static string CheckTrainNumber(string trainNumber)
        {
            bool status;
            do
            {
                if (TrainRepository.traindetails.ContainsKey(trainNumber))
                    return trainNumber;
                else
                {
                    Console.WriteLine("Enter a valid Train Number");
                    trainNumber = Console.ReadLine();
                    status = false;
                }
            } while (!status);
            return null;
        }


        //Method for Securing Password
        public static string SecurePassword()
        {
            string password = "";
            ConsoleKeyInfo input;
            do
            {
                input = Console.ReadKey(true);
                if (input.Key != ConsoleKey.Backspace && input.Key != ConsoleKey.Enter)
                {
                    password += input.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (input.Key == ConsoleKey.Backspace && password.Length > 0)
                    {
                        password = password.Substring(0, (password.Length - 1));
                        Console.Write("\b \b");
                    }
                }
            }
            while (input.Key != ConsoleKey.Enter);
            Console.WriteLine();

            return password;
        }

    }
}
