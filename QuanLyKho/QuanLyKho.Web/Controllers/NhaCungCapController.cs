using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuanLyKho.Core.Service;
using QuanLyKho.Model.Domain;
using QuanLyKho.Model.ViewModel.JsonResult;
using QuanLyKho.Model.ViewModel.User;
using System.Threading.Tasks;
using System;
using QuanLyKho.Model.ViewModel.NhaCungCap;
using QuanLyKho.Service.NhaCungCap;
using QuanLyKho.Model.Service;
using System.Collections.Generic;

namespace QuanLyKho.Web.Controllers
{
    public class NhaCungCapController : Controller
    {
        private readonly INhaCungCapService _nhaCungCapService;
        private readonly IMapper _mapper;

        public NhaCungCapController(INhaCungCapService nhaCungCapService,
                              IMapper mapper)
        {
            _nhaCungCapService = nhaCungCapService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Create(CreateNhaCungCapViewModel model)
        {
            JsonResultModel jsonResultModel = new JsonResultModel();
            try
            {
                NhaCungCapDTO nhaCungCapDTO = _mapper.Map<NhaCungCapDTO>(model);
                var serviceResult = await _nhaCungCapService.AddAsync(nhaCungCapDTO);
                jsonResultModel = _mapper.Map<JsonResultModel>(serviceResult);
            }
            catch (Exception ex)
            {
                jsonResultModel.IsSucceeded = false;
                jsonResultModel.UserMessage = ex.Message;
            }
            return Json(jsonResultModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var serviceResult = await _nhaCungCapService.GetById(id);
            EditNhaCungCapViewModel model = _mapper.Map<EditNhaCungCapViewModel>(serviceResult.TransactionResult);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Edit(EditNhaCungCapViewModel model)
        {
            JsonResultModel jsonResultModel = new JsonResultModel();
            try
            {
                NhaCungCapDTO NhaCungCapDTO = _mapper.Map<NhaCungCapDTO>(model);
                var serviceResult = await _nhaCungCapService.Update(NhaCungCapDTO);
                jsonResultModel = _mapper.Map<JsonResultModel>(serviceResult);
                if (jsonResultModel.IsSucceeded)
                {
                    jsonResultModel.IsRedirect = true;
                    jsonResultModel.RedirectUrl = "/NhaCungCap";
                }
            }
            catch (Exception ex)
            {
                jsonResultModel.IsSucceeded = false;
                jsonResultModel.UserMessage = ex.Message;
            }
            return Json(jsonResultModel);
        }

        [HttpGet]
        public async Task<IActionResult> List(SearchNhaCungCapViewModel model)
        {
            JsonDataTableModel jsonDataTableModel = new JsonDataTableModel();
            try
            {
                NhaCungCapDTO NhaCungCapDTO = _mapper.Map<NhaCungCapDTO>(model);
                ServiceResult<int> serviceCountResult = await _nhaCungCapService.FindCount(NhaCungCapDTO);
                ServiceResult<IEnumerable<NhaCungCapDTO>> serviceListResult = await _nhaCungCapService.Find(NhaCungCapDTO);

                if (serviceCountResult.IsSucceeded && serviceListResult.IsSucceeded)
                {
                    List<ListNhaCungCapViewModel> listVM = _mapper.Map<List<ListNhaCungCapViewModel>>(serviceListResult.TransactionResult);
                    jsonDataTableModel.aaData = listVM;
                    jsonDataTableModel.iTotalDisplayRecords = serviceCountResult.TransactionResult;
                    jsonDataTableModel.iTotalRecords = serviceCountResult.TransactionResult;
                }
                else
                {
                    jsonDataTableModel.IsSucceeded = false;
                    jsonDataTableModel.UserMessage = serviceCountResult.UserMessage + "-" + serviceListResult.UserMessage;
                }
            }
            catch (Exception ex)
            {
                jsonDataTableModel.IsSucceeded = false;
                jsonDataTableModel.UserMessage = ex.Message;
            }

            return Json(jsonDataTableModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            JsonResultModel jsonResultModel = new JsonResultModel();
            try
            {
                ServiceResult serviceResult = await _nhaCungCapService.RemoveById(id);
                jsonResultModel = _mapper.Map<JsonResultModel>(serviceResult);
            }
            catch (Exception ex)
            {
                jsonResultModel.IsSucceeded = false;
                jsonResultModel.UserMessage = ex.Message;
            }
            return Json(jsonResultModel);
        }
    }
}
