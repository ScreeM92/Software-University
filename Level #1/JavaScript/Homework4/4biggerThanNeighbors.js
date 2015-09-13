function biggerThanNeighbors(input, inputArray){
    var index = input;
    var nums = inputArray;
    var num = nums[index];
    var previousNum = nums[index - 1];
    var nextNum = nums[index + 1];

    if(index == 0 || index == nums.length - 1){
        return "only one neighbor";
    }
    else if(num > previousNum && num > nextNum){
        return "bigger";
    }
    else if(num <= previousNum || num <= nextNum){
        return "not bigger";
    }
    else if(index >= nums.length || index < 0){
        return "invalid index";
    }
}

console.log(biggerThanNeighbors(2, [1, 2, 3, 3, 5]));
console.log(biggerThanNeighbors(2, [1, 2, 5, 3, 4]));
console.log(biggerThanNeighbors(5, [1, 2, 5, 3, 4]));
console.log(biggerThanNeighbors(0, [1, 2, 5, 3, 4]));
console.log(biggerThanNeighbors(0, [1, 2, 3, 3, 5]));
