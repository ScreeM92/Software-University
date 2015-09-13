function solve(input){
    var n = input[0];
    var nums = input[1].split(' ');
    var str = '';
    var right = false;

    for (var a = 0; a < n; a++) {
        for (var b = 0; b < n; b++) {
            for (var c = 0; c < n; c++) {
                for (var d = 0; d < n; d++) {
                    if(a != b && a != c && a!= d && b != c && b != d && c != d){
                        var result = nums[a] + nums[b] == nums[c] + nums[d];
                        if(result){
                            right = true;
                            console.log(nums[a] + "|" + nums[b] + "==" + nums[c] + "|" + nums[d])
                        }
                    }
                }
            }
        }
    }
    if(right == false){
        console.log("No")
    }
   }

solve(['5','2 51 1 75 25']);
solve(['7','2 22 23 32 322 222 5']);
solve(['3','5 1 20']);
