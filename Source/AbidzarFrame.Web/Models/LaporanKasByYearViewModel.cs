using AbidzarFrame.Security.Interface.Dto;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbidzarFrame.Web.Models
{   
    public class LaporanKasByYearViewModel
    {
        public string IdUser { get; set; }
        public string NamaUser { get; set; }
        public MenuResponse MenuResponse { get; set; }
    }
}