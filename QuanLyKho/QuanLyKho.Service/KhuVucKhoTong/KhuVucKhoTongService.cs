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
namespace QuanLyKho.Service.KhuVucKhoTong
{
    public class KhuVucKhoTongService : BaseService, IKhuVucKhoTongService
    {
        public KhuVucKhoTongService(IUnitOfWorks unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<ServiceResult> AddAsync(KhuVucKhoTongDTO model)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                using (_unitOfWork)
                {
                    Entity.KhuVucKhoTong entity = _mapper.Map<Data.Entity.KhuVucKhoTong>(model);
                    entity.CreateDate = DateTime.Now;
                    await _unitOfWork.KhuVucKhoTongRepository.AddAsync(entity);
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

        public async Task<ServiceResult<IEnumerable<KhuVucKhoTongDTO>>> Find(KhuVucKhoTongDTO criteria)
        {
            ServiceResult<IEnumerable<KhuVucKhoTongDTO>> result = new ServiceResult<IEnumerable<KhuVucKhoTongDTO>>();
            try
            {
                using (_unitOfWork)
                {
                    IEnumerable<Entity.KhuVucKhoTong> list = await _unitOfWork
                                                                   .KhuVucKhoTongRepository

                                                                   .FindAsync(filter: x => (((string.IsNullOrEmpty(criteria.ten)
                                                                                    || x.ten.Contains(criteria.ten))
                                                                        && (criteria.KhoTongId == null || x.KhoTongId == criteria.KhoTongId))

                                                                          ),
                                                                          includes: new List<string>() { "KhoTong"},
                                                                           orderByDesc: x => x.Id,
                                                                           skip: criteria.PageNumber,
                                                                           take: criteria.RecordCount);

                    result.TransactionResult = _mapper.Map<IEnumerable<KhuVucKhoTongDTO>>(list);
                }
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.UserMessage = string.Format(CommonMessages.MSG0002, ex.Message);
            }
            return result;
        }

        public async Task<ServiceResult<int>> FindCount(KhuVucKhoTongDTO criteria)
        {
            ServiceResult<int> result = new ServiceResult<int>();
            try
            {
                using (_unitOfWork)
                {
                    int count = await _unitOfWork.KhuVucKhoTongRepository


                                                  .FindCountAsync(filter: x => (string.IsNullOrEmpty(criteria.ten) || x.ten.Contains(criteria.ten))
                                                    && (criteria.KhoTongId == null || x.KhoTongId == criteria.KhoTongId)
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
        public async Task<ServiceResult<IEnumerable<KhuVucKhoTongDTO>>> GetAll()
        {
            ServiceResult<IEnumerable<KhuVucKhoTongDTO>> result = new ServiceResult<IEnumerable<KhuVucKhoTongDTO>>();
            try
            {
                using (_unitOfWork)
                {
                    IEnumerable<Entity.KhuVucKhoTong> list = await _unitOfWork.KhuVucKhoTongRepository.GetAllAsync();
                    result.TransactionResult = _mapper.Map<IEnumerable<KhuVucKhoTongDTO>>(list);
                }
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.UserMessage = string.Format(CommonMessages.MSG0002, ex.Message);
            }

            return result;
        }
        public async Task<ServiceResult<KhuVucKhoTongDTO>> GetById(int id)
        {
            ServiceResult<KhuVucKhoTongDTO> result = new ServiceResult<KhuVucKhoTongDTO>();
            try
            {
                using (_unitOfWork)
                {
                    Entity.KhuVucKhoTong entity = await _unitOfWork.KhuVucKhoTongRepository.GetByIdAsync(id);
                    result.TransactionResult = _mapper.Map<KhuVucKhoTongDTO>(entity);
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
                    await _unitOfWork.KhuVucKhoTongRepository.RemoveById(id);
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
        public async Task<ServiceResult> Update(KhuVucKhoTongDTO model)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                using (_unitOfWork)
                {
                    Entity.KhuVucKhoTong entity = await _unitOfWork.KhuVucKhoTongRepository.GetByIdAsync(model.Id.Value);
                    if (entity != null)
                    {
                        _mapper.Map(model, entity);
                        _unitOfWork.KhuVucKhoTongRepository.Update(entity);
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
