var shapes = shapes || {};

(function (scope) {
    function validateRadius(radius) {
        if (isNaN(radius) || radius <= 0) {
            throw new Error('Circle radius should be number greater than 0.');
        }
    }

    var circle = scope.shape.extends({
        init: function init(centerPoint, radius, color) {
            this._super.init.call(this, centerPoint, color);
            validateRadius(radius);
            this._radius = radius;
            this._POINT_TYPE = 'Central point';
            this._type = 'Circle';
            return this;
        },

        toString: function toString() {
            var circle = this._super.toString.call(this) +
                'Radius: ' + this._radius + '\n';

            return circle;
        }
    });
    
    scope.circle = circle;
}(shapes));