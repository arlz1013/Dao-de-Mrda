using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Runtime.InteropServices;
using static System.Console;

namespace DAO.Model
{
    sealed class Conn
    {
        private static readonly string Info = "server=127.0.0.1;user=test;password=;database=testing;";
        private MySqlConnection _connection;

        private static Conn _instance = null;

        public static Conn Instance
        { 
            get 
            {
                if (_instance == null) 
                {
                    _instance = new Conn();
                }         
                return _instance;
            }
        }
        public Conn() 
        {
            _connection = new MySqlConnection(Info);
        }

        public MySqlConnection OpenConn() 
        {
            try 
            {
                if(_connection.State != System.Data.ConnectionState.Open) 
                {
                    _connection.Open();
                    Console.WriteLine("Connected");
                }
            }catch (MySqlException ex) 
            {
                Console.WriteLine("Error to Open the Connection " + ex.Message);
            }
            return _connection;
        }
        public MySqlConnection CloseConn()
        {
            try
            {
                if (_connection.State != System.Data.ConnectionState.Closed)
                {
                    _connection.Open();
                    Console.WriteLine("Closed Connection");
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error to Closed the Connection " + ex.Message);
            }
            return _connection;
        }
    }
}
