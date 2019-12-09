using AbidzarFrame.Utils;
using System;
using AbidzarFrame.Core.Model.Business;
using System.Collections.Generic;
using AbidzarFrame.Core.Mvc.Helpers;
using AbidzarFrame.Master.Interface.Dto;
using AbidzarFrame.Master.Interface;
using AbidzarFrame.Master.Dao;
using System.Reflection;
using AbidzarFrame.Domain.Common;

namespace AbidzarFrame.Master.Manager
{
    public class MasterManager : IMasterManager
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

        protected AgamaDao _AgamaDao
        {
            get { return new AgamaDao(); }
        }

        protected DetailJenisInformasiDao _DetailJenisInformasiDao
        {
            get { return new DetailJenisInformasiDao(); }
        }

        protected DetailJenisKegiatanDao _DetailJenisKegiatanDao
        {
            get { return new DetailJenisKegiatanDao(); }
        }

        protected DokumentasiDetailJenisKegiatanDao _DokumentasiDetailJenisKegiatanDao
        {
            get { return new DokumentasiDetailJenisKegiatanDao(); }
        }

        protected GolonganDarahDao _GolonganDarahDao
        {
            get { return new GolonganDarahDao(); }
        }

        protected JabatanDao _JabatanDao
        {
            get { return new JabatanDao(); }
        }

        protected JenisInformasiDao _JenisInformasiDao
        {
            get { return new JenisInformasiDao(); }
        }

        protected JenisKegiatanDao _JenisKegiatanDao
        {
            get { return new JenisKegiatanDao(); }
        }

        protected JenisKelaminDao _JenisKelaminDao
        {
            get { return new JenisKelaminDao(); }
        }

        protected JenisPekerjaanDao _JenisPekerjaanDao
        {
            get { return new JenisPekerjaanDao(); }
        }

        protected KecamatanDao _KecamatanDao
        {
            get { return new KecamatanDao(); }
        }

        protected KelurahanDao _KelurahanDao
        {
            get { return new KelurahanDao(); }
        }

        protected KewarganegaraanDao _KewarganegaraanDao
        {
            get { return new KewarganegaraanDao(); }
        }

        protected KotaDao _KotaDao
        {
            get { return new KotaDao(); }
        }

        protected KtpDao _KtpDao
        {
            get { return new KtpDao(); }
        }


        protected PendidikanDao _PendidikanDao
        {
            get { return new PendidikanDao(); }
        }

        protected ProvinsiDao _ProvinsiDao
        {
            get { return new ProvinsiDao(); }
        }

        protected SignatureKtpDao _SignatureKtpDao
        {
            get { return new SignatureKtpDao(); }
        }

        protected StatusPerkawinanDao _StatusPerkawinanDao
        {
            get { return new StatusPerkawinanDao(); }
        }

        protected StrukturDao _StrukturDao
        {
            get { return new StrukturDao(); }
        }

        protected PhotoKtpDao _PhotoKtpDao
        {
            get { return new PhotoKtpDao(); }
        }

        //protected JadwalSiskamlingDao _JadwalSiskamlingDao
        //{
        //    get { return new JadwalSiskamlingDao(); }
        //}

        protected AppointmentDiaryDao _AppointmentDiaryDao
        {
            get { return new AppointmentDiaryDao(); }
        }

        protected SlideShowDao _SlideShowDao
        {
            get { return new SlideShowDao(); }
        }

        protected ParameterDao _ParameterDao
        {
            get { return new ParameterDao(); }
        }

        protected RtDao _RtDao
        {
            get { return new RtDao(); }
        }

        protected RwDao _RwDao
        {
            get { return new RwDao(); }
        }

        protected ListOfValueDao _ListOfValueDao
        {
            get { return new ListOfValueDao(); }
        }

        protected LandingPageLevelDao _LandingPageLevelDao
        {
            get { return new LandingPageLevelDao(); }
        }

        protected LandingPageLevelPropertyDao _LandingPageLevelPropertyDao
        {
            get { return new LandingPageLevelPropertyDao(); }
        }
                       
        protected BiodataDao _BiodataDao
        {
            get { return new BiodataDao(); }
        }

        protected TestimoniDao _TestimoniDao
        {
            get { return new TestimoniDao(); }
        }
        #endregion

        #region Implementation

