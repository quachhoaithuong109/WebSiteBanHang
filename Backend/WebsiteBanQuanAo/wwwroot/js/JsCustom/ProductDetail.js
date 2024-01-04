
var productDetail = {

    init: function () {
        productDetail.registerEvent();
    },

    registerEvent: function () {

        var quantitiy = 0;
        $('.quantity-right-plus').click(function (e) {

            // Stop acting like a button
            e.preventDefault();
            // Get the field name
            var quantity = parseInt($('#quantityDetail').val());

            // If is not undefined

            $('#quantityDetail').val(quantity + 1);


            // Increment

        });

        $('.quantity-left-minus').click(function (e) {
            // Stop acting like a button
            e.preventDefault();
            // Get the field name
            var quantity = parseInt($('#quantityDetail').val());

            // If is not undefined

            // Increment
            if (quantity > 0) {
                $('#quantityDetail').val(quantity - 1);
            }
        });


        $('#btnAddToCartDetail').off('click').on('click', function (e) {
            e.preventDefault();
            var productId = $(this).data('id');
            var quantity = parseInt($('#quantityDetail').val());
            productDetail.addItem(productId, quantity);
        });

    },


    /*
     * Thêm sản phẩm vào giỏ hàng
     * NXHOANG 19/07/2022
     * */
    addItem: function (productId, quantity) {

        if (quantity > 0) {
            $.ajax({
                url: '/ShoppingCart/AddCartProductDetail',
                data: {
                    productId: productId,
                    quantity: quantity
                },
                type: 'POST',
                dataType: 'json',
                success: function (response) {
                    if (response.status) {

                        //alert('Thêm sản phẩm thành công.');
                        toastr.success('Thông báo', 'Sản phẩm đã được thêm vào giỏ hàng', { timeOut: 3000 })
                        $("#CountcartItem").text("[ " + response.counter + " ]");
                    } else {
                        toastr.error('Thông báo', 'Có lỗi xảy ra', { timeOut: 3000 })
                    }

                }
            });
        }
        else {
            toastr.warning('Thông báo', 'Vui lòng chọn số lượng sản phẩm', { timeOut: 3000 })
        }
        
    },

}

productDetail.init();










