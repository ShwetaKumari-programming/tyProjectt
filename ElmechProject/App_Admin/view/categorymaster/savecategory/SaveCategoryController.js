
(function () {
    "use strict";
    angular.module("elmechadmin").controller('SaveCategoryController', ['commonService', '$scope', '$stateParams', '$state',
        function (commonService, $scope, $stateParams, $state) {

            if ($stateParams.categoryId > 0) {
                commonService.GetCategoryInfoById($stateParams.categoryId)
                .then(function (response) {
                    $scope.category = response.data;

                }, function (error) {
                    $scope.errorlog = error;
                });
            }

            
            $scope.cancel = function () {
                $state.go('CategoryMaster', { categoryId: $stateParams.categoryId });
            }

            $scope.save = function () {

                commonService.saveCategory($scope.category)
                 .then(function (response) {
                     alert("save is successfully compited ");
                     $scope.cancel();

                 }, function (error) {
                     alert("Something is wrong please try again");
                 });
            }

        }]);
}());