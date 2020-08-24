﻿using FonNature.Filter;
using Models.Repository;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Models.Entity;
using PagedList;

namespace FonNature.Areas.Admin.Controllers
{
    public class DictionaryAdminController : Controller
    {
        private readonly IDictionaryRepository _repository;
        public DictionaryAdminController(IDictionaryRepository repository)
        {
            _repository = repository;
        }
        // GET: Admin/DictionaryAdmin
        public ActionResult Dictionaries(int? page, string searchString = null)
        {
            var dictionaries = _repository.GetDictionaries();

            if (!string.IsNullOrEmpty(searchString))
            {
                dictionaries = _repository.SearchDictionary(searchString);
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var pagedDictionaries = dictionaries.ToPagedList(pageNumber, pageSize);
            ViewBag.SearchString = searchString ?? string.Empty;
            return View(pagedDictionaries);
        }

        public ActionResult CreateDictionary()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateDictionary(Dictionary dictionary)
        {
            if(ModelState.IsValid)
            {
                var addedDictionary = _repository.AddDictionary(dictionary);
                if(addedDictionary == null)
                {
                    ModelState.AddModelError("","Không thể thêm dictionary vào cơ sở dữ liệu!") ;
                    return View(dictionary);
                }
                return RedirectToAction("Dictionaries");
            }
            return View(dictionary);
        }

        public ActionResult Edit(long id)
        {
            var dictionary = _repository.GetDictionary(id);
            if (dictionary == null) return RedirectToAction("Dictionaries");
            return View(dictionary);
        }

        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Edit(Dictionary dictionary)
        {
            if (ModelState.IsValid)
            {
                var dictionaryId = _repository.EditDictionary(dictionary);
                if (dictionaryId == 0) ModelState.AddModelError("", "Sửa dictionary không thành công !");
                return RedirectToAction("Dictionaries");
            }
            return View(dictionary);
        }

        [HttpDelete]
        public ActionResult Delete(long id)
        {
            _repository.RemoveDictionary(id);
            return RedirectToAction("Index");
        }
    }
}