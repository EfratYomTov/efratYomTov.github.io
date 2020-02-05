app.directive("user", function () {
    return {
        restrict: 'E',
        scope: {
            currentUserId: '=',
            user: '='

        },
        templateUrl: './Scripts/app/user/user.template.html'
    }
});