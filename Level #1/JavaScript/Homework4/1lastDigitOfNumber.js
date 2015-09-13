function lastDigitAsText(input){
    var digitLength = input.length;
    var lastDigit = input[digitLength - 1];

    switch(lastDigit){
        case "1": lastDigit = "One";
            break;
        case "2": lastDigit ="Two";
            break;
        case "3": lastDigit ="Three";
            break;
        case "4": lastDigit ="Four";
            break;
        case "5": lastDigit ="Five";
            break;
        case "6": lastDigit ="Six";
            break;
        case "7": lastDigit ="Seven";
            break;
        case "8": lastDigit ="Eight";
            break;
        case "9": lastDigit ="Nine";
            break;
        case "0": lastDigit ="Zero";
            break;
    }

    return lastDigit;
}
console.log(lastDigitAsText("6"));
console.log(lastDigitAsText("-55"));
console.log(lastDigitAsText("133"));
console.log(lastDigitAsText("14567"));
console.log(lastDigitAsText("14562"));
console.log(lastDigitAsText("14560"));
console.log(lastDigitAsText("14561"));
console.log(lastDigitAsText("14569"));