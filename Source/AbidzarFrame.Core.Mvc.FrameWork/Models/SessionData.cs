using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Reflection;
using AbidzarFrame.Core.Mvc.Helpers;

namespace AbidzarFrame.Core.Mvc.Models
{
    public class SessionData : IDisposable
    {
        //private IntPtr handle;
        private bool disposed = false;
        private Object data = null;

        public Object Data
        {
            get
            {
                return data;
            }
            set
            {
                data = value;

                //data = value;
                //GCHandle _handle = GCHandle.Alloc(data, GCHandleType.Pinned);
                //handle = GCHandle.ToIntPtr(_handle);
            }
        }

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
                    Utility.ClearObject(ref data);
                    data = null;

                    //try
                    //{
                    //    CloseHandle(handle);
                    //}
                    //catch (Exception e)
                    //{
                    //    String a = e.Message;
                    //};
                    //handle = IntPtr.Zero;

                    disposed = true;
                }
                
            }
        }

        //[System.Runtime.InteropServices.DllImport("Kernel32")]
        //private extern static Boolean CloseHandle(IntPtr handle);

        ~SessionData() {
            Dispose(false);

            Utility.ClearObject(ref data);
            data = null;
        }
    }

}
