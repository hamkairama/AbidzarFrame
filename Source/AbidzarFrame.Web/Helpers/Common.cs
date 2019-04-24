using AbidzarFrame.Core.Model.Business;
using AbidzarFrame.Core.Mvc.Helpers;
using AbidzarFrame.Master.Interface.Dto;
using AbidzarFrame.Security.Interface.Dto;
using AbidzarFrame.Utils;
using AbidzarFrame.Web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace AbidzarFrame.Web.Helpers
{
    public class Common
    {
        #region Private Instance
    
        #endregion
        public static List<SlideShowResult> GetSlideShow(string kodeRt, int tipe, int posisi)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            string apiUrl = "api/SlideShow/GetSlideShowList";
            SlideShowRequest request = new SlideShowRequest();
            SlideShowResponse response = new SlideShowResponse();
            List<SlideShowResult> resultList = new List<SlideShowResult>();

            try
            {
                request.AuthenticationToken =  AuthenticationConfiguration.GetInstance().WebServiceAuthenticationToken;
                request.KodeRt = kodeRt;

                response = JsonConvert.DeserializeObject<SlideShowResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));
                if (!response.Errors.HasError)
                {
                    resultList = response.SlideShowResultList.Where(x => x.Tipe == tipe & x.Posisi == posisi).ToList();
                }
            }
            catch (Exception ex)
            {
                
            }

            return resultList;
        }
        
        public static List<DetailJenisInformasiResult> GetDetailJenisInformasiNewest(string kodeRt)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            string apiUrl = "api/DetailJenisInformasi/GetDetailJenisInformasiNewest";
            DetailJenisInformasiRequest request = new DetailJenisInformasiRequest();
            DetailJenisInformasiResponse response = new DetailJenisInformasiResponse();
            List<DetailJenisInformasiResult> resultList = new List<DetailJenisInformasiResult>();

            try
            {
                request.AuthenticationToken = AuthenticationConfiguration.GetInstance().WebServiceAuthenticationToken;
                request.KodeRt = kodeRt;
                request.LamaHari = Convert.ToInt32(GetParameterValue("002"));

                response = JsonConvert.DeserializeObject<DetailJenisInformasiResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));
                if (!response.Errors.HasError)
                {
                    resultList = response.DetailJenisInformasiResultList.ToList();
                }
            }
            catch (Exception ex)
            {

            }

            return resultList;
        }

        public static string GetParameterValue(string kode)
        {
            string method = MethodBase.GetCurrentMethod().Name;
            BusinessErrors bussinessError = new BusinessErrors();
            string apiUrl = "api/Parameter/GetParameterFindBy";
            ParameterRequest request = new ParameterRequest();
            ParameterResponse response = new ParameterResponse();
            string result = "";

            try
            {
                request.AuthenticationToken = AuthenticationConfiguration.GetInstance().WebServiceAuthenticationToken;
                request.Kode = kode;

                response = JsonConvert.DeserializeObject<ParameterResponse>(JasonMapper.ConvertHttpResponseToJson(apiUrl, request));
                if (!response.Errors.HasError)
                {
                    result = response.ParameterResult.Value;
                }
            }
            catch (Exception ex)
            {

            }

            return result;
        }


    }
}

