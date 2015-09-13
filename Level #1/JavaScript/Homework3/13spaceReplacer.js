function replaceSpaces(){
    var text = document.getElementById("input").value;
    var newText = "";
    text = text.split(" ");
    for(var i = 0; i < text.length; i += 1){
        if (text[i] === ' ') {
            newText += '&nbsp;'
        }
        else {
            newText += text[i];
        }
    }
    console.log(newText);
}
