function solve(input){
    var numbers = input[0].split(/[() ]+/);
    var nums = [];
    for(var i in numbers){
        if(numbers[i] !== ''){
            nums.push(parseInt(numbers[i]));
        }
    }
    var counter = 0;
    var counterMax = 0;

    var oddBegin = nums[0] % 2 != 0;

    for (var i = 0; i < nums.length; i++) {
        var oddNum = nums[i] % 2 != 0;

        if(oddNum == oddBegin  || nums[i] == 0){
            counter++;
        }
        else{
            oddBegin = oddNum;
            counter = 1;
        }
        oddBegin = !oddBegin;
        if(counter > counterMax){
            counterMax = counter;
        }
    }
    console.log(counterMax);
}

solve(['( 2 )  ( 33 ) (1) (4)   (  -1  ) ']);
solve(['(3) (22) (-18) (55) (44) (3) (21)']);
solve(['(1)(2)(3)(4)(5)(6)(7)(8)(9)(10)']);
