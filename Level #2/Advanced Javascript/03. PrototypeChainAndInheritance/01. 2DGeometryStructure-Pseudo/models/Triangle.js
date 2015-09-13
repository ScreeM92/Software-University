var models = models || {};

(function (scope) {
    function validatePoint(point) {
        if (!(point instanceof scope._Point2D)) {
            throw new Error('Invalid point.');
        }
    }

    var Triangle = function() {
        function Triangle(pointA, pointB, pointC, color) {
            scope._Shape.call(this, pointA, color);
            validatePoint(pointB);
            validatePoint(pointC);
            this.setPointB(pointB);
            this.setPointC(pointC);
            this._POINT_TYPE = 'PointA';
        }

        Triangle.extends(scope._Shape);

        Triangle.prototype.getPointB = function () {
            return this._pointB;
        }

        Triangle.prototype.setPointB = function(pointB) {
            this._pointB = pointB;
        }

        Triangle.prototype.getPointC = function () {
            return this._pointC;
        }

        Triangle.prototype.setPointC = function (pointC) {
            this._pointC = pointC;
        }

        Triangle.prototype.toString = function () {
            var triangle = scope._Shape.prototype.toString.call(this) + 
                            'PointB: ' + this._pointB + '\n' + 
                            'PointC: ' + this._pointC + '\n';

            return triangle;
        }

        return Triangle;
    }();

    scope.getTriangle = function (pointA, pointB, pointC, color) {
        return new Triangle(pointA, pointB, pointC, color);
    }
}(models))