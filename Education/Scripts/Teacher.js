$("#btnUpdate").click(function () {
    var teacher = {
        Id: $("#Teacher_Id").val(), Name: $("#Teacher_Name").val(), SurName: $("#Teacher_SurName").val(), IdentityNumber: $("#Teacher_IdentityNumber").val(), PhoneNumber: $("#Teacher_PhoneNumber").val(), Email: $("#Teacher_Email").val(),
        Age: $("#Teacher_Age").val(), LessonId: $("#Teacher_LessonId").val(), DayOffId: $("#Teacher_DayOffId").val()
    };
    $.ajax({
        url: '/Teacher/Update',
        type: 'POST',
        data: teacher,
        success: function (response) {
            if (response.resultType == true) {
                alert(response.result);
                window.location = "/Teacher/Index";
            } else {
                alert(response.result);
            }
        },
        error: function (response) {
            alert(response.result);
        }
    });
});

$(document).on("click", "#btnteacherdelete",
    function () {
        var result = confirm("Emin misiniz?");
        if (result) {
            var tr = $(this).closest('tr');
            var id = $(this).data("id");
            if (id == "" && id == undefined) {
                console.log("id bulunamadı hatası");
            } else {
                $.ajax({
                    url: '/Teacher/Delete',
                    type: 'POST',
                    data: { teacherId: id },
                    success: function (response) {
                        if (response.resultType == true) {
                            tr.remove();
                        } else {
                            alert(response.result);
                        }
                    },
                    error: function (response) {
                        alert(response.result);
                    }
                });
            }
        }
    });
 