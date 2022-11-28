using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuanLyKho.Core.Service;
using QuanLyKho.Model.Domain;
using QuanLyKho.Model.Service;
using QuanLyKho.Model.ViewModel.JsonResult;
using QuanLyKho.Model.ViewModel.KhoTong;
using QuanLyKho.Service.KhoTong;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace QuanLyKho.Web.Controllers
{
    public class KhoTongController : Controller
    {
        private readonly IKhoTongService _khoTongService;
        private readonly IMapper _mapper;

        public KhoTongController(IKhoTongService khoTongService,
                              IMapper mapper)
        {
            _khoTongService = khoTongService;
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
        public async Task<IActionResult> Create(CreateKhoTongViewModel model)
        {
            JsonResultModel jsonResultModel = new JsonResultModel();
            try
            {
                KhoTongDTO KhoTongDTO = _mapper.Map<KhoTongDTO>(model);
                var serviceResult = await _khoTongService.AddAsync(KhoTongDTO);
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
            var serviceResult = await _khoTongService.GetById(id);
            EditKhoTongViewModel model = _mapper.Map<EditKhoTongViewModel>(serviceResult.TransactionResult);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Edit(EditKhoTongViewModel model)
        {
            JsonResultModel jsonResultModel = new JsonResultModel();
            
            try
            {
                KhoTongDTO KhoTongDTO = _mapper.Map<KhoTongDTO>(model);
                var serviceResult = await _khoTongService.Update(KhoTongDTO);
                jsonResultModel = _mapper.Map<JsonResultModel>(serviceResult);
                if (jsonResultModel.IsSucceeded)
                {
                    jsonResultModel.IsRedirect = true;
                    jsonResultModel.RedirectUrl = "/KhoTong";
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
        public async Task<IActionResult> List(SearchKhoTongViewModel model)
        {
            JsonDataTableModel jsonDataTableModel = new JsonDataTableModel();
            
            try
            {
                KhoTongDTO KhoTongDTO = _mapper.Map<KhoTongDTO>(model);
                ServiceResult<int> serviceCountResult = await _khoTongService.FindCount(KhoTongDTO);
                ServiceResult<IEnumerable<KhoTongDTO>> serviceListResult = await _khoTongService.Find(KhoTongDTO);

                if (serviceCountResult.IsSucceeded && serviceListResult.IsSucceeded)
                {
                    List<ListKhoTongViewModel> listVM = _mapper.Map<List<ListKhoTongViewModel>>(serviceListResult.TransactionResult);
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
                ServiceResult serviceResult = await _khoTongService.RemoveById(id);
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
