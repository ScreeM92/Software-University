var shapes = shapes || {};

(function(scope) {
    function validatePoint(point) {
        if (typeof point.getType !== 'function' || point.getType() !== 'Point2D') {
            throw new Error('Invalid point.');
        }
    }

    var segment = scope.shape.extends({
        init: function init(pointA, pointB, color) {
            this._super.init.call(this, pointA, color);
            validatePoint(pointB);
            this._pointB = pointB;
            this._POINT_TYPE = 'PointA';
            this._type = 'Segment';
            return this;
        },

        toString: function toString() {
            var segment = this._super.toString.call(this) +
                'PointB: ' + this._pointB + '\n';

            return segment;
        }
    });

    scope.segment = segment;
}(shapes))