app.directive("addTweet", function () {
    return {
        restrict: 'E',
        scope: {
            userId: '='

        },
        templateUrl: './Scripts/app/tweet/addTweet.template.html'
    }
});