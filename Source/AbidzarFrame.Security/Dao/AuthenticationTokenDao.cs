using AbidzarFrame.Core.Model.Business;
using AbidzarFrame.Domain.Common;
using AbidzarFrame.Mvc.Infrastructures.Mapping;
using AbidzarFrame.Security.Interface.Dto;
using AbidzarFrame.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace AbidzarFrame.Security.Dao
{
    public class AuthenticationTokenDao
    {
        private readonly ErrorHandler _errHand;
        private readonly FunctionLog _logger;
        private readonly IDbConnFactory conFactory;
        private string serviceName = "SecurityService";
        internal AuthenticationTokenDao()
        {
            conFactory = new SqlDb();
            _errHand = new ErrorHandler();
            _logger = new FunctionLog();
        }

        private IDbConnFactory _dbSql { get { return conFactory; } }

        public BusinessErrors GetAuthenticationToken(AuthenticationTokenRequest request, ref List<AuthenticationTokenResult> MenuResultList)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors messageResult = new BusinessErrors();
            IDbConnection conn = null;
            List<AuthenticationTokenResult> listMenu = new List<AuthenticationTokenResult>();
            DataTable dt = new DataTable();
            try
            {
                conn = _dbSql.CreateConnection();
                IDbCommand cmd = _dbSql.CreateCommand(ref conn, CommandType.StoredProcedure, "SpAutentikasiTokenSelect");
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@Aplikasi", request.Aplikasi));

                cmd.ExecuteNonQuery();
                dt = _dbSql.OpenDataTable(ref cmd);
                if (dt.Rows.Count > 0)
                {
                    listMenu = ModelMapper.FillModelFromDatatable<AuthenticationTokenResult>(dt);
                }
                MenuResultList = listMenu;
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


    }
}
