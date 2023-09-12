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
        public string Surname { get; set; }
        public int Grade { get; set; }
        public string Date { get; set; }
        public double No1 { get; set; }
        public double No2 { get; set; }
        public double No3 { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public User() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public User(int id, string name, string surname, int grade, double no1, double no2, double no3, string fecha)
        {
            Id = id; Name = name; Surname = surname; Grade = grade; ; Date = fecha; No1 = no1; No2 = no2; No3 = no3;
        }
        public User(string name, string surname, int grade, double no1, double no2, double no3, string fecha)
        {
            Name = name; Surname = surname; Grade = grade; Date = fecha; No1 = no1; No2 = no2; No3 = no3;
        }


        public override string ToString()
        {
            return $"id: {Id}\n Name: {Name}\n Surname: {Surname}\n Grade: {Grade}\n Fecha: {Date}\n Nota 1: {No1}\n Nota 2: {No2}\n Nota 3: {No3   }";
        }
    }
}
