app.service('userService', function ($http, $q) {

    this.follow = function (userId, userFollowedId) {
        var def = $q.defer();
        var request = { userId: userId, userFollowedId: userFollowedId };

        $http.post('/api/twitter/follow', request).then(
            function (response) {
                var data = response.data;
                def.resolve(data);
            },
           function (reponse) {
               console.dir(reponse);
               def.reject("Failed to follow user");
           });

        return def.promise;


    }

});