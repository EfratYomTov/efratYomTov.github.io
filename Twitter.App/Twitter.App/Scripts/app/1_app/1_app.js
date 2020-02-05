var app = angular.module("twitterApp", ['ngRoute']);



app.config(function ($routeProvider) {
    $routeProvider.
    when("/Account", {
        templateUrl: "./Scripts/app/account/account.template.html",
        controller: "accountCtrl"
    }).
    when("/Login", {
         templateUrl: "./Scripts/app/login/login.template.html",
         controller: "loginCtrl"
    }).
    when("/Home", {
        templateUrl: "./Scripts/app/home/home.template.html",
        controller: "homeCtrl"
    }).

    otherwise({
        redirectTo: '/Login'
    });
});
