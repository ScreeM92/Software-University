function findMaxSequence() {
    var chars = document.getElementById("input").value;
    chars = chars.split(" ");
    var currentStart = 0;
	var currentLength = 1;
	var maxStart = 0;
	var maxLength = 1;
	
    if(chars.length == 1) {
        console.log(chars);
    }
    else {
		for(i = 1; i < chars.length; i += 1) {
			if(chars[i] == chars[i - 1]) {
				currentLength += 1;
			}
			else {
				currentLength = 1;
				currentStart = i;
			}
			if(currentLength >= maxLength) {
				maxLength = currentLength;
				maxStart = currentStart;
			}
		}
		
		console.log(chars.slice(maxStart, maxStart + maxLength));
    }
}