using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuanLyKho.Core.Service;
using QuanLyKho.Model.Service;
using QuanLyKho.Model.ViewModel.JsonResult;
using QuanLyKho.Model.ViewModel.KhuVucKhoTong;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using QuanLyKho.Model.Domain;
using QuanLyKho.Model.ViewModel.Product;
using Microsoft.AspNetCore.Mvc.Rendering;
using QuanLyKho.Service.KhoTong;

namespace QuanLyKho.Web.Controllers
{
    public class KhuVucKhoTongController : Controller
    {
        private readonly IKhuVucKhoTongService _KhuVucKhoTongService;
        private readonly IKhoTongService _KhoTongService;
        private readonly IMapper _mapper;

        public KhuVucKhoTongController(IKhuVucKhoTongService KhuVucKhoTongService,
            IKhoTongService KhoTongService,
                              IMapper mapper)
        {
            _KhuVucKhoTongService = KhuVucKhoTongService;
            _KhoTongService = KhoTongService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            SearchKhuVucKhoTongViewModel model = new SearchKhuVucKhoTongViewModel();
            model.KhoTongList = await GetKhoTongList();
            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            CreateKhuVucKhoTongViewModel model = new CreateKhuVucKhoTongViewModel();
            model.KhoTongList = await GetKhoTongList();
            return View(model);
        }




        [HttpPost]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Create(CreateKhuVucKhoTongViewModel model)
        {
            JsonResultModel jsonResultModel = new JsonResultModel();
            try
            {
                KhuVucKhoTongDTO KhuVucKhoTongDTO = _mapper.Map<KhuVucKhoTongDTO>(model);
                var serviceResult = await _KhuVucKhoTongService.AddAsync(KhuVucKhoTongDTO);
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

            var serviceResult = await _KhuVucKhoTongService.GetById(id);
            EditKhuVucKhoTongViewModel model = _mapper.Map<EditKhuVucKhoTongViewModel>(serviceResult.TransactionResult);
            model.KhoTongList = await GetKhoTongList();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Edit(EditKhuVucKhoTongViewModel model)
        {
            JsonResultModel jsonResultModel = new JsonResultModel();

            try
            {
                KhuVucKhoTongDTO KhuVucKhoTongDTO = _mapper.Map<KhuVucKhoTongDTO>(model);
                var serviceResult = await _KhuVucKhoTongService.Update(KhuVucKhoTongDTO);
                jsonResultModel = _mapper.Map<JsonResultModel>(serviceResult);
                if (jsonResultModel.IsSucceeded)
                {
                    jsonResultModel.IsRedirect = true;
                    jsonResultModel.RedirectUrl = "/KhuVucKhoTong";
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
        public async Task<IActionResult> List(SearchKhuVucKhoTongViewModel model)
        {
            JsonDataTableModel jsonDataTableModel = new JsonDataTableModel();

            try
            {
                KhuVucKhoTongDTO KhuVucKhoTongDTO = _mapper.Map<KhuVucKhoTongDTO>(model);
                ServiceResult<int> serviceCountResult = await _KhuVucKhoTongService.FindCount(KhuVucKhoTongDTO);
                ServiceResult<IEnumerable<KhuVucKhoTongDTO>> serviceListResult = await _KhuVucKhoTongService.Find(KhuVucKhoTongDTO);

                if (serviceCountResult.IsSucceeded && serviceListResult.IsSucceeded)
                {
                    List<ListKhuVucKhoTongViewModel> listVM = _mapper.Map<List<ListKhuVucKhoTongViewModel>>(serviceListResult.TransactionResult);
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
                ServiceResult serviceResult = await _KhuVucKhoTongService.RemoveById(id);
                jsonResultModel = _mapper.Map<JsonResultModel>(serviceResult);
            }
            catch (Exception ex)
            {
                jsonResultModel.IsSucceeded = false;
                jsonResultModel.UserMessage = ex.Message;
            }

            return Json(jsonResultModel);
        }

        private async Task<IEnumerable<SelectListItem>> GetKhoTongList()
        {
            ServiceResult<IEnumerable<KhoTongDTO>> serviceResult = await _KhoTongService.GetAll();
            IEnumerable<SelectListItem> drpKhoTongList = _mapper.Map<IEnumerable<SelectListItem>>(serviceResult.TransactionResult);
            return drpKhoTongList;
        }
    }
}
