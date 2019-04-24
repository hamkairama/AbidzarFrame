using AbidzarFrame.Utils;
using System;
using AbidzarFrame.Core.Model.Business;
using System.Collections.Generic;
using AbidzarFrame.Core.Mvc.Helpers;
using AbidzarFrame.Questioner.Interface.Dto;
using AbidzarFrame.Questioner.Interface;
using AbidzarFrame.Questioner.Dao;
using System.Reflection;
using AbidzarFrame.Domain.Common;

namespace AbidzarFrame.Questioner.Manager
{
    public class QuestionerManager : IQuestionerManager
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

        protected PemiluDao _PemiluDao
        {
            get { return new PemiluDao(); }
        }

        protected DetailPemiluDao _DetailPemiluDao
        {
            get { return new DetailPemiluDao(); }
        }

        protected PollingPemiluDao _PollingPemiluDao
        {
            get { return new PollingPemiluDao(); }
        }

        protected TanyaRtDao _TanyaRtDao
        {
            get { return new TanyaRtDao(); }
        }

        protected TanyaRtDetailDao _TanyaRtDetailDao
        {
            get { return new TanyaRtDetailDao(); }
        }

        #endregion

        #region Implementation

        #region Pemilu
        public PemiluResponse GetPemiluFindBy(PemiluRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new PemiluResponse()
            {
                Errors = new BusinessErrors(),
                PemiluResult = new PemiluResult(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                PemiluResponse data = new PemiluResponse();
                var refData = data.PemiluResult;
                bussinessError.Add(_PemiluDao.GetPemiluFindBy(request, ref refData));
                response.PemiluResult = refData;
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

        public PemiluResponse GetPemiluList(PemiluRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new PemiluResponse()
            {
                Errors = new BusinessErrors(),
                PemiluResultList = new List<PemiluResult>(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                List<PemiluResult> refData = new List<PemiluResult>();
                bussinessError.Add(_PemiluDao.GetPemiluList(request, ref refData));
                response.PemiluResultList = refData;
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

        public PemiluResponse InsertPemilu(PemiluRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new PemiluResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_PemiluDao.InsertPemilu(request, ref result));
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

        public PemiluResponse UpdatePemilu(PemiluRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new PemiluResponse();

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_PemiluDao.UpdatePemilu(request, ref result));
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

        public PemiluResponse DeletePemilu(PemiluRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new PemiluResponse();

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_PemiluDao.DeletePemilu(request, ref result));
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

        #region DetailPemilu
        public DetailPemiluResponse GetDetailPemiluFindBy(DetailPemiluRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new DetailPemiluResponse()
            {
                Errors = new BusinessErrors(),
                DetailPemiluResult = new DetailPemiluResult(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                DetailPemiluResponse data = new DetailPemiluResponse();
                var refData = data.DetailPemiluResult;
                bussinessError.Add(_DetailPemiluDao.GetDetailPemiluFindBy(request, ref refData));
                response.DetailPemiluResult = refData;
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

        public DetailPemiluResponse GetDetailPemiluList(DetailPemiluRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new DetailPemiluResponse()
            {
                Errors = new BusinessErrors(),
                DetailPemiluResultList = new List<DetailPemiluResult>(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                List<DetailPemiluResult> refData = new List<DetailPemiluResult>();
                bussinessError.Add(_DetailPemiluDao.GetDetailPemiluList(ref refData));
                response.DetailPemiluResultList = refData;
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

        public DetailPemiluResponse GetDetailPemiluListByIdPemilu(DetailPemiluRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new DetailPemiluResponse()
            {
                Errors = new BusinessErrors(),
                DetailPemiluResultList = new List<DetailPemiluResult>(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                List<DetailPemiluResult> refData = new List<DetailPemiluResult>();
                bussinessError.Add(_DetailPemiluDao.GetDetailPemiluListByIdPemilu(request, ref refData));
                response.DetailPemiluResultList = refData;
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


        public DetailPemiluResponse InsertDetailPemilu(DetailPemiluRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new DetailPemiluResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_DetailPemiluDao.InsertDetailPemilu(request, ref result));
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

        public DetailPemiluResponse UpdateDetailPemilu(DetailPemiluRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new DetailPemiluResponse();

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_DetailPemiluDao.UpdateDetailPemilu(request, ref result));
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

        public DetailPemiluResponse DeleteDetailPemilu(DetailPemiluRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new DetailPemiluResponse();

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_DetailPemiluDao.DeleteDetailPemilu(request, ref result));
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

        #region PollingPemilu
        public PollingPemiluResponse GetPollingPemiluFindBy(PollingPemiluRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new PollingPemiluResponse()
            {
                Errors = new BusinessErrors(),
                PollingPemiluResult = new PollingPemiluResult(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                PollingPemiluResponse data = new PollingPemiluResponse();
                var refData = data.PollingPemiluResult;
                bussinessError.Add(_PollingPemiluDao.GetPollingPemiluFindBy(request, ref refData));
                response.PollingPemiluResult = refData;
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

        public PollingPemiluResponse GetPollingPemiluFindByNik(PollingPemiluRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new PollingPemiluResponse()
            {
                Errors = new BusinessErrors(),
                PollingPemiluResult = new PollingPemiluResult(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                PollingPemiluResponse data = new PollingPemiluResponse();
                var refData = data.PollingPemiluResult;
                bussinessError.Add(_PollingPemiluDao.GetPollingPemiluSelectByNik(request, ref refData));
                response.PollingPemiluResult = refData;
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
        
        public PollingPemiluResponse GetPollingPemiluList(PollingPemiluRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new PollingPemiluResponse()
            {
                Errors = new BusinessErrors(),
                PollingPemiluResultList = new List<PollingPemiluResult>(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                List<PollingPemiluResult> refData = new List<PollingPemiluResult>();
                bussinessError.Add(_PollingPemiluDao.GetPollingPemiluList(ref refData));
                response.PollingPemiluResultList = refData;
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

        public PollingPemiluResponse GetPollingPemiluListGrafik(PollingPemiluRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new PollingPemiluResponse()
            {
                Errors = new BusinessErrors(),
                PollingPemiluResultList = new List<PollingPemiluResult>(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                List<PollingPemiluResult> refData = new List<PollingPemiluResult>();
                bussinessError.Add(_PollingPemiluDao.GetPollingPemiluListGrafik(request, ref refData));
                response.PollingPemiluResultList = refData;
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
        
        public PollingPemiluResponse InsertPollingPemilu(PollingPemiluRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new PollingPemiluResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_PollingPemiluDao.InsertPollingPemilu(request, ref result));
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

        public PollingPemiluResponse UpdatePollingPemilu(PollingPemiluRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new PollingPemiluResponse();

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_PollingPemiluDao.UpdatePollingPemilu(request, ref result));
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

        public PollingPemiluResponse DeletePollingPemilu(PollingPemiluRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new PollingPemiluResponse();

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_PollingPemiluDao.DeletePollingPemilu(request, ref result));
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

        #region TanyaRt
        public TanyaRtResponse GetTanyaRtFindBy(TanyaRtRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new TanyaRtResponse()
            {
                Errors = new BusinessErrors(),
                TanyaRtResult = new TanyaRtResult(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                TanyaRtResponse data = new TanyaRtResponse();
                var refData = data.TanyaRtResult;
                bussinessError.Add(_TanyaRtDao.GetTanyaRtFindBy(request, ref refData));
                response.TanyaRtResult = refData;
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

        public TanyaRtResponse GetTanyaRtList(TanyaRtRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new TanyaRtResponse()
            {
                Errors = new BusinessErrors(),
                TanyaRtResultList = new List<TanyaRtResult>(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                List<TanyaRtResult> refData = new List<TanyaRtResult>();
                bussinessError.Add(_TanyaRtDao.GetTanyaRtList(request, ref refData));
                response.TanyaRtResultList = refData;
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

        public TanyaRtResponse TotalTanyaRtOutstanding(TanyaRtRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new TanyaRtResponse()
            {
                Errors = new BusinessErrors(),
                TanyaRtResultList = new List<TanyaRtResult>(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                int refData = 0;
                bussinessError.Add(_TanyaRtDao.TotalTanyaRtOutstanding(request, ref refData));
                response.Count = refData;
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

        public TanyaRtResponse GetTanyaRtListByNik(TanyaRtRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new TanyaRtResponse()
            {
                Errors = new BusinessErrors(),
                TanyaRtResultList = new List<TanyaRtResult>(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                List<TanyaRtResult> refData = new List<TanyaRtResult>();
                bussinessError.Add(_TanyaRtDao.GetTanyaRtListByNik(request, ref refData));
                response.TanyaRtResultList = refData;
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

        public TanyaRtResponse InsertTanyaRt(TanyaRtRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new TanyaRtResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_TanyaRtDao.InsertTanyaRt(request, ref result));
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

        public TanyaRtResponse UpdateTanyaRt(TanyaRtRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new TanyaRtResponse();

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_TanyaRtDao.UpdateTanyaRt(request, ref result));
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

        public TanyaRtResponse DeleteTanyaRt(TanyaRtRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new TanyaRtResponse();

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_TanyaRtDao.DeleteTanyaRt(request, ref result));
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

        #region TanyaRtDetail
        public TanyaRtDetailResponse GetTanyaRtDetailFindBy(TanyaRtDetailRequest request) 
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new TanyaRtDetailResponse()
            {
                Errors = new BusinessErrors(),
                TanyaRtDetailResult = new TanyaRtDetailResult(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                TanyaRtDetailResponse data = new TanyaRtDetailResponse();
                var refData = data.TanyaRtDetailResult;
                bussinessError.Add(_TanyaRtDetailDao.GetTanyaRtDetailFindBy(request, ref refData));
                response.TanyaRtDetailResult = refData;
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

        public TanyaRtDetailResponse GetTanyaRtDetailList(TanyaRtDetailRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new TanyaRtDetailResponse()
            {
                Errors = new BusinessErrors(),
                TanyaRtDetailResultList = new List<TanyaRtDetailResult>(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                List<TanyaRtDetailResult> refData = new List<TanyaRtDetailResult>();
                bussinessError.Add(_TanyaRtDetailDao.GetTanyaRtDetailList(ref refData));
                response.TanyaRtDetailResultList = refData;
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

        public TanyaRtDetailResponse GetTanyaRtDetailListByIdTanyaRt(TanyaRtDetailRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new TanyaRtDetailResponse()
            {
                Errors = new BusinessErrors(),
                TanyaRtDetailResultList = new List<TanyaRtDetailResult>(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                List<TanyaRtDetailResult> refData = new List<TanyaRtDetailResult>();
                bussinessError.Add(_TanyaRtDetailDao.GetTanyaRtDetailListByIdTanyaRt(request, ref refData));
                response.TanyaRtDetailResultList = refData;
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


        public TanyaRtDetailResponse InsertTanyaRtDetail(TanyaRtDetailRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new TanyaRtDetailResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_TanyaRtDetailDao.InsertTanyaRtDetail(request, ref result));
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

        public TanyaRtDetailResponse UpdateTanyaRtDetail(TanyaRtDetailRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new TanyaRtDetailResponse();

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_TanyaRtDetailDao.UpdateTanyaRtDetail(request, ref result));
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

        public TanyaRtDetailResponse DeleteTanyaRtDetail(TanyaRtDetailRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new TanyaRtDetailResponse();

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_TanyaRtDetailDao.DeleteTanyaRtDetail(request, ref result));
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
