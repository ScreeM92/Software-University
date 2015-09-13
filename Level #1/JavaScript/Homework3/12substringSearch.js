function countSubstringOccur(inputArray) {
    var subString = new RegExp(inputArray[0].toLowerCase(), "gi");
    var text = inputArray[1].toLowerCase();

     // second way
    //var counter = 0;
//    var i;
//    var j;
//    for (i = 0; i < text.length - subString.length; i += 1) {
//        for (j = 0; j < subString.length; j += 1) {
//            if (subString[j] !== text[i + j]) {
//                break;
//            }
//            if (j === subString.length - 1 && subString[j] === text[i + j]) {
//                counter++;
//            }
//        }
//    }
    //console.log(counter);

    console.log(text.match(subString).length);
}

countSubstringOccur(["in", "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days."]);
countSubstringOccur(["your", "No one heard a single word you said. They should have seen it in your eyes. What was going around your head."]);
countSubstringOccur(["but", "But you were living in another world tryin' to get your message through."]);