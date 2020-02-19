(function () {
    "use strict";
    angular.module("elmech").controller('CheckoutController', ['$scope', 'commonService', 'security', '$rootScope', '$state',
    function ($scope, commonService, security, $rootScope, $state) {
        debugger
        var order = {};
        $scope.BillingInfo = { Same_as_userdetail: true, OrderId: 0 }
        $scope.paymentinfo = { PaymentMethod: "1" }
        $scope.carts = JSON.parse(localStorage.getItem('addToCart'));
        
        commonService.saveOrder($scope.carts)
             .then(function (response) {
                 order = response.data;
                 $scope.BillingInfo.OrderId = order.Id;
                 //Confirmation
                 //Id
                 //PaymentMethod
                 //Status
                 //TotalAmount
             }, function (error) {
                 $scope.errorlog = error;
             });

        commonService.GetUser()
              .then(function (response) {
                  $scope.UserInfo = response.data;

              }, function (error) {
                  $scope.errorlog = error;
              });

        $scope.save = function () {

            commonService.billingInfo($scope.BillingInfo)
           .then(function (response) {
               $('#billingInfo').trigger('click');
               setTimeout(function () {
                   $('#payamentInfo').trigger('click');
               }, 500)

               alert("Succsessfully submited");
           }, function (error) {
               alert("Something is wrong please try again");
           });
        }
        
        $scope.savepayment = function () {
            var orderObj = {
                Id: order.Id,
                PaymentMethod: $scope.paymentinfo.PaymentMethod
            }
            commonService.savePaymentMethod(orderObj)
           .then(function (response) {
               $('#payamentInfo').trigger('click');
               setTimeout(function () {
                   $('#confirmOrder').trigger('click');
               }, 500)

              // alert("Succsess");
               totalAmount();
           }, function (error) {
               alert("Something is wrong please try again");
           });
        }
        //function totalAmount() {
        //    $scope.TotalAmount = 0;
        //    angular.forEach($scope.carts, function (obj, index) {
        //        $scope.TotalAmount = $scope.TotalAmount + parseInt(obj.CurrentPrice);
        //    });
        //}
        $scope.saveConfirmation = function () {

            var orderObj = {
                Id: order.Id,
                TotalAmount: $scope.grandtotal
            }
            commonService.saveConfirmOrder(orderObj)
           .then(function (response) {
               localStorage.removeItem('addToCart');
               $rootScope.$broadcast("removeToCart")
               alert("Your order placed successfull.");
               $state.go('Product')
           }, function (error) {
               alert("Something is wrong please try again");
           });
        }
        //function grandTotalFunction() {
        var total = 0;
        angular.forEach($scope.carts, function (obj, index) {
            debugger
               total += obj.Amount;
        })
        $scope.grandtotal=total
        //}
       
    }]);
}());