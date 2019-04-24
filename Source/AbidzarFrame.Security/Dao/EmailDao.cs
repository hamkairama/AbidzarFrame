using AbidzarFrame.Core.Model.Business;
using AbidzarFrame.Domain.Common;
using AbidzarFrame.Mvc.Infrastructures.Mapping;
using AbidzarFrame.Security.Interface.Dto;
using AbidzarFrame.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net.Mail;
using System.Net.Mime;
using System.Reflection;

namespace AbidzarFrame.Security.Dao
{
    public class EmailDao
    {
        private readonly ErrorHandler _errHand;
        private readonly FunctionLog _logger;
        private readonly IDbConnFactory conFactory;
        private string serviceName = "SecurityService";
        internal EmailDao()
        {
            conFactory = new SqlDb();
            _errHand = new ErrorHandler();
            _logger = new FunctionLog();
        }

        private IDbConnFactory _dbSql { get { return conFactory; } }

        public BusinessErrors SendEmail(EmailRequest request, ref ResultStatus result)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors messageResult = new BusinessErrors();
            MailMessage mail = new MailMessage();

            try
            {
                mail = MappingEmail(request);
                result = SendEmail(mail, request.Attachment);
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
            }

            return messageResult;
        }

        private ResultStatus SendEmail(MailMessage mail, string attachment)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            ResultStatus rs = new ResultStatus();
            SmtpClient client = new SmtpClient();

            try
            {
                if (attachment != null && attachment != "")
                {
                    FileStream fs = new FileStream(attachment, FileMode.Open, FileAccess.Read);
                    string fileName = StringUtils.GetFileName(attachment);
                    Attachment a = new Attachment(fs, fileName, MediaTypeNames.Application.Octet);

                    mail.Attachments.Add(a);
                }

                client.Send(mail);
                rs.SetSuccessStatus("Email has been sent");
            }
            catch (Exception ex)
            {
                rs.SetErrorStatus(ex.Message);
                _logger.WriteFunctionException(serviceName, method, 2, ref ex, mail.To, mail.To.GetType());
            }

            return rs;
        }

        private MailMessage MappingEmail(EmailRequest customMail)
        {
            MailMessage mail = new MailMessage();
            if (customMail.From != null)
            {
                foreach (var from in customMail.From)
                {
                    mail.From = new MailAddress(from, "AbidzarFrame");
                }
            }          

            foreach (var to in customMail.To)
            {
                mail.To.Add(new MailAddress(to));
            }

            if (customMail.Cc != null)
            {
                foreach (var cc in customMail.Cc)
                {
                    mail.CC.Add(new MailAddress(cc));
                }
            }

            mail.Subject = customMail.Subject;
            mail.IsBodyHtml = true;
            mail.Body = customMail.Body;

            return mail;
        }

        public BusinessErrors GetEmailTemplateFindBy(EmailRequest request, ref EmailResult emilResult)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors messageResult = new BusinessErrors();
            IDbConnection conn = null;
            DataTable dt = new DataTable();
            try
            {
                conn = _dbSql.CreateConnection();
                IDbCommand cmd = _dbSql.CreateCommand(ref conn, CommandType.StoredProcedure, "SpEmailTemplateSelect");
                cmd.Parameters.Add(_dbSql.CreateInputParameter("@KodeTemplate", request.KodeTemplate));

                cmd.CommandTimeout = 3600;
                cmd.ExecuteNonQuery();
                dt = _dbSql.OpenDataTable(ref cmd);
                if (dt.Rows.Count > 0)
                {
                    emilResult = ModelMapper.FillModelFromDatatable<EmailResult>(dt)[0];

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

    }
}
