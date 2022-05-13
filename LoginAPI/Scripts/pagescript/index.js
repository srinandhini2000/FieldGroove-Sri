
var GetLogin = function () {

    var Username = $('#txtUsername').val();
    var Password = $('#txtPassword').val();
    var loginUrl = "/api/Values/GetLogin";
    var loginData = JSON.stringify({ "Username": Username, "Password": Password });
$.ajax({      
        type : "GET.",
        data : loginData,
        Url : loginUrl,
        contentType:"application/json;charset=utf-8",
        dataType : "json",
        success: function (result) {
            alert(result);
        } ,
        error : function (result) {
            alert(result);
        }
});
   
};
   