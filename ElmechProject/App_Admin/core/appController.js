
(function () {
    "use strict";
    angular.module("elmechadmin").controller('AppController', ['$scope', 'security', '$state','$window',
        function ($scope, security, $state, $window) {
            $scope.isLoggedIn = false;
            
            
            $scope.$on("LoggedIn", function (evt, data) {
                if (data.haveLoggedIn) {
                    $scope.isLoggedIn = true;
                    $scope.User = data;
                }
                else {
                    $scope.isLoggedIn = false;
                }
            })

            if (security.isLogin()) {
                $scope.isLoggedIn = true;
                $scope.User = security.getUserDetail();
            }
            else {
                debugger
                $scope.isLoggedIn = false;
                $window.location.href = '/admin/#!/login';
                //$state.go('Login');
            }
        }]);
}());