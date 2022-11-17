using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using QuanLyKho.Core.UnitOfWorks;

namespace QuanLyKho.Service.Base
{
    public class BaseService
    {
        public readonly IUnitOfWorks _unitOfWork;
        public readonly IMapper _mapper;

        public BaseService(IUnitOfWorks unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    }
}
