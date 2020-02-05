app.service('tweetService', function ($http, $q) {

    this.addTweet = function (userId, content) {
        var def = $q.defer();
        var request = { userId: userId, content: content };

        $http.post('/api/twitter/addTweet', request).then(
            function (response) {
                var data = response.data;
                def.resolve(data);
            },
           function (reponse) {
               console.dir(reponse);
               def.reject("Failed to add tweet");
           });

        return def.promise;

        
    }

});