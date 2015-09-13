var app = app || {};
app.views = app.views || {};

app.views.clearView = function () {
    function clearView(selector) {
        var defer = Q.defer();

        $.get('', function () {
            $(selector).html('');
        }).success(function (_data) {
            defer.resolve(_data);
        }).error(function (error) {
            defer.reject(error);
        });

        return defer.promise;
    }

    return {
        load: function (selector) {
            return clearView(selector);
        }
    }
}();