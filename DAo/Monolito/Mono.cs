using System;
using System.Data;
using System.Xml.Linq;
using DAO.Model.Datas;
using MySql.Data.MySqlClient;


using static System.Console;

namespace DAO.Monolito
{
    class Mono
    {
        public Mono() 
        {
            while (Data() == true) 
            {
                ReadKey();
                Clear();
            }
        }
        private bool Data()
        {
            WriteLine("MONO...");
            string connectionString = "server=127.0.0.1;user=test;password=;database=testing;";
            MySqlConnection _conn = new MySqlConnection(connectionString);
            bool data = true;
            int id;
            string name, date; 
            double a, b, c;
            // Menú de opciones
            WriteLine("\nMENU DE OPCIONES:");
            WriteLine("1. Agregar");
            WriteLine("2. Actualizar");
            WriteLine("3. Eliminar");
            WriteLine("4. Listar");
            WriteLine("5. Calcular");
            WriteLine("0. Salir");
            Write("Seleccione una opción: ");
            int opcion = Int32.Parse(ReadLine());
            switch (opcion)
            {
                case 1:
                    name = InputString("Name");
                    date = InputDateNow();
                    a = InputDouble("Alto");
                    b = InputDouble("Ancho");
                    c = InputDouble("Valor x m^2");
                    Insert(name, date, a, b, c, _conn);

                    break;
                case 2:
                    id = InputInt("Digite el id:");
                    name = InputString("Name");
                    date = InputDateNow();
                    a = InputDouble("Alto");
                    b = InputDouble("Ancho");
                    c = InputDouble("Valor x m^2");
                    Update(id, name, date, a, b, c, _conn);
                    break;
                case 3:
                    id = InputInt("Digite la Id");
                    Delete(id, _conn);
                    break;
                case 4:
                    ListarEmpleados(_conn);
                    break;
                case 5:
                    Average(_conn);
                    break;
                default:
                    data = false;
                    break;
            }
            return data;
            
        }

        // Función para actualizar
        private void Update(int id, string name, string date, double a, double b, double c, MySqlConnection connection)
        {
            string updateQuery = $"UPDATE Alumnos SET Name = '{name}', Date = '{date}', height = {a}, weight = {b}, Square_Meter = {c} WHERE id = {id}";
            MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection);
            connection.Open();
            updateCommand.ExecuteNonQuery();
            connection.Close();
            Console.WriteLine("Update successful.");
        }

        // Función para agregar 
        private void Insert(string name, string date, double a, double b, double c, MySqlConnection connection)
        {
            string updateQuery = $"INSERT INTO Alumnos (Name, Date, height, weight , Square_Meter) values ('{name}', '{date}', {a}, {b}, {c});";
            MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection);
            connection.Open();
            updateCommand.ExecuteNonQuery();
            connection.Close();
            Console.WriteLine("Insert successful.");
        }

        // Función para eliminar 
        private void Delete(int id, MySqlConnection connection)
        {
            string deleteQuery = $"DELETE FROM Alumnos WHERE id= {id}";
            MySqlCommand deleteCommand = new MySqlCommand(deleteQuery, connection);
            connection.Open();
            deleteCommand.ExecuteNonQuery();
            connection.Close();
            Console.WriteLine("Empleado eliminado exitosamente.");
        }

        // Funcion Para Calcular
        private void Average(MySqlConnection connection)
        {
            string selectQuery = "SELECT id , height, weight, Square_Meter FROM Alumnos";
            MySqlCommand command = new MySqlCommand(selectQuery, connection);
            connection.Open();

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                double Ave = 0;
                while (reader.Read())
                {
                    int id = reader.GetInt32("id");
                    double hg = reader.GetDouble("height");
                    double wg = reader.GetDouble("weight");
                    double m2 = reader.GetDouble("Square_Meter");
                    Ave =  hg * wg * m2;

                    WriteLine($"id : {id}\n\tWeight: {wg} \t Height: {hg} \t Square Meter: {m2}\n\t Average:{Ave}");
                }

                
            }

            connection.Close();
        }

        // Función para listar 
        private void ListarEmpleados(MySqlConnection connection)
        {
            string selectQuery = "SELECT * FROM Alumnos ORDER BY id";
            MySqlCommand command = new MySqlCommand(selectQuery, connection);
            connection.Open();

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                Console.WriteLine("Lista de empleados:");
                while (reader.Read())
                {
                    int ide = reader.IsDBNull(reader.GetOrdinal("id")) ? 0 : reader.GetInt32("id");
                    string nm = reader.GetString("Name");
                    string dt = reader.GetString("Date");
                    double hg = reader.GetDouble("height");
                    double wg = reader.GetDouble("weight");
                    double m2 = reader.GetDouble("Square_Meter");
                    Console.WriteLine($"id: {ide}\n Name: {nm}\t Fecha: {dt}\n Alto: {hg}\t Ancho: {wg}\n Valor por m^2 {m2}");
                }
            }

            connection.Close();
        }

        //Funciones para Agregar Datos
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
