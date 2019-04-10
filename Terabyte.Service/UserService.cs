using SERVICE.PATTERN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terabyte.Data.Infrastructure;
using Terabyte.Domain.Entities;

namespace Terabyte.Service
{
 public   class UserService : Service<User>, IUserService
    {
        static IDatabaseFactory Factory = new DatabaseFactory();
        static IUnitOfWork utk = new UnitOfWork(Factory);
        public UserService() : base(utk)
        {

        }

        public List<User> getUsers()
        {
           // IEnumerable<User> u = (from user in utk.GetRepositoryBase<User>().GetMany() select user);
            List<User> list = new List<User>();
            return list;
        }
    }
}
