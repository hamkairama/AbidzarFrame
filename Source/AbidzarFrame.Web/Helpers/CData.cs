using AbidzarFrame.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AbidzarFrame.Web.Helpers
{
    public class CData
    {
        //private variabel static
        #region private variabel static
        private static HttpPostedFileBase _getImageFile;
        private static IEnumerable<HttpPostedFileBase> _getImageFiles;
        private static byte[] _getImageByte;
        private static List<string> _listString;
        #endregion

        #region public Accessor
        public static ResultStatus DataImage(HttpPostedFileBase file)
        {
            CData._getImageFile = file;
            ResultStatus rs = new ResultStatus();

            try
            {
                if (file != null & file.ContentLength > 0)
                {
                    System.IO.BinaryReader xBytes = new System.IO.BinaryReader(file.InputStream);
                    CData._getImageByte = xBytes.ReadBytes(file.ContentLength);
                }
                rs.SetSuccessStatus();
            }
            catch (Exception ex)
            {
                rs.SetErrorStatus(ex.Message);
            }

            return rs;
        }
        public static void DataFiles(IEnumerable<HttpPostedFileBase> files)
        {
            CData._getImageFiles = files;
        }
        public static void DataString(string str)
        {
            try
            {
                List<string> lString = new List<string>();
                if (CData._listString != null)
                {
                    lString = CData._listString;
                }

                lString.Add(str);
                CData._listString = lString;
            }
            catch (Exception ex)
            {
                var e = ex.Message;
            }


        }

        #endregion

        #region public method
        public static HttpPostedFileBase GetImageFile
        {
            get
            {
                return CData._getImageFile;
            }
            set
            {
                CData._getImageFile = value;
            }
        }

        public static IEnumerable<HttpPostedFileBase> GetImageFiles
        {
            get
            {
                return CData._getImageFiles;
            }
            set
            {
                CData._getImageFiles = value;
            }
        }

        public static byte[] GetImageByte
        {
            get
            {
                return CData._getImageByte;
            }
            set
            {
                CData._getImageByte = value;
            }
        }


        public static void CleanDataImage()
        {
            CData._getImageByte = null;
        }

        public static void CleanDataImageFiles()
        {
            _getImageFiles = null;
        }
        public static List<string> GetListString
        {
            get
            {
                return CData._listString;
            }
            set
            {
                CData._listString = value;
            }
        }

        public static void ListStringRemoveOne(string str)
        {
            _listString.Remove(str);
        }

        public static void CleanDataString()
        {
            CData._listString = null;
        }
        #endregion



    }

}