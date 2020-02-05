app.factory('storageService', function () {

    var dataStorage = {
        user: null
    };

    dataStorage.updateUser = function (user) {
        dataStorage.user = user;
    };

    dataStorage.getUser = function () {
        return dataStorage.user;
    };

    dataStorage.resetUser = function () {
        return dataStorage.user = null;
    };

    return dataStorage;

    
});

