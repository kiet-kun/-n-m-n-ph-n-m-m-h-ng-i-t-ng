using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using QuanLyKho.Model.Domain;
using QuanLyKho.Model.Service;

namespace QuanLyKho.Core.Service
{
    public interface IUserService : IService<UserDTO>
    {
        Task<ServiceResult> Login(string email, string password);
    }
}
