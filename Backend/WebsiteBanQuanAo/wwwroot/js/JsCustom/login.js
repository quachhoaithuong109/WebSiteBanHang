

var login = {
    init: function () {
        login.registerEvent();
    },

    /**
     * Khởi tạo sự kiện
     * */
    registerEvent: function () {

        $('#btnLogin').off('click').on('click', function (e) {
            e.preventDefault();
            if (login.checkValidateLogin()) {
                // valid hợp lệ tiến hành thực hiện login

                var email = $('#txtUserEmail').val();
                var passWord = $('#txtPassWord').val();

                login.executeLogin(email, passWord);
            }
        });

        $('#btnLogout').off('click').on('click', function (e) {
            e.preventDefault();
            login.executeLogout();
        })
    },

    /**
     * Check validate
     * */
    checkValidateLogin: function () {

        let isCheckValid = true;

        var email = $('#txtUserEmail').val();
        var passWord = $('#txtPassWord').val();

        if (email == '' || email == null) {
            $('.validate-email').text('Vui lòng nhập email');
            isCheckValid = false;
        }
        else {
            if (login.validateEmail(email) == null) {
                // Email ko hợp lệ

                $('.validate-email').text('Email không hợp lệ');
                isCheckValid = false;
            }
            else {
                $('.validate-email').text('');
            }
        }

        if (passWord == '' || passWord == null) {
            $('.validate-password').text('Vui lòng nhập mật khẩu');
            isCheckValid = false;
        }
        else {
            $('.validate-password').text('');
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
     * Hàm thực hiện đăng nhập
     * */
    executeLogin: function (email, passWord) {
        $.ajax({
            url: '/Account/Login',
            type: 'POST',
            dataType: 'json',
            data: {
                UserEmail: email,
                UserPassWord: passWord
            },
            success: function (response) {
                if (response.status) {
                    toastr.success('Thông báo', 'Đăng nhập thành công.', { timeOut: 3000 });
                    window.location.href = "/";
                }
                else {
                    toastr.warning('Thông báo', 'Đăng nhập không thành công.', { timeOut: 3000 });
                }
            }
        })
    },

    /**
     * Hàm thực hiện đăng xuất
     * */
    executeLogout: function () {
        $.ajax({
            url: '/Account/Logout',
            type: 'POST',
            dataType: 'json',
            //data: {
            //    UserEmail: email,
            //    UserPassWord: passWord
            //},
            success: function (response) {
                if (response.status) {
                    /*toastr.success('Thông báo', 'Đăng nhập thành công.', { timeOut: 3000 });*/
                    window.location.href = "/";
                }
                else {
                    toastr.warning('Thông báo', 'Đăng xuất không thành công.', { timeOut: 3000 });
                }
            }
        })
    }

}

login.init();
