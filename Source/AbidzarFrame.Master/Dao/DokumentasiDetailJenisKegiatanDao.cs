using AbidzarFrame.Core.Model.Business;
using AbidzarFrame.Master.Interface.Dto;
using AbidzarFrame.Utils;
using AbidzarFrame.Mvc.Infrastructures.Mapping;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using AbidzarFrame.Domain.Common;

namespace AbidzarFrame.Master.Dao
{
    public class DokumentasiDetailJenisKegiatanDao
    {
        private readonly ErrorHandler _errHand;
        private readonly FunctionLog _logger;
        private readonly IDbConnFactory conFactory;
        private string serviceName = "DokumentasiDetailJenisKegiatanService";

        internal DokumentasiDetailJenisKegiatanDao()
        {
            conFactory = new SqlDb();
            _errHand = new ErrorHandler();
            _logger = new FunctionLog();
        }

        private IDbConnFactory _dbSql
        {
            get
            {
                return conFactory;
            }
        }

        public BusinessErrors GetDokumentasiDetailJenisKegiatanFindBy(DokumentasiDetailJenisKegiatanRequest request, ref DokumentasiDetailJenisKegiatanResult DokumentasiDetailJenisKegiatanResult)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors messageResult = new BusinessErrors();
            IDbConnection conn = null;
            DataTable dt = new DataTable();
            try
            {
                conn = _dbSql.CreateConnection();
                IDbCommand cmd = _dbSql.CreateCommand(ref conn, CommandType.StoredProcedure, "SpDokumentasiDetailJenisKegiatanSelect");
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@Id", request.Id));

                cmd.CommandTimeout = 3600;
                cmd.ExecuteNonQuery();
                dt = _dbSql.OpenDataTable(ref cmd);
                if (dt.Rows.Count > 0)
                {
                    DokumentasiDetailJenisKegiatanResult = ModelMapper.FillModelFromDatatable<DokumentasiDetailJenisKegiatanResult>(dt)[0];
                }
                cmd.Dispose();
            }
            catch (SqlException ex)
            {
                _logger.WriteFunctionException(serviceName, method, 2, ref ex, request, request.GetType());
                messageResult = _errHand.FillError(ex);
            }
            catch (Exception ex)
            {
                _logger.WriteFunctionException(serviceName, method, 2, ref ex, request, request.GetType());
                messageResult = _errHand.FillError(ex);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            return messageResult;
        }

        public BusinessErrors GetDokumentasiDetailJenisKegiatanList(ref List<DokumentasiDetailJenisKegiatanResult> DokumentasiDetailJenisKegiatanResultList)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors messageResult = new BusinessErrors();
            IDbConnection conn = null;
            List<DokumentasiDetailJenisKegiatanResult> listDokumentasiDetailJenisKegiatan = new List<DokumentasiDetailJenisKegiatanResult>();
            DataTable dt = new DataTable();
            try
            {
                conn = _dbSql.CreateConnection();
                IDbCommand cmd = _dbSql.CreateCommand(ref conn, CommandType.StoredProcedure, "SpDokumentasiDetailJenisKegiatanSelect");
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@Id", 0));

                cmd.CommandTimeout = 3600;
                cmd.ExecuteNonQuery();
                dt = _dbSql.OpenDataTable(ref cmd);
                if (dt.Rows.Count > 0)
                {
                    listDokumentasiDetailJenisKegiatan = ModelMapper.FillModelFromDatatable<DokumentasiDetailJenisKegiatanResult>(dt);
                }
                DokumentasiDetailJenisKegiatanResultList = listDokumentasiDetailJenisKegiatan;
                cmd.Dispose();
            }
            catch (SqlException ex)
            {
                _logger.WriteFunctionException(serviceName, method, 2, ref ex, "", typeof(string));
                messageResult = _errHand.FillError(ex);
            }
            catch (Exception ex)
            {
                _logger.WriteFunctionException(serviceName, method, 2, ref ex, "", typeof(string));
                messageResult = _errHand.FillError(ex);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            return messageResult;
        }

        public BusinessErrors GetDokumentasiDetailJenisKegiatanListByIdDetailJenisKegiatan(DokumentasiDetailJenisKegiatanRequest request, ref List<DokumentasiDetailJenisKegiatanResult> DokumentasiDetailJenisKegiatanResultList)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors messageResult = new BusinessErrors();
            IDbConnection conn = null;
            List<DokumentasiDetailJenisKegiatanResult> listDokumentasiDetailJenisKegiatan = new List<DokumentasiDetailJenisKegiatanResult>();
            DataTable dt = new DataTable();
            try
            {
                conn = _dbSql.CreateConnection();
                IDbCommand cmd = _dbSql.CreateCommand(ref conn, CommandType.StoredProcedure, "SpDokumentasiDetailJenisKegiatanSelectByIdDetailJenisKegiatan");
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@IdDetailJenisKegiatan", request.IdDetailJenisKegiatan));

                cmd.CommandTimeout = 3600;
                cmd.ExecuteNonQuery();
                dt = _dbSql.OpenDataTable(ref cmd);
                if (dt.Rows.Count > 0)
                {
                    listDokumentasiDetailJenisKegiatan = ModelMapper.FillModelFromDatatable<DokumentasiDetailJenisKegiatanResult>(dt);
                }
                DokumentasiDetailJenisKegiatanResultList = listDokumentasiDetailJenisKegiatan;
                cmd.Dispose();
            }
            catch (SqlException ex)
            {
                _logger.WriteFunctionException(serviceName, method, 2, ref ex, "", typeof(string));
                messageResult = _errHand.FillError(ex);
            }
            catch (Exception ex)
            {
                _logger.WriteFunctionException(serviceName, method, 2, ref ex, "", typeof(string));
                messageResult = _errHand.FillError(ex);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            return messageResult;
        }


