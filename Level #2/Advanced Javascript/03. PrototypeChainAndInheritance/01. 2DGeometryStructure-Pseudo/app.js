(function (scope) {
    var consoleOutput = document.getElementById('console');

    var circle = scope.getCircle(scope.getPoint2D(1, 2), 5, 'blue');
    var rectangle = scope.getRectangle(scope.getPoint2D(3, 4), 2, 3, 'red');
    var triangle = scope.getTriangle(scope.getPoint2D(1, 2), scope.getPoint2D(3, 4), scope.getPoint2D(5, 6), 'green');
    var line = scope.getLine(scope.getPoint2D(11, 12), scope.getPoint2D(13, 14), 'violet');
    var segment = scope.getSegment(scope.getPoint2D(21, 22), scope.getPoint2D(23, 24), 'purple');

    var shapes = [circle, rectangle, triangle, line, segment];

    shapes.forEach(function (shape) {
        consoleOutput.innerHTML += shape.toString() + '<hr>';
        console.log(shape.toString());
    });
}(models))