
(function () {
    "use strict";
    angular.module("elmechadmin").controller('OrderManagementController', ['$scope', 'commonService',
        function ($scope, commonService) {

            commonService.GetOrderInfo()
             .then(function (response) {
                 $scope.Orderinfo = response.data;

             }, function (error) {
                 $scope.errorlog = error;
             });


        }]);
}());