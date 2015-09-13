var shapes = shapes || {};

(function (scope) {
    function validateCoordinates(x, y) {
        if (isNaN(x) || isNaN(y)) {
            throw new Error('Point coordinates should be numbers.');
        }
    }

    var point2D = {
        init: function init(x, y) {
            validateCoordinates(x, y);
            this._x = x;
            this._y = y;
            this._type = 'Point2D';
            return this;
        },

        getType: function getType() {
            return this._type;
        },

        toString: function toString() {
            var point = 'x = ' + this._x + ' , y = ' + this._y;

            return point;
        }
    };

    scope.point2D = point2D;
}(shapes));