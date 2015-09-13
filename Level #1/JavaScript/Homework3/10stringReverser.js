function reverseString(){
    var text = document.getElementById("input").value

    var reverseText = reverse(text);
    console.log(reverseText);
}
function reverse(text){
    return text.split("").reverse().join("");
}
