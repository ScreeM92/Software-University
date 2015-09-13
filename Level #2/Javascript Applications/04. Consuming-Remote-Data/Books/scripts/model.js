var books = books || {};

(function(scope) {
    function Models(baseUrl) {
        this.baseUrl = baseUrl;
        this.books = new Books(this.baseUrl);
    }

    var Books = (function() {
        function Books(baseUrl) {
            this.serviceUrl = baseUrl + "Book/";
        }

        Books.prototype.getAllBooks = function(success, error) {
            return books.requester.getRequest(this.serviceUrl, success, error);
        };

        Books.prototype.createBook = function(book, success, error) {
            return books.requester.postRequest(this.serviceUrl, book, success, error);
        }

        Books.prototype.editBook = function (id, book, success, error) {
            return books.requester.putRequest(this.serviceUrl + id, book, success, error);
        }

        Books.prototype.deleteBook = function (id, success, error) {
            return books.requester.deleteRequest(this.serviceUrl + id, success, error);
        }

        return Books;
    }());

    scope.models = {
        loadModels: function(baseUrl) {
            return new Models(baseUrl);
        }
    }
}(books));