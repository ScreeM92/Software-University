Array.prototype.flatten = function () {
    return this.reduce(function(flat, toFlatten) {
        return flat.concat(Array.isArray(toFlatten) ? toFlatten.flatten() : toFlatten);
    }, []);
}

var arrays = [
    [1, 2, 3, 4],
    [1, 2, [3, 4], [5, 6]],
    [0, ["string", "values"], 5.5, [[1, 2, true], [3, 4, false]], 10]
];

for (var i = 0, len = arrays.length; i < len; i += 1) {
    console.log(arrays[i].flatten());
    console.log(arrays[i]);
    console.log();
}