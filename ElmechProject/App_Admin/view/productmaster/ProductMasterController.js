
(function () {
    "use strict";
    angular.module("elmechadmin").controller('ProductMasterController', ['$scope', 'commonService', '$stateParams', '$state',
        function ($scope, commonService, $stateParams, $state) {

            function getProducts() {
                commonService.GetProductInfo($stateParams.categoryId)
             .then(function (response) {
                 $scope.products = response.data;

             }, function (error) {
                 $scope.errorlog = error;
             });

            }
            getProducts();

            $scope.saveproduct = function (product) {
                $state.go('SaveProduct', { productId: product.Id, categoryId: $stateParams.categoryId });
                
            };

            $scope.Deleteproduct = function (productId) {
                if (confirm("Are you sure you want to delete this product")) {
                    commonService.DeleteProduct(productId)
                     .then(function (response) {
                         getProducts()
                       

                     }, function (error) {
                         $scope.errorlog = error;
                     });
                }

            }

        }]);
}());