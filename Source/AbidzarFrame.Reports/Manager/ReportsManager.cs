using AbidzarFrame.Utils;
using System;
using AbidzarFrame.Core.Model.Business;
using System.Collections.Generic;
using AbidzarFrame.Core.Mvc.Helpers;
using AbidzarFrame.Reports.Interface.Dto;
using AbidzarFrame.Reports.Interface;
using AbidzarFrame.Master.Dao;
using System.Reflection;
using AbidzarFrame.Domain.Common;

namespace AbidzarFrame.Reports.Manager
{
    public class ReportsManager : IReportsManager
    {
        private const string _serviceName = "API_MasterServiceManager";
        private ResultStatus result = new ResultStatus();

        #region Instance
        protected ErrorHandler _errHand
        {
            get { return new ErrorHandler(); }
        }

        protected FunctionLog _functionLog
        {
            get { return new FunctionLog(); }
        }

        protected LaporanKasDao _LaporanKasDao
        {
            get { return new LaporanKasDao(); }
        }

        #endregion

        #region Implementation

        #region LaporanKas
        public LaporanKasResponse GetLaporanKasFindBy(LaporanKasRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new LaporanKasResponse()
            {
                Errors = new BusinessErrors(),
                LaporanKasResult = new LaporanKasResult(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                LaporanKasResponse data = new LaporanKasResponse();
                var refData = data.LaporanKasResult;
                bussinessError.Add(_LaporanKasDao.GetLaporanKasFindBy(request, ref refData));
                response.LaporanKasResult = refData;
            }
            catch (Exception ex)
            {
                _errHand.FillError(ex.Message, ref bussinessError);
            }
            finally
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.end);
            }
            response.Errors = bussinessError;
            return response;
        }

        public LaporanKasResponse GetLaporanKasList(LaporanKasRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new LaporanKasResponse()
            {
                Errors = new BusinessErrors(),
                LaporanKasResultList = new List<LaporanKasResult>(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                List<LaporanKasResult> refData = new List<LaporanKasResult>(); 
                bussinessError.Add(_LaporanKasDao.GetLaporanKasList(request, ref refData));
                response.LaporanKasResultList = refData;
                response.Count = refData.Count;
            }
            catch (Exception ex)
            {
                _errHand.FillError(ex.Message, ref bussinessError);
            }
            finally
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.end);
            }
            response.Errors = bussinessError;
            return response;
        }

        public LaporanKasResponse GetLaporanKasListByDate(LaporanKasRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new LaporanKasResponse()
            {
                Errors = new BusinessErrors(),
                LaporanKasResultList = new List<LaporanKasResult>(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                List<LaporanKasResult> refData = new List<LaporanKasResult>();
                bussinessError.Add(_LaporanKasDao.GetLaporanKasListByDate(request, ref refData));
                response.LaporanKasResultList = refData;
                response.Count = refData.Count;
            }
            catch (Exception ex)
            {
                _errHand.FillError(ex.Message, ref bussinessError);
            }
            finally
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.end);
            }
            response.Errors = bussinessError;
            return response;
        }

        public LaporanKasResponse GetLaporanKasListByYear(LaporanKasRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new LaporanKasResponse()
            {
                Errors = new BusinessErrors(),
                LaporanKasResultList = new List<LaporanKasResult>(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                List<LaporanKasResult> refData = new List<LaporanKasResult>();
                bussinessError.Add(_LaporanKasDao.GetLaporanKasListByYear(request, ref refData));
                response.LaporanKasResultList = refData;
                response.Count = refData.Count;
            }
            catch (Exception ex)
            {
                _errHand.FillError(ex.Message, ref bussinessError);
            }
            finally
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.end);
            }
            response.Errors = bussinessError;
            return response;
        }

        public LaporanKasResponse InsertLaporanKas(LaporanKasRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new LaporanKasResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_LaporanKasDao.InsertLaporanKas(request, ref result));
            }
            catch (Exception ex)
            {
                result.SetErrorStatus(ex.Message);
                _errHand.FillError(ex.Message, ref bussinessError);
            }
            finally
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.end);
            }
            response.Errors = bussinessError;
            response.ResultStatus = result;
            return response;
        }

        public LaporanKasResponse UpdateLaporanKas(LaporanKasRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new LaporanKasResponse();

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_LaporanKasDao.UpdateLaporanKas(request, ref result));
            }
            catch (Exception ex)
            {
                result.SetErrorStatus(ex.Message);
                _errHand.FillError(ex.Message, ref bussinessError);
            }
            finally
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.end);
            }
            response.Errors = bussinessError;
            response.ResultStatus = result;
            return response;
        }

        public LaporanKasResponse DeleteLaporanKas(LaporanKasRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new LaporanKasResponse();

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_LaporanKasDao.DeleteLaporanKas(request, ref result));
            }
            catch (Exception ex)
            {
                result.SetErrorStatus(ex.Message);
                _errHand.FillError(ex.Message, ref bussinessError);
            }
            finally
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.end);
            }
            response.Errors = bussinessError;
            response.ResultStatus = result;
            return response;
        }

        #endregion

        #endregion

    }
}
