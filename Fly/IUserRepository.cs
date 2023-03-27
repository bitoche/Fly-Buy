using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fly
{
    public interface IUserRepository
    {
        public User[] GetAll();
        public User GetById(int id);
        public User GetByLogin(string login);
        public User GetByUserName(string userName);
        public void Create(User user);
        public void ChangeRole(int userId, int roleId);
        public void ChangeRoleToReservist(string userLogin);
        public void TopUpBalance(int userId, long amountToTopUp);
        public void WriteOffBalance(int userId, long amountToWriteOff);
        public void DeleteUserById(int userId);
    }
}
