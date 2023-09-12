using System;
using System.Data;

using static System.Console;

namespace DAO.Model._dao
{
    internal class DAOExept : Exception
    {
        public DAOExept(string message) : base(message) { }
        public DAOExept(string message, Exception innerExeption) { }

    }
}
