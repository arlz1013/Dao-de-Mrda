using DAO.Model;
using DAO.Model.Datas;
using MySql.Data.MySqlClient;

namespace DAO.Model._dao
{
    class UsFac
    {
        public static IUsers CreateUsDAO()
        {
            MySqlConnection conn = Conn.Instance.OpenConn();
            return new UserDao(conn);
        }
    }
}
