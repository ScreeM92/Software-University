function solve(input) {
    var numbers = input[0].split(/[() ]+/);
    numbers.pop();
    numbers.shift();
    var nums = [];

    for (var i in numbers) {
        nums.push(parseInt(numbers[i]));
    }

    var currentLength = 0;
    var maxLength = 0;
    var oddRule = nums[0] % 2 != 0;

    for (var i = 0; i < nums.length; i++) {
        var isOdd = nums[i] % 2 != 0;

        if(oddRule == isOdd || nums[i] == 0){
            currentLength++;
        }
        else{
            oddRule = isOdd;
            currentLength = 1;
        }
        oddRule = !oddRule;
        if(currentLength > maxLength){
            maxLength =  currentLength
        }
    }

    console.log(maxLength);

}
solve(['(3) (22) (-18) (55) (44) (3) (21)']);
solve(['(1)(2)(3)(4)(5)(6)(7)(8)(9)(10)']);