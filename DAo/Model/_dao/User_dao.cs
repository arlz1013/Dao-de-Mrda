using System;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

using static System.Console;
using Google.Protobuf;
using DAO.Model.Datas;
using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Xml.Linq;

namespace DAO.Model._dao
{
    public class UserDao : IUsers
    {
        //private const string INSERT_QUERY = "INSERT INTO Alumnos (Namex, Surname, Grade, Fecha , Not1, Not2, Not3) values (' @name ', ' @surname ', @grade ,' @date ', @no1, @no2, @no3)";
        private const string SELECT_ALL_QUERY = "SELECT * FROM Alumnos ORDER BY id";
        //private const string UPDATE_QUERY = "UPDATE Alumnos SET Namex=@name, Surname=@surname, Grade=@grade, Fecha = @date ,Not1=@no1, Not2=@no2, Not3=@no3 WHERE id=@id";
        private const string DELETE_QUERY = "DELETE FROM Alumnos WHERE id=@id";
        private const string SELECT_BY_ID_QUERY = "SELECT * FROM Alumnos WHERE id=@id";
        private const string SELECT_ALL_EMPLEADOS_QUERY = "SELECT * FROM Alumnos";

        private readonly MySqlConnection _connection;
        public UserDao(MySqlConnection connection)
        {
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));
        }

        public bool Register(User user)
        {
            bool send = false;

            try
            {
                string data =  $"INSERT INTO Alumnos (Namex, Surname, Grade, Fecha , Not1, Not2, Not3) values ('{user.Name}', '{user.Surname}', {user.Grade} ,' {user.Date} ', {user.No1}, {user.No2}, {user.No3})";
                ProveState();
                using ( MySqlCommand cmd = new MySqlCommand(data, _connection))
                {
                    cmd.ExecuteNonQuery();
                    send = true;

                    user.Id = (int)cmd.LastInsertedId;
                    send = true;
                }

            }
            catch (Exception ex)
            {
                throw new DAOExept("Error To Insert User to Base Data", ex);
            }

            return send;
        }

        public bool Update(User user)
        {
            bool send = false;
            try
            {
                string data = $"UPDATE Alumnos SET Namex = '{user.Name}', Surname = '{user.Surname}', Grade = {user.Grade}, Fecha = '{user.Date}' ,Not1 = {user.No1}, Not2 = {user.No2}, Not3 = {user.No3} WHERE id = {user.Id}";
                WriteLine(data);
                ProveState();
                using (MySqlCommand cmd = new MySqlCommand(data, _connection))
                {
                    /*
                    cmd.Parameters.AddWithValue("@name", user.Name);
                    cmd.Parameters.AddWithValue("@surname", user.Surname);
                    cmd.Parameters.AddWithValue("@grade", user.Grade);
                    cmd.Parameters.AddWithValue("@data", user.Date);
                    cmd.Parameters.AddWithValue("@no1", user.No1);
                    cmd.Parameters.AddWithValue("@no2", user.No2);
                    cmd.Parameters.AddWithValue("@no3", user.No3);
                    cmd.Parameters.AddWithValue("@id", user.Id);
                    */
                    cmd.ExecuteNonQuery();
                    send = true;
                }
            }
            catch (Exception ex)
            {
                throw new DAOExept("Error To Update User", ex);
            }
            finally
            {
                _connection.Close();
            }
            return send;
        }

        public bool Delete(User user)
        {
            bool send = false;

            try
            {
                ProveState();
                using (MySqlCommand cmd = new MySqlCommand(DELETE_QUERY, _connection))
                {
                    cmd.Parameters.AddWithValue("@id", user.Id);
                    cmd.ExecuteNonQuery();
                    send = true;
                }
            }
            catch (Exception ex)
            {
                throw new DAOExept("Error deleting user", ex);
            }
            finally
            {
                _connection.Close();
            }

            return send;
        }

        public User GetId(int id)
        {
            User us = null;

            try
            {
                ProveState();
                using (MySqlCommand cmd = new MySqlCommand(SELECT_BY_ID_QUERY, _connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (MySqlDataReader read = cmd.ExecuteReader())
                    {
                        if (read.Read())
                        {
                            us = CreateUser(read);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new DAOExept("Error getting User", ex);
            }
            finally
            {
                _connection.Close();
            }
            return us;
        }

        public List<User> getData()
        {
            List<User> list = new List<User>();
            try
            {
                ProveState();
                using (MySqlCommand cmd = new MySqlCommand(SELECT_ALL_QUERY, _connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            User us = CreateUser(reader);
                            list.Add(us);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new DAOExept("Error getting table", ex);
            }
            finally
            {
                _connection.Close();
            }
            return list;
        }

        public List<User> GetAll()
        {
            List<User> list = new List<User>();
            try
            {
                ProveState();
                using (MySqlCommand cmd = new MySqlCommand(SELECT_ALL_EMPLEADOS_QUERY, _connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            User us = CreateUser(reader);
                            list.Add(us);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new DAOExept("Error getting table", ex);
            }
            finally
            {
                _connection.Close();
            }
            return list;
        }

        public  List<double> Average(User us) 
        {
            double Ave = (us.No1 * 0.3) + (us.No2 * 0.3) + (us.No3 * 0.4) ;
            return new List<double>{us.Id, us.No1, us.No2 , us.No3 ,Ave};
        }

        private void ProveState()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
        }

        private User CreateUser(MySqlDataReader reader)
        {
            int ide = reader.IsDBNull(reader.GetOrdinal("id")) ? 0 : reader.GetInt32("id");
            string nm = reader.GetString("Namex");
            string srnm = reader.GetString("Surname");
            int grd = reader.GetInt32("Grade");
            string dttm = reader.GetString("Fecha");
            double n1 = reader.GetDouble("Not1");
            double n2 = reader.GetDouble("Not2");
            double n3 = reader.GetDouble("Not3");
            return new User(ide, nm, srnm, grd, n1, n2,n3,dttm);

        }

    }
}
