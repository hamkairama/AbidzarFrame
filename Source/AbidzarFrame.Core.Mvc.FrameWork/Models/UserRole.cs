using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace AbidzarFrame.Core.Mvc.Models
{
    public class UserRole: IDisposable
    {

        protected String _role = null;
        protected String _controller = null;
        protected String _action = null;

        [XmlAttribute("Role")]
        public String Role
        {
            get
            {
                return _role;
            }
            set
            {
                _role = value;
            }
        }

        [XmlAttribute("Controller")]
        public String Controller
        {
            get
            {
                return _controller;
            }
            set
            {
                _controller = value;
            }
        }

        [XmlAttribute("Action")]
        public String Action
        {
            get
            {
                return _action;
            }
            set
            {
                _action = value;
            }
        }

        public bool isMatched(String userRole, String controller, String action)
        {
            bool matched = true;
            matched = matched && (userRole.Equals(_role) || "*".Equals(_role));
            matched = matched && (controller.Equals(_controller) || "*".Equals(_controller));
            matched = matched && (action.Equals(_action) || "*".Equals(_action));
            return matched;
        }

        public override bool Equals(object obj)
        {
            if (obj != null)
            {
                if (this.GetType().Equals(obj.GetType()))
                {
                    UserRole other = (UserRole)obj;
                    return isMatched(other._role, other._controller, other._action);
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            //int hash = 13;
            //hash = (hash * 7) + this.Role.GetHashCode();
            //hash = (hash * 7) + this.Controller.GetHashCode();
            //hash = (hash * 7) + this.Action.GetHashCode();
            //return hash;
            return new { @A = this.Role, @B = this.Controller, @C = this.Action }.GetHashCode();
        }

            private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this._action = null;
                    this._controller = null;
                    this._role = null;
                }
                
            }
        }

        ~UserRole()
        {
            Dispose(false);

            this._action = null;
            this._controller = null;
            this._role = null;
        }
    }
}
