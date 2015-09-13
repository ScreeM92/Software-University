function solve(input) {
    var n = input[0];
    input.shift();
    var nums = [];

    for (var obj in input) {
        nums.push(parseInt(input[obj]));
    }

    var numbers = [];

    for (var a = 0; a < n; a++) {
        for (var b = 0; b < n; b++) {
            for (var c = 0; c < n; c++) {
                if (b != a && b > a) {
                    var complete = nums[a]*nums[a] + nums[b]*nums[b] === nums[c]*nums[c];
                    if(complete){
                        var expression = nums[a] + "*" + nums[a] +  " + " + nums[b]+"*"+nums[b] +" = "+ nums[c]+"*" + nums[c];
                        if (numbers.indexOf(expression) < 0) {
                            numbers.push(expression);
                        }
                    }
                }

            }

        }

    }
    if(numbers.length < 1){
        console.log('No');
    }
    else{
        console.log(numbers.join('\n'));
    }
}
solve(['8','41','5','9','12','4','13','40','3']);
solve(['3','10','20','30']);
solve(['5','3','12','5','0','4']);