app.directive("account", function () {
    return {
        restrict: 'E',
        scope: {
            user: '='
        },
        templateUrl: './Scripts/app/account/account.template.html'
    }
});