var app = app || {};

app.requester = (function () {
    function Requester(baseUrl) {
        this._baseUrl = baseUrl;
    }

    Requester.prototype.get = function (serviceUrl, headers) {
        var url = this._baseUrl + serviceUrl;

        return makeRequest('GET', headers, url);
    };

    Requester.prototype.post = function (serviceUrl, headers, data) {
        var url = this._baseUrl + serviceUrl;

        return makeRequest('POST', headers, url, data);
    };

    Requester.prototype.delete = function (serviceUrl, headers) {
        var url = this._baseUrl + serviceUrl;

        return makeRequest('DELETE', headers, url);
    };

    Requester.prototype.put = function (serviceUrl, headers, data) {
        var url = this._baseUrl + serviceUrl;

        return makeRequest('PUT', headers, url, data);
    };

    function makeRequest(method, headers, url, data) {
        var defer = Q.defer();
        $.ajax({
            method: method,
            headers: headers,
            url: url,
            data: JSON.stringify(data),
            processData: false,
            success: function (_data) {
                defer.resolve(_data);
            },
            error: function (error) {
                defer.reject(error);
            }
        });

        return defer.promise;
    }

    return {
        get: function (baseUrl) {
            return new Requester(baseUrl);
        }
    }
}());