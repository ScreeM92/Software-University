var symbol = 1;
var matrix = [[0, 0, 0], [0, 0, 0], [0, 0, 0]];

function generateNextSymbol(num, row, col){

    if(symbol == 1){
        document.getElementById(num).style.backgroundImage = "url(circle.jpg)";
        document.getElementById(num).style.backgroundRepeat = "no-repeat"
        document.getElementById(num).style.backgroundPosition = "center center";
        symbol++;
        matrix[row][col] = 1;
    }
    else if(symbol == 2){
        document.getElementById(num).style.backgroundImage = "url(cross.jpg)";
        document.getElementById(num).style.backgroundRepeat = "no-repeat"
        document.getElementById(num).style.backgroundPosition = "center center";
        symbol--;
        matrix[row][col] = 2;
    }

    if(checkWin()){
        alert("Congratulations");
    };
}

function checkWin(){
    var win = false;
for(var row = 0; row < 3; row += 1){
    for(var col = 0; col < 2; col +=1){
        if(matrix[row][col] != 0){
            if(matrix[row][col] == matrix[row][col + 1]){
                win = true;
                continue;
            }
            else{
                win = false;
                break;
            };
        }
        else{
            break;
        };
    };
    if(win == true){
        return win;
    };
};
    for(var col = 0; col < 3; col+=1){
        for(var row = 0; row < 2; row += 1){
            if(matrix[row][col] != 0){
                if(matrix[row][col] == matrix[row + 1][col]){
                    win = true;
                    continue;
                }
                else{
                    win = false;
                    break;
                }
            }
            else{
                break;
            }
        }
        if(win == true){
            return win;
        };
    }
    if(matrix[0][0] != 0 && matrix[1][1] != 0 && matrix[2][2] != 0){
        if(matrix[0][0] == matrix[1][1] && matrix[1][1] == matrix[2][2]){
            win = true;
        }
    }
    if(matrix[0][2] != 0 && matrix[1][1] != 0 && matrix[2][0] != 0) {
        if(matrix[0][2] == matrix[1][1] && matrix[1][1] == matrix[2][0]){
            win = true;
        }
    }
return win;
}

