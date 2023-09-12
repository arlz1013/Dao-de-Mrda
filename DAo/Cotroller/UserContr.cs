/*
using DAO.Model._dao;
using DAO.Model.Datas;
using DAO.View;
using Google.Protobuf.WellKnownTypes;
using System;
using System.Data;

using static System.Console;

namespace DAO.Cotroller
{
    class UserContr
    {
        private look view = new look();
        private IUsers dao;

        public UserContr(look view, IUsers dao)
        {
            this.dao = dao ?? throw new ArgumentNullException(nameof(dao));
        }

        public bool RegisterUs(User us)
        {
            try
            {
                return dao.Register(us);
            }
            catch (DAOExept ex)
            {
                WriteLine("Error to Register User" + ex.Message);
                return false;
            }
        }
        public bool UpdateUs(User us)
        {
            try
            {
                return dao.Update(us);
            }
            catch (DAOExept ex)
            {
                WriteLine("Error to Update User" + ex.Message);
                return false;
            }
        }
        public bool DeleteUs(User us)
        {
            try
            {
                return dao.Delete(us);
            }
            catch (DAOExept ex)
            {
                WriteLine("Error to Delete User" + ex.Message);
                return false;
            }
        }
        public void LookUs()
        {
            try
            {
                List<User> uss = dao.getData();
                view.ViewUsers(uss);
            }
            catch (DAOExept ex)
            {
                WriteLine("Error to Get User" + ex);
            }
        }
        public void Average() 
        {
            
        }
        public void Averages() 
        {
            
        }
    }
}
*/