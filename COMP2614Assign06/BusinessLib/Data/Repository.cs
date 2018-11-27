using BusinessLib.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLib.Data
{
    public class Repository
    {
        private static string connectionString = @"Server = tcp:skeena.database.windows.net,1433;
                                                Initial Catalog = comp2614;
                                                User ID = student;
                                                Password=93nu5#Z183;
                                                Encrypt = True;
                                                TrustServerCertificate=False;
                                                Connection Timeout = 30;";

        public static int CreateClient(Customer client)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Client967008 
                                (ClientCode, CompanyName, Address1, Address2, City, Province, PostalCode, YTDSales, CreditHold, Notes) 
                                Values(@clientCode, @companyName, @address1, @address2, @city, @province, @postalCode, @ytdSales, @creditHold, @notes)";

                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = query;
                    command.Connection = connection;

                    command.Parameters.AddWithValue("@clientCode", client.ClientCode);
                    command.Parameters.AddWithValue("@companyName", client.CompanyName);
                    command.Parameters.AddWithValue("@address1", client.Address1);

                    if (client.Address2 != null)
                    {
                        command.Parameters.AddWithValue("@address2", client.Address2);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@address2", DBNull.Value);
                    }

                    if (client.City != null)
                    {
                        command.Parameters.AddWithValue("@city", client.City);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@city", DBNull.Value);
                    }

                    command.Parameters.AddWithValue("@province", client.Province);

                    if (client.PostalCode != null)
                    {
                        command.Parameters.AddWithValue("@postalCode", client.PostalCode);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@postalCode", DBNull.Value);
                    }

                    command.Parameters.AddWithValue("@ytdSales", client.YTDSales);
                    command.Parameters.AddWithValue("@creditHold", client.CreditHold);

                    if (client.Notes != null)
                    {
                        command.Parameters.AddWithValue("@notes", client.Notes);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@notes", DBNull.Value);
                    }

                    connection.Open();

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected;
                }
            }
        }

        public static ClientCollection ReadClient()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT * FROM Client967008";

                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = query;
                    command.Connection = connection;
                    connection.Open();

                    ClientCollection clientInfo = new ClientCollection();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        string clientCode = null;
                        string companyName = null;
                        string address1 = null;
                        string address2 = null;
                        string city = null;
                        string province = null;
                        string postalCode = null;
                        decimal ytdSales = 0.0m;
                        bool creditHold = false;
                        string notes = null;

                        while (reader.Read())
                        {
                            clientCode = reader["ClientCode"] as string;
                            companyName = reader["CompanyName"] as string;
                            address1 = reader["Address1"] as string;

                            if (!reader.IsDBNull(3))
                            {
                                address2 = reader["Address2"] as string;
                            }

                            if (!reader.IsDBNull(4))
                            {
                                city = reader["city"] as string;
                            }

                            province = reader["Province"] as string;

                            if (!reader.IsDBNull(6))
                            {
                                postalCode = reader["PostalCode"] as string;
                            }

                            ytdSales = (decimal)reader["YTDSales"];
                            creditHold = (bool)reader["CreditHold"];

                            if (!reader.IsDBNull(9))
                            {
                                notes = reader["Notes"] as string;
                            }

                            clientInfo.Add(new Customer(clientCode, companyName, address1, address2, city, province, postalCode, ytdSales, creditHold, notes));

                            clientCode = null;
                            companyName = null;
                            address1 = null;
                            address2 = null;
                            city = null;
                            province = null;
                            postalCode = null;
                            ytdSales = 0.0m;
                            creditHold = false;
                            notes = null;
                        }
                    }
                    return clientInfo;
                }
            }
        }

        public static int UpdateClient(Customer client)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Client967008
                                SET CompanyName = @companyName
                                , Address1 = @address1
                                , Address2 = @address2
                                , City = @city
                                , Province = @province
                                , PostalCode = @postalCode
                                , YTDSales = @ytdSales
                                , CreditHold = @creditHold
                                , Notes = @notes
                                WHERE ClientCode = @clientCode";

                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = query;
                    command.Connection = connection;

                    command.Parameters.AddWithValue("@clientCode", client.ClientCode);
                    command.Parameters.AddWithValue("@companyName", client.CompanyName);
                    command.Parameters.AddWithValue("@address1", client.Address1);

                    if (client.Address2 != null)
                    {
                        command.Parameters.AddWithValue("@address2", client.Address2);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@address2", DBNull.Value);
                    }

                    if (client.City != null)
                    {
                        command.Parameters.AddWithValue("@city", client.City);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@city", DBNull.Value);
                    }

                    command.Parameters.AddWithValue("@province", client.Province);

                    if (client.PostalCode != null)
                    {
                        command.Parameters.AddWithValue("@postalCode", client.PostalCode);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@postalCode", DBNull.Value);
                    }

                    command.Parameters.AddWithValue("@ytdSales", client.YTDSales);
                    command.Parameters.AddWithValue("@creditHold", client.CreditHold);

                    if (client.Notes != null)
                    {
                        command.Parameters.AddWithValue("@notes", client.Notes);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@notes", DBNull.Value);
                    }

                    connection.Open();

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected;
                }
            }
        }

        public static int DeleteClient(Customer client)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"DELETE Client967008 
                                WHERE ClientCode = @clientCode";

                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = query;
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@clientCode", client.ClientCode);

                    connection.Open();

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected;
                }
            }
        }
    }
}
