var app = app || {};

(function(scope) {
    scope.getStudentsData = (function () {
        function getStudentsData() {
            var studentsData = JSON.parse($('#students-input').val());

            return studentsData;
        }

        return getStudentsData;
    }());

    scope.studentsView = (function () {
        function StudentsView(selector, data) {
            $(selector).empty();

            $.get('templates/students.html', function (template) {
                var output = Mustache.render(template, data);
                $(selector).append(output);
            });
        }

        return {
            load: function (selector, data) {
                return new StudentsView(selector, data);
            }
        }
    }());

    scope.attachEventListeners = function () {
        $(document).on('click', '#by-country button', function () {
            var country = $('#by-country input').val();
            var students = scope.filterByCountry(scope.getStudentsData(), country);

            scope.studentsView.load($('#result'), { students: students });
        });

        $(document).on('click', '#by-age button', function () {
            var minAge = Number($('#min-age').val());
            var maxAge = Number($('#max-age').val());
            var students = scope.filterByAge(scope.getStudentsData(), minAge, maxAge);

            scope.studentsView.load($('#result'), { students: students });
        });

        $(document).on('click', '#by-name-alphabetically button', function () {
            var order = Number($('#by-name-alphabetically select').val());
            var students = scope.compareNames(scope.getStudentsData(), order);

            scope.studentsView.load($('#result'), { students: students });
        });

        $(document).on('click', '#last button', function () {
            var n = Number($('#last input').val());
            var students = scope.last(scope.getStudentsData(), n);

            scope.studentsView.load($('#result'), { students: students });
        });

        $(document).on('click', '#mixed button', function () {
            var first = Number($('#first').val());
            var bool = $('#bool').val() === 'true';
            var country = $('#country').val();
            var gender = $('#gender').val();
            var students = scope.mixed(scope.getStudentsData(), first, bool, country, gender);
            
            scope.studentsView.load($('#result'), { students: students });
        });
    };
    
    scope.filterByCountry = (function () {
        function filterByCountry(data, filter) {
            var result = _.filter(data, function (s) {
                return s.country.toLowerCase() === filter.toLowerCase();
            });

            return result;
        }

        return filterByCountry;
    }());

    scope.filterByAge = (function() {
        function filterByAge(data, minAge, maxAge) {
            var result = _.filter(data, function (s) {
                return Number(s.age) >= minAge && Number(s.age) <= maxAge;
            });

            return result;
        }

        return filterByAge;
    }());

    scope.compareNames = (function() {
        function compareNames(data, order) {
            var result = _.filter(data, function (s) {
                return (s.firstName).localeCompare(s.lastName) === order;
            });

            return result;
        }

        return compareNames;
    }());

    scope.last = (function() {
        function last(data, n) {
            var result = _.takeRight(data, n);

            return result;
        }

        return last;
    }());

    scope.mixed = (function() {
        function mixed(data, first, bool, country, gender) {
            var result = _.chain(data)
                .filter(function(s) {
                    return bool ?
                        s.country.toLowerCase() === country.toLowerCase() :
                        s.country.toLowerCase() !== country.toLowerCase();
                })
                .where({ gender: gender })
                .take(first)
                .value();
            
            return result;
        }

        return mixed;
    }());
}(app));