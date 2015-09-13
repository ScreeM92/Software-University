var app = app || {};

(function(scope) {
    scope.getBooksData = (function () {
        function getBooksData() {
            var booksData = JSON.parse($('#books-input').val());

            return booksData;
        }

        return getBooksData;
    }());

    scope.booksView = (function () {
        function BooksView(path, selector, data) {
            $(selector).empty();

            $.get(path, function (template) {
                var temp = Handlebars.compile(template);
                var html = temp(data);
                $(selector).append(html);
            });
        }

        return {
            load: function (path, selector, data) {
                return new BooksView(path, selector, data);
            }
        }
    }());

    scope.attachEventListeners = function () {
        $(document).on('click', '#group button', function () {
            var groupBy = $('#group-by').val();
            var firstSort = $('#first-sort').val();
            var firstSortType = $('#first-sort-type').val() === 'true';
            var secondSort = $('#second-sort').val();
            var secondSortType = $('#second-sort-type').val() === 'true';

            var books = scope.group(scope.getBooksData(), groupBy, firstSort, firstSortType, secondSort, secondSortType);

            scope.booksView.load('templates/books.html', $('#result'), { books: books });
        });

        $(document).on('click', '#average-price button', function () {
            var books = scope.average(scope.getBooksData(), 'author');
            scope.booksView.load('templates/average-price.html', $('#result'), { books: books });
        });

        $(document).on('click', '#language button', function () {
            var language = $('#book-language').val();
            var priceType = $('#price-type').val() === 'true';
            var price = $('#price').val();

            var books = scope.language(scope.getBooksData(), language, priceType, price, 'author');
            scope.booksView.load('templates/books.html', $('#result'), { books: books });
        });
    };

    scope.group = (function() {
        function group(data, groupBy, firstSort, firstSortType, secondSort, secondSortType) {
            var result = _.chain(data)
                .groupBy(groupBy)
                .mapValues(function (value) {
                    return _.sortByOrder(value, [firstSort, secondSort], [firstSortType, secondSortType]);
                })
                .value();
            return result;
        }

        return group;
    }());

    scope.average = (function () {
        function average(data, groupBy) {
            var result = _.chain(data)
                .groupBy(groupBy)
                .mapValues(function (value, key) {
                    return {
                        author: key,
                        averagePrice: (_.sum(_.map(value, function (x) {
                            return x.price.replace(/,/g, '.');
                        })) / value.length).toFixed(2)
                    }
                })
                .value();

            return result;
        }

        return average;
    }());

    scope.language = (function() {
        function gropuByLanguage(data, language, priceType, price, groupBy) {
            var result = _.chain(data)
                .filter(function (value) {
                    return value.language.toLowerCase() === language.toLowerCase();
                })
                .filter(function (value) {
                    var p = Number(value.price.replace(/,/g, '.'));
                    return priceType ? p < Number(price) : p > Number(price) ;
                })
                .groupBy(function(value) {
                    return value[groupBy];
                })
                .value();

            return result;
        }

        return gropuByLanguage;
    }());
}(app));