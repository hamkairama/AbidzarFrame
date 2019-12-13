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
    public class KtpDao
    {
        private readonly ErrorHandler _errHand;
        private readonly FunctionLog _logger;
        private readonly IDbConnFactory conFactory;
        private string serviceName = "KtpService";

        internal KtpDao()
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

        public BusinessErrors GetKtpFindBy(KtpRequest request, ref KtpResult KtpResult)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors messageResult = new BusinessErrors();
            IDbConnection conn = null;
            DataTable dt = new DataTable();
            try
            {
                conn = _dbSql.CreateConnection();
                IDbCommand cmd = _dbSql.CreateCommand(ref conn, CommandType.StoredProcedure, "SpKtpSelect");
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@Id", request.Id));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@Nik", request.Nik));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@KodeRt", request.KodeRt));

                cmd.CommandTimeout = 3600;
                cmd.ExecuteNonQuery();
                dt = _dbSql.OpenDataTable(ref cmd);
                if (dt.Rows.Count > 0)
                {
                    KtpResult = ModelMapper.FillModelFromDatatable<KtpResult>(dt)[0];
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

        public BusinessErrors GetKtpList(KtpRequest request, ref List<KtpResult> KtpResultList)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors messageResult = new BusinessErrors();
            IDbConnection conn = null;
            List<KtpResult> listKtp = new List<KtpResult>();
            DataTable dt = new DataTable();
            try
            {
                conn = _dbSql.CreateConnection();
                IDbCommand cmd = _dbSql.CreateCommand(ref conn, CommandType.StoredProcedure, "SpKtpSelect");
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@Id", 0));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@Nik", request.Nik));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@KodeRt", request.KodeRt));

                cmd.CommandTimeout = 3600;
                cmd.ExecuteNonQuery();
                dt = _dbSql.OpenDataTable(ref cmd);
                if (dt.Rows.Count > 0)
                {
                    listKtp = ModelMapper.FillModelFromDatatable<KtpResult>(dt);
                }
                KtpResultList = listKtp;
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

        public BusinessErrors GetKtpListBy(KtpRequest request, ref List<KtpResult> KtpResultList)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors messageResult = new BusinessErrors();
            IDbConnection conn = null;
            List<KtpResult> listKtp = new List<KtpResult>();
            DataTable dt = new DataTable();
            try
            {
                conn = _dbSql.CreateConnection();
                IDbCommand cmd = _dbSql.CreateCommand(ref conn, CommandType.StoredProcedure, "SpKtpSelectBy");
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@Nik", request.Nik));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@Nama", request.Nama));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@KodeRt", request.KodeRt));

                cmd.CommandTimeout = 3600;
                cmd.ExecuteNonQuery();
                dt = _dbSql.OpenDataTable(ref cmd);
                if (dt.Rows.Count > 0)
                {
                    listKtp = ModelMapper.FillModelFromDatatable<KtpResult>(dt);
                }
                KtpResultList = listKtp;
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


        public BusinessErrors InsertKtp(KtpRequest request, ref ResultStatus result)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors messageResult = new BusinessErrors();
            IDbConnection conn = null;
            List<KtpResult> listKtp = new List<KtpResult>();
            try
            {
                conn = _dbSql.CreateConnection();
                IDbCommand cmd = _dbSql.CreateCommand(ref conn, CommandType.StoredProcedure, "SpKtpInsert");
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@Nik", request.Nik));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@Nama", request.Nama));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@TempatLahir", request.TempatLahir));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@TanggalLahir", request.TanggalLahir));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@IdJenisKelamin", request.IdJenisKelamin));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@Alamat", request.Alamat));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@IdKelurahan", request.IdKelurahan));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@Rt", request.Rt));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@Rw", request.Rw));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@IdAgama", request.IdAgama));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@IdStatusPerkawinan", request.IdStatusPerkawinan));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@TanggalPerkawinan", request.TanggalPerkawinan));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@IdJenisPekerjaan", request.IdJenisPekerjaan));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@IdKewarganegaraan", request.IdKewarganegaraan));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@IdGolonganDarah", request.IdGolonganDarah));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@IdPendidikan", request.IdPendidikan));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@IdPhotoKtp", request.IdPhotoKtp));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@IdSignatureKtp", request.IdSignatureKtp));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@KodePos", request.KodePos));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@NamaAyah", request.NamaAyah));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@NamaIbu", request.NamaIbu));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@DibuatOleh", request.DibuatOleh));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@KodeRt", request.KodeRt));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@Kk", request.Kk));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@IdKelurahanTinggal", request.IdKelurahanTinggal));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@RwTinggal", request.RwTinggal));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@RtTinggal", request.RtTinggal));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@AlamatTinggal", request.AlamatTinggal));
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

        public BusinessErrors UpdateKtp(KtpRequest request, ref ResultStatus result)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors messageResult = new BusinessErrors();
            IDbConnection conn = null;
            List<KtpResult> listKtp = new List<KtpResult>();
            try
            {
                conn = _dbSql.CreateConnection();
                IDbCommand cmd = _dbSql.CreateCommand(ref conn, CommandType.StoredProcedure, "SpKtpUpdate");
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@Id", request.Id));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@Nik", request.Nik));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@Nama", request.Nama));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@TempatLahir", request.TempatLahir));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@TanggalLahir", request.TanggalLahir));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@IdJenisKelamin", request.IdJenisKelamin));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@Alamat", request.Alamat));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@IdKelurahan", request.IdKelurahan));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@Rt", request.Rt));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@Rw", request.Rw));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@IdAgama", request.IdAgama));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@IdStatusPerkawinan", request.IdStatusPerkawinan));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@TanggalPerkawinan", request.TanggalPerkawinan));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@IdJenisPekerjaan", request.IdJenisPekerjaan));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@IdKewarganegaraan", request.IdKewarganegaraan));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@IdGolonganDarah", request.IdGolonganDarah));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@IdPendidikan", request.IdPendidikan));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@IdPhotoKtp", request.IdPhotoKtp));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@IdSignatureKtp", request.IdSignatureKtp));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@KodePos", request.KodePos));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@NamaAyah", request.NamaAyah));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@NamaIbu", request.NamaIbu));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@Kk", request.Kk));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@AlamatTinggal", request.AlamatTinggal));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@IdKelurahanTinggal", request.IdKelurahanTinggal));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@RtTinggal", request.RtTinggal));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@RwTinggal", request.RwTinggal));
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

        public BusinessErrors DeleteKtp(KtpRequest request, ref ResultStatus result)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors messageResult = new BusinessErrors();
            IDbConnection conn = null;
            List<KtpResult> listKtp = new List<KtpResult>();
            try
            {
                conn = _dbSql.CreateConnection();
                IDbCommand cmd = _dbSql.CreateCommand(ref conn, CommandType.StoredProcedure, "SpKtpDelete");
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
