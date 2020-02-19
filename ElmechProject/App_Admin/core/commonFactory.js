
var api_path = '/api/';

angular.module("elmechadmin").factory('commonService', function ($http) {
    return {
        GetInquiryInfo: function () {
            return $http.get(api_path + 'InquiryManage/GetInquiry');
        },
        GetOrderInfo: function () {
            return $http.get(api_path + 'OrderManage/GetOrder');
        },
        GetUserInfo: function () {
            return $http.get(api_path + 'UserManage/GetUser');
        },
        GetCategoryInfo: function () {
            return $http.get(api_path + 'CategoryManage/GetCategory');
        },
        GetProductInfo: function (categoryId) {
            return $http.get(api_path + 'ProductManage/GetProduct/' + categoryId);
          
        },
        GetCatalogInfo: function () {
            return $http.get(api_path + 'CatalogManage/GetCatalog');

        },
        DeleteProduct: function (productId) {
            return $http.delete(api_path + 'ProductManage/DeleteProduct/' + productId)
        },
        Deletecatalog: function (catalogId) {
            return $http.delete(api_path + 'CatalogManage/DeleteCatalog/' + catalogId)
        },
        GetProductInfoById: function (productId) {
            return $http.get(api_path + 'ProductManage/GetProductById/' + productId);

        },
        saveInfo: function (data) {
            return $http({
                method: 'POST',
                url: api_path + 'ProductManage/saveInfo',
                data: data
            });
        },
        GetCatalogInfoById: function (catalogId) {
            return $http.get(api_path + 'CatalogManage/GetCatalogById/' + catalogId);

        },
        saveCatalog: function (data) {
            return $http({
                method: 'POST',
                url: api_path + 'CatalogManage/saveCatalog',
                data: data
            });
        },
        Deletecategory: function (categoryId) {
            return $http.delete(api_path + 'CategoryManage/DeleteCategory/' + categoryId)
        },
        GetCategoryInfoById: function (categoryId) {
            return $http.get(api_path + 'CategoryManage/GetCategoryById/' + categoryId);

        },
        saveCategory: function (data) {
            return $http({
                method: 'POST',
                url: api_path + 'CategoryManage/saveCategory',
                data: data
            });
        },
        SendResponse: function (data)
        {
            return $http({
                method: 'POST',
            url: api_path + 'InquiryManage/SendResponse',
            data: data
        });
        }

    }


});
