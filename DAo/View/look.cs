using DAO.Model.Datas;
using System;
using System.Data;

using static System.Console;

namespace DAO.View
{
    class look
    {
        public void ViewUser(User us) 
        {
            WriteLine("Datas from Users:\n" + us.ToString());
        }
        public void ViewUsers(List<User> uss) 
        {
            if (uss.Count == 0) 
            {
                WriteLine("Nothing");
                return;
            }
            WriteLine("Users List");
            foreach (User u in uss) 
            {
                WriteLine("\n");
                WriteLine(u.ToString());
            }
        }

        public void ViewAverage(List<double> da) 
        {
            foreach (double d in da) 
            {
                Write(d + "\t");
            }
        }
    }
}
