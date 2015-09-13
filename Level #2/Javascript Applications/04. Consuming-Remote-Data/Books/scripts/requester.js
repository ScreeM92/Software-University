var books = books || {};

(function(scope) {
    var Requester = (function() {
        function makeRequest(method, url, data, success, error) {
            $.ajax({
                method: method,
                headers: {
                    'X-Parse-Application-Id': 'dJ5cef8XX8dnbV8GAvlNPSU6z7A6Yl0tw44Bst0h',
                    'X-Parse-REST-API-Key': '9buDpbLA7t16Lvhgn6s7wDFP1gxlcCelR0RZL9Wh'
                },
                url: url,
                contentType: 'application/json',
                data: JSON.stringify(data) || undefined,
                success: success,
                error: error
            });
        }

        function getRequest(url, success, error) {
            return makeRequest('GET', url, null, success, error);
        }

        function postRequest(url, data, success, error) {
            return makeRequest('POST', url, data, success, error);
        }

        function putRequest(url, data, success, error) {
            return makeRequest('PUT', url, data, success, error);
        }

        function deleteRequest(url, success, error) {
            return makeRequest('DELETE', url, null, success, error);
        }

        return {
            getRequest: getRequest,
            postRequest: postRequest,
            putRequest: putRequest,
            deleteRequest: deleteRequest
        }
    }());

    scope.requester = Requester;
}(books));