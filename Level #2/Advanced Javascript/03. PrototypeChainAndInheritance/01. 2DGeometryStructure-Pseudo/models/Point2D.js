var models = models || {};

(function (scope) {
    function validateCoordinates(x, y) {
        if (isNaN(x) || isNaN(y)) {
            throw new Error('Point coordinates should be numbers.');
        }
    }

    var Point2D = function() {
        function Point2D(x, y) {
            validateCoordinates(x, y);
            this.setX(x);
            this.setY(y);
        }

        Point2D.prototype.setX = function(x) {
            this._x = x;
        }

        Point2D.prototype.setY = function (y) {
            this._y = y;
        }

        Point2D.prototype.toString = function() {
            var point = 'x = ' + this._x + ' , y = ' + this._y;

            return point;
        }

        return Point2D;
    }();

    scope._Point2D = Point2D;
    scope.getPoint2D = function (x, y) {
        return new Point2D(x, y);
    }
}(models));