        public BusinessErrors InsertDokumentasiDetailJenisKegiatan(DokumentasiDetailJenisKegiatanRequest request, ref ResultStatus result)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors messageResult = new BusinessErrors();
            IDbConnection conn = null;
            List<DokumentasiDetailJenisKegiatanResult> listDokumentasiDetailJenisKegiatan = new List<DokumentasiDetailJenisKegiatanResult>();
            try
            {
                conn = _dbSql.CreateConnection();
                IDbCommand cmd = _dbSql.CreateCommand(ref conn, CommandType.StoredProcedure, "SpDokumentasiDetailJenisKegiatanInsert");
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@IdDetailJenisKegiatan", request.IdDetailJenisKegiatan));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@NamaFile", request.NamaFile));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@DibuatOleh", request.DibuatOleh));
                cmd.ExecuteNonQuery();

                result.SetSuccessStatus();
                cmd.Dispose();
            }
            catch (SqlException ex)
            {
                result.SetErrorStatus(ex.Message);
                _logger.WriteFunctionException(serviceName, method, 2, ref ex, request, request.GetType());
                messageResult = _errHand.FillError(ex);
            }
            catch (Exception ex)
            {
                result.SetErrorStatus(ex.Message);
                _logger.WriteFunctionException(serviceName, method, 2, ref ex, request, request.GetType());
                messageResult = _errHand.FillError(ex);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            return messageResult;
        }

        public BusinessErrors UpdateDokumentasiDetailJenisKegiatan(DokumentasiDetailJenisKegiatanRequest request, ref ResultStatus result)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors messageResult = new BusinessErrors();
            IDbConnection conn = null;
            List<DokumentasiDetailJenisKegiatanResult> listDokumentasiDetailJenisKegiatan = new List<DokumentasiDetailJenisKegiatanResult>();
            try
            {
                conn = _dbSql.CreateConnection();
                IDbCommand cmd = _dbSql.CreateCommand(ref conn, CommandType.StoredProcedure, "SpDokumentasiDetailJenisKegiatanUpdate");
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@Id", request.Id));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@IdDetailJenisKegiatan", request.IdDetailJenisKegiatan));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@NamaFile", request.NamaFile));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@DieditOleh", request.DieditOleh));
                cmd.ExecuteNonQuery();

                result.SetSuccessStatus();
                cmd.Dispose();
            }
            catch (SqlException ex)
            {
                result.SetErrorStatus(ex.Message);
                _logger.WriteFunctionException(serviceName, method, 2, ref ex, request, request.GetType());
                messageResult = _errHand.FillError(ex);
            }
            catch (Exception ex)
            {
                result.SetErrorStatus(ex.Message);
                _logger.WriteFunctionException(serviceName, method, 2, ref ex, request, request.GetType());
                messageResult = _errHand.FillError(ex);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            return messageResult;
        }

        public BusinessErrors DeleteDokumentasiDetailJenisKegiatan(DokumentasiDetailJenisKegiatanRequest request, ref ResultStatus result)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors messageResult = new BusinessErrors();
            IDbConnection conn = null;
            List<DokumentasiDetailJenisKegiatanResult> listDokumentasiDetailJenisKegiatan = new List<DokumentasiDetailJenisKegiatanResult>();
            try
            {
                conn = _dbSql.CreateConnection();
                IDbCommand cmd = _dbSql.CreateCommand(ref conn, CommandType.StoredProcedure, "SpDokumentasiDetailJenisKegiatanDelete");
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@Id", request.Id));
                cmd.ExecuteNonQuery();

                result.SetSuccessStatus();
                cmd.Dispose();
            }
            catch (SqlException ex)
            {
                result.SetErrorStatus(ex.Message);
                _logger.WriteFunctionException(serviceName, method, 2, ref ex, request, request.GetType());
                messageResult = _errHand.FillError(ex);
            }
            catch (Exception ex)
            {
                result.SetErrorStatus(ex.Message);
                _logger.WriteFunctionException(serviceName, method, 2, ref ex, request, request.GetType());
                messageResult = _errHand.FillError(ex);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            return messageResult;
        }
        
    }
}
