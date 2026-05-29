using Course.Entities;
using System;
using System.Collections.Generic; 
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Net;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;
using System.Xml;
using Course.Entities.Expeceptions;
namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                Console.Write("Room number: ");
                int number = int.Parse(Console.ReadLine()!);

                Console.Write("Check-int data (dd/MM/yyyy): ");
                DateTime checkIn = DateTime.Parse(Console.ReadLine()!);

                Console.Write("Check-out date (dd/MM/yyyy): ");
                DateTime checkOut = DateTime.Parse(Console.ReadLine()!);


                Reservention reserve = new Reservention(number, checkIn, checkOut);
                Console.WriteLine();
                Console.WriteLine(reserve);
                Console.WriteLine();
                Console.WriteLine("UPDATE RESERVE: ");

                Console.Write("Check-int data (dd/MM/yyyy): ");
                checkIn = DateTime.Parse(Console.ReadLine()!);

                Console.Write("Check-out date (dd/MM/yyyy): ");
                checkOut = DateTime.Parse(Console.ReadLine()!);

                reserve.UpdateDates(checkIn, checkOut);

                Console.WriteLine();

                Console.WriteLine("UPDATE: " + reserve);
            }  

            catch (DomainException ex)
            {
                Console.WriteLine(ex.Message);
            }
           catch(FormatException e) 
            {
                Console.WriteLine("Format error " + e.Message);
            }

            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}