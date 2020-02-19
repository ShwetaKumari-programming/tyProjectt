
(function () {
    "use strict";

    angular.module("elmechadmin").controller('InquiryManagementController', ['$scope', 'commonService','$state',
        function ($scope, commonService, $state) {
           
            commonService.GetInquiryInfo()
             .then(function (response) {
                 $scope.Inquiryinfo = response.data;
               
             }, function (error) {
                 $scope.errorlog = error;
             });
          //  $scope.UserEmail = "";
            $scope.GiveResponse = function (Id) {
                debugger
                $state.go('InquiryResponse',{Id : Id });

            }
        }
    ]);
}());