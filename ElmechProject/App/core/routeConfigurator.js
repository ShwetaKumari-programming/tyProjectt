(function () {
    "use strict";

    angular.module("elmech").config(["$stateProvider", "$urlRouterProvider", "$locationProvider",
        function ($stateProvider, $urlRouterProvider, $locationProvider) {
            $stateProvider
                .state('Home', {
                    cache: true,
                    url: "/home",
                    templateUrl: "App/Views/home/home.html",
                    controller: "HomeController"
                })
                .state('Product', {
                    cache: true,
                    url: "/product",
                    templateUrl: "App/Views/product/product.html",
                    controller: "ProductController"
                })
                .state('Catalog', {
                    cache: true,
                    url: "/catalog",
                    templateUrl: "App/Views/catalog/catalog.html",
                    controller: "CatalogController"
                })
                .state('AboutUs', {
                    cache: true,
                    url: "/about-us",
                    templateUrl: "App/Views/about-us/about-us.html",
                    controller: "AboutUsController"
                })
                .state('Inquiry', {
                    cache: true,
                    url: "/inquiry",
                    templateUrl: "App/Views/inquiry/inquiry.html",
                    controller: "InquiryController"
                }).state('ContactUs', {
                    cache: true,
                    url: "/contact-us",
                    templateUrl: "App/Views/contact-us/contact-us.html",
                    controller: "HomeController"
                })
                .state('Login', {
                 cache: true,
                 url: "/login/:returnUrl",
                 templateUrl: "App/Views/login/login.html",
                 controller: "LoginController"
                })
                .state('ForgotPassword', {
                    cache: true,
                    url: "/forgotPassword",
                    templateUrl: "App/Views/forgot-password/forgot-password.html",
                    controller: "ForgotPasswordController"
                })
                .state('MyAccount', {
                    cache: true,
                    url: "/myaccount",
                    templateUrl: "App/Views/myaccount/myaccount.html",
                    controller: "MyAccountController"
                })
             .state('Registration', {
                 cache: true,
                 url: "/registration/:returnUrl",
                 templateUrl: "App/Views/registration/registration.html",
                 controller: "RegistrationController"
             })
            .state('Checkout', {
                cache: true,
                url: "/checkout",
                templateUrl: "App/Views/checkout/checkout.html",
                controller: "CheckoutController"
            })
             .state('ViewCart', {
                 cache: true,
                 url: "/viewcart/:OrderId",
                 templateUrl: "App/Views/viewcart/viewcart.html",
                 controller: "ViewCartController"
             })
             .state('DisplayOrder', {
                 cache: true,
                 url: "/displayorder",
                 templateUrl: "App/Views/displayorder/displayorder.html",
                 controller: "DisplayOrderController"
             })

              .state('Sample', {
                     cache: true,
                     url: "/sample",
                     templateUrl: "App/Views/sample/sample.html",
                     controller: "SampleController"
                 })
            .state('ResetPassword', {
                cache: true,
                url: "/ResetPassword",
                templateUrl: "App/Views/reset-password/reset-password.html",
                controller: "ResetPasswordController"
            })


            $urlRouterProvider.when("/", "/home");

            $urlRouterProvider.otherwise("/");

            $locationProvider.html5Mode(false).hashPrefix("!");
        }]);
}());