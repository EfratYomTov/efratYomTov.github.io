app.controller('homeCtrl', ['$scope', 'homeService', '$q', '$window', 'storageService', function ($scope, homeService, $q, $window, storageService) {

    $scope.user = storageService.getUser();

    $scope.editUser = function () {
        $window.location.href = '#!Account';
    }

    $scope.logout = function () {
        $scope.showTweet = true;
        $scope.user = null;
        storageService.resetUser();
        $window.location.href = '#!Login';
    }

    $scope.getOwnTweets = function () {
        var def = $q.defer();

        homeService.getOwnTweets($scope.user.id).then(
            function (data) {
                if (data.isSucceeded) {
                    $scope.tweets = data.tweets;
                }
                else
                    alert("failed to get own tweets");

                def.resolve($scope.tweets);

            }, function (error) {
                console.log(error);
                def.reject(error);
                alert(error);
            });

        return def.promise;
        
    }

    $scope.getFollowedUsersTweets = function () {
        $scope.showTweet = true;
        var def = $q.defer();

        homeService.getFollowedUsersTweets($scope.user.id).then(
            function (data) {
                if (data.isSucceeded) {
                    $scope.tweets = data.tweets;
                }
                else
                    alert("failed to get followed users tweets");

                def.resolve($scope.tweets);

            }, function (error) {
                console.log(error);
                def.reject(error);
                alert(error);
            });

        return def.promise;
    }

    $scope.getUsers = function () {

        $scope.showTweet = false;
        var def = $q.defer();

        homeService.getUsers($scope.searchUserFirstName).then(
            function (data) {
                if (data.isSucceeded) {
                    $scope.users = data.users;
                }
                else
                    alert("failed to get users");
                def.resolve($scope.users);

            }, function (error) {
                console.log(error);
                def.reject(error);
                alert(error);
            });

        return def.promise;
    }

}]);