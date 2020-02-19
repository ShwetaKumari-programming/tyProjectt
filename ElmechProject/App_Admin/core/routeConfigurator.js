(function () {
    "use strict";

    angular.module("elmechadmin").config(["$stateProvider", "$urlRouterProvider", "$locationProvider",
        function ($stateProvider, $urlRouterProvider, $locationProvider) {
            $stateProvider
                .state('Home', {
                    cache: true,
                    url: "/home",
                    templateUrl: "/App_Admin/view/home/home.html",
                    //controller: "HomeController"
                })
                .state('Login', {
                    cache: true,
                    url: "/login",
                    templateUrl: "/App_Admin/view/login/login.html",
                    controller: "LoginController"
                        })
                 .state('CategoryMaster', {
                     cache: true,
                     url: "/categorymaster",
                     templateUrl: "/App_Admin/view/categorymaster/categorymaster.html",
                     controller: "CategoryMasterController"
                 })
                .state('ProductMaster', {
                     cache: true,
                     url: "/productmaster/:categoryId",
                     templateUrl: "/App_Admin/view/productmaster/productmaster.html",
                     controller: "ProductMasterController"
                })
                .state('CatalogManagement', {
                     cache: true,
                     url: "/catalogmanagement",
                     templateUrl: "/App_Admin/view/catalogmanagement/catalogmanagement.html",
                     controller: "CatalogManagementController"
                 }) .state('InquiryManagement', {
                     cache: true,
                     url: "/inquirymanagement",
                     templateUrl: "/App_Admin/view/inquirymanagement/inquirymanagement.html",
                     controller: "InquiryManagementController"
                 }) .state('OrderManagement', {
                     cache: true,
                     url: "/ordermanagement",
                     templateUrl: "/App_Admin/view/ordermanagement/ordermanagement.html",
                     controller: "OrderManagementController"
                 }) .state('UserManagement', {
                     cache: true,
                     url: "/usermanagement",
                     templateUrl: "/App_Admin/view/usermanagement/usermanagement.html",
                     controller: "UserManagementController"
                 })
            .state('SaveProduct', {
                cache: true,
                url: "/saveproduct/:categoryId/:productId",
                templateUrl: "/App_Admin/view/productmaster/save-product/save-product.html",
                controller: "SaveProductController"
            })
             .state('Savecatalog', {
                 cache: true,
                 url: "/savecatalog/:catalogId",
                 templateUrl: "/App_Admin/view/catalogmanagement/savecatalog/savecatalog.html",
                 controller: "SaveCatalogController"
             })
             .state('Savecategory', {
                 cache: true,
                 url: "/savecategory/:categoryId",
                 templateUrl: "/App_Admin/view/categorymaster/savecategory/savecategory.html",
                 controller: "SaveCategoryController"
             })
            
            .state('InquiryResponse', {
                cache: true,
                url: "/inquiryresponse/:Id",
                templateUrl: "/App_Admin/view/inquirymanagement/inquiryresponse/inquiryresponse.html",
                controller: "InquiryResponseController"
            })


            $urlRouterProvider.when("/", "/categorymaster");

            $urlRouterProvider.otherwise("/");

            $locationProvider.html5Mode(false).hashPrefix("!");
        }]);
}());