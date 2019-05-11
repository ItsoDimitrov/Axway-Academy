using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Axway.Database;
using Microsoft.EntityFrameworkCore.Internal;

namespace Axway
{
    class StartUp
    {
        static void Main(string[] args)
        {
            AxwayContext context = new AxwayContext();
            //EF 
            var student = context.Students.Select(s => s.Name).FirstOrDefault();
            Console.WriteLine(student);

            //ADO.NET
            string queryString = @"SELECT TOP(1) [s].[Name]
                                            FROM [Students] AS [s]";

            using (SqlConnection connection = new SqlConnection(ConnectionConfiguration.CONNECTION_STRING))
            {
                SqlCommand command = new SqlCommand(
                    
                    queryString,connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(reader[0]);
                    }
                }
            }




        }
    }
}
