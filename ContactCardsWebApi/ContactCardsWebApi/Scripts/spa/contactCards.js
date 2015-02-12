var contactCardsApp = angular.module('contactCardsApp', []);

contactCardsApp.controller('ContactListCtrl', ['$scope', '$http',function ($scope, $http) {
    $scope.contacts = [];
    $http.get('/api/contacts')
        .success(function (response) {
            $scope.contacts = response;
        })
        .error(function (error) {
            console.log(error);
            alert(error);
        });
    $scope.mobileFilter = function (contact) {
        if (contact.MobilePhone === null || contact.MobilePhone === undefined) {
            return false;
        }
        return true;
    };
}]);