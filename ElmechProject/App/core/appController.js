
(function () {
    "use strict";
    angular.module("elmech").controller('AppController', ['$scope', 'security', '$state', '$rootScope', '$filter',
        function ($scope, security, $state, $rootScope, $filter) {
            $scope.userRegister = false;
            debugger
            if (security.isLogin()) {
                $scope.userRegister = true;
                $scope.User = security.getUserDetail();
            }
            var carts = localStorage.getItem('addToCart');
            $scope.carts = [];
            if (carts != undefined && carts != null) {
                $scope.carts = JSON.parse(localStorage.getItem('addToCart'));
            }

            $scope.$on("LoggedIn", function (evt, data) {
                if (data.haveLoggedIn) {
                    $scope.userRegister = true;
                    $scope.User = data;
                }
                else {
                    $scope.userRegister = false;
                }
            })
            $scope.plus = function (index) {
                $scope.carts[index].Quantity = $scope.carts[index].Quantity + 1;
                $scope.carts[index].Amount = $scope.carts[index].Quantity * $scope.carts[index].CurrentPrice;
                localStorage.removeItem('addToCart')
                localStorage.setItem('addToCart', JSON.stringify($scope.carts))
            }
            $scope.minus = function (index) {
                if ($scope.carts[index].Quantity > 1) {
                    $scope.carts[index].Quantity = $scope.carts[index].Quantity - 1;
                    $scope.carts[index].Amount = $scope.carts[index].Quantity * $scope.carts[index].CurrentPrice;
                    localStorage.removeItem('addToCart')
                    localStorage.setItem('addToCart', JSON.stringify($scope.carts))
                }
            }

            $scope.$on("addToCart", function (evt, data) {
                var isPresent = false;
                angular.forEach($scope.carts, function (obj, index) {
                    if (data.Id == obj.ProductId) {
                        $scope.carts[index].Quantity = $scope.carts[index].Quantity + 1;
                        $scope.carts[index].Amount = $scope.carts[index].Quantity * $scope.carts[index].CurrentPrice;
                        isPresent = true;
                    }
                })
                if (!isPresent) {
                    var insertData = {
                        Quantity: 1,
                        ProductId: data.Id,
                        CurrentPrice: data.CurrentPrice,
                        Amount: data.CurrentPrice,
                        ImageURL: data.ImageURL,
                        Name: data.Name
                    }

                    $scope.carts.push(insertData);
                }

                localStorage.removeItem('addToCart');
                localStorage.setItem('addToCart', JSON.stringify($scope.carts))

            })

            $scope.$on("removeToCart", function (evt, data) {

                localStorage.removeItem('addToCart');
                $scope.carts = [];
                //CatagoryId:1
                //CurrentPrice:10000
                //CurrentQuantity:4
                //DeleteFlag:false
                //Description:"Flange mounted motor"
                //Id:1
                //ImageURL:"1.jpg"
                //Name:"Flange mounted motor"
            })

            $scope.remove = function (index) {
                $scope.carts.splice(index, 1);
                localStorage.removeItem('addToCart');
                localStorage.setItem('addToCart', JSON.stringify($scope.carts));
            }

            $scope.checkout = function () {
                debugger
                var isLoggedIn = security.isLogin();
                if (isLoggedIn) {
                    $state.go('Checkout')
                }
                else {
                    $state.go('Login', { returnUrl: 'Checkout' })
                }
            }

            $scope.logout = function () {
                if (confirm("Are you sure you want to logout.")) {
                    security.logout()
                    .then(function (response) {
                        $scope.userRegister = false;
                        $state.go('Product');
                    }, function (error) {
                        alert("Your username or password is wrong please try again.");
                    });
                }
            }

            $scope.gotoviewcart = function () {
                $state.go('DisplayOrder');
            }
        }]);
}());