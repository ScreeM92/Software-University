function calcSupply(){
    var yearsNow = document.getElementById("input").value;
    var yearsDied = document.getElementById("input1").value;
    var kg = document.getElementById("input2").value;

    var years = yearsDied - yearsNow;
    var allKg = years * 365 * kg;

    document.getElementById("result").innerHTML = allKg + "kg of chocolate would be enough until I am 118 years old.";
    console.log(allKg + "kg of chocolate would be enough until I am 118 years old.");
}