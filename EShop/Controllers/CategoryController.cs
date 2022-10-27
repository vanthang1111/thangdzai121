using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EShop.Models;
using System.Data.Entity;


namespace EShop.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            //Truy Vấn Để Lấy Dữ Liệu Cho View
            // Tạo DB
            EShopEntities db = new EShopEntities();
            List<tb_Category> lst = db.tb_Category.ToList();

            return View(lst);
        }


        // Get: Add category
        public ActionResult Add()
        {
            return View();
        }

        //Post: Add to db
        [HttpPost]
        public ActionResult Add(tb_Category obj)
        {
            try
            {
                // B1: Tạo DBConText
                EShopEntities db = new EShopEntities();
                //Thực Hiện Truy Vấn
                db.tb_Category.Add(obj);
                db.SaveChanges();
                ViewBag.Message = "Thêm Mới Thành Công";
                //Quay về  Trang Index
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Message = "Thêm Mới Thất Bại";
            }

            return View();
        }
        /////////////////////////
        //Get: Update
        public ActionResult Update(int Id)
        {
            EShopEntities db = new EShopEntities();
            var obj = db.tb_Category.Find(Id);
            return View(obj);
        }

        //Cập Nhật Thông Tin
        [HttpPut]
        public ActionResult Update(tb_Category obj)
        {
            try
            {
                EShopEntities db = new EShopEntities();
                db.Entry(obj).State = EntityState.Modified;
                db.SaveChanges();
                ViewBag.Message = "Sửa Thành Công";
                //Quay về  Trang Index
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Message = "Sửa Thất Bại";
            }
            return View(obj);
        }

        /////////////////////////
        //Get: Delete
        public ActionResult Delete()
        {
            EShopEntities db = new EShopEntities();
            var obj = db.tb_Category;
            return View(obj);
        }

        //Xóa Thông Tin
        [HttpDelete]
        public ActionResult Delete(int Id)
        {
            try
            {
                EShopEntities db = new EShopEntities();
                var category = db.tb_Category.Find(Id);
                db.tb_Category.Remove(category);
                db.SaveChanges();
                ViewBag.Message = "Xóa Thành Công";
                //Quay về  Trang Index
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Message = "Xóa Thất Bại";
            }
            return View();
        }
    }
}