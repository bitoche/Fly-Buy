using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fly.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbContextFactory<FlyDbContext> dbContextFactory;
        public UserRepository(IDbContextFactory<FlyDbContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public void Create(User user)
        {
            var dbContext = dbContextFactory.CreateDbContext();
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
        }

        public User[] GetAll()
        {
            var dbContext = dbContextFactory.CreateDbContext();
            var users = dbContext.Users.ToArray();
            return users;
        }

        public User GetById(int id)
        {
            var dbContext = dbContextFactory.CreateDbContext();
            var user = dbContext.Users.Single(x => x.Id == id);
            return user;
        }
        public User GetByLogin(string login)
        {
            var dbContext = dbContextFactory.CreateDbContext();
            var user = dbContext.Users.Single(x => x.Login == login);
            return user;
        }
        public User GetByUserName(string userName)
        {
            var dbContext = dbContextFactory.CreateDbContext();
            var user = dbContext.Users.Single(x => x.Name == userName);
            return user;
        }


        public void ChangeRole(int userId, int roleId)
        {
            var dbContext = dbContextFactory.CreateDbContext();
            var user = dbContext.Users.Single(x=>x.Id == userId);
            user.Role = (Role)roleId;
            dbContext.SaveChanges();

        }
        public void ChangeRoleToReservist(string userLogin)
        {
            var dbContext = dbContextFactory.CreateDbContext();
            var user = dbContext.Users.Single(x => x.Login == userLogin);
            user.Role = Role.Reservist;
            dbContext.SaveChanges();
        }
        public void TopUpBalance(int userId, long amountToTopUp)
        {
            var dbContext = dbContextFactory.CreateDbContext();
            var user = dbContext.Users.Single(x => x.Id == userId);
            user.Balance+=amountToTopUp;
            dbContext.SaveChanges();
        }
        public void WriteOffBalance(int userId, long amountToWriteOff)
        {
            var dbContext = dbContextFactory.CreateDbContext();
            var user = dbContext.Users.Single(x => x.Id == userId);
            user.Balance -= amountToWriteOff;
            dbContext.SaveChanges();
        }
        public void DeleteUserById(int userId)
        {
            var dbContext = dbContextFactory.CreateDbContext();
            var user = dbContext.Users.Single(x => x.Id == userId);
            dbContext.Remove(user);
            dbContext.SaveChanges();
        }
    }
}
