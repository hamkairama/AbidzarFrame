using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbidzarFrame.Core.Mvc.Helpers;
using AbidzarFrame.Core.Mvc.Models;
using AbidzarFrame.Core.Mvc.Controllers;
using System.IO;

namespace AbidzarFrame.Core.Mvc.Views
{
    public class EnhancedViewPage : System.Web.Mvc.ViewPage
    {

        private static EnhancedViewPage instance = null;
        //private static readonly String DECIMAL_FORMAT_DEFINITION = "__DECIMAL_FORMAT_DEFINITION";
        //private static readonly String TERM_DEFINITIONS = "__TERM_DEFINITIONS";

        private static String _init = "N";
        private static Dictionary<String, BusinessTerm> termDefinitions = null;
        private static Dictionary<String, IDecimalFormatter> decimalFormatters = null;
        private static EnhancedViewPage _singleton = null;

        public EnhancedViewPage()
            : base()
        {
            if (!HasTerm())
            {
                lock (_init)
                {
                    if (!HasTerm())
                    {
                        try
                        {
                            SaveTermFileDefinitions();
                        }
                        catch (Exception e)
                        {
                            throw new Exception("Error in reading BusinessTerm.dat (" + e.Message + ")");
                        }
                        AddBusinessTermDictionaries(DefineTerms());

                        _singleton = this;
                    }
                }
            }
            Initialize();
        }
        
        public static EnhancedViewPage GetInstance()
        {
            if (_singleton == null)
                _singleton = new EnhancedViewPage();

            return _singleton;
        }

        public virtual void Initialize()
        {
            // To be overrided by child class
        }

        public Errors Errors
        {
            get
            {
                return (Errors)Session[ErrorResult.SEARCH_RESULT];
            }
        }

        protected string CurrentSystemLanguage
        {
            get
            {
                return (string)Session[EnhancedViewEngine.SYSTEM_LANGUAGE];
            }
        }

        public virtual BusinessTerm[] DefineTerms()
        {
            // to be overrided by child class
            return new BusinessTerm[] { };
        }

        #region "Term Dictionary and Term Translation Logics"

        private Dictionary<String, BusinessTerm> GetTermDictionary(Boolean autoCreate)
        {
            //Dictionary<String, Dictionary<String, BusinessTerm>> termTableDictionary = (Dictionary<String, Dictionary<String, BusinessTerm>>)Session[EnhancedViewPage.TERM_DEFINITIONS];
            //if (termTableDictionary == null)
            //{
            //    termTableDictionary = new Dictionary<String, Dictionary<String, BusinessTerm>>();
            //    Application[EnhancedViewPage.TERM_DEFINITIONS] = termTableDictionary;
            //}

            //Dictionary<String, BusinessTerm> termTable = null;
            //String k = this.GetType().FullName;
            //if (k != null)
            //{
            //    if (!termTableDictionary.ContainsKey(k))
            //    {
            //        if (autoCreate)
            //        {
            //            termTable = new Dictionary<String, BusinessTerm>();
            //            termTableDictionary.Add(k, termTable);
            //        }
            //    }
            //    else
            //    {
            //        termTable = termTableDictionary[k];
            //    }
            //}
            //return termTable;

            if (autoCreate)
            {
                if (termDefinitions == null)
                {
                    termDefinitions = new Dictionary<string, BusinessTerm>();
                }
            }

            return termDefinitions;
        }

        public void AddBusinessTermDictionaries(BusinessTerm[] terms)
        {
            Dictionary<String, BusinessTerm> termDictionary = GetTermDictionary(true);
            foreach (BusinessTerm term in terms)
            {
                if (termDictionary.ContainsKey(term.TermName))
                    termDictionary[term.TermName].AddValueDescriptions(term);
                else
                    termDictionary.Add(term.TermName, (BusinessTerm)term.Clone());
            }
            _init = "Y";
        }

        public Boolean HasTerm()
        {
            //return (GetTermDictionary(false) != null);
            return _init.Equals("Y");
        }

        public virtual String Translate(String dataField, String value, String defaultValue = null)
        {
            String languageCode = (String)Session[EnhancedViewEngine.SYSTEM_LANGUAGE];

            Dictionary<String, BusinessTerm> termDictionary = GetTermDictionary(false);
            if (termDictionary != null)
            {
                if (termDictionary.ContainsKey(dataField))
                {
                    String desc = termDictionary[dataField].GetDescription(value, languageCode, defaultValue);
                    return desc;
                }
            }

            return defaultValue;
        }

