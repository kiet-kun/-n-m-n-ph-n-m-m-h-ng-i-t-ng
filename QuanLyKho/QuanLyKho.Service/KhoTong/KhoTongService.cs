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

namespace QuanLyKho.Service.KhoTong
{
    public class KhoTongService : BaseService, IKhoTongService
    {
        public KhoTongService(IUnitOfWorks unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<ServiceResult> AddAsync(KhoTongDTO model)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                using (_unitOfWork)
                {
                    Entity.KhoTong entity = _mapper.Map<Data.Entity.KhoTong>(model);
                    entity.CreateDate = DateTime.Now;
                    await _unitOfWork.KhoTongRepository.AddAsync(entity);
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

        public async Task<ServiceResult<IEnumerable<KhoTongDTO>>> Find(KhoTongDTO criteria)
        {
            ServiceResult<IEnumerable<KhoTongDTO>> result = new ServiceResult<IEnumerable<KhoTongDTO>>();
            try
            {
                using (_unitOfWork)
                {
                    IEnumerable<Entity.KhoTong> list = await _unitOfWork
                                                                   .KhoTongRepository

                                                                   .FindAsync(filter: x => (string.IsNullOrEmpty(criteria.ten)
                                                                                    || x.ten.Contains(criteria.ten)),

                                                                           orderByDesc: x => x.Id,
                                                                           skip: criteria.PageNumber,
                                                                           take: criteria.RecordCount);

                    result.TransactionResult = _mapper.Map<IEnumerable<KhoTongDTO>>(list);
                }
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.UserMessage = string.Format(CommonMessages.MSG0002, ex.Message);
            }
            return result;
        }

        public async Task<ServiceResult<int>> FindCount(KhoTongDTO criteria)
        {
            ServiceResult<int> result = new ServiceResult<int>();
            try
            {
                using (_unitOfWork)
                {
                    int count = await _unitOfWork.KhoTongRepository


                                                  .FindCountAsync(filter: x => (string.IsNullOrEmpty(criteria.ten) || x.ten.Contains(criteria.ten))

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
        public async Task<ServiceResult<IEnumerable<KhoTongDTO>>> GetAll()
        {
            ServiceResult<IEnumerable<KhoTongDTO>> result = new ServiceResult<IEnumerable<KhoTongDTO>>();
            try
            {
                using (_unitOfWork)
                {
                    IEnumerable<Entity.KhoTong> list = await _unitOfWork.KhoTongRepository.GetAllAsync();
                    result.TransactionResult = _mapper.Map<IEnumerable<KhoTongDTO>>(list);
                }
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.UserMessage = string.Format(CommonMessages.MSG0002, ex.Message);
            }

            return result;
        }
        public async Task<ServiceResult<KhoTongDTO>> GetById(int id)
        {
            ServiceResult<KhoTongDTO> result = new ServiceResult<KhoTongDTO>();
            try
            {
                using (_unitOfWork)
                {
                    Entity.KhoTong entity = await _unitOfWork.KhoTongRepository.GetByIdAsync(id);
                    result.TransactionResult = _mapper.Map<KhoTongDTO>(entity);
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
                    await _unitOfWork.KhoTongRepository.RemoveById(id);
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
        public async Task<ServiceResult> Update(KhoTongDTO model)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                using (_unitOfWork)
                {
                    Entity.KhoTong entity = await _unitOfWork.KhoTongRepository.GetByIdAsync(model.Id.Value);
                    if (entity != null)
                    {
                        _mapper.Map(model, entity);
                        _unitOfWork.KhoTongRepository.Update(entity);
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
