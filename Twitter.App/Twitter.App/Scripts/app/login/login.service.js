﻿app.service('loginService', function ($http, $q) {

    this.validateLogin = function (user) {
        var def = $q.defer();
        var request = JSON.stringify(user);

        $http.post('/api/twitter/login', request).then(
            function (response) {
                var data = response.data;
                def.resolve(data);
            },
           function (reponse) {
               console.dir(reponse);
               def.reject("Failed to login user");
           });

        return def.promise;

      
    }

});