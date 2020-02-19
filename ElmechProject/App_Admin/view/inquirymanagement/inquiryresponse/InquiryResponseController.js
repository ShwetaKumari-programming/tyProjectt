
(function () {
    "use strict";

    angular.module("elmechadmin").controller('InquiryResponseController', ['$scope', 'commonService', '$stateParams', '$state',
        function ($scope, commonService, $stateParams, $state) {
            $scope.sendInquiryResponse = function () {
                debugger

                var data = {
                    Id: $stateParams.Id,
                Message:$scope.message

                }

                commonService.SendResponse(data)

          .then(function (response) {
              alert("Successfully Send");
              $state.go('InquiryManagement');
          }, function (error) {
              alert("Something is wrong please try again");
          });
            }
        }]);
}());