        protected virtual void SaveTermFileDefinitions()
        {
            List<BusinessTerm> terms = ReadTermDefintions();
            AddBusinessTermDictionaries(terms.ToArray());
        }

        protected virtual List<BusinessTerm> ReadTermDefintions()
        {
            String _file = ApplicationSetting.GetInstance().BusinessTermFile;

            List<BusinessTerm> _terms = new List<BusinessTerm>();
            FileStream _fileStream = null;

            try
            {
                _fileStream = new FileStream(_file, FileMode.Open);
                IBusinessTermReader reader = new BusinessTermReader(_fileStream);
                while (reader.Next())
                {
                    _terms.Add(reader.GetBusinessTerm());
                }
            }
            catch (Exception e)
            {
                Logger.GetInstance().WriteLogData(
                        new LogData(LogData.STAGE.error, "", "", "", "", DateTime.Now,
                        Session.SessionID, e.Message, ""), 1, LogData.LOG_TYPE.data);
            }
            finally
            {
                if (_fileStream != null) _fileStream.Close();
            }
            return _terms;
        }
        //
        #endregion

        #region "Data Formatting Logics (Decimal Values Only)"
        //
        private Dictionary<String, IDecimalFormatter> GetDecimalFormatSetting(Boolean autoCreate)
        {
            
            //Dictionary<String, IDecimalFormatter> setting = (Dictionary<String, IDecimalFormatter>)Session[EnhancedViewPage.DECIMAL_FORMAT_DEFINITION];
            //if (setting == null && autoCreate)
            //{
            //    setting = new Dictionary<String, IDecimalFormatter>();
            //}
            //return setting;
            if (autoCreate)
            {
                if (decimalFormatters == null)
                {
                    decimalFormatters = new Dictionary<string, IDecimalFormatter>();
                }
            }
            return decimalFormatters;
        }

        private void SetDecimalFormatSetting(Dictionary<String, IDecimalFormatter>  settings)
        {
            //Session[EnhancedViewPage.DECIMAL_FORMAT_DEFINITION] = settings;
            decimalFormatters = settings;
        }

        public void AddDecimalFormatter(String languageCode, IDecimalFormatter formatter)
        {
            try
            {
                Dictionary<String, IDecimalFormatter> setting = GetDecimalFormatSetting(true);
                if (setting == null)
                {
                    setting = new Dictionary<String, IDecimalFormatter>();
                }
                if (setting.ContainsKey(languageCode))
                    setting[languageCode] = formatter;
                else
                    setting.Add(languageCode, formatter);
                SetDecimalFormatSetting(setting);
            }
            catch (Exception e)
            {
                Logger.GetInstance().WriteLogData(new LogData(LogData.STAGE.error, "", "Initing FormatDecimal", "", "", DateTime.Now , 
                        Session.SessionID, "Error: " + e.Message, ""), 0, LogData.LOG_TYPE.data);
            }

        }

        public virtual String FormatDecimal(Decimal value)
        {
            String formatResult = "";
            try {
                Dictionary<String, IDecimalFormatter> setting = GetDecimalFormatSetting(false);
                if (setting != null)
                {
                    String language = (String)Session[EnhancedViewEngine.SYSTEM_LANGUAGE];
                    IDecimalFormatter formatter = setting[language];
                    //formatResult = formatter.format(value);
                    formatResult = FormatDecimal(value, formatter);
                }
                else
                {
                    formatResult = value.ToString();
                }
            } catch (Exception e) {
                Logger.GetInstance().WriteLogData(new LogData(LogData.STAGE.error, "", "FormatDecimal", "", "", DateTime.Now, Session.SessionID, 
                        "Error: " + e.Message, ""), 0, LogData.LOG_TYPE.data);
                formatResult = value.ToString();
            }
            return formatResult;
        }

        public virtual String FormatDecimal(Decimal value, IDecimalFormatter formatter)
        {
            try
            {
                return formatter.format(value);
            }
            catch (Exception e)
            {
                Logger.GetInstance().WriteLogData(new LogData(LogData.STAGE.error, "", "FormatDecimal(value, formatter)", "", "", DateTime.Now, Session.SessionID,
                        "Error: " + e.Message, ""), 0, LogData.LOG_TYPE.data);
                return value.ToString();
            }
        }

        //
        #endregion 

    }
}
