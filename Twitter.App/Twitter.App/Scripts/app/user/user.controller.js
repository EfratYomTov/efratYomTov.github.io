app.controller('userCtrl', ['$scope', 'userService', '$q', function ($scope, userService, $q) {

    $scope.follow = function () {


        var def = $q.defer();

        userService.follow($scope.currentUserId, $scope.user.id).then(
            function (data) {

                var result = JSON.parse(data);
                if (!result.isSucceeded) {
                    alert("failed follow to user");
                }
            }, function (error) {
                console.log(error);
                def.reject(error);

            });

        return def.promise;
    }
}]);