
(function () {
    "use strict";
    angular.module("elmech").controller('ViewCartController', ['$scope', 'commonService', '$stateParams',
    function ($scope, commonService,$stateParams) {
            
        commonService.GetOrderProductDetails($stateParams.OrderId)
             .then(function (response) {
                 debugger
                 $scope.Orderinfo = response.data;

             }, function (error) {
                 $scope.errorlog = error;
             });
        var ttl = 0;
        angular.forEach($scope.Orderinfo, function (obj, index) {
            debugger
            ttl += obj.items.Amount;
        })
        $scope.total = ttl;


        }]);
}());