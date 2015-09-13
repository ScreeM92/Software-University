function findMaxSequence(){
    var nums = document.getElementById("input").value;
    var numbers = [];

    nums = nums.split(" ");
    var currentStart = 0;
    var currentLenght = 1;
    var maxStart = 0;
    var maxLenght = 1;

    for(var i = 0; i < nums.length; i++){
        numbers[i] = nums[i];
    }

    for(var j = 1; j < nums.length; j += 1){
        if((parseInt(numbers[j])) > parseInt(numbers[j - 1])){
            currentLenght += 1;
        }
        else{
            currentLenght = 1;
            currentStart = j;
        }
        if(currentLenght >= maxLenght){
            maxLenght = currentLenght;
            maxStart = currentStart;
        }
    }
    var maxNumbers = [];
    var maxNumbersI = 0;

    if(currentLenght == 1){
        console.log("no");
    }
    else{
        for(k = maxStart; k < maxStart + maxLenght; k++){
            maxNumbers[maxNumbersI] = numbers[k];
            maxNumbersI++;
        }
        console.log(maxNumbers);
    }
}
