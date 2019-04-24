using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;
using AbidzarFrame.Utils;
using AbidzarFrame.Core.Model.Business;
using System.Data.SqlClient;
using Microsoft.Reporting.WebForms;
using System.Reflection;
using System.Web.Hosting;

namespace AbidzarFrame.Reports
{
    public class GlobalReport
    {
        private ErrorHandler _errHand;
        private FunctionLog _logger;
        private IDbConnFactory conFactory;

        public string pathRpt;
        //private IDbConnFactory conFactory;

        internal bool aa()
        {
            conFactory = new SqlDb();
            _errHand = new ErrorHandler();
            _logger = new FunctionLog();

            return true;

        }

        private IDbConnFactory _dbSql
        {
            get
            {
                conFactory = new SqlDb();
                return conFactory;
            }
        }

        
        #region Money Market Report
        public ActionResult MoneyMarketRpt(DataTable dtTablePrint, bool flagFrm, string dealNo, string maskLiq)
        {

            Microsoft.Reporting.WebForms.LocalReport lclReport = new Microsoft.Reporting.WebForms.LocalReport();
            Microsoft.Reporting.WebForms.ReportDataSource source;

            lclReport.ReportPath = "bin\\MoneyMarketReport\\RptMoneyMarket.rdlc";
            source = new Microsoft.Reporting.WebForms.ReportDataSource("DSMoneyMarket", dtTablePrint);
            lclReport.DataSources.Clear();

            //for parameter logo            
            string imgLogoPath = System.Web.HttpContext.Current.Server.MapPath("~/Content/Images/rpt_logo.jpg");
            lclReport.EnableExternalImages = true;
            lclReport.SetParameters(new ReportParameter("logo", imgLogoPath));

            lclReport.SetParameters(new ReportParameter("printed_on", "Printed on " + DateTime.Now + " by " + (string)System.Web.HttpContext.Current.Session["userId"]));

            lclReport.DataSources.Add(source);
            lclReport.Refresh();


            byte[] renderedBytes = null;
            System.IO.FileStream streamFile;
            Microsoft.Reporting.WebForms.Warning[] warnings = null;
            string[] streamids = null;
            string mimeType = null;
            string encoding = null;
            string extension = null;
            string DeviceInfo = (" <DeviceInfo> " + ("  <PageWidth>100%</PageWidth>" + ("  <PageHeight>21cm</PageHeight>" + ("  <MarginTop>1.0cm</MarginTop>" + ("  <MarginLeft>2.0cm</MarginLeft>" + ("  <MarginRight>1.0cm</MarginRight>" + ("  <MarginBottom>1.0cm</MarginBottom>" + "</DeviceInfo>")))))));

            renderedBytes = lclReport.Render("pdf", DeviceInfo, out mimeType, out encoding, out extension, out streamids, out warnings);

            object pathDestination = System.Web.HttpContext.Current.Server.MapPath("Report");
            string path_file = (pathDestination + ("\\" + dealNo + ".pdf"));


            streamFile = new System.IO.FileStream(path_file, System.IO.FileMode.Create);
            streamFile.Write(renderedBytes, 0, renderedBytes.Length);
            streamFile.Flush();
            streamFile.Dispose();
            streamFile.Close();

            pathRpt = path_file;

            return null;
        }

        public string GetPathReportDownload()
        {
            return pathRpt;
        }


        #endregion

    }
}
