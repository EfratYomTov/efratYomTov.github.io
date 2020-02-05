app.controller('loginCtrl', ['$scope', 'loginService', '$q', '$window', 'storageService', function ($scope, loginService, $q, $window, storageService) {

  
   
    $scope.login = function () {
        $scope.showLoading = true;
        var def = $q.defer();

        loginService.validateLogin($scope.user).then(
            function (data) {

                var result = JSON.parse(data);
                if (result.isSucceeded) {
                    $scope.user = result.user;
                    storageService.updateUser(result.user);
                    $window.location.href = '#!Home/';
                }
                else
                    alert("login failed, email or password is invalid");

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