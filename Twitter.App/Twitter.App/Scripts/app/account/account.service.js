app.service('accountService', function ($http, $q) {

    this.createAccount = function (user) {
        var def = $q.defer();
        var request = JSON.stringify(user);

        $http.post('/api/twitter/createAccount', request).then(
            function (response) {
                var data = response.data;
                def.resolve(data);
            },
           function (reponse) {
               console.dir(reponse);
               def.reject("Failed to create user");
           });

        return def.promise;
    }

    this.editAccount = function (user) {
        var def = $q.defer();
        var request = JSON.stringify(user);

        $http.post('/api/twitter/editAccount', request).then(
            function (response) {
                var data = response.data;
                def.resolve(data);
            },
           function (reponse) {
               console.dir(reponse);
               def.reject("Failed to edit user");
           });

        return def.promise;
    }

});