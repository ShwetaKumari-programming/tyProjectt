
(function () {
    "use strict";
    angular.module("elmech").controller('RegistrationController', ['$state', '$stateParams', '$scope', 'security','$rootScope',
        function ($state, $stateParams, $scope, security, $rootScope) {
            //$scope.User = {
            //    Name: 'Jaimin Panchal',
            //    Address1: "Harivilla",
            //    Address2: "Ranip",
            //    Email: "panchaljaimin22@gmail.com",
            //    PhoneNumber: "9638527414",
            //    State: "Gujarat",
            //    City: "Ahmedabad",
            //    Password:"Jaimin123*",
            //    ConfirmPassword: "Jaimin123*"
            //}
            $scope.reset = function () {
                $state.go('Home');
            }
            $scope.save = function () {
                debugger
                security.register($scope.User)
               .then(function (response) {
                   var userData = {
                       haveLoggedIn :true,
                       Name: response.name,
                       PhoneNumber: response.phoneNumber,
                       UserId: response.userId,
                       UserName: response.userName
                   };
                   alert("your registration successfully Complited");
                   $rootScope.$broadcast("LoggedIn", userData);
                   if ($stateParams.returnUrl == 'Product') {
                       $state.go('Product');
                   }
                   else if ($stateParams.returnUrl == 'Checkout') {
                       $state.go('Checkout');
                   }

               }, function (error) {
                   alert("Something is wrong please try again");
               });
            }
           
        }]);
}());