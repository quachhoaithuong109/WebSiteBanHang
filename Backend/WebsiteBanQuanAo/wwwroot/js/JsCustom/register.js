
var register = {

    init: function () {
        register.registerEvent();
    },

    /**
    * Khởi tạo sự kiện
    * */
    registerEvent: function () {

        $('#btnRegister').off('click').on('click', function (e) {
            e.preventDefault();
            if (register.checkValidateLogin()) {

                var userName = $('#txtUserName').val();
                var email = $('#txtUserEmail').val();
                var userPhone = $('#txtUserPhone').val();
                var userAddress = $('#txtUserAddress').val();
                var userPassWord = $('#txtPassWord').val();

                var param = {
                    UserName: userName,
                    UserEmail: email,
                    PassWord: userPassWord,
                    UserPhone: userPhone,
                    Address: userAddress    
                }

                register.executeRegister(param);

            }
        });
    },


    /**
     * Thực hiện đăng ký
     * @param {any} param
     */
    executeRegister: function (param) {

        $.ajax({
            url: '/Account/Register',
            type: 'POST',
            dataType: 'json',
            data: param,
            success: function (response) {
                if (response.status) {
                    toastr.success('Thông báo', 'Đăng ký thành công.', { timeOut: 3000 });
                    window.location.href = "/dang-nhap.html";
                }
                else {
                    toastr.error('Thông báo', 'Đăng ký không thành công.', { timeOut: 3000 });
                }
            }
        })


    },


    /**
     * Check validate
     * */
    checkValidateLogin: function () {

        let isCheckValid = true;

        var userName = $('#txtUserName').val();
        var email = $('#txtUserEmail').val();
        var userPhone = $('#txtUserPhone').val();
        var userAddress = $('#txtUserAddress').val();
        var userPassWord = $('#txtPassWord').val();
        var userPassWordAgain = $('#txtPassWordAgain').val();

        if (userName == '' || userName == null) {
            $('.validate-user-name').text('Vui lòng nhập họ tên')
            isCheckValid = false;
        }
        else {
            $('.validate-user-name').text('')
        }

        if (email == '' || email == null) {
            $('.validate-email').text('Vui lòng nhập email');
            isCheckValid = false;
        }
        else {
            if (register.validateEmail(email) == null) {
                // Email ko hợp lệ

                $('.validate-user-email').text('Email không hợp lệ');
                isCheckValid = false;
            }
            else {
                $('.validate-user-email').text('');
            }
        }

        if (userPhone == '' || userPhone == null) {
            $('.validate-user-Table').text('Vui lòng nhập số điện thoại');
            isCheckValid = false;
        }
        else {
            if (register.validateUserPhone(userPhone) == null) {
                $('.validate-user-Phone').text('Số điện thoại không hợp lệ');
                isCheckValid = false;
            }
            else {
                $('.validate-user-Phone').text('');
            }
        }

        if (userAddress == '' || userAddress == null) {
            $('.validate-user-address').text('Vui lòng nhập địa chỉ');
            isCheckValid = false;
        }
        else {
            $('.validate-user-address').text('');
        }

        if (userPassWord == '' || userPassWord == null) {
            $('.validate-user-password').text('Vui lòng nhập mật khẩu');
            isCheckValid = false;
        } else {
            if (register.validateUserPassWord(userPassWord) != null) {
                $('.validate-user-password').text('');
            } else {
                if (userPassWord.length < 8) {
                    $('.validate-user-password').text('Mật khẩu phải có ít nhất 8 ký tự');
                    isCheckValid = false;
                }
                else {
                    $('.validate-user-password').text('Mật khẩu phải có ký tự chữ số');
                    isCheckValid = false;
                }
            }
        }

        if (userPassWordAgain == '' || userPassWordAgain == null) {
            $('.validate-user-password-again').text('Vui lòng nhập mật khẩu');
            isCheckValid = false;
        }
        else {
            if (userPassWordAgain != userPassWord) {
                $('.validate-user-password-again').text('Mật khẩu nhập lại không hợp lệ');
                isCheckValid = false
            }
            else {
                $('.validate-user-password-again').text('');
            }
        }


        return isCheckValid;
    },


    /**
     * Xử lý validate email
     * 
     * @param {any} email
     */
    validateEmail: function (email) {
        return email.match(
            /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/
        )
    },

    /**
     * Xử lý validate Table
     * @param {any} Table
     */
    validateUserPhone: function (userPhone) {
        return userPhone.match(
            /^\d{10}$/
        )
    },

    /**
     * Validate passWord
     * more than 8 chars
     *  at least one number
     * */
    validateUserPassWord: function (userPassWord) {
        return userPassWord.match(
            /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}$/
        )
    }


}


register.init();

