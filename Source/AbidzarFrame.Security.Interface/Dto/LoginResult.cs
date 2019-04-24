using System;
using System.Runtime.Serialization;

namespace AbidzarFrame.Security.Interface.Dto
{
    [Serializable()]
    [DataContract()]
    public class LoginResult
    {
        [DataMember()]
        public string UserId { get; set; }

        [DataMember()]
        public string UserName { get; set; }

        [DataMember()]
        public string Password { get; set; }

        [DataMember()]
        public string Email { get; set; }

        [DataMember()]
        public string Departement { get; set; }

        [DataMember()]
        public string Flag { get; set; }

        [DataMember()]
        public bool IsLocked { get; set; }

        [DataMember()]
        public DateTime LockedDate { get; set; }
    }
}
