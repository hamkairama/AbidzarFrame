using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace AbidzarFrame.Core.Mvc.Models
{
    [Serializable()]
    public class UserRoles: IDisposable
    {

        private List<String> _roleList = new List<String>();
        public List<String> RoleList
        {
            get
            {
                return _roleList;
            }
            set
            {
                _roleList = value;
            }
        }

        private List<UserRole> _rightList = new List<UserRole>();
        public List<UserRole> RightList
        {
            get
            {
                return _rightList;
            }
            set
            {
                _rightList = value;
            }
        }

        private List<String> _sitemap = new List<String>();
        public List<String> Sitemap
        {
            get
            {
                return _sitemap;
            }
            set
            {
                _sitemap = value;
            }
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
                    this._rightList.Clear();
                    this._roleList.Clear();
                    this._sitemap.Clear();

                    this._rightList = null;
                    this._roleList = null;
                    this._sitemap = null;
                }
                
            }
        }

        ~UserRoles()
        {
            Dispose(false);

            this._rightList.Clear();
            this._roleList.Clear();
            this._sitemap.Clear();

            this._rightList = null;
            this._roleList = null;
            this._sitemap = null;
        }
    }
}
