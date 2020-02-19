
(function () {
    "use strict";
    angular.module("elmech").controller('ForgotPasswordController', ['$scope', '$rootScope', '$state', '$stateParams', 'security',
        function ($scope, $rootScope, $state, $stateParams, security) {

          
            $scope.forgotPassword = function () {
               
                security.forgotPassword($scope.User)
               .then(function (response) {
                   alert("Please check your email for reset password link.");
                   
               }, function (error) {
                       alert("Something is wrong please try again");
                   }
               );

            }
           
            
        }]);
}());