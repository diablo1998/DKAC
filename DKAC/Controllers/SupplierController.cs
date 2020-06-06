using DKAC.Common;
using DKAC.Models.EntityModel;
using DKAC.Models.InfoModel;
using DKAC.Models.RequestModel;
using DKAC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DKAC.Controllers
{
    public class SupplierController : BaseController
    {
        SupplierRepository _supRepo = new SupplierRepository();

        // GET: Supplier
        public ActionResult Index(string KeySearch, int page = 1, int pageSize = 10)
        {
            SupplierRequestModel model = new SupplierRequestModel();
            model = _supRepo.GetAllSupplier(KeySearch, page, pageSize);
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            Supplier sup = _supRepo.GetById(id);
            SupplierInfo supInfo = new SupplierInfo()
            {
                id = sup.id,
                SupplierCode = sup.SupplierCode,
                SupplierName = sup.SupplierName,
                Address = sup.Address,
                Tel = sup.Tel,
            };
            return View("Edit", supInfo);
        }

        public ActionResult Add(SupplierInfo model)
        {
            Employee em = (Employee)Session[CommonConstants.USER_SESSION];
            model.CreatedBy = em.id;
            model.ModifyBy = em.id;
            model.SupplierCode = model.SupplierCode.ToUpper(); //Chuyển trường mã thành dạng chữ in hoa
            var result = _supRepo.Add(model);
            if (result == 1)
            {
                return Json(new { status = 1, message = "Thêm thành công"}, JsonRequestBehavior.AllowGet);
            }
            return Json(new { status = 0, message = "Thêm thất bại" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Update(SupplierInfo model)
        {
            Employee em = (Employee)Session[CommonConstants.USER_SESSION];
            model.ModifyBy = em.id;
            model.SupplierCode = model.SupplierCode.ToUpper(); //Chuyển trường mã thành dạng chữ in hoa
            var result = _supRepo.Update(model);
            if (result == 1)
            {
                return Json(new { status = 1, message = "Cập nhật thành công" }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { status = 0, message = "Cập nhật thất bại" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int id)
        {
            Employee em = (Employee)Session[CommonConstants.USER_SESSION];
            var sup = _supRepo.GetById(id);
            sup.ModifyBy = em.id;
            var result = _supRepo.Delete(sup);
            if (result == 1)
            {
                return Json(new { status = 1, message = "Xóa thành công" }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { status = 1, message = "Xóa thất bại" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CheckDuplicatedCode(string SupplierCode, int id)
        {
            var result = _supRepo.GetByCodeId(SupplierCode, id);
            if (result != null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}