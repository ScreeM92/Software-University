function createArray(){
    var numbersArray = new Array(20);

    for(var i = 0; i < 20; i += 1){
        numbersArray[i] = i * 5;
    }
    console.log(numbersArray);
}
createArray();