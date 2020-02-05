app.controller('addTweetCtrl', ['$scope', 'tweetService', '$q', function ($scope, tweetService, $q) {

    $scope.addTweet = function () {
        var def = $q.defer();

        tweetService.addTweet($scope.userId, $scope.content).then(
            function (data) {
                var result = JSON.parse(data);
                if (result.isSucceeded)
                    $scope.content = null;
                else
                    alert("failed to add tweet");

                def.resolve();

            }, function (error) {
                console.log(error);
                def.reject(error);
            });

        return def.promise;
    }
}]);
