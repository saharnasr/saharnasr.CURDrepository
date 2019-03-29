using ProductMangement.Models;
using ProductMangement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductMangement.Controllers
{
    public class ProductController : Controller
    {
        private IRepository<Product> _repository = null;
        public ProductController()
        {
            this._repository = new Repository<Product>();
        }

        public ActionResult Index()
        {
            var products = _repository.GetAll();
            return View(products);
        }
        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _repository.Insert(product);
                _repository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }

        [Authorize]
        public ActionResult Edit(int Id)
        {
            var product = _repository.GetById(Id);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(product);
                _repository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }

        public ActionResult Details(int Id)
        {
            var product = _repository.GetById(Id);
            return View(product);
        }
        [Authorize]
        public ActionResult Delete(int Id)
        {
            var product = _repository.GetById(Id);
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int Id)
        {
            var product = _repository.GetById(Id);
            _repository.Delete(Id);
            _repository.Save();
            return RedirectToAction("Index");
        }
    }
}