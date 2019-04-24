using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AbidzarFrame.Domain.Common
{
    [DataContract]
    [Serializable]
    public class ResultStatus
    {
        #region Private Variables
        [DataMember(Name = "Status")]
        private int _status = -1;

        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }

        [DataMember(Name = "MessageText")]
        private string _messageText;


        public string MessageText
        {
            get { return _messageText; }
            set { _messageText = value; }
        }

        #endregion

        #region Constructors/Destructors/Finalisers
        public ResultStatus()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public ResultStatus(ValidationResult validations)
        {
            //StringBuilder mess = new StringBuilder();
            //if (validations.IsValid)
            //    _status = 0;
            //else
            //{
            //    foreach (ValidationResult val in validations)
            //    {
            //        mess.Append(val.Message + '\n');
            //    }
            //    _messageText = mess.ToString();
            //}
        }

        public ResultStatus(Exception ex, string message)
        {
            //TODO log ex.Message 
            //if (!(ex is DataAlreadyExistException ||
            //            ex is ConcurrencyException ||
            //            ex.InnerException is DataAlreadyExistException ||
            //            ex.InnerException is ConcurrencyException))
            //{
            //    ExceptionPolicy.HandleException(ex, "Facade Policy");
            //}
            //_messageText = message;
            //_status = -1;
        }
        #endregion

        #region Public Methods and Properties
        public bool IsSuccess
        {
            get
            {
                return Status == 0;
            }
        }


        public void SetSuccessStatus(string message)
        {
            Status = 0;
            _messageText = message;
        }

        public void SetSuccessStatus()
        {
            Status = 0;
        }

        public void SetErrorStatus(string message)
        {
            Status = -1;
            _messageText = message;
        }
        #endregion
    }
}
