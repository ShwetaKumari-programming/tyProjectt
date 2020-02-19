
(function () {
    "use strict";
    angular.module("elmechadmin").controller('LoginController', ['$scope', '$rootScope', '$state', '$stateParams', 'security',
        function ($scope, $rootScope, $state, $stateParams, security) {

            $scope.User = {
                appId: 1
            }
            $scope.login = function () {
                security.login($scope.User)
                   .then(function (response) {
                       var userData = {
                           haveLoggedIn: true,
                           Name: response.name,
                           PhoneNumber: response.phoneNumber,
                           UserId: response.userId,
                           UserName: response.userName
                       };
                       $rootScope.$broadcast("LoggedIn", userData);

                       $state.go('CategoryMaster');

                   }, function (error) {
                       alert("Your username or password is wrong please try again.");
                   });
            }
        }]);
}());