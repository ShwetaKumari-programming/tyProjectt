(function () {
    "use strict";
    angular.module("elmech").controller('SampleController', ['$scope', 'commonService',
        function ($scope, commonService) {

            commonService.GetSampleInfo()
             .then(function (response) {
                 $scope.Sinfo = response.data;

             }, function (error) {
                 $scope.errorlog = error;
             });
      
          
        }]);
}());