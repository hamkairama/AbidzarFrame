using AbidzarFrame.Core.Model.Business;
using AbidzarFrame.Security.Interface.Dto;
using AbidzarFrame.Utils;
using AbidzarFrame.Mvc.Infrastructures.Mapping;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using AbidzarFrame.Domain.Common;

namespace AbidzarFrame.Security.Dao
{
    public class HistoricalUserLoginDao
    {
        private readonly ErrorHandler _errHand;
        private readonly FunctionLog _logger;
        private readonly IDbConnFactory conFactory;
        private string serviceName = "HistoricalUserLoginService";

        internal HistoricalUserLoginDao()
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

        public BusinessErrors GetHistoricalUserLoginFindBy(HistoricalUserLoginRequest request, ref HistoricalUserLoginResult HistoricalUserLoginResult)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors messageResult = new BusinessErrors();
            IDbConnection conn = null;
            DataTable dt = new DataTable();
            try
            {
                conn = _dbSql.CreateConnection();
                IDbCommand cmd = _dbSql.CreateCommand(ref conn, CommandType.StoredProcedure, "SpHistoricalUserLoginSelect");
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@Id", request.Id));

                cmd.CommandTimeout = 3600;
                cmd.ExecuteNonQuery();
                dt = _dbSql.OpenDataTable(ref cmd);
                if (dt.Rows.Count > 0)
                {
                    HistoricalUserLoginResult = ModelMapper.FillModelFromDatatable<HistoricalUserLoginResult>(dt)[0];
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

        public BusinessErrors GetHistoricalUserLoginList(ref List<HistoricalUserLoginResult> HistoricalUserLoginResultList)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors messageResult = new BusinessErrors();
            IDbConnection conn = null;
            List<HistoricalUserLoginResult> listHistoricalUserLogin = new List<HistoricalUserLoginResult>();
            DataTable dt = new DataTable();
            try
            {
                conn = _dbSql.CreateConnection();
                IDbCommand cmd = _dbSql.CreateCommand(ref conn, CommandType.StoredProcedure, "SpHistoricalUserLoginSelect");
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@Id", 0));

                cmd.CommandTimeout = 3600;
                cmd.ExecuteNonQuery();
                dt = _dbSql.OpenDataTable(ref cmd);
                if (dt.Rows.Count > 0)
                {
                    listHistoricalUserLogin = ModelMapper.FillModelFromDatatable<HistoricalUserLoginResult>(dt);
                }
                HistoricalUserLoginResultList = listHistoricalUserLogin;
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


        public BusinessErrors GetHistoricalUserLoginListByDate(HistoricalUserLoginRequest request, ref List<HistoricalUserLoginResult> HistoricalUserLoginResultList)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors messageResult = new BusinessErrors();
            IDbConnection conn = null;
            List<HistoricalUserLoginResult> listHistoricalUserLogin = new List<HistoricalUserLoginResult>();
            DataTable dt = new DataTable();
            try
            {
                conn = _dbSql.CreateConnection();
                IDbCommand cmd = _dbSql.CreateCommand(ref conn, CommandType.StoredProcedure, "SpHistoricalUserLoginSelectByDate");
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@Nik", request.Nik));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@Login", request.Login));

                cmd.CommandTimeout = 3600;
                cmd.ExecuteNonQuery();
                dt = _dbSql.OpenDataTable(ref cmd);
                if (dt.Rows.Count > 0)
                {
                    listHistoricalUserLogin = ModelMapper.FillModelFromDatatable<HistoricalUserLoginResult>(dt);
                }
                HistoricalUserLoginResultList = listHistoricalUserLogin;
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


        public BusinessErrors GetHistoricalUserLoginListByMonth(HistoricalUserLoginRequest request, ref List<HistoricalUserLoginResult> HistoricalUserLoginResultList)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors messageResult = new BusinessErrors();
            IDbConnection conn = null;
            List<HistoricalUserLoginResult> listHistoricalUserLogin = new List<HistoricalUserLoginResult>();
            DataTable dt = new DataTable();
            try
            {
                conn = _dbSql.CreateConnection();
                IDbCommand cmd = _dbSql.CreateCommand(ref conn, CommandType.StoredProcedure, "SpHistoricalUserLoginSelectByMonth");
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@Nik", request.Nik));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@Login", request.Login));

                cmd.CommandTimeout = 3600;
                cmd.ExecuteNonQuery();
                dt = _dbSql.OpenDataTable(ref cmd);
                if (dt.Rows.Count > 0)
                {
                    listHistoricalUserLogin = ModelMapper.FillModelFromDatatable<HistoricalUserLoginResult>(dt);
                }
                HistoricalUserLoginResultList = listHistoricalUserLogin;
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


        public BusinessErrors GetHistoricalUserLoginListByYear(HistoricalUserLoginRequest request, ref List<HistoricalUserLoginResult> HistoricalUserLoginResultList)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors messageResult = new BusinessErrors();
            IDbConnection conn = null;
            List<HistoricalUserLoginResult> listHistoricalUserLogin = new List<HistoricalUserLoginResult>();
            DataTable dt = new DataTable();
            try
            {
                conn = _dbSql.CreateConnection();
                IDbCommand cmd = _dbSql.CreateCommand(ref conn, CommandType.StoredProcedure, "SpHistoricalUserLoginSelectByYear");
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@Nik", request.Nik));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@Login", request.Login));

                cmd.CommandTimeout = 3600;
                cmd.ExecuteNonQuery();
                dt = _dbSql.OpenDataTable(ref cmd);
                if (dt.Rows.Count > 0)
                {
                    listHistoricalUserLogin = ModelMapper.FillModelFromDatatable<HistoricalUserLoginResult>(dt);
                }
                HistoricalUserLoginResultList = listHistoricalUserLogin;
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


        public BusinessErrors InsertHistoricalUserLogin(HistoricalUserLoginRequest request, ref ResultStatus result)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors messageResult = new BusinessErrors();
            IDbConnection conn = null;
            List<HistoricalUserLoginResult> listHistoricalUserLogin = new List<HistoricalUserLoginResult>();
            try
            {
                conn = _dbSql.CreateConnection();
                IDbCommand cmd = _dbSql.CreateCommand(ref conn, CommandType.StoredProcedure, "SpHistoricalUserLoginInsert");
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@Nik", request.Nik));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@Login", request.Login));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@Logout", null));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@IsMobile", request.IsMobile));
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

        public BusinessErrors UpdateHistoricalUserLogin(HistoricalUserLoginRequest request, ref ResultStatus result)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors messageResult = new BusinessErrors();
            IDbConnection conn = null;
            List<HistoricalUserLoginResult> listHistoricalUserLogin = new List<HistoricalUserLoginResult>();
            try
            {
                conn = _dbSql.CreateConnection();
                IDbCommand cmd = _dbSql.CreateCommand(ref conn, CommandType.StoredProcedure, "SpHistoricalUserLoginUpdate");
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@Id", request.Id));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@Nik", request.Nik));
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

        public BusinessErrors DeleteHistoricalUserLogin(HistoricalUserLoginRequest request, ref ResultStatus result)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors messageResult = new BusinessErrors();
            IDbConnection conn = null;
            List<HistoricalUserLoginResult> listHistoricalUserLogin = new List<HistoricalUserLoginResult>();
            try
            {
                conn = _dbSql.CreateConnection();
                IDbCommand cmd = _dbSql.CreateCommand(ref conn, CommandType.StoredProcedure, "SpHistoricalUserLoginDelete");
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
