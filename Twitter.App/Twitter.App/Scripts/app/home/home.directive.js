app.directive("home", function () {
    return {
        restrict: 'E',
        scope: {
            user: '='

        },
        templateUrl: './Scripts/app/home/home.template.html'
    }
});