function LoginTest(){
    var jsonRequest = {
        IdUser: $("#IdUser").val(),
        Sandi: $("#Sandi").val(),
    };

    var path = location.origin + "/Account/Login";

    $.ajax({
        async: true,
        type: "POST",
        url: path,
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({
            model: jsonRequest
        }),
        datatype: "application/json",
        success: function (ret) {
            alert("");
        },
        error: function () {
            $(this).modal('hide');
            alertError("Failed to open form, please try again");
        }
    })
}