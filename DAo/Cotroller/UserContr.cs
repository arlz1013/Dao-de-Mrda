
using DAO.Model._dao;
using DAO.Model.Datas;
using DAO.View;
using System;
using System.Data;

using static System.Console;

namespace DAO.Cotroller
{
    class UserContr
    {
        private static IUsers dao = UsFac.CreateUsDAO();


        public UserContr() 
        {
            while (Send() == true)
            {
                ReadKey();
                Clear();
            }
        }

        private bool Send() 
        {
            bool data = true;
            string Acc;
            WriteLine("DAO...");

            WriteLine("\nMENU DE OPCIONES:");
            WriteLine("|I| Insert");
            WriteLine("|U| Update");
            WriteLine("|D| Delete");
            WriteLine("|L| List");
            WriteLine("|A| Average");
            WriteLine("Exit");
            Acc = ReadLine()?.ToUpper();
            if (!string.IsNullOrEmpty(Acc))
            {
                try
                {
                    switch (Acc)
                    {
                        case "L":
                            ListUs();
                            break;
                        case "I":
                            InsertUs();
                            break;
                        case "U":
                            UpdateUs();
                            break;
                        case "D":
                            DeleteUs();
                            break;
                        case "A":
                            Average();
                            break;
                        default:
                            WriteLine("Fuck You!!!");
                            data = false;
                            break;
                    }
                }
                catch (DAOExept ex)
                {
                    WriteLine("Fuck You " + ex.Message);
                }
            }
            
            return data;
        }
        private static void InsertUs()
        {
            try
            {
                User us = InputEmpleado();
                if (dao.Register(us))
                {
                    WriteLine("Susccesful: " + us.Id);
                    WriteLine("\n\nCreado: " + us);
                }
                else
                {
                    WriteLine("Error");
                }
            }
            catch (DAOExept e)
            {
                WriteLine("Error to insert Data: " + e.Message);
            }
        }

        private static void UpdateUs()
        {
            int id = InputInt("Insert Id");
            User us = dao.GetId(id);
            WriteLine("------------Datos originales------------");
            WriteLine(us);
            WriteLine("Ingrese los nuevos datos");

            string name = InputString("Insert Nombre");
            string date = InputDateNow();
            double n1 = InputDouble("Insert Alto");
            double n2 = InputDouble("Insert Ancho");
            double n3 = InputDouble("Insert Valor x m^2");

            us = new User(id, name, n1, n2, n3, date);
            try
            {
                if (dao.Update(us))
                {
                    WriteLine("Actualización exitosa");
                }
                else
                {
                    WriteLine("Error al actualizar el empleado.");
                }
            }
            catch (DAOExept e)
            {
                WriteLine("Error al actualizar el empleado: " + e.Message);
            }
        }

        private static void DeleteUs()
        {
            int id = InputInt("Insert Id");
            User us = null;

            try
            {
                us = dao.GetId(id);
            }
            catch (DAOExept daoe)
            {
                WriteLine("Error: " + daoe.Message);
            }

            if (us != null && dao.Delete(us))
            {
                WriteLine("Empleado eliminado: " + us.Id);
            }
            else
            {
                WriteLine("Error al eliminar el empleado.");
            }
        }

        private static void Average() 
        {
            int id = InputInt("Insert Id");
            User us = null;
            List<double> da = null;
            try
            {
                us = dao.GetId(id);
                da = dao.Average(us);
            }
            catch (DAOExept daoe)
            {
                WriteLine("Error: " + daoe.Message);
            }
            WriteLine("Info About Id: " + us.Id);
            WriteLine("Id\tNota1\tNota2\tNota3\tPromedio");
            foreach (double i in da)
            {
                Write(i + "\t");
            }
            WriteLine("\n");

        }

        private static void ListUs()
        {
            try
            {
                List<User> uss = dao.getData();
                foreach (User us in uss)
                {
                    WriteLine(us.ToString() + "\n");
                }
            }
            catch (DAOExept e)
            {
                WriteLine("Error al obtener todos los empleados: " + e.Message);
                WriteLine("StackTrace: " + e.StackTrace);
            }
        }

        private static User InputEmpleado()
        {
            string name = InputString("Insert Nombre");
            string date = InputDateNow();
            double n1 = InputDouble("Insert Alto");
            double n2 = InputDouble("Insert Ancho");
            double n3 = InputDouble("Insert Valor x m^2");

            return new User( name, n1, n2, n3, date);
        }

        private static string InputString(string message)
        {
            string s;
            while (true)
            {
                WriteLine(message);
                s = ReadLine()?.Trim();
                if (!string.IsNullOrEmpty(s) && s.Length >= 2)
                {
                    break;
                }
                else
                {
                    WriteLine("La longitud de la cadena debe ser >= 2");
                }
            }
            return s;
        }

        private static double InputDouble(string message)
        {
            double s;
            while (true)
            {
                try
                {
                    WriteLine(message);
                    if (double.TryParse(ReadLine(), out s))
                    {
                        break;
                    }
                    else
                    {
                        WriteLine("Error de formato de número");
                    }
                }
                catch (FormatException)
                {
                    WriteLine("Error de formato de número");
                }
            }
            return s;
        }

        private static int InputInt(string message) 
        {
            int s;
            while (true)
            {
                try
                {
                    WriteLine(message);
                    if (int.TryParse(ReadLine(), out s))
                    {
                        break;
                    }
                    else
                    {
                        WriteLine("Error de formato de número");
                    }
                }
                catch (FormatException)
                {
                    WriteLine("Error de formato de número");
                }
            }
            return s;
        }

        private static string InputDateNow()
        {
            DateTime Fecha = DateTime.Now;
            string FormatoFechaSql = Fecha.ToString("yyyy-MM-dd HH:mm:ss");
            WriteLine(FormatoFechaSql);
            return FormatoFechaSql;
        }
    }
}
