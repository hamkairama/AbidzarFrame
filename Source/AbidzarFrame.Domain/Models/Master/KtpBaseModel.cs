using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AbidzarFrame.Domain.Models
{
    [Serializable()]
    [DataContract()]
    public abstract class KtpBaseModel : BaseModel
    {
        [DataMember()]
        [StringLength(16)]
        [Display(Name = "Nik")]
        [Required]
        public string Nik { get; set; }

        [DataMember()]
        [StringLength(100)]
        [Display(Name = "Nama")]
        [Required]
        public string Nama { get; set; }

        [DataMember()]
        [StringLength(100)]
        [Display(Name = "Tempat Lahir")]
        [Required]
        public string TempatLahir { get; set; }

        [DataMember()]
        [Display(Name = "Tanggal Lahir")]
        [Required]
        public System.DateTime TanggalLahir { get; set; }

        [DataMember()]
        [Display(Name = "Jenis Kelamin")]
        [Required]
        public int IdJenisKelamin { get; set; }

        [DataMember()]
        [StringLength(200)]
        [Display(Name = "Alamat")]
        [Required]
        public string Alamat { get; set; }

        [DataMember()]
        [Display(Name = "Kelurahan")]
        [Required]
        public int IdKelurahan { get; set; }

        [DataMember()]
        [StringLength(3)]
        [Display(Name = "RT")]
        [Required]
        public string Rt { get; set; }

        [DataMember()]
        [StringLength(3)]
        [Display(Name = "RW")]
        [Required]
        public string Rw { get; set; }

        [DataMember()]
        [Display(Name = "Agama")]
        [Required]
        public int IdAgama { get; set; }

        [DataMember()]
        [Display(Name = "Status Perkawinan")]
        [Required]
        public int IdStatusPerkawinan { get; set; }

        [DataMember()]
        [Display(Name = "Tanggal Perkawinan")]
        public DateTime TanggalPerkawinan { get; set; }

        [DataMember()]
        [Display(Name = "Pekerjaan")]
        [Required]
        public int IdJenisPekerjaan { get; set; }

        [DataMember()]
        [Display(Name = "Kewarganegaraan")]
        [Required]
        public int IdKewarganegaraan { get; set; }

        [DataMember()]
        [Display(Name = "Golongan Darah")]
        [Required]
        public int IdGolonganDarah { get; set; }

        [DataMember()]
        [Display(Name = "Pendidikan")]
        [Required]
        public int IdPendidikan { get; set; }

        [DataMember()]
        [Display(Name = "Photo")]
        //[Required]
        public Nullable<int> IdPhotoKtp { get; set; }


        [DataMember()]
        [Display(Name = "Tanda Tangan")]
        //[Required]
        public Nullable<int> IdSignatureKtp { get; set; }

        [DataMember()]
        [StringLength(5)]
        [Display(Name = "Kode Pos")]
        [Required]
        public string KodePos { get; set; }

        [DataMember()]
        [StringLength(100)]
        [Display(Name = "Nama Ayah")]
        [Required]
        public string NamaAyah { get; set; }

        [DataMember()]
        [StringLength(100)]
        [Display(Name = "Nama Ibu")]
        [Required]
        public string NamaIbu { get; set; }

        [DataMember()]
        public string JenisKelamin { get; set; }

        [DataMember()]
        public string NamaKelurahan { get; set; }

        [DataMember()]
        public string NamaAgama { get; set; }

        [DataMember()]
        public string StatusPerkawinan { get; set; }

        [DataMember()]
        public string JenisPekerjaan { get; set; }

        [DataMember()]
        public string JenisKewarganegaraan { get; set; }

        [DataMember()]
        public string GolonganDarah { get; set; }

        [DataMember()]
        public string Pendidikan { get; set; }

        [DataMember()]
        public string NamaFilePhoto { get; set; }

        [DataMember()]
        public string NamaFileSignature { get; set; }

        [DataMember()]
        public string NamaKecamatan { get; set; }

        [DataMember()]
        public string NamaKota { get; set; }

        [DataMember()]
        public string NamaProvinsi { get; set; }

        [DataMember()]
        [Display(Name = "Kota")]
        [Required]
        public int IdKota { get; set; }

        [DataMember()]
        [Display(Name = "Kecamatan")]
        [Required]
        public int IdKecamatan { get; set; }

        [DataMember()]
        public string Kk { get; set; }

    }
}
