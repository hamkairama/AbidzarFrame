using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbidzarFrame.Core.Mvc.Models
{
    public class SystemAccessRecord
    {

        private String sessionId = null;
        private DateTime accessTime = DateTime.MinValue;

        public SystemAccessRecord(String sessionId, DateTime t)
        {
            this.sessionId = sessionId;
            this.accessTime = t;
        }

        public SystemAccessRecord() : this(null, DateTime.MinValue) { }

        public String SessionId
        {
            get
            {
                return sessionId;
            }
            set
            {
                sessionId = value;
            }
        }

        public DateTime AccessTime
        {
            get
            {
                return accessTime;
            }
            set
            {
                accessTime = value;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            else
            {
                if (obj.GetType().Equals(typeof(SystemAccessRecord)))
                {
                    return (((SystemAccessRecord)obj).sessionId.Equals(this.sessionId));
                }
                else
                {
                    return false;
                }
            }
        }

    }
}
