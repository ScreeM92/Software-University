function printArgsInfo() {
    for (var i = 0; i < arguments.length; i++) {
        console.log(arguments[i] + " (" + typeof (arguments[i]) + ")\n");
    }
}

console.log("-==== Call without arguments: ====-\n");
printArgsInfo.call();

console.log("-==== Call with arguments: ====-");
printArgsInfo.call(null, 2, 3, 2.5, -110.5564, false);

console.log("-==== Apply without arguments: ====-\n");
printArgsInfo.apply();

console.log("-==== Apply with arguments: ====-");
printArgsInfo.apply(null, [2, 3, 2.5, -110.5564, false]);