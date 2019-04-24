using AbidzarFrame.Domain.Models;
using System.Collections.Generic;

namespace AbidzarFrame.Web.Models
{
    public partial class DairyEventModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int SomeImportantKeyID { get; set; }
        public string StartDateString { get; set; }
        public string EndDateString { get; set; }
        public string StatusString { get; set; }
        public string StatusColor { get; set; }
        public string ClassName { get; set; }
    }
}