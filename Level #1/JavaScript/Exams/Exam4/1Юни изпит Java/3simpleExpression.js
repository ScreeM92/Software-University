function solve(input) {
    var digits = input[0].split(' ');

    var str = '';
    for (var i in digits) {
        if(digits[i] != '') {
            str += digits[i];
        }
    }

    console.log(eval(str).toFixed(16))
}
solve(['  5 -33   + 12 -  55-  1  - 2+6'])
solve(['1.5 + 2.5'])
solve(['0.05+0.01 - 1'])
solve(['9876543210 + 0.987654321'])