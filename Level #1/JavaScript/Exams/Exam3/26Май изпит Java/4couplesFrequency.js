function solve(input) {
    var nums = input[0].split(/[ ]/);
    var countNumber = [];
    var number = [];
    var count = 0;

    for (var i = 0; i < nums.length - 3; i++) {
        for (var j = 0; j < nums.length; j++) {

            var num = nums[i] + nums[i + 1];
            var nextNum = nums[j+2] + nums[j+3];
            if(num == nextNum){
                count++;
            }
            if(i == nums.length - 3){
                number.push(num);
                countNumber.push(count);
                count = 0;
            }
        }
    }
    console.log(number);
    console.log(countNumber);
}
solve(['3 4 2 3 4 2 1 12 2 3 4']);
