var models = models || {};

(function (scope) {
    function validateRadius(radius) {
        if (isNaN(radius) || radius <= 0) {
            throw new Error('Circle radius should be number greater than 0.');
        }
    }

    var Circle = function() {
        function Circle(centerPoint, radius, color) {
            scope._Shape.call(this, centerPoint, color);
            validateRadius(radius);
            this.setRadius(radius);
            this._POINT_TYPE = 'Central point';
        }

        Circle.extends(scope._Shape);

        Circle.prototype.setRadius = function(radius) {
            this._radius = radius;
        }

        Circle.prototype.getRadius = function() {
            return this._radius;
        }

        Circle.prototype.toString = function() {
            var circle = scope._Shape.prototype.toString.call(this) +
                'Radius: ' + this._radius + '\n';

            return circle;
        }

        return Circle;
    }();

    scope.getCircle = function (centerPoint, radius, color) {
        return new Circle(centerPoint, radius, color);
    }
}(models));