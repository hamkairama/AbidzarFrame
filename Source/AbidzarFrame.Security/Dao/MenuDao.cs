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
   public class MenuDao
    {
        private readonly ErrorHandler _errHand;
        private readonly FunctionLog _logger;
        private readonly IDbConnFactory conFactory;
        private string serviceName = "SecurityService";
        internal MenuDao()
        {
            conFactory = new SqlDb();
            _errHand = new ErrorHandler();
            _logger = new FunctionLog();
        }

        private IDbConnFactory _dbSql { get { return conFactory; } }

        public BusinessErrors GetMenuAccessRight(MenuRequest request, ref List<MenuResult> MenuResultList)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors messageResult = new BusinessErrors();
            IDbConnection conn = null;
            List<MenuResult> listMenu = new List<MenuResult>();
            DataTable dt = new DataTable();
            try
            {
                conn = _dbSql.CreateConnection();
                IDbCommand cmd = _dbSql.CreateCommand(ref conn, CommandType.StoredProcedure, "SpMenuAccessRight");
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@Nik", request.Nik));
                cmd.ExecuteNonQuery();
                dt = _dbSql.OpenDataTable(ref cmd);
                if (dt.Rows.Count > 0)
                {
                    listMenu = ModelMapper.FillModelFromDatatable<MenuResult>(dt);
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

        public BusinessErrors GetMenuFindBy(MenuRequest request, ref MenuResult MenuResult)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors messageResult = new BusinessErrors();
            IDbConnection conn = null;
            DataTable dt = new DataTable();
            try
            {
                conn = _dbSql.CreateConnection();
                IDbCommand cmd = _dbSql.CreateCommand(ref conn, CommandType.StoredProcedure, "SpMenuSelect");
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@Id", request.Id));

                cmd.CommandTimeout = 3600;
                cmd.ExecuteNonQuery();
                dt = _dbSql.OpenDataTable(ref cmd);
                if (dt.Rows.Count > 0)
                {
                    MenuResult = ModelMapper.FillModelFromDatatable<MenuResult>(dt)[0];
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

        public BusinessErrors GetMenuList(MenuRequest request, ref List<MenuResult> MenuResultList)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors messageResult = new BusinessErrors();
            IDbConnection conn = null;
            List<MenuResult> listMenu = new List<MenuResult>();
            DataTable dt = new DataTable();
            try
            {
                conn = _dbSql.CreateConnection();
                IDbCommand cmd = _dbSql.CreateCommand(ref conn, CommandType.StoredProcedure, "SpMenuSelect");
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@Id", 0));

                cmd.ExecuteNonQuery();
                dt = _dbSql.OpenDataTable(ref cmd);
                if (dt.Rows.Count > 0)
                {
                    listMenu = ModelMapper.FillModelFromDatatable<MenuResult>(dt);
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

        public BusinessErrors InsertMenu(MenuRequest request, ref ResultStatus result)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors messageResult = new BusinessErrors();
            IDbConnection conn = null;
            List<MenuResult> listMenu = new List<MenuResult>();
            try
            {
                conn = _dbSql.CreateConnection();
                IDbCommand cmd = _dbSql.CreateCommand(ref conn, CommandType.StoredProcedure, "SpMenuInsert");
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@NamaMenu", request.NamaMenu));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@ParentId", request.ParentId));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@NamaParent", request.NamaParent));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@NamaIcon", request.NamaIcon));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@MenuArea", request.MenuArea));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@MenuController", request.MenuController));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@MenuAction", request.MenuAction));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@MenuLink", request.MenuLink));
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

        public BusinessErrors UpdateMenu(MenuRequest request, ref ResultStatus result)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors messageResult = new BusinessErrors();
            IDbConnection conn = null;
            List<MenuResult> listMenu = new List<MenuResult>();
            try
            {
                conn = _dbSql.CreateConnection();
                IDbCommand cmd = _dbSql.CreateCommand(ref conn, CommandType.StoredProcedure, "SpMenuUpdate");
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@Id", request.Id));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@NamaMenu", request.NamaMenu));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@ParentId", request.ParentId));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@NamaParent", request.NamaParent));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@NamaIcon", request.NamaIcon));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@MenuArea", request.MenuArea));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@MenuController", request.MenuController));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@MenuAction", request.MenuAction));
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@MenuLink", request.MenuLink));
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

        public BusinessErrors DeleteMenu(MenuRequest request, ref ResultStatus result)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors messageResult = new BusinessErrors();
            IDbConnection conn = null;
            List<MenuResult> listMenu = new List<MenuResult>();
            try
            {
                conn = _dbSql.CreateConnection();
                IDbCommand cmd = _dbSql.CreateCommand(ref conn, CommandType.StoredProcedure, "SpMenuDelete");
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
