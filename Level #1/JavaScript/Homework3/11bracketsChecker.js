function checkBrackets(){
    var text = document.getElementById("input").value
    var correctText = 'correct';
    var bracketsCounter = 0;
    var correct = false;
    var i;

    for(i = 0; i < text.length; i += 1){
        if(text[i] == '('){
            bracketsCounter++;
            correct = true;
        }
        else if(text[i] == ')'){
            bracketsCounter--;
            correct = true;
        }
    }
    if(bracketsCounter != 0){
        correctText = 'incorrect';
        console.log(correctText)
    }
    else if(bracketsCounter == 0 && correct == true){
        console.log(correctText)
    }
    else if(bracketsCounter == 0 && correct == false){
        correctText = 'incorrect';
        console.log(correctText)
    }
}
