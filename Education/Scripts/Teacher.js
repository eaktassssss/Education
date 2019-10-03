$("#btnSend1").click(function () {
    var teacher = {
        Name: $("#Teacher_Name").val(), SurName: $("#Teacher_SurName").val(), IdentityNumber: $("#Teacher_IdentityNumber").val(), PhoneNumber: $("#Teacher_PhoneNumber").val(), Email: $("#Teacher_Email").val(),
        Age: $("#Teacher_Age").val(), LessonId: $("#Teacher_LessonId").val(), DayOffId: $("#Teacher_DayOffId").val()
    };
    $.ajax({
        url: '/Teacher/Add',
        type: 'POST',
        data: teacher,
        success: function (response) {
            if (response.resultType == true) {
                alert(response.result);
                Clear();
            } else {
                alert(response.result);
            }
        },
        error: function (response) {
            alert(response.result);
        }
    });
});

function Clear() {
    $("#Teacher_PhoneNumber").val('');
    $("#Teacher_Name").val('');
    $("#Teacher_SurName").val('');
    $("#Teacher_IdentityNumber").val('');
    $("#Teacher_Email").val('');
}