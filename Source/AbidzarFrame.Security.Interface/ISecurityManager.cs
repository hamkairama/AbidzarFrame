using AbidzarFrame.Security.Interface.Dto;
using System.ServiceModel;

namespace AbidzarFrame.Security.Interface
{
    [ServiceContract()]
    public interface ISecurityManager
    {
        #region Login Using ActiveDirectory
        [OperationContract()]
        ActiveDirectoryResponse CheckUser(ActiveDirectoryRequest request, ref UserResult userResult);
        #endregion

        #region Role
        [OperationContract()]
        RoleResponse GetRoleFindBy(RoleRequest request);

        [OperationContract()]
        RoleResponse GetRoleList(RoleRequest request);

        [OperationContract()]
        RoleResponse InsertRole(RoleRequest request);

        [OperationContract()]
        RoleResponse UpdateRole(RoleRequest request);

        [OperationContract()]
        RoleResponse DeleteRole(RoleRequest request);
        #endregion

        #region User
        [OperationContract()]
        UserResponse GetUserFindBy(UserRequest request);

        [OperationContract()]
        UserResponse GetUserList(UserRequest request);

        [OperationContract()]
        UserResponse UserRegistrasi(UserRequest request);

        [OperationContract()]
        UserResponse UserUpdateSandi(UserRequest request);

        [OperationContract()]
        UserResponse UserVerifikasi(UserRequest request);

        [OperationContract()]
        UserResponse InsertUser(UserRequest request);

        [OperationContract()]
        UserResponse UpdateUser(UserRequest request);

        [OperationContract()]
        UserResponse DeleteUser(UserRequest request);
        #endregion

        #region Menu
        [OperationContract()]
        MenuResponse GetMenuAccessRight(MenuRequest request);

        [OperationContract()]
        MenuResponse GetMenuFindBy(MenuRequest request);

        [OperationContract()]
        MenuResponse GetMenuList(MenuRequest request);

        [OperationContract()]
        MenuResponse InsertMenu(MenuRequest request);

        [OperationContract()]
        MenuResponse UpdateMenu(MenuRequest request);

        [OperationContract()]
        MenuResponse DeleteMenu(MenuRequest request);
        #endregion

        #region Authentication Token

        [OperationContract()]
        AuthenticationTokenResponse GetAuthenticationToken(AuthenticationTokenRequest request);
        #endregion

        #region Send Email

        [OperationContract()]
        EmailResponse SendEmail(EmailRequest request);
        #endregion

        #region  UserApi
        [OperationContract()]
        UserApiResponse GetUserApiFindBy(UserApiRequest request);
        #endregion

        #region  Email template
        [OperationContract()]
        EmailResponse GetEmailTemplateFindBy(EmailRequest request);
        #endregion

        #region RoleMenu
        [OperationContract()]
        RoleMenuResponse GetRoleMenuListByRoleId(RoleMenuRequest request);

        [OperationContract()]
        RoleMenuResponse GetRoleMenuFindBy(RoleMenuRequest request);

        [OperationContract()]
        RoleMenuResponse GetRoleMenuList(RoleMenuRequest request);

        [OperationContract()]
        RoleMenuResponse InsertRoleMenu(RoleMenuRequest request);

        [OperationContract()]
        RoleMenuResponse UpdateRoleMenu(RoleMenuRequest request);

        [OperationContract()]
        RoleMenuResponse DeleteRoleMenu(RoleMenuRequest request);
        #endregion

        #region HistoricalUserLogin
        [OperationContract()]
        HistoricalUserLoginResponse GetHistoricalUserLoginFindBy(HistoricalUserLoginRequest request);

        [OperationContract()]
        HistoricalUserLoginResponse GetHistoricalUserLoginList(HistoricalUserLoginRequest request);

        [OperationContract()]
        HistoricalUserLoginResponse GetHistoricalUserLoginListByDate(HistoricalUserLoginRequest request);

        [OperationContract()]
        HistoricalUserLoginResponse GetHistoricalUserLoginListByMonth(HistoricalUserLoginRequest request);

        [OperationContract()]
        HistoricalUserLoginResponse GetHistoricalUserLoginListByYear(HistoricalUserLoginRequest request);


        [OperationContract()]
        HistoricalUserLoginResponse InsertHistoricalUserLogin(HistoricalUserLoginRequest request);

        [OperationContract()]
        HistoricalUserLoginResponse UpdateHistoricalUserLogin(HistoricalUserLoginRequest request);

        [OperationContract()]
        HistoricalUserLoginResponse DeleteHistoricalUserLogin(HistoricalUserLoginRequest request);
        #endregion



    }
}
