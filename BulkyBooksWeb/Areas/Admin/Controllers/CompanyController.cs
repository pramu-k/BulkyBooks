using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Bulky.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBooksWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CompanyController:Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CompanyController(IWebHostEnvironment webHostEnvironment,IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

         public IActionResult Index()
        {
            List<Company> objCompanyList = _unitOfWork.CompanyRepository.GetAll().ToList();
            return View(objCompanyList);
        }

        public IActionResult Upsert(int? id) 
        {
            if (id==null || id==0)
            {
                return View(new Company());
            }
            else
            {
                Company companyObj = _unitOfWork.CompanyRepository.Get(u => u.Id == id);
                return View(companyObj);
            }

        }
        [HttpPost]
        public IActionResult Upsert(Company companyObj)
        {
            if (ModelState.IsValid)
            {
                
                if (companyObj.Id==0)
                {
                    _unitOfWork.CompanyRepository.Add(companyObj);
                }
                else
                {
                    _unitOfWork.CompanyRepository.Update(companyObj);
                }

                _unitOfWork.Save();
                TempData["success"] = "Company added successfully";
                return RedirectToAction("Index","Company");
            }
            else
            {
                return View(companyObj);
            }
            
        }


        //public IActionResult Delete(int? id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }
        //    Company? companyFromDb = _unitOfWork.CompanyRepository.Get(u => u.Id == id);

        //    if (companyFromDb == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(companyFromDb);
        //}

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeletePost(int id)
        {
            Company? companyFromDb = _unitOfWork.CompanyRepository.Get(u => u.Id == id);
            if (companyFromDb!=null)
            {
                _unitOfWork.CompanyRepository.Remove(companyFromDb);
                _unitOfWork.Save();
                TempData["success"] = "Company deleted successfully!";
                return RedirectToAction("Index", "Company");
            }
            return NotFound();
        }

        #region API Calls

        [HttpGet]
        public IActionResult GetAll() 
        {
            List<Company> objCompanyList = _unitOfWork.CompanyRepository.GetAll().ToList();
            return Json(new {data =  objCompanyList});
        }
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            Company? companyToBeDeleted = _unitOfWork.CompanyRepository.Get(u => u.Id == id);
            if (companyToBeDeleted != null)
            {
                _unitOfWork.CompanyRepository.Remove(companyToBeDeleted);
                _unitOfWork.Save();
                TempData["success"] = "Company deleted successfully!";
                List<Company> objCompanyList = _unitOfWork.CompanyRepository.GetAll(includeProperties: "Category").ToList();
                return Json(new { success = true, message = "Company Successfully Deleted!" });
            }
            else
            {
                return Json(new {success = false,message = "Error while deleting"});
            }
            
            
        }
        #endregion
    }
}
