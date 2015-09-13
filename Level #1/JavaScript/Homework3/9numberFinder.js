function findMostFreqNum() {
    var numbers = document.getElementById("input").value;
    numbers = numbers.split(" ");
    numbers.sort();
    var currentStart = 0;
    var currentLenght = 1;
    var maxStart = 0;
    var maxLenght = 1;

    for (var j = 1; j < numbers.length; j += 1) {
        if ((parseInt(numbers[j])) == parseInt(numbers[j - 1])) {
            currentLenght += 1;
        }
        else {
            currentLenght = 1;
            currentStart = j;
        }
        if (currentLenght > maxLenght) {
            maxLenght = currentLenght;
            maxStart = currentStart;
        }
    }

    console.log(numbers[maxStart] + " -> " + maxLenght + " times");
}