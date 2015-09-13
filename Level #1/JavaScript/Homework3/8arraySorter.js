function sortArray(){
    var numbers = document.getElementById("input").value;
    numbers = numbers.split(" ");

    var i, j;
    var iMin;

    for(j = 0; j < numbers.length - 1; j++){
        iMin = j;

        for(i = j + 1; i < numbers.length; i++){
            if(parseInt(numbers[iMin]) > parseInt(numbers[i])){
                iMin = i;
            }
        }

        if(iMin != j){
            swap(numbers, j, iMin)
        }
    }
    console.log(numbers);
}
function swap(numbers, firstIndex, secondIndex) {
    var temp = numbers[firstIndex];
    numbers[firstIndex] = numbers[secondIndex];
    numbers[secondIndex] = temp;
}
