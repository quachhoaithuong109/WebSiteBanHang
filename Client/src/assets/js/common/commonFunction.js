export const CommonFunction = {

    /**
     * Hàm định dạng hiển thị tiền tệ
     * @param {any} money :  bất cữ kiểu giữ liệu gì
     * CreatedBy : NXHoang (26/10/2021)
    */
     formatMoney : function(money){
        if (money) {
            return Number(money).toFixed(0).replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1.");
        }
        return "";
    },

    /**
     * Thực hiện việc Autocomplete khi focus vào combobox
     * @param {*} cbSelected 
     * @param {*} buttonCombobox 
    */
    onFocusToggleItemCombobox : function(cbSelected , buttonCombobox) {
        if(cbSelected.classList.contains("m-hidden-dropdown"))
        {
            cbSelected.classList.remove("m-hidden-dropdown");
            if(buttonCombobox.children[0].classList.contains("fa-chevron-up")){
                buttonCombobox.innerHTML = "<i class='fa fa-chevron-down' aria-hidden='true'></i>";
            }else{
                buttonCombobox.innerHTML = "<i class='fa fa-chevron-up' aria-hidden='true'></i>";
            }
        }
    },


    /**
     * Hàm thực hiện selected vào item của combobox
     * CreatedBy : NXHoang (28/10/2021)
    */
     selectedItemCombobox : function(data){
        
        var itemCombobox;
        if(data.event.target)
        {
            itemCombobox = data.event.target;
        }
        else{
            itemCombobox = data.event;
        }
        itemCombobox.parentElement.previousSibling.previousElementSibling.value = data.name;
    
        var cbItems =  itemCombobox.parentElement.children;
        for(const cbitem of cbItems)
        {
            cbitem.classList.remove('m-item-selected');
            var iconRemove = cbitem.children;
            if(iconRemove[0])
            {
                cbitem.removeChild(iconRemove[0]);
            }
        }
        itemCombobox.classList.add("m-item-selected")
        itemCombobox.innerHTML = "<i class='fa fa-check' aria-hidden='true'></i>" + data.name.toString();
        itemCombobox.parentElement.classList.toggle("m-hidden-dropdown")
        itemCombobox.parentElement.previousSibling.innerHTML = "<i class='fa fa-chevron-down' aria-hidden='true'></i>";
    },



    /**
     * Hàm convert định dạng tiền thành số ( VD : 1.000.000 -> 1000000)
     * CreatedBy : 
    */
     convertMoneyToNumber : function(money){
        if(money)
        {
            return money.replaceAll('.' , '').trim();
        }
        return "";
    },

    /**
     * Method dùng để tạo một object mới dùng để thêm hoặc sửa vào database
     * CreatedBy : NXHoang (17/11/2021)
    */
    createObjectToAddOrEdit : function(productEdited)
    {
        var newObject = {
            ProductId : productEdited.ProductId,
            ProductName :productEdited.ProductName,
            CategoryID :productEdited.CategoryID,
            Price :CommonFunction.convertMoneyToNumber(productEdited.Price),
            PromotionPrice : CommonFunction.convertMoneyToNumber(productEdited.PromotionPrice),
            Quantity :productEdited.Quantity,
            Warranty :productEdited.Warranty,
            Alias :productEdited.Alias, //CommonFunction.formatDateToSave(fixedAsset.FixedAssetCategoryId),
            Image :productEdited.Image,
            Content :productEdited.Content,
        }
        return newObject;
    },

    /**
     * Method dùng để tạo một object mới dùng để thêm hoặc sửa vào database
     * CreatedBy : NXHoang (17/11/2021)
    */
    createObjectProductCategory : function(productCategpryEdited)
    {
      
        var newProductCategory = {
            ProductCategoryId : productCategpryEdited.ProductCategoryId,
            ProductCategoryName : productCategpryEdited.ProductCategoryName,
            Alias : productCategpryEdited.Alias,
            Description : productCategpryEdited.Description
        }
        
        return newProductCategory;
    },
    /**
     * Method dùng xóa một phần tử trong mảng
     * CreatedBy : NXHoang 
    */
    arrayRemove : function(arr, value) { 
        return arr.filter(function(ele){ 
            return ele != value; 
        });
    },

    /**
     * Hàm thực hiện format date sang dạng (ngày/tháng/năm)
     * CreatedBy : NXHoang (25/10/2021)
    */
    formatDate : function(value){
        if(value)
        {
            var date = new Date(value);
            let day = date.getDate();
            let month = date.getMonth() + 1;
            let year = date.getFullYear();
            day = day < 10 ? '0' + day : day;
            month = month < 10 ? '0' + month : month;
            return day + '/' + month + '/' + year;
        }else{
            return "";
        }
    },

}