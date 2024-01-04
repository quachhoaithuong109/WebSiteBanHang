

var cart = {
    init: function () {
        cart.loadData();
        cart.registerEvent();
    },

    registerEvent: function () {

        $('.btnAddToCart').off('click').on('click', function (e) {
            e.preventDefault();
            var productId = $(this).data('id');
            cart.addItem(productId);
        });


        $('#cartBody').on('click', '.btnDeleteItem', function (e) {
            e.preventDefault();
            var productId = $(this).data('id');
            cart.deleteItem(productId);
        });

        $('#cartBody').off('keyup').on('keyup','.txtQuantity',function () {
            var quantity = parseInt($(this).val());
            var productId = $(this).data('id');
            var price = parseFloat($(this).data('price'));
            if (isNaN(quantity) == false) {

                var amount = quantity * price;

                $('#amount_' + productId).text(numeral(amount).format('0,0'));
            }
            else {
                $('#amount_' + productId).text(0);
            }

            /*$('#lblTotalOrder').text(numeral(cart.getTotalOrder()).format('0,0') + "Vnđ");*/
            cart.updateAll();
        });

        

        $('#btnCheckout').off('click').on('click', function (e) {
            e.preventDefault();

            //Check xem người dung đăng nhập hay chưa
            cart.checkUserLogin();

            //$('#divCheckout').show();
        });

        $('#btnCreateOrder').off('click').on('click', function (e) {
            e.preventDefault();

            // Nhớ check validate

            cart.createOrder();

        });

        $('#btnDeleteAll').off('click').on('click', function (e) {
            e.preventDefault();
            cart.deleteAll();
        });

    },

    checkUserLogin: function () {
        $.ajax({
            url: '/ShoppingCart/CheckUserLogin',
            type: 'POST',
            dataType: 'json',
            data: {
                
            },
            success: function (response) {
                if (response.status) {
                    cart.createOrderUserLogin();
                }
                else {
                    $('#divCheckout').show();
                }
            }
        })
    },


    /**
     * Xác nhận đặt hàng
     * NXHOANG 21/07/2022
     * */
    createOrderUserLogin: function () {

        $.ajax({
            url: '/ShoppingCart/createOrderUserLogin',
            type: 'POST',
            dataType: 'json',
            data: {
               
            },
            success: function (response) {
                if (response.status) {
                    $('#divCheckout').hide();
                    cart.deleteAll();

                    toastr.success('Thông báo', 'Cảm ơn bạn đã đặt hàng thành công. Chúng tôi sẽ liên hệ sớm nhất.', { timeOut: 3000 })
                }
                else {
                    toastr.warning('Thông báo', 'Sản phẩm hiện tại đang hết hàng.', { timeOut: 3000 })
                }
            }
        })

    },


    /**
     * Xác nhận đặt hàng
     * NXHOANG 21/07/2022
     * */
    createOrder: function () {
        var order = {
            UserName: $('#txtName').val(),
            UserAddress: $('#txtAddress').val(),
            UserEmail: $('#txtEmail').val(),
            UserPhone: $('#txtPhone').val(),
            UserMessage: $('#txtMessage').val(),
            Status: 1
        }

        $.ajax({
            url: '/ShoppingCart/CreateOrder',
            type: 'POST',
            dataType: 'json',
            data: {
                orderViewModel: JSON.stringify(order)
            },
            success: function (response) {
                if (response.status) {
                    $('#divCheckout').hide();
                    cart.deleteAll();

                    //setTimeout(function () {
                    //    $('#cartContent').html('Cảm ơn bạn đã đặt hàng thành công. Chúng tôi sẽ liên hệ sớm nhất.');
                    //}, 2000);

                    toastr.success('Thông báo', 'Cảm ơn bạn đã đặt hàng thành công. Chúng tôi sẽ liên hệ sớm nhất.', { timeOut: 3000 })
                }
                else {
                    toastr.warning('Thông báo', 'Sản phẩm hiện tại đang hết hàng.', { timeOut: 3000 })
                }
            }
        })

    },

    /**
     * Xóa tất cả sản phẩm trong giỏ hàng
     * @param {any} productId : Id sản phẩm
     * NXHOANG 23/07/2022
     */

    deleteAll: function () {
        $.ajax({
            url: '/ShoppingCart/DeleteAll',
            type: 'POST',
            dataType: 'json',
            success: function (respose) {
                if (respose.status) {
                    cart.loadData();
                    $("#CountcartItem").text("[ " + response.counter + " ]");
                }
            }
        })
    },





    /**
     * Cập nhật lại giỏ hàng
     * NXHOANG 21/07/2022
     * */
    updateAll: function () {
        var cartList = [];
        $.each($('.txtQuantity'), function (i, item) {
            cartList.push({ 
                ProductId: $(item).data('id'),
                Quantity: $(item).val()
            });
        });

        $.ajax({
            url: '/ShoppingCart/Update',
            type: 'POST',
            data: {
                cartData: JSON.stringify(cartList)
            },
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    cart.loadData();
                    $("#CountcartItem").text("[ " + response.counter + " ]");
                }
            }
        });

    },



    /**
     * Xóa sản phẩm trong giỏ hàng
     * @param {any} productId : Id sản phẩm
     * NXHOANG 21/07/2022
     */
    deleteItem: function (productId) {
        $.ajax({
            url: '/ShoppingCart/DeleteItem',
            data: {
                productId: productId
            },
            type: 'POST',
            dataType: 'Json',
            success: function (response) {
                if (response.status) {
                    cart.loadData();
                    $("#CountcartItem").text("[ " + res.counter + " ]");
                }
            }
        });
    },



    /*
     * Thêm sản phẩm vào giỏ hàng
     * NXHOANG 19/07/2022
     * */
    addItem: function (productId) {
        $.ajax({
            url: '/ShoppingCart/Add',
            data: {
                productId: productId
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status) {

                    //alert('Thêm sản phẩm thành công.');
                    toastr.success('Thông báo', 'Sản phẩm đã được thêm vào giỏ hàng', { timeOut: 3000 })
                    $("#CountcartItem").text("[ " + response.counter + " ]");
                } else {
                    toastr.error('Thông báo','Có lỗi xảy ra', { timeOut: 3000 })
                }

            }
        });
    },


    /**
     * Hàm load dữ liệu giỏ hàng
     * NXHOANG 20/07/2022
     * */
    loadData: function () {
        $.ajax({
            url: '/ShoppingCart/GetAll',
            type: 'GET',
            dataType: 'json',
            success: function (res) {
                if (res.status) {
                    var template = $('#tplCart').html();
                    var html = '';
                    var data = res.data;

                    var searchRegExp = /,/gi;
                    var replaceWith = '.';

                    $.each(data, function (i, item) {

                        let image = "";
                        if (item.product.typeProduct == 1) {
                            // Bàn Ghế
                            image = "BanGhe/" + item.product.image;
                        }
                        else if (item.product.typeProduct == 2) {
                            // Tủ

                            image = "Tu/" + item.product.image;
                        }
                        else if (item.product.typeProduct == 3) {
                            // Giuong

                            image = "Giuong/" + item.product.image;
                        }

                        html += Mustache.render(template, {
                            ProductId: item.product.productId,
                            ProductName: item.product.productName,
                            Image: image,
                            Price: item.product.price ?? 0,
                            Price: numeral(item.product.price).format('0,0').replace(searchRegExp, replaceWith),
                            Quantity: item.quantity ?? 0,
                            Amount: numeral((item.quantity ?? 0) * (item.product.price ?? 0)).format('0,0').replace(searchRegExp, replaceWith)
                        });
                    });

                    $("#CountcartItem").text("[ " + res.counter + " ]");

                    $('#cartBody').html(html);

                    if (html == '') {
                        $('#cartContent').html('Không có sản phẩm nào trong giỏ hàng');
                    }

                }
            }
        })
    }
}


cart.init();


