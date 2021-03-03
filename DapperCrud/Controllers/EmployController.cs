using DapperCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;

namespace DapperCrud.Controllers
{
    public class EmployController : Controller
    {

        // GET: Employ
        public ActionResult Index()
        {
                return View(DapperORM.ReturList<EmployModel>("EmployViewAll", null)); 
        }
        [HttpGet]
        //For add URL is= ../Employ/AddOrEdit
        //for update URL is= ../Employ/AddOrEdit/id
        public ActionResult AddOrEdit(int id = 0) // view for insert and update method
        {
            if (id == 0)
            {
                return View();
            }
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@EmployID", id);
                try
                {
                    return View(DapperORM.ReturList<EmployModel>("EmployViewByID", param).FirstOrDefault<EmployModel>());
                }
                catch (Exception)
                {
                    
                    throw;
                }
                
            }
        }
        [HttpPost]
        public ActionResult AddOrEdit(EmployModel employModel)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@EmployID", employModel.EmployID);
            param.Add("@Name", employModel.Name);
            param.Add("@City", employModel.City);
            param.Add("@Age", employModel.Age);
            param.Add("@Salary", employModel.Salary);
            
            try
            {
                DapperORM.ExecuteWithoutReturn("EmployAddOrEdit", param);
            }
            catch (Exception)
            {
                
                throw;
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@EmployID", id);
            try
            {
                DapperORM.ExecuteWithoutReturn("[dbo].[EmployDeleteByID]", param);
            }
            catch (Exception)
            {

                throw;
            }
            
            return RedirectToAction("Index");
        }


    }
}