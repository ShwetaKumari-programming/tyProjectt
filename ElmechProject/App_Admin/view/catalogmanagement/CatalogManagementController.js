
(function () {
    "use strict";
    angular.module("elmechadmin").controller('CatalogManagementController',['$scope', 'commonService','$state',
        function ($scope, commonService, $state) {
            function getcatalogs() {
                commonService.GetCatalogInfo()
                .then(function (response) {
                    $scope.Cataloginfo = response.data;

                }, function (error) {
                    $scope.errorlog = error;
                });
            }
           
            getcatalogs();

            $scope.Savecatalog = function (catalog) {
                              $state.go('Savecatalog', { catalogId : catalog.Id });
            };

            $scope.Deletecatalog = function (catalogId) {
                if (confirm("Are you sure you want to delete this catalog")) {
                    commonService.Deletecatalog(catalogId)
                     .then(function (response) {
                         getcatalogs()
                         alert("Record delete successfully.");

                     }, function (error) {
                         $scope.errorlog = error;
                     });
                }

            }

        }]);
}());