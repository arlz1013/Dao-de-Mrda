using DAO.Cotroller;
using DAO.Model._dao;
using DAO.Model.Datas;
using DAO.Monolito;
using System;
using System.Data;

using static System.Console;

namespace DAO
{
    class main
    {
        static void Main(string[] args) 
        {
            UserContr DAO;
            Mono MN;
            while (true) 
            {
                WriteLine("What do you want to do?");
                WriteLine("|1| Monolito");
                WriteLine("|2| DAO without ASP");

                string a = ReadLine();
                switch (a) 
                {
                    case "1":
                        MN = new Mono();
                        break;
                    case "2":
                        DAO = new UserContr();
                        break;
                    default:
                        return;
                }
                ReadKey();
                Clear();
            }
        
        }
    }
}