function solve(input) {
    var length = input[0].length;
    var text = [];

    for (var i in input) {
        text.push(input[i]);
    }

    var wholeRow = [];
    for (var i in text) {
        wholeRow[i] = text[i].split('');
    }
    //console.log(wholeRow)
    var I = 0;
    var L = 0;
    var J = 0;
    var O = 0;

    for (var col = 0; col < text.length - 1; col++) {
        var i0 = wholeRow[col];
        var i1 = wholeRow[col + 1];
        var i2 = wholeRow[col + 2];
        var i3 = wholeRow[col + 3];

        for (var row = 0; row < length - 1; row++) {
//            if(i0[row] == 'o' && i1[row] == 'o' && i2[row] == 'o' && i3[row] == 'o'){
//                I++;
//            }
//            if(i0[row] == 'o' && i1[row] == 'o' && i2[row] == 'o' && i2[row + 1] == 'o'){
//                L++;
//            }
//            if(i0[row + 1] == 'o' && i1[row + 1] == 'o' && i2[row + 1] == 'o' && i2[row] == 'o'){
//                J++;
//            }
            if(i0[row] == 'o' && i0[row + 1] == 'o' && i1[row] == 'o' && i1[row + 1] == 'o'){
                O++;
            }
        }
    }
    console.log(I);
    console.log(L);
    console.log(J);
    console.log(O);
}

solve(['--o--o-',
       '--oo-oo',
       'ooo-oo-',
       '-ooooo-',
       '---oo--'])
