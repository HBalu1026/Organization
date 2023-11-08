using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;

namespace Organization_console // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Organization> lista = new List<Organization>();
            foreach(var sor in File.ReadAllLines("organizations-100000.csv").Skip(1))
            {
                lista.Add(new Organization(sor.Split(';')));
            }

            //1 feladat
            foreach (var item in lista.Select(x => x.Country).Distinct().OrderBy(x => x))
            {
                Console.WriteLine(item + ',');
            }

            //2
            foreach (var item in lista.Where(x => x.Website.EndsWith("org/")).GroupBy(x => x.Country))
            {
                Console.WriteLine(item.Key + ":" + item.Count() + "||");
            }

            //3
            Console.WriteLine(lista.Where(x => x.Founded >= 2010 && x.Founded < 2020 && x.Industry == "Plastic").Select(x => x.EmployeesNumber).Average() + "||");

            //4
            foreach (var csoport in lista.GroupBy(x => x.Country))
            {
                Console.WriteLine(csoport.MaxBy(x => x.Name.Length).Name + "||");
            }
        }
    }
}