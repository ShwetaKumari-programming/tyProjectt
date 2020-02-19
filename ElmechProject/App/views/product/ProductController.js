
(function () {
    "use strict";
    angular.module("elmech").controller('ProductController', ['$scope',  'commonService','$rootScope','$filter',
        function ($scope,  commonService, $rootScope,$filter) {

            commonService.getProduct()
                .then(function (response) {
                    $scope.products = response.data;
                    setTimeout(function () {
                        readyPage();
                    },500)
                }, function (error) {
                    $scope.errorlog = error;
                });
            //$scope.subproduct.CurrentPrice = $filter('currency')($scope.subproduct.CurrentPrice, '&#8377;');

            $scope.open = function (size, parentSelector) {
                var parentElem = parentSelector ?
                  angular.element($document[0].querySelector('.modal-demo ' + parentSelector)) : undefined;

                var modalInstance = $uibModal.open({
                    animation: true,
                    ariaLabelledBy: 'modal-title',
                    ariaDescribedBy: 'modal-body',
                    templateUrl: 'myModalContent.html',
                    appendTo: parentElem
                });

                modalInstance.result.then(function (selectedItem) {

                }, function () {
                    $log.info('Modal dismissed at: ' + new Date());
                });
            }

            $scope.addToCart = function (product) {
                debugger
                //var productToCart = {
                //    ProductId: product.Id,
                //    ImageURL: product.ImageURL,
                //    Name: product.Name,
                //    CurrentPrice: product.CurrentPrice,
                //    Quantity:1
                //}
                $rootScope.$broadcast("addToCart", product);
            }

        }]);
}());

