using AbidzarFrame.Questioner.Interface.Dto;
using System.Collections.Generic;
using System.ServiceModel;


namespace AbidzarFrame.Questioner.Interface
{
    [ServiceContract()]
    public interface IQuestionerManager
    {
        #region Pemilu
        [OperationContract()]
        PemiluResponse GetPemiluFindBy(PemiluRequest request);

        [OperationContract()]
        PemiluResponse GetPemiluList(PemiluRequest request);

        [OperationContract()]
        PemiluResponse InsertPemilu(PemiluRequest request);

        [OperationContract()]
        PemiluResponse UpdatePemilu(PemiluRequest request);

        [OperationContract()]
        PemiluResponse DeletePemilu(PemiluRequest request);
        #endregion


        #region DetailPemilu
        [OperationContract()]
        DetailPemiluResponse GetDetailPemiluFindBy(DetailPemiluRequest request);

        [OperationContract()]
        DetailPemiluResponse GetDetailPemiluList(DetailPemiluRequest request);

        [OperationContract()]
        DetailPemiluResponse GetDetailPemiluListByIdPemilu(DetailPemiluRequest request);

        [OperationContract()]
        DetailPemiluResponse InsertDetailPemilu(DetailPemiluRequest request);

        [OperationContract()]
        DetailPemiluResponse UpdateDetailPemilu(DetailPemiluRequest request);

        [OperationContract()]
        DetailPemiluResponse DeleteDetailPemilu(DetailPemiluRequest request);
        #endregion


        #region PollingPemilu
        [OperationContract()]
        PollingPemiluResponse GetPollingPemiluFindBy(PollingPemiluRequest request);

        [OperationContract()]
        PollingPemiluResponse GetPollingPemiluFindByNik(PollingPemiluRequest request);

        [OperationContract()]
        PollingPemiluResponse GetPollingPemiluList(PollingPemiluRequest request);

        [OperationContract()]
        PollingPemiluResponse GetPollingPemiluListGrafik(PollingPemiluRequest request);

        [OperationContract()]
        PollingPemiluResponse InsertPollingPemilu(PollingPemiluRequest request);

        [OperationContract()]
        PollingPemiluResponse UpdatePollingPemilu(PollingPemiluRequest request);

        [OperationContract()]
        PollingPemiluResponse DeletePollingPemilu(PollingPemiluRequest request);
        #endregion


        #region TanyaRt
        [OperationContract()]
        TanyaRtResponse GetTanyaRtFindBy(TanyaRtRequest request);

        [OperationContract()]
        TanyaRtResponse GetTanyaRtList(TanyaRtRequest request);

        [OperationContract()]
        TanyaRtResponse TotalTanyaRtOutstanding(TanyaRtRequest request);

        [OperationContract()]
        TanyaRtResponse GetTanyaRtListByNik(TanyaRtRequest request);

        [OperationContract()]
        TanyaRtResponse InsertTanyaRt(TanyaRtRequest request);

        [OperationContract()]
        TanyaRtResponse UpdateTanyaRt(TanyaRtRequest request);

        [OperationContract()]
        TanyaRtResponse DeleteTanyaRt(TanyaRtRequest request);
        #endregion

        #region TanyaRtDetail
        [OperationContract()]
        TanyaRtDetailResponse GetTanyaRtDetailFindBy(TanyaRtDetailRequest request);

        [OperationContract()]
        TanyaRtDetailResponse GetTanyaRtDetailList(TanyaRtDetailRequest request); 

        [OperationContract()]
        TanyaRtDetailResponse GetTanyaRtDetailListByIdTanyaRt(TanyaRtDetailRequest request); 

         [OperationContract()]
        TanyaRtDetailResponse InsertTanyaRtDetail(TanyaRtDetailRequest request);

        [OperationContract()]
        TanyaRtDetailResponse UpdateTanyaRtDetail(TanyaRtDetailRequest request);

        [OperationContract()]
        TanyaRtDetailResponse DeleteTanyaRtDetail(TanyaRtDetailRequest request);
        #endregion

    }
}
