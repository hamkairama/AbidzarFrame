using AbidzarFrame.Reports.Interface.Dto;
using System.ServiceModel;

namespace AbidzarFrame.Reports.Interface
{
    [ServiceContract()]
    public interface IReportsManager
    {
        #region LaporanKas
        [OperationContract()]
        LaporanKasResponse GetLaporanKasFindBy(LaporanKasRequest request);

        [OperationContract()]
        LaporanKasResponse GetLaporanKasList(LaporanKasRequest request);

        [OperationContract()]
        LaporanKasResponse GetLaporanKasListByDate(LaporanKasRequest request);

        [OperationContract()]
        LaporanKasResponse GetLaporanKasListByYear(LaporanKasRequest request);

        [OperationContract()]
        LaporanKasResponse InsertLaporanKas(LaporanKasRequest request);

        [OperationContract()]
        LaporanKasResponse UpdateLaporanKas(LaporanKasRequest request);

        [OperationContract()]
        LaporanKasResponse DeleteLaporanKas(LaporanKasRequest request);
        #endregion

    }
}
