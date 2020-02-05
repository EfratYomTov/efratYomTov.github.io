app.service('homeService', function ($http, $q) {

    this.getOwnTweets = function (userId) {
        var def = $q.defer();
        $http.get('/api/twitter/getOwnTweets', { params: { userId: userId } }).then(
            function (response) {
                var data = JSON.parse(response.data);
                def.resolve(data);
            },
           function (reponse) {
               console.dir(reponse);
               def.reject("Failed to get own tweets");
           });

        return def.promise;
    }

    this.getFollowedUsersTweets = function (userId) {
        var def = $q.defer();
        $http.get('/api/twitter/getFollowedUsersTweets', { params: { userId: userId } }).then(
            function (response) {
                var data = JSON.parse(response.data);
                def.resolve(data);
            },
           function (reponse) {
               console.dir(reponse);
               def.reject("Failed to get own tweets");
           });

        return def.promise;
    }

    this.getUsers = function (userId, searchUserFirstName) {
        var def = $q.defer();
        $http.get('/api/twitter/getUsers', { params: { userId: userId, firstName: searchUserFirstName } }).then(
            function (response) {
                var data = JSON.parse(response.data);
                def.resolve(data);
            },
           function (reponse) {
               console.dir(reponse);
               def.reject("Failed to get users");
           });

        return def.promise;
    }
});