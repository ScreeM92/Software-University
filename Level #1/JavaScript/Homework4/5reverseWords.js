function reverseWordsInString(input){
    var text = input.split(/[ ]/);
    var word = '';
    var sentance = '';

    for(var i in text){
        word = text[i];
        var reverseWord = word.split("").reverse().join("");
        sentance += reverseWord + " ";
    }
    return sentance;
}
console.log(reverseWordsInString("Hello, how are you."));
console.log(reverseWordsInString("Life is pretty good, isn’t it?"));