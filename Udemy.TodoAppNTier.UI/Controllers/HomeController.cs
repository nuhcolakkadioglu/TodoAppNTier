﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Udemy.TodoAppNTier.Business.Interfaces;
using Udemy.TodoAppNTier.Dtos.WorkDtos;

namespace Udemy.TodoAppNTier.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWorkService _workService;

        public HomeController(IWorkService workService)
        {
            _workService = workService;
        }
        
        public async Task<IActionResult> Index()
        {
    
            var workList = await _workService.GetAll();
            return View(workList);
        }
 
        public IActionResult Create()
        {
     
            return View(new WorkCreateDto());
        }
        [HttpPost]
        public async Task<IActionResult> Create(WorkCreateDto model)
        {

            if (ModelState.IsValid)
            {
                await _workService.Create(model);

                return RedirectToAction("Index");
            }
         
            return View(model);
        }

        public async Task<IActionResult> Update(int id)
        {
          var work=  await _workService.GetById<WorkUpdateDto>(id);

            return View(work);
        }
        [HttpPost]
        public IActionResult Update(WorkUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                var result = _workService.Update(model);
                return RedirectToAction("Index");
            }

           return View(model);
        }

        public async Task<IActionResult> Remove(int id)
        {
          await  _workService.Remove(id);
            return RedirectToAction("index");
        }

    }
}
