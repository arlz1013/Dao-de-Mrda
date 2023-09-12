using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Model.Datas
{
    public interface IUsers
    {
        bool Register(User user);
        List<User> getData();
        bool Update(User user);
        bool Delete(User user);
        User GetId(int id);
        List<User> GetAll();
        //PROMEDIO
        List<double> Average(User us);
    }
}
