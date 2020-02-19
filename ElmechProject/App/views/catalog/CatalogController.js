
(function () {
    "use strict";
    angular.module("elmech").controller('CatalogController', ['$scope', 'commonService',
        function ($scope,  commonService) {

            commonService.GetCatalog()
                .then(function (response) {
                    $scope.catalogs = response.data;
                }, function (error) {
                    $scope.errorlog = error;
                });
            
            $scope.open = function (pdfurl) {
                debugger
                window.open('Content/catalogs/'+pdfurl);
            }

        
        }]);
}());


