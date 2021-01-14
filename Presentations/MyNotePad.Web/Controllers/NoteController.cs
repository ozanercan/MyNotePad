using Microsoft.AspNetCore.Mvc;
using MyNotePad.ClientBusiness.Abstract;
using MyNotePad.ClientBusiness.Concrete;
using MyNotePad.Web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyNotePad.Web.Controllers
{
    [Controller]
    public class NoteController : Controller
    {
        IWebApiService webApiService = new WebApiManager();

        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            var noteResult = await webApiService.GetNoteDtosAsync();
            var viewModel = new NoteIndexViewModel() { NoteDtos = noteResult.Data };
            ViewData["Notes"] = JsonConvert.SerializeObject(viewModel.NoteDtos);
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateAsync(NoteCreateViewModel noteCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                var createResult = await webApiService.CreateAsync(noteCreateViewModel.NoteCreateDto);
                ViewBag.Alert = createResult.Message;
            }
            else
            {
                ViewBag.Alert = "Lütfen Tüm Alanlara En Az 3 Karakter Girin!";
            }
            
            return View();
        }
    }
}
