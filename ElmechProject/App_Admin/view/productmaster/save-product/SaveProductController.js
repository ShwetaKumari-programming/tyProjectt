
(function () {
    "use strict";
    angular.module("elmechadmin").controller('SaveProductController', ['commonService', '$scope', '$stateParams', '$state',
        function (commonService, $scope, $stateParams, $state) {

            if ($stateParams.productId > 0) {
                commonService.GetProductInfoById($stateParams.productId)
                .then(function (response) {
                    $scope.product = response.data;

                }, function (error) {
                    $scope.errorlog = error;
                });
            }
            $scope.cancel = function () {
                $state.go('ProductMaster', { categoryId: $stateParams.categoryId });
            }

            $scope.save = function () {

                 $scope.product.ImageURL = $scope.image;
                $scope.product.CatagoryId = $stateParams.categoryId;
                commonService.saveInfo($scope.product)
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
            $scope.imageIsLoaded = function (e) {
                debugger
                $scope.image = e.target.result;

            }




        }]);
}());