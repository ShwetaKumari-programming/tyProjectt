
(function () {
    "use strict";
    angular.module("elmech").controller('DisplayOrderController', ['$scope', 'commonService','$state',
        function ($scope, commonService, $state) {

            commonService.GetOrderProduct()
             .then(function (response) {
                 $scope.Orderinfo = response.data;

             }, function (error) {
                 $scope.errorlog = error;
             });
            $scope.ViewCart = function (orderId) {

                $state.go('ViewCart', { OrderId: orderId });
            }

        }]);
}());