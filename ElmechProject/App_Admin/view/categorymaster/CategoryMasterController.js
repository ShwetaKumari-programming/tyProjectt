
(function () {
    "use strict";
    angular.module("elmechadmin").controller('CategoryMasterController', ['$scope', 'commonService','$state',
        function ($scope, commonService, $state) {
            function getcategory() {
                commonService.GetCategoryInfo()
             .then(function (response) {
                 $scope.Catagorys = response.data;

             }, function (error) {
                 $scope.errorlog = error;
             });
            }
            

            $scope.productpage = function (category) {
                $state.go('ProductMaster', { 'categoryId': category.Id })
            }


            getcategory();

            $scope.savecategory = function (category) {
                $state.go('Savecategory', { categoryId : category.Id });

            };

            $scope.Deletecategory = function (categoryId) {
                if (confirm("Are you sure you want to delete this product")) {
                    commonService.Deletecategory(categoryId)
                     .then(function (response) {
                         getcategory()


                     }, function (error) {
                         $scope.errorlog = error;
                     });
                }

            }
        
        }]);
}());