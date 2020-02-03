app.controller('loginCtrl',  ['$scope','loginService', function($scope, loginService) {

    $scope.user = {
        email: 'sdsd',
        password:null
    };
   
    $scope.login = function () {
        debugger;
        var def = $q.defer();

        loginService.validateLogin($scope.email, $scope.password).then(
            function (data) {
                console.dir(data);
                $scope.user = data[0];
                def.resolve($scope.user);
            }, function (error) {
                console.log(error);
                def.reject(error);
            });

        return def.promise;
    }

}]);