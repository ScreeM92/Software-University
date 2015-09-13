function findMinAndMax(){
    var numsArray = new Array();
    var nums = document.getElementById("input").value;
    nums = nums.split(" ");

    for(var i = 0; i < nums.length; i += 1){
        numsArray[i] = nums[i];
    }
    console.log("Min -> %s", Math.min.apply(Math, numsArray));
    console.log("Max -> %s", Math.max.apply(Math, numsArray));
}