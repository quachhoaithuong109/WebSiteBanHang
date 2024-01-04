

export const Resource = {
    VN : {

        checkHaveQuantity : {
            HaveQuantity : "Còn hàng",
            NotHaveQuantity : "Hết hàng"
        },

        checkStatus : {
            Option1 : "Chưa giao",
            Option2 : "Đã giao"
        },

        SrcImage : {
            Phone : "https://localhost:44397/images/ImageProduct/DienThoai/",
            Laptop : "https://localhost:44397/images/ImageProduct/Laptop/",
            Tablet : "https://localhost:44397/images/ImageProduct/MayTinhBang/",
            Tivi : "https://localhost:44397/images/ImageProduct/Tivi/",
            Default : "https://localhost:44397/images/ImageProduct/"
        },

        TypeProduct : {
            Phone : 1,
            
            Laptop : 2,

            Tablet : 3,
            
            Tivi : 4
        },

        Validate : {
            Required : function(nameToValidate) {
                return `Cần phải nhập thông tin ${nameToValidate}`;
            },
            MaxLenght : function(nameToValidate , maxLength)
            {
                return `Thông tin ${nameToValidate} không được vượt quá ${maxLength} ký tự`;
            },
            NoContentGridDialog : "Không có tài sản nào được chọn.Vui lòng chọn tài sản"
        },

        MessageDialogConfirm : {
            MessageFixedAssetUsed : function(voucherCode){
                return `Tài sản đã phát sinh chứng từ ghi tăng .Tại chứng từ <span class = "highline-text-confirm">${voucherCode}</span>`
            },
            ConfirmHidePopupProduct : "Bạn có muốn hủy bỏ khai báo sản phẩm này?",
            ConfirmSaveInfoFixedAsset : "Thông tin thay đổi sẽ không được cập nhật nếu bạn không lưu.Bạn có muốn lưu các thay đổi này?",
            ConfirmSaveInfo : "Thông tin thay đổi sẽ không được cập nhật nếu bạn không lưu.Bạn có muốn lưu các thay đổi này?",
            DeleteConfirmOneRecord : function(fixedAssetCode , fixedAssetName) {
                return `Bạn có muốn xóa tài sản <span class = "highline-text-confirm"> ${fixedAssetCode} - ${fixedAssetName} ? </span>`
            },
            DeleteConfirm : function( GridName, Code , Name) {
                if(Name)
                {
                    return `Bạn có muốn xóa ${GridName} <span class = "highline-text-confirm"> ${Code} - ${Name} ? </span>`
                }
                return `Bạn có muốn xóa ${GridName} <span class = "highline-text-confirm"> ${Code} ? </span>`
            },
            DeleteMultipleRecord : function(numberRecordDelete , tableName)
            {
                return `<span class = "highline-text-confirm">${numberRecordDelete}</span> ${tableName} đã được chọn. Bạn có muốn xóa các ${tableName} này ra khỏi danh sách?`
            },

            deleteMessage : "Bạn có muốn xóa sản phẩm này không?"
        },
        MessageDialogValidate : {
            Required : "Cần phải nhập thông tin"
        },
        ValidateDialogOrigin : {
            Required : "Vui lòng nhập giá trị",
            Choosed : "Nguồn kinh phí này đã được chọn",
            RequiredCombobox : "Vui lòng chọn nguồn kinh phí"
        }
    },
    API : {
        Host : "https://localhost:44397",
        Product : "/api/v1/Product",
        GetProductApi : "/api/v1/Product/getProduct",
        GetProductCategory : "/api/v1/ProductCategory",
        User : "/api/v1/User",
        ProductCategory : "/api/v1/ProductCategory",
        AddNewProductCategory : "/AddNewProductCategory",
        UpdateProductCategory : "/UpdateProductCategory",
        ProductOrder : "/api/v1/Order",
        searchProduct : function(txtSearch,pageSize,pageIndex)
        {
            return  `/searchPaging?txtSearch=${txtSearch}&pageSize=${pageSize}&pageIndex=${pageIndex}`
        },
            
        searchUser : function(txtSearch,pageSize,pageIndex)
        {
            return  `/searchPaging?txtSearch=${txtSearch}&pageSize=${pageSize}&pageIndex=${pageIndex}`
        },

        searchProductCategory : function(txtSearch,pageSize,pageIndex)
        {
            return  `/searchProductCategory?txtSearch=${txtSearch}&pageSize=${pageSize}&pageIndex=${pageIndex}`
        },
        
        searchProductOrder : function(txtSearch,pageSize,pageIndex)
        {
            return  `/searchPaging?txtSearch=${txtSearch}&pageSize=${pageSize}&pageIndex=${pageIndex}`
        },

        getOriginFundingByFixedAssetId : function(fixedAssetId)
        {
            return `/originFunds?fixedAssetId=${fixedAssetId}`
        },
    },

    Icon : {
        FaChevronDown : "<i class='fa fa-chevron-down' aria-hidden='true'></i>",
        FaCheck : "<i class='fa fa-check' aria-hidden='true'></i>"
    },

    SearchPaging : {
        PageSize : 5,
        PageIndex : 1,
        textSearch : '',
    },


}