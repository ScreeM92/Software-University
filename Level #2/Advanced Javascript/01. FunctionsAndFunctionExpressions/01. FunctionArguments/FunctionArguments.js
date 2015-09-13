function printArgsInfo() {
    for (var i = 0; i < arguments[0].length; i++) {
        console.log(arguments[0][i] + " (" + typeof (arguments[0][i]) + ")\n");
    }
}

var input = [
    [2, 3, 2.5, -110.5564, false],
    [null, undefined, "", 0, [], {}],
    [[1, 2], ["string", "array"], ["single value"]],
    ["some string", [1, 2], ["string", "array"], ["mixed", 2, false, "array"], { name: "Peter", age: 20 }],
    [[[1, [2, [3, [4, 5]]]], ["string", "array"]]]
];

for (var i in input) {
    printArgsInfo(input[i]);
    console.log("***************************");
}