
(function () {
    "use strict";
    angular.module("elmechadmin").controller('UserManagementController', ['$scope', 'commonService',
        function ($scope, commonService) {
           
            commonService.GetUserInfo()
             .then(function (response) {
                 $scope.Userinfo = response.data;
               
             }, function (error) {
                 $scope.errorlog = error;
             });

        
        }]);
}());