function calcCylinderVol(){
    var radius = document.getElementById("input").value;
    var height = document.getElementById("input1").value;
    var volume = Math.PI*radius*radius*height;

    document.getElementById("result").innerHTML = volume.toFixed(3);
    console.log(volume.toFixed(3))
}
