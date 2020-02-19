
(function () {
    "use strict";
    angular.module("elmech").controller('LoginController', ['$scope', '$rootScope', '$state', '$stateParams', 'security',
        function ($scope, $rootScope, $state, $stateParams, security) {

            $scope.User = {
                appId : 0
            }
            $scope.gotoRegister = function () {
                $state.go('Registration', { returnUrl: 'Checkout' });
            }
          
            $scope.forgetpassword = function () {
               
                $state.go('ForgotPassword');
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
                       if ($stateParams.returnUrl == 'Product') {
                           $state.go('Product');
                       }
                       else if ($stateParams.returnUrl == 'Checkout') {
                           $state.go('Checkout');
                       }

                   }, function (error) {
                       alert("Your username or password is wrong please try again.");
                   });
            }
        }]);
}());