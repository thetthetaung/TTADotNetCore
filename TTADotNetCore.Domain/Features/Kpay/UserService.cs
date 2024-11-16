using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTADotNetCore.Database.Models;

namespace TTADotNetCore.Domain.Features.Kpay
{
    public class UserService
    {
        private readonly AppDbContext2 _db = new AppDbContext2();

        public List<TblUser> GetUsers()
        {
            var model = _db.TBlUser.AsNoTracking().ToList();
            return model;
        }

        public TblUser CreateUser(TblUser user)
        {
            _db.TBlUser.Add(user);
            _db.SaveChanges();
            return user;
        }

        public TblUser GetById(int id)
        {
            var item = _db.TBlUser
                    .AsNoTracking()
                    .FirstOrDefault(x => x.UserId == id);

            return item;
        }

        public TblUser UpdateBlog(int id, TblUser user)
        {
            var item = _db.TBlUser
                .AsNoTracking()
                .FirstOrDefault(x => x.UserId == id);

            if (item is null)
            {
                return null;
            }
            item.UserId = user.UserId;
            item.FullName = user.FullName;
            item.MoobileNumber = user.MoobileNumber;
            item.Balance = user.Balance;
            item.Pin = user.Pin;
            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();
            return item;
        }

        public bool DeleteUser(int id)
        {
            var item = _db.TBlUser
                .AsNoTracking()
                .FirstOrDefault(x => x.UserId == id);
            if (item is null)
            {
                return false;
            }
            _db.Entry(item).State = EntityState.Deleted;
            int result = _db.SaveChanges();
            return result > 0;

        }
    }
}


