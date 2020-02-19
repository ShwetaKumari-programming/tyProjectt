
(function () {
    "use strict";
    angular.module("elmechadmin").controller('SaveCatalogController', ['commonService', '$scope', '$stateParams', '$state',
        function (commonService, $scope, $stateParams, $state) {

            if ($stateParams.catalogId > 0) {
                commonService.GetCatalogInfoById($stateParams.catalogId)
                .then(function (response) {
                    $scope.catalog = response.data;

                }, function (error) {
                    $scope.errorlog = error;
                });
            }
            $scope.cancel = function () {
                $state.go('CatalogManagement', {});
            }

            $scope.save = function () {

                debugger
                
                $scope.catalog.PDFurl = $scope.pdf
                $scope.catalog.Thumbnail = $scope.image;
                commonService.saveCatalog($scope.catalog)
               .then(function (response) {

                   alert("save is successfully compited ");
                   $scope.cancel();

               }, function (error) {
                   alert("Something is wrong please try again");
               });
            }
            $scope.imageUpload = function (event) {
                debugger
                var files = event.target.files; //FileList object
                for (var i = 0; i < files.length; i++) {
                    var file = files[i];
                    var reader = new FileReader();
                    reader.onload = $scope.imageIsLoaded;
                    reader.readAsDataURL(file);
                }
            }
            $scope.pdfUpload = function (event) {
                debugger
                var files = event.target.files; //FileList object
                for (var i = 0; i < files.length; i++) {
                    var file = files[i];
                    var reader = new FileReader();
                    reader.onload = $scope.pdfIsLoaded;
                    reader.readAsDataURL(file);
                }
            }

            $scope.imageIsLoaded = function (e) {
                debugger
                    $scope.image=e.target.result;
                
            }
            $scope.pdfIsLoaded = function (e) {
                debugger
                $scope.pdf = e.target.result;

            }


        }]);
}());