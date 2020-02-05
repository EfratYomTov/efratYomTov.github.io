app.controller('accountCtrl', ['$scope', 'accountService', '$q', '$window', 'storageService', function ($scope, accountService, $q, $window, storageService) {

    $scope.user = storageService.getUser();
    $scope.isExistUser = $scope.user != null;

    $scope.createAccount = function () {
        $scope.showLoading = true;
        var def = $q.defer();

        accountService.createAccount($scope.user).then(
            function (data) {
                var result = JSON.parse(data);
                if (result.isSucceeded) {
                    $scope.user = result.user;
                    storageService.updateUser(result.user);
                    $window.location.href = '#!Home/';
                }
                else
                    alert("Failed to create user");

                $scope.showLoading = false;
                def.resolve($scope.user);

            }, function (error) {
                console.log(error);
                def.reject(error);
                alert(error);
                $scope.showLoading = false;
            });

        return def.promise;
    }


    $scope.editAccount = function () {

        $scope.showLoading = true;
        var def = $q.defer();

        accountService.editAccount($scope.user).then(
            function (data) {

                var result = JSON.parse(data);
                if (result.isSucceeded) {
                    $scope.user = result.user;
                    storageService.updateUser(result.user);
                    $window.location.href = '#!Home/';
                }
                else
                    alert("Failed to edit user");

                $scope.showLoading = false;
                def.resolve($scope.user);

            }, function (error) {
                console.log(error);
                def.reject(error);
                alert(error);
                $scope.showLoading = false;
            });

        return def.promise;
    }


}]);