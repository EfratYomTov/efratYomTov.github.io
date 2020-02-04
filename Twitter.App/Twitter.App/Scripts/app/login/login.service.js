app.service('loginService', function ($http, $q) {

    this.validateLogin = function (user) {
        var def = $q.defer();

        var request = {
            method: 'POST',
            url: '/api/twitter/login',
            data: JSON.stringify(user),
        }

        $http(request).then(
            function (response) {
                var data = response.data;
                def.resolve(data);
            },
           function (reponse) {
               console.dir(reponse);
               def.reject("Failed to login user");
           });

        return def.promise;

        /*
        $http.get('/api/twitter/login', { params: { email: user.email, password: user.password } }).then(
            function (response) {
                debugger;
                var data = JSON.parse(response.data);
                def.resolve(data);
            },
           function (reponse) {
               console.dir(reponse);
               def.reject("Failed to login user");
           });

        return def.promise;*/
    }

});