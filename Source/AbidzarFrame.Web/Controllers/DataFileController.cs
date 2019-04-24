using AbidzarFrame.Domain.Common;
using AbidzarFrame.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AbidzarFrame.Web.Controllers
{
    public class DataFileController : Controller
    {
        ResultStatus rs = new ResultStatus();
        //INews repo;
        public DataFileController()
        {
            //repo = new NewsRepo();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }


        public void SaveDataFile(HttpPostedFileBase file)
        {
            ResultStatus rs = new ResultStatus();
            rs.SetSuccessStatus();
            if (file != null)
            {
                try
                {
                    string physicalPath = "";
                    string ImageName = System.IO.Path.GetFileName(file.FileName);
                    physicalPath = Server.MapPath("~" + FileConfiguration.GetInstance().ConfigFilePath + ImageName);

                    file.SaveAs(physicalPath);
                    CData.DataString(FileConfiguration.GetInstance().ConfigFilePath + ImageName);

                }
                catch (Exception ex)
                {
                    rs.SetErrorStatus(ex.Message);
                }
            }
        }

        public void DeleteDataFile(HttpPostedFileBase file)
        {
            ResultStatus rs = new ResultStatus();
            rs.SetSuccessStatus();
            if (file != null)
            {
                try
                {
                    string physicalPath = "";
                    string ImageName = System.IO.Path.GetFileName(file.FileName);
                    physicalPath = Server.MapPath("~" + FileConfiguration.GetInstance().ConfigFilePath + ImageName);

                    System.IO.File.Delete(physicalPath);

                }
                catch (Exception ex)
                {
                    rs.SetErrorStatus(ex.Message);
                }
            }
        }



    }
}