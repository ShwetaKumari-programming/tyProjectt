
(function () {
    "use strict";
    angular.module("elmech").controller('ResetPasswordController', ['$scope', '$rootScope', '$state', '$stateParams', 'security', '$location',
        function ($scope, $rootScope, $state, $stateParams, security, $location) {
            var searchObject = $location.search();
            debugger
            $scope.user = {
                UserId: searchObject.userid,
                Token: searchObject.code,
                NewPassword : "",
                ConfirmPassword:""
            }
            

            $scope.resetPassword = function () {
                if ($scope.user.NewPassword !== $scope.user.ConfirmPassword) {
                return false;
            }
                security.resetPassword($scope.user)
               .then(function (response) {
                   alert("Password Changed Successfuly.");

               }, function (error) {
                   alert("Something is wrong please try again");
               }
               );

            }
        }]);
}());