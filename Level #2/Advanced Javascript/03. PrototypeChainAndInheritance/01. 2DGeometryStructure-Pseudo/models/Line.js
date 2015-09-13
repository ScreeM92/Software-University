var modlels = models || {};

(function (scope) {
    function validatePoint(point) {
        if (!(point instanceof scope._Point2D)) {
            throw new Error('Invalid point.');
        }
    }

    var Line = function () {
        function Line(pointA, pointB, color) {
            scope._Shape.call(this, pointA, color);
            validatePoint(pointB);
            this.setPointB(pointB);
            this._POINT_TYPE = 'PointA';
        }

        Line.extends(scope._Shape);

        Line.prototype.getPointB = function() {
            return this._pointB;
        }

        Line.prototype.setPointB = function(pointB) {
            this._pointB = pointB;
        }

        Line.prototype.toString = function() {
            var line = scope._Shape.prototype.toString.call(this) +
                'PointB: ' + this._pointB + '\n';

            return line;
        }

        return Line;
    }();


    scope._Line = Line;
    scope.getLine = function (pointA, pointB, color) {
        return new Line(pointA, pointB, color);
    }
}(models));