﻿using AbidzarFrame.Core.Model.Business;
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
    public class ProvinsiDao
    {
        private readonly ErrorHandler _errHand;
        private readonly FunctionLog _logger;
        private readonly IDbConnFactory conFactory;
        private string serviceName = "ProvinsiService";

        internal ProvinsiDao()
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

        public BusinessErrors GetProvinsiFindBy(ProvinsiRequest request, ref ProvinsiResult ProvinsiResult)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors messageResult = new BusinessErrors();
            IDbConnection conn = null;
            DataTable dt = new DataTable();
            try
            {
                conn = _dbSql.CreateConnection();
                IDbCommand cmd = _dbSql.CreateCommand(ref conn, CommandType.StoredProcedure, "SpProvinsiSelect");
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@Id", request.Id));

                cmd.CommandTimeout = 3600;
                cmd.ExecuteNonQuery();
                dt = _dbSql.OpenDataTable(ref cmd);
                if (dt.Rows.Count > 0)
                {
                    ProvinsiResult = ModelMapper.FillModelFromDatatable<ProvinsiResult>(dt)[0];
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

        public BusinessErrors GetProvinsiList(ref List<ProvinsiResult> ProvinsiResultList)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors messageResult = new BusinessErrors();
            IDbConnection conn = null;
            List<ProvinsiResult> listProvinsi = new List<ProvinsiResult>();
            DataTable dt = new DataTable();
            try
            {
                conn = _dbSql.CreateConnection();
                IDbCommand cmd = _dbSql.CreateCommand(ref conn, CommandType.StoredProcedure, "SpProvinsiSelect");
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@Id", 0));

                cmd.CommandTimeout = 3600;
                cmd.ExecuteNonQuery();
                dt = _dbSql.OpenDataTable(ref cmd);
                if (dt.Rows.Count > 0)
                {
                    listProvinsi = ModelMapper.FillModelFromDatatable<ProvinsiResult>(dt);
                }
                ProvinsiResultList = listProvinsi;
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


        public BusinessErrors InsertProvinsi(ProvinsiRequest request, ref ResultStatus result)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors messageResult = new BusinessErrors();
            IDbConnection conn = null;
            List<ProvinsiResult> listProvinsi = new List<ProvinsiResult>();
            try
            {
                conn = _dbSql.CreateConnection();
                IDbCommand cmd = _dbSql.CreateCommand(ref conn, CommandType.StoredProcedure, "SpProvinsiInsert");
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@NamaProvinsi", request.NamaProvinsi));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@KodeProvinsi", request.KodeProvinsi));
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

        public BusinessErrors UpdateProvinsi(ProvinsiRequest request, ref ResultStatus result)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors messageResult = new BusinessErrors();
            IDbConnection conn = null;
            List<ProvinsiResult> listProvinsi = new List<ProvinsiResult>();
            try
            {
                conn = _dbSql.CreateConnection();
                IDbCommand cmd = _dbSql.CreateCommand(ref conn, CommandType.StoredProcedure, "SpProvinsiUpdate");
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@Id", request.Id));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@NamaProvinsi", request.NamaProvinsi));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@KodeProvinsi", request.KodeProvinsi));
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

        public BusinessErrors DeleteProvinsi(ProvinsiRequest request, ref ResultStatus result)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors messageResult = new BusinessErrors();
            IDbConnection conn = null;
            List<ProvinsiResult> listProvinsi = new List<ProvinsiResult>();
            try
            {
                conn = _dbSql.CreateConnection();
                IDbCommand cmd = _dbSql.CreateCommand(ref conn, CommandType.StoredProcedure, "SpProvinsiDelete");
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
