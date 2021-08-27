using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vakantiedagen
{
    class Program
    {
        static void Main(string[] args)
        {
            // parameters
            string name;

            DateTime currentDate = DateTime.Now;
            DateTime birthDate;
            DateTime workDate;

            int freeDays;
            int PN;

            // data
            while (true)
            {
                try
                {
                    Console.WriteLine("Please enter your personnel number.");
                    name = Console.ReadLine();
                    PN = Convert.ToInt32(name.Substring(0, 1));
                    break;
                }
                catch (Exception) { Console.WriteLine("Invalid. Please try again."); }
            }

            while (true)
            {
                try
                {
                    Console.WriteLine("What is your birthdate?");
                    birthDate = Convert.ToDateTime(Console.ReadLine());
                    break;
                }
                catch (Exception) { Console.WriteLine("Invalid. Please try again."); }
            }

            while (true)
            {
                try
                {
                    Console.WriteLine("When did you start working here?");
                    workDate = Convert.ToDateTime(Console.ReadLine());
                    break;
                }
                catch (Exception) { Console.WriteLine("Invalid. Please try again."); }
            }

            // math
            int ageY = currentDate.Year - birthDate.Year;
            int ageM = currentDate.Month - birthDate.Month;
            int ageD = currentDate.Day - birthDate.Day;

            int worY = currentDate.Year - workDate.Year;
            int worM = currentDate.Month - workDate.Month;
            int worD = currentDate.Day - workDate.Day;

            if (ageM < 0 || (ageD < 0 && ageM == 0) )
            {
                ageY -= 1;
            }
            if (worM < 0 || (worD < 0 && worM == 0))
            {
                worY -= 1;
            }


            if (PN == 1) { freeDays = 24; }
            else if (PN == 2) { freeDays = 23; }
            else if (PN == 3) { freeDays = 22; }
            else { freeDays = 20; }

            if (worY >= 10) { freeDays += 3; }

            if (ageY >= 50) { freeDays += 5; }

            if (ageY >= 55)
            {
                freeDays += (ageY - 54);
            }

            // conclusion
            Console.WriteLine("Your personnel number is: " + name);
            Console.WriteLine("The current date is: " + currentDate);
            Console.WriteLine("Your birthdate is: " + birthDate);
            Console.WriteLine("Your are this old: " + ageY);
            Console.WriteLine("You work here this many years: " + worY);
            Console.WriteLine("Your vacation days: " + freeDays);
        }
    }
    // afhankelijk van afdeling
        // afdeling 1: 24 dagen
        // afdeling 2: 23 dagen
        // afdeling 3: 22 dagen
        // overige afdelingen 20 dagen
    // afdelingsnummer is 1e cijfer van personeelsnummer
    // 10 jaar of langer in dienst: dagverhoging met 3
    // 50 jaar of ouder: dagverhoging met 5
    // 55 jaar of ouder: ieder jaar dagverhoging met 5
    // bepaal vakantiedagen, leeftijd en dienstjaren
}
