
(function () {
    "use strict";
    angular.module("elmech").controller('InquiryController', ['$state','$scope','commonService',
        function ($state, $scope,commonService) {
          
            $scope.reset = function () {
                $state.go('Home');
            }
            $scope.save = function () {
               
                commonService.InquiryInfo($scope.Inquiry)
               .then(function (response) {
                   //var userData = {
                      
                   //    Subject: response.subject,
                   //    Details: response.details,
                   //   FirstName: response.firstname,
                   //   LastName: response.lastname,
                   //   CompanyName:response.companyname,
                   //   Email:response.email,
                   //   Telephone:response.telephone,
                   //   State:response.state,
                   //    City:response.city
                   //};
                   alert("your query is successfully compited ");
                  
               }, function (error) {
                   alert("Something is wrong please try again");
               });
            }
        }]);
}());