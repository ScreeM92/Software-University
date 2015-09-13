var models = models || {};

(function(scope) {
    var Segment = function() {
        function Segment(pointA, pointB, color) {
            scope._Line.call(this, pointA, pointB, color);
        }

        Segment.extends(scope._Line);

        return Segment;
    }();

    scope.getSegment = function (pointA, pointB, color) {
        return new Segment(pointA, pointB, color);
    }
}(models))