        #region Agama
        public AgamaResponse GetAgamaFindBy(AgamaRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new AgamaResponse()
            {
                Errors = new BusinessErrors(),
                AgamaResult = new AgamaResult(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                AgamaResponse data = new AgamaResponse();
                var refData = data.AgamaResult;
                bussinessError.Add(_AgamaDao.GetAgamaFindBy(request, ref refData));
                response.AgamaResult = refData;
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

        public AgamaResponse GetAgamaList(AgamaRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new AgamaResponse()
            {
                Errors = new BusinessErrors(),
                AgamaResultList = new List<AgamaResult>(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                List<AgamaResult> refData = new List<AgamaResult>();
                bussinessError.Add(_AgamaDao.GetAgamaList(ref refData));
                response.AgamaResultList = refData;
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

        public AgamaResponse InsertAgama(AgamaRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new AgamaResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_AgamaDao.InsertAgama(request, ref result));
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

        public AgamaResponse UpdateAgama(AgamaRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new AgamaResponse();

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_AgamaDao.UpdateAgama(request, ref result));
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

        public AgamaResponse DeleteAgama(AgamaRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new AgamaResponse();

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_AgamaDao.DeleteAgama(request, ref result));
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

        #region DetailJenisInformasi
        public DetailJenisInformasiResponse GetDetailJenisInformasiFindBy(DetailJenisInformasiRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new DetailJenisInformasiResponse()
            {
                Errors = new BusinessErrors(),
                DetailJenisInformasiResult = new DetailJenisInformasiResult(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                DetailJenisInformasiResponse data = new DetailJenisInformasiResponse();
                var refData = data.DetailJenisInformasiResult;
                bussinessError.Add(_DetailJenisInformasiDao.GetDetailJenisInformasiFindBy(request, ref refData));
                response.DetailJenisInformasiResult = refData;
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

        public DetailJenisInformasiResponse GetDetailJenisInformasiNewest(DetailJenisInformasiRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new DetailJenisInformasiResponse()
            {
                Errors = new BusinessErrors(),
                DetailJenisInformasiResult = new DetailJenisInformasiResult(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                DetailJenisInformasiResponse data = new DetailJenisInformasiResponse();
                var refData = data.DetailJenisInformasiResultList;
                bussinessError.Add(_DetailJenisInformasiDao.GetDetailJenisInformasiNewest(request, ref refData));
                response.DetailJenisInformasiResultList = refData;
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

        public DetailJenisInformasiResponse GetDetailJenisInformasiList(DetailJenisInformasiRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new DetailJenisInformasiResponse()
            {
                Errors = new BusinessErrors(),
                DetailJenisInformasiResultList = new List<DetailJenisInformasiResult>(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                List<DetailJenisInformasiResult> refData = new List<DetailJenisInformasiResult>();
                bussinessError.Add(_DetailJenisInformasiDao.GetDetailJenisInformasiList(ref refData));
                response.DetailJenisInformasiResultList = refData;
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

        public DetailJenisInformasiResponse GetDetailJenisInformasiListByIdJenisInformasi(DetailJenisInformasiRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new DetailJenisInformasiResponse()
            {
                Errors = new BusinessErrors(),
                DetailJenisInformasiResultList = new List<DetailJenisInformasiResult>(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                List<DetailJenisInformasiResult> refData = new List<DetailJenisInformasiResult>();
                bussinessError.Add(_DetailJenisInformasiDao.GetDetailJenisInformasiListByIdJenisInformasi(request, ref refData));
                response.DetailJenisInformasiResultList = refData;
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


        public DetailJenisInformasiResponse InsertDetailJenisInformasi(DetailJenisInformasiRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new DetailJenisInformasiResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_DetailJenisInformasiDao.InsertDetailJenisInformasi(request, ref result));
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

        public DetailJenisInformasiResponse UpdateDetailJenisInformasi(DetailJenisInformasiRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new DetailJenisInformasiResponse();

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_DetailJenisInformasiDao.UpdateDetailJenisInformasi(request, ref result));
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

        public DetailJenisInformasiResponse DeleteDetailJenisInformasi(DetailJenisInformasiRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new DetailJenisInformasiResponse();

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_DetailJenisInformasiDao.DeleteDetailJenisInformasi(request, ref result));
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
        public DetailJenisInformasiResponse SpGetDetailJenisInformasiByIdRw(DetailJenisInformasiRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new DetailJenisInformasiResponse()
            {
                Errors = new BusinessErrors(),
                DetailJenisInformasiResultList = new List<DetailJenisInformasiResult>(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                List<DetailJenisInformasiResult> refData = new List<DetailJenisInformasiResult>();
                bussinessError.Add(_DetailJenisInformasiDao.SpGetDetailJenisInformasiByIdRw(request, ref refData));
                response.DetailJenisInformasiResultList = refData;
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

        #endregion

        #region DetailJenisKegiatan
        public DetailJenisKegiatanResponse GetDetailJenisKegiatanFindBy(DetailJenisKegiatanRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new DetailJenisKegiatanResponse()
            {
                Errors = new BusinessErrors(),
                DetailJenisKegiatanResult = new DetailJenisKegiatanResult(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                DetailJenisKegiatanResponse data = new DetailJenisKegiatanResponse();
                var refData = data.DetailJenisKegiatanResult;
                bussinessError.Add(_DetailJenisKegiatanDao.GetDetailJenisKegiatanFindBy(request, ref refData));
                response.DetailJenisKegiatanResult = refData;
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

        public DetailJenisKegiatanResponse GetDetailJenisKegiatanList(DetailJenisKegiatanRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new DetailJenisKegiatanResponse()
            {
                Errors = new BusinessErrors(),
                DetailJenisKegiatanResultList = new List<DetailJenisKegiatanResult>(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                List<DetailJenisKegiatanResult> refData = new List<DetailJenisKegiatanResult>();
                bussinessError.Add(_DetailJenisKegiatanDao.GetDetailJenisKegiatanList(ref refData));
                response.DetailJenisKegiatanResultList = refData;
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

        public DetailJenisKegiatanResponse GetDetailJenisKegiatanListByIdJenisKegiatan(DetailJenisKegiatanRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new DetailJenisKegiatanResponse()
            {
                Errors = new BusinessErrors(),
                DetailJenisKegiatanResultList = new List<DetailJenisKegiatanResult>(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                List<DetailJenisKegiatanResult> refData = new List<DetailJenisKegiatanResult>();
                bussinessError.Add(_DetailJenisKegiatanDao.GetDetailJenisKegiatanListByIdJenisKegiatan(request, ref refData));
                response.DetailJenisKegiatanResultList = refData;
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

        public DetailJenisKegiatanResponse InsertDetailJenisKegiatan(DetailJenisKegiatanRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new DetailJenisKegiatanResponse();

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_DetailJenisKegiatanDao.InsertDetailJenisKegiatan(request, ref result));
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

        public DetailJenisKegiatanResponse UpdateDetailJenisKegiatan(DetailJenisKegiatanRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new DetailJenisKegiatanResponse();

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_DetailJenisKegiatanDao.UpdateDetailJenisKegiatan(request, ref result));
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

        public DetailJenisKegiatanResponse DeleteDetailJenisKegiatan(DetailJenisKegiatanRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new DetailJenisKegiatanResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_DetailJenisKegiatanDao.DeleteDetailJenisKegiatan(request, ref result));
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

        #region DokumentasiDetailJenisKegiatan
        public DokumentasiDetailJenisKegiatanResponse GetDokumentasiDetailJenisKegiatanFindBy(DokumentasiDetailJenisKegiatanRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new DokumentasiDetailJenisKegiatanResponse()
            {
                Errors = new BusinessErrors(),
                DokumentasiDetailJenisKegiatanResult = new DokumentasiDetailJenisKegiatanResult(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                DokumentasiDetailJenisKegiatanResponse data = new DokumentasiDetailJenisKegiatanResponse();
                var refData = data.DokumentasiDetailJenisKegiatanResult;
                bussinessError.Add(_DokumentasiDetailJenisKegiatanDao.GetDokumentasiDetailJenisKegiatanFindBy(request, ref refData));
                response.DokumentasiDetailJenisKegiatanResult = refData;
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

        public DokumentasiDetailJenisKegiatanResponse GetDokumentasiDetailJenisKegiatanList(DokumentasiDetailJenisKegiatanRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new DokumentasiDetailJenisKegiatanResponse()
            {
                Errors = new BusinessErrors(),
                DokumentasiDetailJenisKegiatanResultList = new List<DokumentasiDetailJenisKegiatanResult>(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                List<DokumentasiDetailJenisKegiatanResult> refData = new List<DokumentasiDetailJenisKegiatanResult>();
                bussinessError.Add(_DokumentasiDetailJenisKegiatanDao.GetDokumentasiDetailJenisKegiatanList(ref refData));
                response.DokumentasiDetailJenisKegiatanResultList = refData;
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

        public DokumentasiDetailJenisKegiatanResponse GetDokumentasiDetailJenisKegiatanListByIdDetailJenisKegiatan(DokumentasiDetailJenisKegiatanRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new DokumentasiDetailJenisKegiatanResponse()
            {
                Errors = new BusinessErrors(),
                DokumentasiDetailJenisKegiatanResultList = new List<DokumentasiDetailJenisKegiatanResult>(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                List<DokumentasiDetailJenisKegiatanResult> refData = new List<DokumentasiDetailJenisKegiatanResult>();
                bussinessError.Add(_DokumentasiDetailJenisKegiatanDao.GetDokumentasiDetailJenisKegiatanListByIdDetailJenisKegiatan(request, ref refData));
                response.DokumentasiDetailJenisKegiatanResultList = refData;
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

        public DokumentasiDetailJenisKegiatanResponse InsertDokumentasiDetailJenisKegiatan(DokumentasiDetailJenisKegiatanRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new DokumentasiDetailJenisKegiatanResponse();

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_DokumentasiDetailJenisKegiatanDao.InsertDokumentasiDetailJenisKegiatan(request, ref result));
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

        public DokumentasiDetailJenisKegiatanResponse UpdateDokumentasiDetailJenisKegiatan(DokumentasiDetailJenisKegiatanRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new DokumentasiDetailJenisKegiatanResponse();

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_DokumentasiDetailJenisKegiatanDao.UpdateDokumentasiDetailJenisKegiatan(request, ref result));
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

        public DokumentasiDetailJenisKegiatanResponse DeleteDokumentasiDetailJenisKegiatan(DokumentasiDetailJenisKegiatanRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new DokumentasiDetailJenisKegiatanResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_DokumentasiDetailJenisKegiatanDao.DeleteDokumentasiDetailJenisKegiatan(request, ref result));
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

        #region GolonganDarah
        public GolonganDarahResponse GetGolonganDarahFindBy(GolonganDarahRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new GolonganDarahResponse()
            {
                Errors = new BusinessErrors(),
                GolonganDarahResult = new GolonganDarahResult(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                GolonganDarahResponse data = new GolonganDarahResponse();
                var refData = data.GolonganDarahResult;
                bussinessError.Add(_GolonganDarahDao.GetGolonganDarahFindBy(request, ref refData));
                response.GolonganDarahResult = refData;
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

        public GolonganDarahResponse GetGolonganDarahList(GolonganDarahRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new GolonganDarahResponse()
            {
                Errors = new BusinessErrors(),
                GolonganDarahResultList = new List<GolonganDarahResult>(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                List<GolonganDarahResult> refData = new List<GolonganDarahResult>();
                bussinessError.Add(_GolonganDarahDao.GetGolonganDarahList(ref refData));
                response.GolonganDarahResultList = refData;
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

        public GolonganDarahResponse InsertGolonganDarah(GolonganDarahRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            ResultStatus result = new ResultStatus();
            var response = new GolonganDarahResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_GolonganDarahDao.InsertGolonganDarah(request, ref result));
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

        public GolonganDarahResponse UpdateGolonganDarah(GolonganDarahRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            ResultStatus result = new ResultStatus();
            var response = new GolonganDarahResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_GolonganDarahDao.UpdateGolonganDarah(request, ref result));
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

        public GolonganDarahResponse DeleteGolonganDarah(GolonganDarahRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            ResultStatus result = new ResultStatus();
            var response = new GolonganDarahResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_GolonganDarahDao.DeleteGolonganDarah(request, ref result));
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

        #region Jabatan
        public JabatanResponse GetJabatanFindBy(JabatanRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new JabatanResponse()
            {
                Errors = new BusinessErrors(),
                JabatanResult = new JabatanResult(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                JabatanResponse data = new JabatanResponse();
                var refData = data.JabatanResult;
                bussinessError.Add(_JabatanDao.GetJabatanFindBy(request, ref refData));
                response.JabatanResult = refData;
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

        public JabatanResponse GetJabatanList(JabatanRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new JabatanResponse()
            {
                Errors = new BusinessErrors(),
                JabatanResultList = new List<JabatanResult>(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                List<JabatanResult> refData = new List<JabatanResult>();
                bussinessError.Add(_JabatanDao.GetJabatanList(ref refData));
                response.JabatanResultList = refData;
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

        public JabatanResponse InsertJabatan(JabatanRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            ResultStatus result = new ResultStatus();
            var response = new JabatanResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_JabatanDao.InsertJabatan(request, ref result));
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

        public JabatanResponse UpdateJabatan(JabatanRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            ResultStatus result = new ResultStatus();
            var response = new JabatanResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_JabatanDao.UpdateJabatan(request, ref result));
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

        public JabatanResponse DeleteJabatan(JabatanRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            ResultStatus result = new ResultStatus();
            var response = new JabatanResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_JabatanDao.DeleteJabatan(request, ref result));
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

        #region JenisInformasi
        public JenisInformasiResponse GetJenisInformasiFindBy(JenisInformasiRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new JenisInformasiResponse()
            {
                Errors = new BusinessErrors(),
                JenisInformasiResult = new JenisInformasiResult(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                JenisInformasiResponse data = new JenisInformasiResponse();
                var refData = data.JenisInformasiResult;
                bussinessError.Add(_JenisInformasiDao.GetJenisInformasiFindBy(request, ref refData));
                response.JenisInformasiResult = refData;
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

        public JenisInformasiResponse GetJenisInformasiList(JenisInformasiRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new JenisInformasiResponse()
            {
                Errors = new BusinessErrors(),
                JenisInformasiResultList = new List<JenisInformasiResult>(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                List<JenisInformasiResult> refData = new List<JenisInformasiResult>();
                bussinessError.Add(_JenisInformasiDao.GetJenisInformasiList(request, ref refData));
                response.JenisInformasiResultList = refData;
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

        public JenisInformasiResponse InsertJenisInformasi(JenisInformasiRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new JenisInformasiResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_JenisInformasiDao.InsertJenisInformasi(request, ref result));
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

        public JenisInformasiResponse UpdateJenisInformasi(JenisInformasiRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new JenisInformasiResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_JenisInformasiDao.UpdateJenisInformasi(request, ref result));
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

        public JenisInformasiResponse DeleteJenisInformasi(JenisInformasiRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new JenisInformasiResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_JenisInformasiDao.DeleteJenisInformasi(request, ref result));
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

        #region JenisKegiatan
        public JenisKegiatanResponse GetJenisKegiatanFindBy(JenisKegiatanRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new JenisKegiatanResponse()
            {
                Errors = new BusinessErrors(),
                JenisKegiatanResult = new JenisKegiatanResult(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                JenisKegiatanResponse data = new JenisKegiatanResponse();
                var refData = data.JenisKegiatanResult;
                bussinessError.Add(_JenisKegiatanDao.GetJenisKegiatanFindBy(request, ref refData));
                response.JenisKegiatanResult = refData;
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

        public JenisKegiatanResponse GetJenisKegiatanList(JenisKegiatanRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new JenisKegiatanResponse()
            {
                Errors = new BusinessErrors(),
                JenisKegiatanResultList = new List<JenisKegiatanResult>(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                List<JenisKegiatanResult> refData = new List<JenisKegiatanResult>();
                bussinessError.Add(_JenisKegiatanDao.GetJenisKegiatanList(request, ref refData));
                response.JenisKegiatanResultList = refData;
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

        public JenisKegiatanResponse InsertJenisKegiatan(JenisKegiatanRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new JenisKegiatanResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_JenisKegiatanDao.InsertJenisKegiatan(request, ref result));
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

        public JenisKegiatanResponse UpdateJenisKegiatan(JenisKegiatanRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new JenisKegiatanResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_JenisKegiatanDao.UpdateJenisKegiatan(request, ref result));
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

        public JenisKegiatanResponse DeleteJenisKegiatan(JenisKegiatanRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new JenisKegiatanResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_JenisKegiatanDao.DeleteJenisKegiatan(request, ref result));
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

        #region JenisKelamin
        public JenisKelaminResponse GetJenisKelaminFindBy(JenisKelaminRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new JenisKelaminResponse()
            {
                Errors = new BusinessErrors(),
                JenisKelaminResult = new JenisKelaminResult(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                JenisKelaminResponse data = new JenisKelaminResponse();
                var refData = data.JenisKelaminResult;
                bussinessError.Add(_JenisKelaminDao.GetJenisKelaminFindBy(request, ref refData));
                response.JenisKelaminResult = refData;
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

        public JenisKelaminResponse GetJenisKelaminList(JenisKelaminRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new JenisKelaminResponse()
            {
                Errors = new BusinessErrors(),
                JenisKelaminResultList = new List<JenisKelaminResult>(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                List<JenisKelaminResult> refData = new List<JenisKelaminResult>();
                bussinessError.Add(_JenisKelaminDao.GetJenisKelaminList(ref refData));
                response.JenisKelaminResultList = refData;
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

        public JenisKelaminResponse InsertJenisKelamin(JenisKelaminRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new JenisKelaminResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_JenisKelaminDao.InsertJenisKelamin(request, ref result));
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

        public JenisKelaminResponse UpdateJenisKelamin(JenisKelaminRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new JenisKelaminResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_JenisKelaminDao.UpdateJenisKelamin(request, ref result));
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

        public JenisKelaminResponse DeleteJenisKelamin(JenisKelaminRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new JenisKelaminResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_JenisKelaminDao.DeleteJenisKelamin(request, ref result));
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

        #region JenisPekerjaan
        public JenisPekerjaanResponse GetJenisPekerjaanFindBy(JenisPekerjaanRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new JenisPekerjaanResponse()
            {
                Errors = new BusinessErrors(),
                JenisPekerjaanResult = new JenisPekerjaanResult(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                JenisPekerjaanResponse data = new JenisPekerjaanResponse();
                var refData = data.JenisPekerjaanResult;
                bussinessError.Add(_JenisPekerjaanDao.GetJenisPekerjaanFindBy(request, ref refData));
                response.JenisPekerjaanResult = refData;
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

        public JenisPekerjaanResponse GetJenisPekerjaanList(JenisPekerjaanRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new JenisPekerjaanResponse()
            {
                Errors = new BusinessErrors(),
                JenisPekerjaanResultList = new List<JenisPekerjaanResult>(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                List<JenisPekerjaanResult> refData = new List<JenisPekerjaanResult>();
                bussinessError.Add(_JenisPekerjaanDao.GetJenisPekerjaanList(ref refData));
                response.JenisPekerjaanResultList = refData;
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

        public JenisPekerjaanResponse InsertJenisPekerjaan(JenisPekerjaanRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new JenisPekerjaanResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_JenisPekerjaanDao.InsertJenisPekerjaan(request, ref result));
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

        public JenisPekerjaanResponse UpdateJenisPekerjaan(JenisPekerjaanRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new JenisPekerjaanResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_JenisPekerjaanDao.UpdateJenisPekerjaan(request, ref result));
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

        public JenisPekerjaanResponse DeleteJenisPekerjaan(JenisPekerjaanRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new JenisPekerjaanResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_JenisPekerjaanDao.DeleteJenisPekerjaan(request, ref result));
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

        #region Kecamatan
        public KecamatanResponse GetKecamatanFindBy(KecamatanRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new KecamatanResponse()
            {
                Errors = new BusinessErrors(),
                KecamatanResult = new KecamatanResult(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                KecamatanResponse data = new KecamatanResponse();
                var refData = data.KecamatanResult;
                bussinessError.Add(_KecamatanDao.GetKecamatanFindBy(request, ref refData));
                response.KecamatanResult = refData;
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

        public KecamatanResponse GetKecamatanList(KecamatanRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new KecamatanResponse()
            {
                Errors = new BusinessErrors(),
                KecamatanResultList = new List<KecamatanResult>(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                List<KecamatanResult> refData = new List<KecamatanResult>();
                bussinessError.Add(_KecamatanDao.GetKecamatanList(request, ref refData));
                response.KecamatanResultList = refData;
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

        public KecamatanResponse InsertKecamatan(KecamatanRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new KecamatanResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_KecamatanDao.InsertKecamatan(request, ref result));
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

        public KecamatanResponse UpdateKecamatan(KecamatanRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new KecamatanResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_KecamatanDao.UpdateKecamatan(request, ref result));
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

        public KecamatanResponse DeleteKecamatan(KecamatanRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new KecamatanResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_KecamatanDao.DeleteKecamatan(request, ref result));
            }
            catch (Exception ex)
            {
                response.ResultStatus = result;
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

        #region Kelurahan
        public KelurahanResponse GetKelurahanFindBy(KelurahanRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new KelurahanResponse()
            {
                Errors = new BusinessErrors(),
                KelurahanResult = new KelurahanResult(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                KelurahanResponse data = new KelurahanResponse();
                var refData = data.KelurahanResult;
                bussinessError.Add(_KelurahanDao.GetKelurahanFindBy(request, ref refData));
                response.KelurahanResult = refData;
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

        public KelurahanResponse GetKelurahanList(KelurahanRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new KelurahanResponse()
            {
                Errors = new BusinessErrors(),
                KelurahanResultList = new List<KelurahanResult>(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                List<KelurahanResult> refData = new List<KelurahanResult>();
                bussinessError.Add(_KelurahanDao.GetKelurahanList(request, ref refData));
                response.KelurahanResultList = refData;
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

        public KelurahanResponse InsertKelurahan(KelurahanRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new KelurahanResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_KelurahanDao.InsertKelurahan(request, ref result));
            }
            catch (Exception ex)
            {
                response.ResultStatus = result;
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

        public KelurahanResponse UpdateKelurahan(KelurahanRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new KelurahanResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_KelurahanDao.UpdateKelurahan(request, ref result));
            }
            catch (Exception ex)
            {
                response.ResultStatus = result;
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

        public KelurahanResponse DeleteKelurahan(KelurahanRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new KelurahanResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_KelurahanDao.DeleteKelurahan(request, ref result));
            }
            catch (Exception ex)
            {
                response.ResultStatus = result;
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

        #region Kewarganegaraan
        public KewarganegaraanResponse GetKewarganegaraanFindBy(KewarganegaraanRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new KewarganegaraanResponse()
            {
                Errors = new BusinessErrors(),
                KewarganegaraanResult = new KewarganegaraanResult(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                KewarganegaraanResponse data = new KewarganegaraanResponse();
                var refData = data.KewarganegaraanResult;
                bussinessError.Add(_KewarganegaraanDao.GetKewarganegaraanFindBy(request, ref refData));
                response.KewarganegaraanResult = refData;
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

        public KewarganegaraanResponse GetKewarganegaraanList(KewarganegaraanRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new KewarganegaraanResponse()
            {
                Errors = new BusinessErrors(),
                KewarganegaraanResultList = new List<KewarganegaraanResult>(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                List<KewarganegaraanResult> refData = new List<KewarganegaraanResult>();
                bussinessError.Add(_KewarganegaraanDao.GetKewarganegaraanList(ref refData));
                response.KewarganegaraanResultList = refData;
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

        public KewarganegaraanResponse InsertKewarganegaraan(KewarganegaraanRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new KewarganegaraanResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_KewarganegaraanDao.InsertKewarganegaraan(request, ref result));
            }
            catch (Exception ex)
            {
                response.ResultStatus = result;
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

        public KewarganegaraanResponse UpdateKewarganegaraan(KewarganegaraanRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new KewarganegaraanResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_KewarganegaraanDao.UpdateKewarganegaraan(request, ref result));
            }
            catch (Exception ex)
            {
                response.ResultStatus = result;
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

        public KewarganegaraanResponse DeleteKewarganegaraan(KewarganegaraanRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new KewarganegaraanResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_KewarganegaraanDao.DeleteKewarganegaraan(request, ref result));
            }
            catch (Exception ex)
            {
                response.ResultStatus = result;
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

        #region Kota
        public KotaResponse GetKotaFindBy(KotaRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new KotaResponse()
            {
                Errors = new BusinessErrors(),
                KotaResult = new KotaResult(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                KotaResponse data = new KotaResponse();
                var refData = data.KotaResult;
                bussinessError.Add(_KotaDao.GetKotaFindBy(request, ref refData));
                response.KotaResult = refData;
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

        public KotaResponse GetKotaList(KotaRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new KotaResponse()
            {
                Errors = new BusinessErrors(),
                KotaResultList = new List<KotaResult>(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                List<KotaResult> refData = new List<KotaResult>();
                bussinessError.Add(_KotaDao.GetKotaList(request, ref refData));
                response.KotaResultList = refData;
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

        public KotaResponse InsertKota(KotaRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new KotaResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_KotaDao.InsertKota(request, ref result));
            }
            catch (Exception ex)
            {
                response.ResultStatus = result;
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

        public KotaResponse UpdateKota(KotaRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new KotaResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_KotaDao.UpdateKota(request, ref result));
            }
            catch (Exception ex)
            {
                response.ResultStatus = result;
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

        public KotaResponse DeleteKota(KotaRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new KotaResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_KotaDao.DeleteKota(request, ref result));
            }
            catch (Exception ex)
            {
                response.ResultStatus = result;
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

        #region Ktp
        public KtpResponse GetKtpFindBy(KtpRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new KtpResponse()
            {
                Errors = new BusinessErrors(),
                KtpResult = new KtpResult(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                KtpResponse data = new KtpResponse();
                var refData = data.KtpResult;
                bussinessError.Add(_KtpDao.GetKtpFindBy(request, ref refData));
                response.KtpResult = refData;
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

        public KtpResponse GetKtpList(KtpRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new KtpResponse()
            {
                Errors = new BusinessErrors(),
                KtpResultList = new List<KtpResult>(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                List<KtpResult> refData = new List<KtpResult>();
                bussinessError.Add(_KtpDao.GetKtpList(request, ref refData));
                response.KtpResultList = refData;
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

        public KtpResponse GetKtpListBy(KtpRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new KtpResponse()
            {
                Errors = new BusinessErrors(),
                KtpResultList = new List<KtpResult>(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                List<KtpResult> refData = new List<KtpResult>();
                bussinessError.Add(_KtpDao.GetKtpListBy(request, ref refData));
                response.KtpResultList = refData;
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


        public KtpResponse InsertKtp(KtpRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new KtpResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_KtpDao.InsertKtp(request, ref result));
            }
            catch (Exception ex)
            {
                response.ResultStatus = result;
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

        public KtpResponse UpdateKtp(KtpRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new KtpResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_KtpDao.UpdateKtp(request, ref result));
            }
            catch (Exception ex)
            {
                response.ResultStatus = result;
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

        public KtpResponse DeleteKtp(KtpRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new KtpResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_KtpDao.DeleteKtp(request, ref result));
            }
            catch (Exception ex)
            {
                response.ResultStatus = result;
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

        #region Pendidikan
        public PendidikanResponse GetPendidikanFindBy(PendidikanRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new PendidikanResponse()
            {
                Errors = new BusinessErrors(),
                PendidikanResult = new PendidikanResult(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                PendidikanResponse data = new PendidikanResponse();
                var refData = data.PendidikanResult;
                bussinessError.Add(_PendidikanDao.GetPendidikanFindBy(request, ref refData));
                response.PendidikanResult = refData;
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

        public PendidikanResponse GetPendidikanList(PendidikanRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new PendidikanResponse()
            {
                Errors = new BusinessErrors(),
                PendidikanResultList = new List<PendidikanResult>(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                List<PendidikanResult> refData = new List<PendidikanResult>();
                bussinessError.Add(_PendidikanDao.GetPendidikanList(ref refData));
                response.PendidikanResultList = refData;
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

        public PendidikanResponse InsertPendidikan(PendidikanRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new PendidikanResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_PendidikanDao.InsertPendidikan(request, ref result));
            }
            catch (Exception ex)
            {
                response.ResultStatus = result;
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

        public PendidikanResponse UpdatePendidikan(PendidikanRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new PendidikanResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_PendidikanDao.UpdatePendidikan(request, ref result));
            }
            catch (Exception ex)
            {
                response.ResultStatus = result;
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

        public PendidikanResponse DeletePendidikan(PendidikanRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new PendidikanResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_PendidikanDao.DeletePendidikan(request, ref result));
            }
            catch (Exception ex)
            {
                response.ResultStatus = result;
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

        #region Provinsi
        public ProvinsiResponse GetProvinsiFindBy(ProvinsiRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new ProvinsiResponse()
            {
                Errors = new BusinessErrors(),
                ProvinsiResult = new ProvinsiResult(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                ProvinsiResponse data = new ProvinsiResponse();
                var refData = data.ProvinsiResult;
                bussinessError.Add(_ProvinsiDao.GetProvinsiFindBy(request, ref refData));
                response.ProvinsiResult = refData;
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

        public ProvinsiResponse GetProvinsiList(ProvinsiRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new ProvinsiResponse()
            {
                Errors = new BusinessErrors(),
                ProvinsiResultList = new List<ProvinsiResult>(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                List<ProvinsiResult> refData = new List<ProvinsiResult>();
                bussinessError.Add(_ProvinsiDao.GetProvinsiList(ref refData));
                response.ProvinsiResultList = refData;
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

        public ProvinsiResponse InsertProvinsi(ProvinsiRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new ProvinsiResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_ProvinsiDao.InsertProvinsi(request, ref result));
            }
            catch (Exception ex)
            {
                response.ResultStatus = result;
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

        public ProvinsiResponse UpdateProvinsi(ProvinsiRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new ProvinsiResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_ProvinsiDao.UpdateProvinsi(request, ref result));
            }
            catch (Exception ex)
            {
                response.ResultStatus = result;
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

        public ProvinsiResponse DeleteProvinsi(ProvinsiRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new ProvinsiResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_ProvinsiDao.DeleteProvinsi(request, ref result));
            }
            catch (Exception ex)
            {
                response.ResultStatus = result;
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

        #region SignatureKtp
        public SignatureKtpResponse GetSignatureKtpFindBy(SignatureKtpRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new SignatureKtpResponse()
            {
                Errors = new BusinessErrors(),
                SignatureKtpResult = new SignatureKtpResult(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                SignatureKtpResponse data = new SignatureKtpResponse();
                var refData = data.SignatureKtpResult;
                bussinessError.Add(_SignatureKtpDao.GetSignatureKtpFindBy(request, ref refData));
                response.SignatureKtpResult = refData;
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

        public SignatureKtpResponse GetSignatureKtpList(SignatureKtpRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new SignatureKtpResponse()
            {
                Errors = new BusinessErrors(),
                SignatureKtpResultList = new List<SignatureKtpResult>(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                List<SignatureKtpResult> refData = new List<SignatureKtpResult>();
                bussinessError.Add(_SignatureKtpDao.GetSignatureKtpList(ref refData));
                response.SignatureKtpResultList = refData;
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

        public SignatureKtpResponse InsertSignatureKtp(SignatureKtpRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new SignatureKtpResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_SignatureKtpDao.InsertSignatureKtp(request, ref result));
            }
            catch (Exception ex)
            {
                response.ResultStatus = result;
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

        public SignatureKtpResponse UpdateSignatureKtp(SignatureKtpRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new SignatureKtpResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_SignatureKtpDao.UpdateSignatureKtp(request, ref result));
            }
            catch (Exception ex)
            {
                response.ResultStatus = result;
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

        public SignatureKtpResponse DeleteSignatureKtp(SignatureKtpRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new SignatureKtpResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_SignatureKtpDao.DeleteSignatureKtp(request, ref result));
            }
            catch (Exception ex)
            {
                response.ResultStatus = result;
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

        #region StatusPerkawinan
        public StatusPerkawinanResponse GetStatusPerkawinanFindBy(StatusPerkawinanRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new StatusPerkawinanResponse()
            {
                Errors = new BusinessErrors(),
                StatusPerkawinanResult = new StatusPerkawinanResult(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                StatusPerkawinanResponse data = new StatusPerkawinanResponse();
                var refData = data.StatusPerkawinanResult;
                bussinessError.Add(_StatusPerkawinanDao.GetStatusPerkawinanFindBy(request, ref refData));
                response.StatusPerkawinanResult = refData;
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

        public StatusPerkawinanResponse GetStatusPerkawinanList(StatusPerkawinanRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new StatusPerkawinanResponse()
            {
                Errors = new BusinessErrors(),
                StatusPerkawinanResultList = new List<StatusPerkawinanResult>(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                List<StatusPerkawinanResult> refData = new List<StatusPerkawinanResult>();
                bussinessError.Add(_StatusPerkawinanDao.GetStatusPerkawinanList(ref refData));
                response.StatusPerkawinanResultList = refData;
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

        public StatusPerkawinanResponse InsertStatusPerkawinan(StatusPerkawinanRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new StatusPerkawinanResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_StatusPerkawinanDao.InsertStatusPerkawinan(request, ref result));
            }
            catch (Exception ex)
            {
                response.ResultStatus = result;
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

        public StatusPerkawinanResponse UpdateStatusPerkawinan(StatusPerkawinanRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new StatusPerkawinanResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_StatusPerkawinanDao.UpdateStatusPerkawinan(request, ref result));
            }
            catch (Exception ex)
            {
                response.ResultStatus = result;
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

        public StatusPerkawinanResponse DeleteStatusPerkawinan(StatusPerkawinanRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new StatusPerkawinanResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_StatusPerkawinanDao.DeleteStatusPerkawinan(request, ref result));
            }
            catch (Exception ex)
            {
                response.ResultStatus = result;
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

        #region Struktur
        public StrukturResponse GetStrukturFindBy(StrukturRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new StrukturResponse()
            {
                Errors = new BusinessErrors(),
                StrukturResult = new StrukturResult(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                StrukturResponse data = new StrukturResponse();
                var refData = data.StrukturResult;
                bussinessError.Add(_StrukturDao.GetStrukturFindBy(request, ref refData));
                response.StrukturResult = refData;
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

        public StrukturResponse GetStrukturList(StrukturRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new StrukturResponse()
            {
                Errors = new BusinessErrors(),
                StrukturResultList = new List<StrukturResult>(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                List<StrukturResult> refData = new List<StrukturResult>();
                bussinessError.Add(_StrukturDao.GetStrukturList(request, ref refData));
                response.StrukturResultList = refData;
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

        public StrukturResponse InsertStruktur(StrukturRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new StrukturResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_StrukturDao.InsertStruktur(request, ref result));
            }
            catch (Exception ex)
            {
                response.ResultStatus = result;
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

        public StrukturResponse UpdateStruktur(StrukturRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new StrukturResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_StrukturDao.UpdateStruktur(request, ref result));
            }
            catch (Exception ex)
            {
                response.ResultStatus = result;
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

        public StrukturResponse UpdateStrukturByDrag(StrukturRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new StrukturResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_StrukturDao.UpdateStrukturByDrag(request, ref result));
            }
            catch (Exception ex)
            {
                response.ResultStatus = result;
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


        public StrukturResponse DeleteStruktur(StrukturRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new StrukturResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_StrukturDao.DeleteStruktur(request, ref result));
            }
            catch (Exception ex)
            {
                response.ResultStatus = result;
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

        #region PhotoKtp
        public PhotoKtpResponse GetPhotoKtpFindBy(PhotoKtpRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new PhotoKtpResponse()
            {
                Errors = new BusinessErrors(),
                PhotoKtpResult = new PhotoKtpResult(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                PhotoKtpResponse data = new PhotoKtpResponse();
                var refData = data.PhotoKtpResult;
                bussinessError.Add(_PhotoKtpDao.GetPhotoKtpFindBy(request, ref refData));
                response.PhotoKtpResult = refData;
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

        public PhotoKtpResponse GetPhotoKtpList(PhotoKtpRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new PhotoKtpResponse()
            {
                Errors = new BusinessErrors(),
                PhotoKtpResultList = new List<PhotoKtpResult>(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                List<PhotoKtpResult> refData = new List<PhotoKtpResult>();
                bussinessError.Add(_PhotoKtpDao.GetPhotoKtpList(ref refData));
                response.PhotoKtpResultList = refData;
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

        public PhotoKtpResponse InsertPhotoKtp(PhotoKtpRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new PhotoKtpResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_PhotoKtpDao.InsertPhotoKtp(request, ref result));
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

        public PhotoKtpResponse UpdatePhotoKtp(PhotoKtpRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new PhotoKtpResponse();

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_PhotoKtpDao.UpdatePhotoKtp(request, ref result));
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

        public PhotoKtpResponse DeletePhotoKtp(PhotoKtpRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new PhotoKtpResponse();

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_PhotoKtpDao.DeletePhotoKtp(request, ref result));
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

        //#region JadwalSiskamling
        //public JadwalSiskamlingResponse GetJadwalSiskamlingFindBy(JadwalSiskamlingRequest request)
        //{
        //    string method = MethodBase.GetCurrentMethod().Name;
        //    BusinessErrors bussinessError = new BusinessErrors();
        //    var response = new JadwalSiskamlingResponse()
        //    {
        //        Errors = new BusinessErrors(),
        //        JadwalSiskamlingResult = new JadwalSiskamlingResult(),
        //    };

        //    try
        //    {
        //        _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
        //        JadwalSiskamlingResponse data = new JadwalSiskamlingResponse();
        //        var refData = data.JadwalSiskamlingResult;
        //        bussinessError.Add(_JadwalSiskamlingDao.GetJadwalSiskamlingFindBy(request, ref refData));
        //        response.JadwalSiskamlingResult = refData;
        //    }
        //    catch (Exception ex)
        //    {
        //        _errHand.FillError(ex.Message, ref bussinessError);
        //    }
        //    finally
        //    {
        //        _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.end);
        //    }
        //    response.Errors = bussinessError;
        //    return response;
        //}

        //public JadwalSiskamlingResponse GetJadwalSiskamlingList(JadwalSiskamlingRequest request)
        //{
        //    string method = MethodBase.GetCurrentMethod().Name;
        //    BusinessErrors bussinessError = new BusinessErrors();
        //    var response = new JadwalSiskamlingResponse()
        //    {
        //        Errors = new BusinessErrors(),
        //        JadwalSiskamlingResultList = new List<JadwalSiskamlingResult>(),
        //    };

        //    try
        //    {
        //        _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
        //        List<JadwalSiskamlingResult> refData = new List<JadwalSiskamlingResult>();
        //        bussinessError.Add(_JadwalSiskamlingDao.GetJadwalSiskamlingList(ref refData));
        //        response.JadwalSiskamlingResultList = refData;
        //        response.Count = refData.Count;
        //    }
        //    catch (Exception ex)
        //    {
        //        _errHand.FillError(ex.Message, ref bussinessError);
        //    }
        //    finally
        //    {
        //        _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.end);
        //    }
        //    response.Errors = bussinessError;
        //    return response;
        //}

        //public JadwalSiskamlingResponse InsertJadwalSiskamling(JadwalSiskamlingRequest request)
        //{
        //    string method = MethodBase.GetCurrentMethod().Name;
        //    BusinessErrors bussinessError = new BusinessErrors();
        //    var response = new JadwalSiskamlingResponse()
        //    {
        //        Errors = new BusinessErrors(),
        //    };

        //    try
        //    {
        //        _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
        //        bussinessError.Add(_JadwalSiskamlingDao.InsertJadwalSiskamling(request, ref result));
        //    }
        //    catch (Exception ex)
        //    {
        //        result.SetErrorStatus(ex.Message);
        //        _errHand.FillError(ex.Message, ref bussinessError);
        //    }
        //    finally
        //    {
        //        _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.end);
        //    }
        //    response.Errors = bussinessError;
        //    response.ResultStatus = result;
        //    return response;
        //}

        //public JadwalSiskamlingResponse UpdateJadwalSiskamling(JadwalSiskamlingRequest request)
        //{
        //    string method = MethodBase.GetCurrentMethod().Name;
        //    BusinessErrors bussinessError = new BusinessErrors();
        //    var response = new JadwalSiskamlingResponse();

        //    try
        //    {
        //        _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
        //        bussinessError.Add(_JadwalSiskamlingDao.UpdateJadwalSiskamling(request, ref result));
        //    }
        //    catch (Exception ex)
        //    {
        //        result.SetErrorStatus(ex.Message);
        //        _errHand.FillError(ex.Message, ref bussinessError);
        //    }
        //    finally
        //    {
        //        _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.end);
        //    }
        //    response.Errors = bussinessError;
        //    response.ResultStatus = result;
        //    return response;
        //}

        //public JadwalSiskamlingResponse DeleteJadwalSiskamling(JadwalSiskamlingRequest request)
        //{
        //    string method = MethodBase.GetCurrentMethod().Name;
        //    BusinessErrors bussinessError = new BusinessErrors();
        //    var response = new JadwalSiskamlingResponse();

        //    try
        //    {
        //        _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
        //        bussinessError.Add(_JadwalSiskamlingDao.DeleteJadwalSiskamling(request, ref result));
        //    }
        //    catch (Exception ex)
        //    {
        //        result.SetErrorStatus(ex.Message);
        //        _errHand.FillError(ex.Message, ref bussinessError);
        //    }
        //    finally
        //    {
        //        _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.end);
        //    }
        //    response.Errors = bussinessError;
        //    response.ResultStatus = result;
        //    return response;
        //}

        //#endregion

        #region AppointmentDiary
        public AppointmentDiaryResponse GetAppointmentDiarySelectByDateRange(AppointmentDiaryRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new AppointmentDiaryResponse()
            {
                Errors = new BusinessErrors(),
                AppointmentDiaryResult = new AppointmentDiaryResult(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                List<AppointmentDiaryResult> refData = new List<AppointmentDiaryResult>();
                bussinessError.Add(_AppointmentDiaryDao.GetAppointmentDiarySelectByDateRange(request, ref refData));
                response.AppointmentDiaryResultList = refData;
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

        public AppointmentDiaryResponse GetAppointmentDiarySelectByTitle(AppointmentDiaryRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new AppointmentDiaryResponse()
            {
                Errors = new BusinessErrors(),
                AppointmentDiaryResult = new AppointmentDiaryResult(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                List<AppointmentDiaryResult> refData = new List<AppointmentDiaryResult>();
                bussinessError.Add(_AppointmentDiaryDao.GetAppointmentDiarySelectByTitle(request, ref refData));
                response.AppointmentDiaryResultList = refData;
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

        public AppointmentDiaryResponse GetAppointmentDiarySelectByTitleAndMonth(AppointmentDiaryRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new AppointmentDiaryResponse()
            {
                Errors = new BusinessErrors(),
                AppointmentDiaryResult = new AppointmentDiaryResult(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                AppointmentDiaryResponse data = new AppointmentDiaryResponse();
                var refData = data.AppointmentDiaryResult;
                bussinessError.Add(_AppointmentDiaryDao.GetAppointmentDiarySelectByTitleAndMonth(request, ref refData));
                response.AppointmentDiaryResult = refData;
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


        public AppointmentDiaryResponse InsertAppointmentDiary(AppointmentDiaryRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new AppointmentDiaryResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_AppointmentDiaryDao.InsertAppointmentDiary(request, ref result));
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

        public AppointmentDiaryResponse UpdateAppointmentDiary(AppointmentDiaryRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new AppointmentDiaryResponse();

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_AppointmentDiaryDao.UpdateAppointmentDiary(request, ref result));
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

        #region SlideShow
        public SlideShowResponse GetSlideShowFindBy(SlideShowRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new SlideShowResponse()
            {
                Errors = new BusinessErrors(),
                SlideShowResult = new SlideShowResult(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                SlideShowResponse data = new SlideShowResponse();
                var refData = data.SlideShowResult;
                bussinessError.Add(_SlideShowDao.GetSlideShowFindBy(request, ref refData));
                response.SlideShowResult = refData;
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

        public SlideShowResponse GetSlideShowList(SlideShowRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new SlideShowResponse()
            {
                Errors = new BusinessErrors(),
                SlideShowResultList = new List<SlideShowResult>(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                List<SlideShowResult> refData = new List<SlideShowResult>();
                bussinessError.Add(_SlideShowDao.GetSlideShowList(request, ref refData));
                response.SlideShowResultList = refData;
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

        public SlideShowResponse InsertSlideShow(SlideShowRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new SlideShowResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_SlideShowDao.InsertSlideShow(request, ref result));
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

        public SlideShowResponse UpdateSlideShow(SlideShowRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new SlideShowResponse();

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_SlideShowDao.UpdateSlideShow(request, ref result));
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

        public SlideShowResponse DeleteSlideShow(SlideShowRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new SlideShowResponse();

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_SlideShowDao.DeleteSlideShow(request, ref result));
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

        #region Parameter
        public ParameterResponse GetParameterFindBy(ParameterRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new ParameterResponse()
            {
                Errors = new BusinessErrors(),
                ParameterResult = new ParameterResult(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                ParameterResponse data = new ParameterResponse();
                var refData = data.ParameterResult;
                bussinessError.Add(_ParameterDao.GetParameterFindBy(request, ref refData));
                response.ParameterResult = refData;
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

        public ParameterResponse GetParameterList(ParameterRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new ParameterResponse()
            {
                Errors = new BusinessErrors(),
                ParameterResultList = new List<ParameterResult>(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                List<ParameterResult> refData = new List<ParameterResult>();
                bussinessError.Add(_ParameterDao.GetParameterList(ref refData));
                response.ParameterResultList = refData;
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

        public ParameterResponse InsertParameter(ParameterRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new ParameterResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_ParameterDao.InsertParameter(request, ref result));
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

        public ParameterResponse UpdateParameter(ParameterRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new ParameterResponse();

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_ParameterDao.UpdateParameter(request, ref result));
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

        public ParameterResponse DeleteParameter(ParameterRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new ParameterResponse();

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_ParameterDao.DeleteParameter(request, ref result));
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

        #region Rt
        public RtResponse GetRtFindBy(RtRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new RtResponse()
            {
                Errors = new BusinessErrors(),
                RtResult = new RtResult(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                RtResponse data = new RtResponse();
                var refData = data.RtResult;
                bussinessError.Add(_RtDao.GetRtFindBy(request, ref refData));
                response.RtResult = refData;
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

        public RtResponse GetRtList(RtRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new RtResponse()
            {
                Errors = new BusinessErrors(),
                RtResultList = new List<RtResult>(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                List<RtResult> refData = new List<RtResult>();
                bussinessError.Add(_RtDao.GetRtList(ref refData));
                response.RtResultList = refData;
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

        public RtResponse InsertRt(RtRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new RtResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_RtDao.InsertRt(request, ref result));
            }
            catch (Exception ex)
            {
                response.ResultStatus = result;
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

        public RtResponse UpdateRt(RtRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new RtResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_RtDao.UpdateRt(request, ref result));
            }
            catch (Exception ex)
            {
                response.ResultStatus = result;
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

        public RtResponse DeleteRt(RtRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new RtResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_RtDao.DeleteRt(request, ref result));
            }
            catch (Exception ex)
            {
                response.ResultStatus = result;
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

        public RtResponse GetRtByIdRw(RtRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new RtResponse()
            {
                Errors = new BusinessErrors(),
                RtResultList = new List<RtResult>(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                List<RtResult> refData = new List<RtResult>();
                bussinessError.Add(_RtDao.GetRtByIdRw(request, ref refData));
                response.RtResultList = refData;
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


        #endregion

        #region Rw
        public RwResponse GetRwFindBy(RwRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new RwResponse()
            {
                Errors = new BusinessErrors(),
                RwResult = new RwResult(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                RwResponse data = new RwResponse();
                var refData = data.RwResult;
                bussinessError.Add(_RwDao.GetRwFindBy(request, ref refData));
                response.RwResult = refData;
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

        public RwResponse GetRwList(RwRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new RwResponse()
            {
                Errors = new BusinessErrors(),
                RwResultList = new List<RwResult>(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                List<RwResult> refData = new List<RwResult>();
                bussinessError.Add(_RwDao.GetRwList(ref refData));
                response.RwResultList = refData;
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

        public RwResponse InsertRw(RwRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new RwResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_RwDao.InsertRw(request, ref result));
            }
            catch (Exception ex)
            {
                response.ResultStatus = result;
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

        public RwResponse UpdateRw(RwRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new RwResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_RwDao.UpdateRw(request, ref result));
            }
            catch (Exception ex)
            {
                response.ResultStatus = result;
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

        public RwResponse DeleteRw(RwRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new RwResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_RwDao.DeleteRw(request, ref result));
            }
            catch (Exception ex)
            {
                response.ResultStatus = result;
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
        public RwResponse GetRwByKodeRt(RwRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new RwResponse()
            {
                Errors = new BusinessErrors(),
                RwResult = new RwResult(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                RwResponse data = new RwResponse();
                var refData = data.RwResult;
                bussinessError.Add(_RwDao.GetRwByKodeRt(request, ref refData));
                response.RwResult = refData;
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

        #endregion

        #region ListOfValue
        public ListOfValueResponse GetListOfValueFindBy(ListOfValueRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new ListOfValueResponse()
            {
                Errors = new BusinessErrors(),
                ListOfValueResult = new ListOfValueResult(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                ListOfValueResponse data = new ListOfValueResponse();
                var refData = data.ListOfValueResult;
                bussinessError.Add(_ListOfValueDao.GetListOfValueFindBy(request, ref refData));
                response.ListOfValueResult = refData;
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

        public ListOfValueResponse GetListOfValueList(ListOfValueRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new ListOfValueResponse()
            {
                Errors = new BusinessErrors(),
                ListOfValueResultList = new List<ListOfValueResult>(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                List<ListOfValueResult> refData = new List<ListOfValueResult>();
                bussinessError.Add(_ListOfValueDao.GetListOfValueList(ref refData));
                response.ListOfValueResultList = refData;
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

        public ListOfValueResponse InsertListOfValue(ListOfValueRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new ListOfValueResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_ListOfValueDao.InsertListOfValue(request, ref result));
            }
            catch (Exception ex)
            {
                response.ResultStatus = result;
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

        public ListOfValueResponse UpdateListOfValue(ListOfValueRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new ListOfValueResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_ListOfValueDao.UpdateListOfValue(request, ref result));
            }
            catch (Exception ex)
            {
                response.ResultStatus = result;
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

        public ListOfValueResponse DeleteListOfValue(ListOfValueRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new ListOfValueResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_ListOfValueDao.DeleteListOfValue(request, ref result));
            }
            catch (Exception ex)
            {
                response.ResultStatus = result;
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

        #region LandingPageLevel
        public LandingPageLevelResponse GetLandingPageLevelFindBy(LandingPageLevelRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new LandingPageLevelResponse()
            {
                Errors = new BusinessErrors(),
                LandingPageLevelResult = new LandingPageLevelResult(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                LandingPageLevelResponse data = new LandingPageLevelResponse();
                var refData = data.LandingPageLevelResult;
                bussinessError.Add(_LandingPageLevelDao.GetLandingPageLevelFindBy(request, ref refData));
                response.LandingPageLevelResult = refData;
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

        public LandingPageLevelResponse GetLandingPageLevelList(LandingPageLevelRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new LandingPageLevelResponse()
            {
                Errors = new BusinessErrors(),
                LandingPageLevelResultList = new List<LandingPageLevelResult>(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                List<LandingPageLevelResult> refData = new List<LandingPageLevelResult>();
                bussinessError.Add(_LandingPageLevelDao.GetLandingPageLevelList(ref refData));
                response.LandingPageLevelResultList = refData;
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

        public LandingPageLevelResponse InsertLandingPageLevel(LandingPageLevelRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new LandingPageLevelResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_LandingPageLevelDao.InsertLandingPageLevel(request, ref result));
            }
            catch (Exception ex)
            {
                response.ResultStatus = result;
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

        public LandingPageLevelResponse UpdateLandingPageLevel(LandingPageLevelRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new LandingPageLevelResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_LandingPageLevelDao.UpdateLandingPageLevel(request, ref result));
            }
            catch (Exception ex)
            {
                response.ResultStatus = result;
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

        public LandingPageLevelResponse DeleteLandingPageLevel(LandingPageLevelRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new LandingPageLevelResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_LandingPageLevelDao.DeleteLandingPageLevel(request, ref result));
            }
            catch (Exception ex)
            {
                response.ResultStatus = result;
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

        #region LandingPageLevelProperty
        public LandingPageLevelPropertyResponse GetLandingPageLevelPropertyFindBy(LandingPageLevelPropertyRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new LandingPageLevelPropertyResponse()
            {
                Errors = new BusinessErrors(),
                LandingPageLevelPropertyResult = new LandingPageLevelPropertyResult(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                LandingPageLevelPropertyResponse data = new LandingPageLevelPropertyResponse();
                var refData = data.LandingPageLevelPropertyResult;
                bussinessError.Add(_LandingPageLevelPropertyDao.GetLandingPageLevelPropertyFindBy(request, ref refData));
                response.LandingPageLevelPropertyResult = refData;
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

        public LandingPageLevelPropertyResponse GetLandingPageLevelPropertyList(LandingPageLevelPropertyRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new LandingPageLevelPropertyResponse()
            {
                Errors = new BusinessErrors(),
                LandingPageLevelPropertyResultList = new List<LandingPageLevelPropertyResult>(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                List<LandingPageLevelPropertyResult> refData = new List<LandingPageLevelPropertyResult>();
                bussinessError.Add(_LandingPageLevelPropertyDao.GetLandingPageLevelPropertyList(ref refData));
                response.LandingPageLevelPropertyResultList = refData;
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

        public LandingPageLevelPropertyResponse InsertLandingPageLevelProperty(LandingPageLevelPropertyRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new LandingPageLevelPropertyResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_LandingPageLevelPropertyDao.InsertLandingPageLevelProperty(request, ref result));
            }
            catch (Exception ex)
            {
                response.ResultStatus = result;
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

        public LandingPageLevelPropertyResponse UpdateLandingPageLevelProperty(LandingPageLevelPropertyRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new LandingPageLevelPropertyResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_LandingPageLevelPropertyDao.UpdateLandingPageLevelProperty(request, ref result));
            }
            catch (Exception ex)
            {
                response.ResultStatus = result;
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

        public LandingPageLevelPropertyResponse DeleteLandingPageLevelProperty(LandingPageLevelPropertyRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new LandingPageLevelPropertyResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_LandingPageLevelPropertyDao.DeleteLandingPageLevelProperty(request, ref result));
            }
            catch (Exception ex)
            {
                response.ResultStatus = result;
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

        #region Biodata
        public BiodataResponse GetBiodataFindBy(BiodataRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new BiodataResponse()
            {
                Errors = new BusinessErrors(),
                BiodataResult = new BiodataResult(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                BiodataResponse data = new BiodataResponse();
                var refData = data.BiodataResult;
                bussinessError.Add(_BiodataDao.GetBiodataFindBy(request, ref refData));
                response.BiodataResult = refData;
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

        public BiodataResponse GetBiodataList(BiodataRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new BiodataResponse()
            {
                Errors = new BusinessErrors(),
                BiodataResultList = new List<BiodataResult>(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                List<BiodataResult> refData = new List<BiodataResult>();
                bussinessError.Add(_BiodataDao.GetBiodataList(ref refData));
                response.BiodataResultList = refData;
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

        public BiodataResponse InsertBiodata(BiodataRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new BiodataResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_BiodataDao.InseBiodataBiodata(request, ref result));
            }
            catch (Exception ex)
            {
                response.ResultStatus = result;
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

        public BiodataResponse UpdateBiodata(BiodataRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new BiodataResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_BiodataDao.UpdateBiodata(request, ref result));
            }
            catch (Exception ex)
            {
                response.ResultStatus = result;
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

        public BiodataResponse DeleteBiodata(BiodataRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new BiodataResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_BiodataDao.DeleteBiodata(request, ref result));
            }
            catch (Exception ex)
            {
                response.ResultStatus = result;
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

        public BiodataResponse GetBiodataByNik(BiodataRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new BiodataResponse()
            {
                Errors = new BusinessErrors(),
                BiodataResultList = new List<BiodataResult>(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                List<BiodataResult> refData = new List<BiodataResult>();
                bussinessError.Add(_BiodataDao.GetBiodataByNik(request, ref refData));
                response.BiodataResultList = refData;
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



        #endregion

        #region Testimoni
        public TestimoniResponse GetTestimoniFindBy(TestimoniRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new TestimoniResponse()
            {
                Errors = new BusinessErrors(),
                TestimoniResult = new TestimoniResult(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                TestimoniResponse data = new TestimoniResponse();
                var refData = data.TestimoniResult;
                bussinessError.Add(_TestimoniDao.GetTestimoniFindBy(request, ref refData));
                response.TestimoniResult = refData;
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

        public TestimoniResponse GetTestimoniList(TestimoniRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new TestimoniResponse()
            {
                Errors = new BusinessErrors(),
                TestimoniResultList = new List<TestimoniResult>(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                List<TestimoniResult> refData = new List<TestimoniResult>();
                bussinessError.Add(_TestimoniDao.GetTestimoniList(ref refData));
                response.TestimoniResultList = refData;
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

        public TestimoniResponse InsertTestimoni(TestimoniRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new TestimoniResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_TestimoniDao.InsertTestimoni(request, ref result));
            }
            catch (Exception ex)
            {
                response.ResultStatus = result;
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

        public TestimoniResponse UpdateTestimoni(TestimoniRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new TestimoniResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_TestimoniDao.UpdateTestimoni(request, ref result));
            }
            catch (Exception ex)
            {
                response.ResultStatus = result;
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

        public TestimoniResponse DeleteTestimoni(TestimoniRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new TestimoniResponse()
            {
                Errors = new BusinessErrors(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                bussinessError.Add(_TestimoniDao.DeleteTestimoni(request, ref result));
            }
            catch (Exception ex)
            {
                response.ResultStatus = result;
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

        public TestimoniResponse GetTestimoniByIdRw(TestimoniRequest request)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            var response = new TestimoniResponse()
            {
                Errors = new BusinessErrors(),
                TestimoniResultList = new List<TestimoniResult>(),
            };

            try
            {
                _functionLog.WriteFunctionLog(_serviceName, method, 1, LogData.LOG_TYPE.begin);
                List<TestimoniResult> refData = new List<TestimoniResult>();
                bussinessError.Add(_TestimoniDao.GetTestimoniByIdRw(request, ref refData));
                response.TestimoniResultList = refData;
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



        #endregion


        #endregion

    }
}
