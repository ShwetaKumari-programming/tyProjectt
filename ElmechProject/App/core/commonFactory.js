
var api_path = '/api/';

angular.module("elmech").factory('commonService', function ($http) {
    return {
        getProduct: function () {
            return $http.get(api_path + 'Product/GetProduct');
        },
        GetCatalog: function () {
            return $http.get(api_path + 'Catalog/GetCatalog');
        },
        GetUser: function () {
            return $http.get(api_path + 'Registration/GetUser');
        },
        saveOrder: function (data) {
            return $http({
                method: 'POST',
                url: api_path + 'CheckOut/SaveOrder',
                data: data
            });
        },
        GetSampleInfo:function(){
            return $http.get(api_path + 'Sinfo/GetSinfo');
        },

        billingInfo: function (data) {
            return $http({
                method: 'POST',
                url: api_path + 'Registration/savebillingInfo',
                //data: $.param(data),
                data: data

            });
            //headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
        },
        InquiryInfo:function(data){
            return $http({
                method : 'POST',
                url: api_path + 'Inquiry/saveInquiryInfo',
                data:data
            });
        },
        saveSinfo: function (data) {
            return $http({
                method: 'POST',
                url: api_path + 'Sinfo/saveInfo',
                data: data
            });
        },

        UpdateInfo: function (data) {
            return $http({
                method: 'PUT',
                url: api_path + 'Sinfo/UpdateSInfo',
                data: data
            });
        },

        DeleteSinfo: function (data) {
            return $http.delete(api_path + 'Sinfo/DeleteSInfo')
        },
        GetOrderInfo: function () {
            return $http.get(api_path + 'OrderManage/GetOrder');
        },
        GetOrderProduct: function () {
            return $http.get(api_path + 'OrderManage/GetOrderProduct');
        },

        GetOrderProductDetails: function (orderId) {
            return $http.get(api_path + 'OrderManage/GetOrderProduct/' + orderId);
        },
        savePaymentMethod: function (data) {
            return $http({
                method: 'PUT',
                url: api_path + 'CheckOut/UpdateOrder',
                data: data
            });
        },
        saveConfirmOrder: function (data) {
        return $http({
            method: 'PUT',
            url: api_path + 'CheckOut/UpdateOrderConfirm',
            data: data
        });
    }
    }

});
