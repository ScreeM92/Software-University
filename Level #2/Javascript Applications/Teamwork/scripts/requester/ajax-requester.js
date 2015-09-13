var app = app || {};

app.requester = (function () {
    function Requester(baseUrl) {
        this._baseUrl = baseUrl;
    }

    Requester.prototype.get = function (serviceUrl) {
        var headers = getHeaders();
        var url = this._baseUrl + serviceUrl;

        return makeRequest('GET', headers, url);
    };

    Requester.prototype.post = function (serviceUrl, data) {
        var headers = getHeaders();
        var url = this._baseUrl + serviceUrl;

        return makeRequest('POST', headers, url, data);
    };

    Requester.prototype.delete = function (serviceUrl, id) {
        var headers = getHeaders();
        var url = this._baseUrl + serviceUrl + id;

        return makeRequest('DELETE', headers, url);
    };

    Requester.prototype.put = function (serviceUrl, id, data) {
        var headers = getHeaders();
        var url = this._baseUrl + serviceUrl + id;

        return makeRequest('PUT', headers, url, data);
    };

    Requester.prototype.postFile = function(serviceUrl, file){
        var headers = getHeaders();
            headers['Content-Type'] = file.type;

        var url = this._baseUrl + serviceUrl + file.name;

        return uploadFile('POST', headers, url, file);
    };

    function makeRequest(method, headers, url, data) {
        var defer = Q.defer();
        $.ajax({
            method: method,
            headers: headers,
            url: url,
            //contentType : 'application/json',
            data: JSON.stringify(data),
            processData: false,
            success: function (data) {
                defer.resolve(data);
            },
            error: function (error) {
                defer.reject(error);
            }
        });

        return defer.promise;
    }

    function uploadFile(method, headers, url, file) {
        var defer = Q.defer();
        $.ajax({
            method: method,
            headers: headers,
            url: url,
            data: file,
            processData: false,
            success: function (data) {
                defer.resolve(data);
            },
            error: function (error) {
                defer.reject(error);
            }
        });

        return defer.promise;
    }

    function getHeaders() {
        var PARSE_APP_ID = 'ytpkDUGc9OUgl6y0Qf2eaj1dmeyEiuNdR6LJIJeb';
        var PARSE_REST_API_KEY = '7lbrQ3fOwpYTiFPAfhfd1sjUYGCDZ2tLPQ2uihZ2';

        var headers = {
            'X-Parse-Application-Id': PARSE_APP_ID,
            'X-Parse-REST-API-Key': PARSE_REST_API_KEY,
            'Content-Type': 'application/json'
        };

        if (sessionStorage['logged-in']) {
            headers['X-Parse-Session-Token'] = sessionStorage['logged-in'];
        }

        return headers;
    }

    return {
        get: function (baseUrl) {
            return new Requester(baseUrl);
        }
    }
}());
