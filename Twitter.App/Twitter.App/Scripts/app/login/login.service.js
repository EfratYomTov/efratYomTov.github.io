app.service('loginService', function ($http, $q) {

    this.validateLogin = function (email, password) {
        var def = $q.defer();

        $http.get('/Twitter/GetUser', { params: { email: email, password: password } }).then(
            function (response) {
                var data = JSON.parse(response.data);
                console.dir(data);
                def.resolve(data);
            },
           function (reponse) {
               console.dir(reponse);
               def.reject("Failed to get user");
           });

        return def.promise;
    }

});