using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using QuanLyKho.Core.Repository;
using QuanLyKho.Data.Context;
using QuanLyKho.Repository.Base;

namespace QuanLyKho.Repository.User
{
    public class UserRepository : Repository<QuanLyKho.Data.Entity.User>, IUserRepository
    {
        private WarehouseDbContext dbContext { get => _context as WarehouseDbContext; }

        public UserRepository(DbContext context) : base(context)
        {
        }

        public async Task<bool> EmailValidationCreateUser(string email)
        {
            return await dbContext.User.AnyAsync(x => x.Email == email);
        }

        public async Task<bool> EmailValidationUpdateUser(string email, int Id)
        {
            return await dbContext.User.AnyAsync(x => x.Email == email && x.Id != Id);
        }
        public async Task<bool> Login(string email, string password)
        {
            return await dbContext.User.AnyAsync(x => x.Email == email && x.Password == password);
        }
    }
}
