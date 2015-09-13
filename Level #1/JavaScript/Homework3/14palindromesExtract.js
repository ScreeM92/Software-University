function findPalindromes() {
    var text = document.getElementById("input").value;
    text = text.split(/\W+/).filter(function (el) {
        return el != "";
    });
    var i, j;
    for (i = 0; i < text.length; i += 1) {
        // var k = 1;
        var isPalindrome = true;
        var word = text[i].toLowerCase();
        for (j = 0; j < word.length / 2; j += 1) {
            if (word[j] != word[word.length - j - 1]) {
                //if(word[j] != word[word.length - k]){
                isPalindrome = false;
                break;
            }

            // k++;
        }

        if (isPalindrome) {
            console.log(word);
        }
    }
}
