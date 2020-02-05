app.directive("tweet", function () {
    return {
        restrict: 'E',
        scope: {
            tweet: '='

        },
        templateUrl: './Scripts/app/tweet/tweetDetails.template.html'
    }
});