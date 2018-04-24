define('dataservice', ['ajax'],
    function (ajax) {
        var _apiRoot = 'http://localhost:5001/api/'
        return {
            saveUser: function (userDetails) {
                return ajax.post(_apiRoot + 'user', userDetails);
            }
        }
    }
);