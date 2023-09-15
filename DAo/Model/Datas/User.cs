using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Model.Datas
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public double Square_Meter { get; set; }

// Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public User() { }
// Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public User(int id, string name, double height, double weight, double square_meter, string fecha)
        {
            Id = id; Name = name; Date = fecha; Height = height; Weight = weight; Square_Meter = square_meter;
        }
        public User(string name, double height, double weight, double square_meter, string fecha)
        {
            Name = name; Date = fecha; Height = height; Weight = weight; Square_Meter = square_meter;
        }


        public override string ToString()
        {
            return $"id: {Id}\n Name: {Name}\t Fecha: {Date}\n Alto: {Height}\t Ancho: {Weight}\n Valor por m^2 {Square_Meter}";
        }
    }
}
