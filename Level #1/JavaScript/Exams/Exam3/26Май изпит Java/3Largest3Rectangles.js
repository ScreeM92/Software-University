function solve(input) {
    //console.log(input);
    var numbers = input[0].split(/\D+/);

    numbers.pop();
    numbers.shift();

    var nums = [];

    for (var i = 0; i < numbers.length - 1; i += 2) {
        nums.push(parseInt(numbers[i]) * parseInt(numbers[i + 1]))
    }

    var maxSum = 0;
    for (var i = 0; i < nums.length - 2; i++) {
        var currentSum = nums[i] + nums[i + 1] + nums[i + 2];

        if (currentSum > maxSum) {
            maxSum = currentSum;
        }
    }
    console.log(maxSum)
}
solve(['[3 x 3] [3 x 2] [4 x 3] [1 x 4] [5 x 3] [3 x 1]']);
solve(['[12x7][3x5][10x12]  [4x3][1x8]  ']);
solve(['[2x2][3x3][4x4][5x5][6x6][7x7][8x8][9x9][10x10]']);