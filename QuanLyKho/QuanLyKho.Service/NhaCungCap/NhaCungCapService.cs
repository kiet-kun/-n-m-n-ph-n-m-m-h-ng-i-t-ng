using AutoMapper;
using QuanLyKho.Common.Message;
using QuanLyKho.Core.Service;
using QuanLyKho.Core.UnitOfWorks;
using QuanLyKho.Model.Domain;
using QuanLyKho.Model.Service;
using QuanLyKho.Service.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entity = QuanLyKho.Data.Entity;

namespace QuanLyKho.Service.NhaCungCap
{
    public class NhaCungCapService : BaseService, INhaCungCapService
    {
        public NhaCungCapService(IUnitOfWorks unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<ServiceResult> AddAsync(NhaCungCapDTO model)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                using (_unitOfWork)
                {
                    Entity.NhaCungCap entity = _mapper.Map<Data.Entity.NhaCungCap>(model);
                    entity.CreateDate = DateTime.Now;
                    await _unitOfWork.NhaCungCapRepository.AddAsync(entity);
                    await _unitOfWork.SaveAsync();
                    result.Id = entity.Id;
                    result.UserMessage = CommonMessages.MSG0001;
                }
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.UserMessage = string.Format(CommonMessages.MSG0002, ex.Message);
            }
            return result;
        }

        public async Task<ServiceResult<IEnumerable<NhaCungCapDTO>>> Find(NhaCungCapDTO criteria)
        {
            ServiceResult<IEnumerable<NhaCungCapDTO>> result = new ServiceResult<IEnumerable<NhaCungCapDTO>>();
            try
            {
                using (_unitOfWork)
                {
                    IEnumerable<Entity.NhaCungCap> list = await _unitOfWork
                                                                   .NhaCungCapRepository                                                                  
      
                                                                   .FindAsync(filter: x => (string.IsNullOrEmpty(criteria.TenNhaCungCap) 
                                                                                    || x.TenNhaCungCap.Contains(criteria.TenNhaCungCap)),
                                                                                          
                                                                           orderByDesc: x => x.Id,
                                                                           skip: criteria.PageNumber,
                                                                           take: criteria.RecordCount);
                                                                   
                    result.TransactionResult = _mapper.Map<IEnumerable<NhaCungCapDTO>>(list);
                }
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.UserMessage = string.Format(CommonMessages.MSG0002, ex.Message);
            }
            return result;
        }

        public async Task<ServiceResult<int>> FindCount(NhaCungCapDTO criteria)
        {
            ServiceResult<int> result = new ServiceResult<int>();
            try
            {
                using (_unitOfWork)
                {
                    int count = await _unitOfWork.NhaCungCapRepository
                        
                                                 
                                                  .FindCountAsync(filter: x => (string.IsNullOrEmpty(criteria.TenNhaCungCap) || x.TenNhaCungCap.Contains(criteria.TenNhaCungCap))
                                                                              
                                                                              );
                   
                    result.TransactionResult = count;
                }
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.UserMessage = string.Format(CommonMessages.MSG0002, ex.Message);
            }
            return result;
        }
        public async Task<ServiceResult<IEnumerable<NhaCungCapDTO>>> GetAll()
        {
            ServiceResult<IEnumerable<NhaCungCapDTO>> result = new ServiceResult<IEnumerable<NhaCungCapDTO>>();
            try
            {
                using (_unitOfWork)
                {
                    IEnumerable<Entity.NhaCungCap> list = await _unitOfWork.NhaCungCapRepository.GetAllAsync();
                    result.TransactionResult = _mapper.Map<IEnumerable<NhaCungCapDTO>>(list);
                }
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.UserMessage = string.Format(CommonMessages.MSG0002, ex.Message);
            }

            return result;
        }
        public async Task<ServiceResult<NhaCungCapDTO>> GetById(int id)
        {
            ServiceResult<NhaCungCapDTO> result = new ServiceResult<NhaCungCapDTO>();
            try
            {
                using (_unitOfWork)
                {
                    Entity.NhaCungCap entity = await _unitOfWork.NhaCungCapRepository.GetByIdAsync(id);
                    result.TransactionResult = _mapper.Map<NhaCungCapDTO>(entity);
                }
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.UserMessage = string.Format(CommonMessages.MSG0002, ex.Message);
            }
            return result;
        }
        public async Task<ServiceResult> RemoveById(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                using (_unitOfWork)
                {
                    await _unitOfWork.NhaCungCapRepository.RemoveById(id);
                    await _unitOfWork.SaveAsync();
                    result.UserMessage = CommonMessages.MSG0001;
                }
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.UserMessage = string.Format(CommonMessages.MSG0002, ex.Message);
            }
            return result;
        }
        public async Task<ServiceResult> Update(NhaCungCapDTO model)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                using (_unitOfWork)
                {
                    Entity.NhaCungCap entity = await _unitOfWork.NhaCungCapRepository.GetByIdAsync(model.Id.Value);
                    if (entity != null)
                    {
                        _mapper.Map(model, entity);
                        _unitOfWork.NhaCungCapRepository.Update(entity);
                        await _unitOfWork.SaveAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.UserMessage = string.Format(CommonMessages.MSG0002, ex.Message);
            }
            return result;
        }
    }
}
