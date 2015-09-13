function solve(input) {
    var result = [];
    for (var i = 0; i < input.length; i++) {
        result[i] = input[i].split("");
    }

    for (var row = 0; row < input.length; row++) {
        for (var col = 0; col < input[row].length; col++) {
            if (isValid(input, row, col)) {
                result[row][col] = "*";
                result[row - 1][col] = "*";
                result[row][col - 1] = "*";
                result[row][col + 1] = "*";
            }
        }
    }

    console.log(result.map(function(el) {
        return el.join("");
    }).join("\n"));

    function isInRange(input, row, col) {
        var result = row >= 0 && row < input.length &&
            col >= 0 && col < input[row].length;
        return result;
    }

    function isValid(input, row, col) {
        var char = input[row][col];
        var result = isInRange(input, row - 1, col) && input[row - 1][col] == char &&
            isInRange(input, row, col - 1) && input[row][col - 1] == char &&
            isInRange(input, row, col + 1) && input[row][col + 1] == char;
        return result;
    }
}
solve(['abcdexgh', 'bbbdxxxh', 'abcxxxxx']);
solve(['aa', 'aaa', 'aaaa', 'aaaaa']);
solve(['ax', 'xxx', 'b', 'bbb', 'bbbb']);
