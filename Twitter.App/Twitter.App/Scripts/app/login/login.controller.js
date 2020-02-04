app.controller('loginCtrl', ['$scope', 'loginService','$q',  function ($scope, loginService, $q) {

    $scope.user = {
        email: null,
        password:null
    };
   
    $scope.login = function () {
        debugger;
        $scope.showLoading = true;
        var def = $q.defer();

        loginService.validateLogin($scope.user).then(
            function (data) {

                if (data && data.isSucceeded) {
                    $scope.user = data.user;
                    //Go to user details
                }
                else
                    console.log("login failed, email or password is invalid");

                $scope.showLoading = false;
                def.resolve($scope.user);

            }, function (error) {
                console.log(error);
                def.reject(error);
                $scope.showLoading = false;
            });

        return def.promise;
    }

}]);