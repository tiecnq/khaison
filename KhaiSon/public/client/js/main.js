function fullpageSlideMarina() {
    const sm = $(window).width(); if (sm >= 991) {
        $('#fullpageMarina').fullpage({
            navigation: true,
            navigationPosition: 'right',
            navigationTooltips: ['Khai Sơn City', 'Chính sách ưu đãi', 'Hội tựu tinh túy', 'Chủ đầu tư dự án', 'Thông tin dự án', 'Vị thế đắc địa', 'Đặc điểm nổi bật', 'Tiện ích bên ngoài', 'Tiện ích bên trong', 'Video giới thiệu', 'Đăng ký đầu tư'], css3: true
        });
    }
}
$(document).ready(function () { fullpageSlideMarina() })
function ValidateEmail(email) {
    var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
    return emailReg.test(email);
}
function ValidatePhone(value) {
    var nameRegex = /(09|01[2|6|8|9])+([0-9]{8})\b/;
    return nameRegex.test(value);
}
$("#btnFormSubmit").off('click').on('click', function () {
    var obj = {
        FullName: $("#name").val(),
        Phone: $("#phone_number").val(),
        Email: $("#email").val(),
        Content: $("#message").val()
    };
    if ($("#name").val() == "" || $("#name").val() == undefined || $("#name").val() == null) {
        alert("Yêu cầu nhập Họ tên");
        return;
    }
    if ($("#phone_number").val() == "" || $("#phone_number").val() == undefined || $("#phone_number").val() == null) {
        alert("Yêu cầu nhập Số điện thoại");
        return;
    }
    if ($("#email").val() == "" || $("#email").val() == undefined || $("#email").val() == null) {
        alert("Yêu cầu nhập Email");
        return;
    }
    var phone = ValidatePhone(obj.Phone);
    if (phone == false) {
        alert("Yêu cầu nhập đúng định dạng Số điện thoại");
        return;
    }
    var email = ValidateEmail(obj.Email);
    if (email == false) {
        alert("Yêu cầu nhập đúng định dạng Email");
        return;
    }
    if ($("#message").val() == "" || $("#message").val() == undefined || $("#message").val() == null) {
        alert("Yêu cầu nhập Yêu cầu");
        return;
    }
    $.ajax({
        url: '/Home/SendEmail',
        type: "POST",
        dataType: "json",
        async: true,
        data: { data: obj },
        success: function (result) {
            alert(result.Title);
            $("#name").val('');
            Phone: $("#phone_number").val('');
            Email: $("#email").val('');
            Content: $("#message").val('');
        },
        error: function (errormessage) {
            alert("Lỗi");
        }
    });
});