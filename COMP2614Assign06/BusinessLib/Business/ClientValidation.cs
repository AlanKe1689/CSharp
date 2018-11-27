using BusinessLib.Common;
using BusinessLib.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLib.Business
{
    public class ClientValidation
    {
        private static List<string> errors;

        static ClientValidation()
        {
            errors = new List<string>();
        }

        public static string ErrorMessage
        {
            get
            {
                string message = "";

                foreach (string line in errors)
                {
                    message += line + "\r\n";
                }

                return message;
            }
        }

        public static ClientCollection GetCustomer() => Repository.ReadClient();

        public static int CreateClient(Customer client)
        {
            if (validate(client))
            {
                return Repository.CreateClient(client);
            }
            else
            {
                return -1;
            }
        }

        public static int UpdateClient(Customer client)
        {
            if (validate(client))
            {
                return Repository.UpdateClient(client);
            }
            else
            {
                return -1;
            }
        }

        public static int DeleteClient(Customer client) => Repository.DeleteClient(client);

        public static bool validate(Customer client)
        {
            bool success = true;
            errors.Clear();

            if (string.IsNullOrEmpty(client.ClientCode))
            {
                errors.Add("Client code cannot be empty.");
                success = false;
            }

            if (!Regex.IsMatch(client.ClientCode, @"^[A-Z]{5}$"))
            {
                errors.Add("Client code can only contain 5 capital letters.");
                success = false;
            }

            if (string.IsNullOrEmpty(client.CompanyName))
            {
                errors.Add("Company name cannot be empty.");
                success = false;
            }

            if (string.IsNullOrEmpty(client.Address1))
            {
                errors.Add("Address 1 cannot be empty.");
                success = false;
            }

            if (string.IsNullOrEmpty(client.Province))
            {
                errors.Add("Province cannot be empty.");
                success = false;
            }

            if (!Regex.IsMatch(client.Province, @"^[A-Z]{2}$"))
            {
                errors.Add("Province can only contain 2 capital letters.");
                success = false;
            }

            if (!Regex.IsMatch(client.PostalCode, @"^[A-Z]\d[A-Z] \d[A-Z]\d$"))
            {
                errors.Add("Postal code format is incorrect.");
                success = false;
            }

            if (client.YTDSales < 0)
            {
                errors.Add("YTD sales cannot be less than zero.");
                success = false;
            }
            return success;
        }
    }
}
