function solve (input) {
    var words = input[0].split(/[^a-zA-Z]+/);

    var output = [];
    for (var a = 0; a < words.length; a++) {
        for (var b = 0; b < words.length; b++) {
            for (var c = 0; c < words.length; c++) {
                // Check if a!=b and a|b=c
                if (b !== a) {
                    var check = (words[a] + words[b]) === (words[c]);
                    var check02 = words[a]!=='' && words[b]!=='' && words[c]!=='';
                    if (check && check02) {
                        var word = words[a] + "|" + words[b] + "=" + words[c];
                        if (output.indexOf(word) < 0) {
                            output.push(word);
                        }
                    }
                }
            }
        }
    }

    if (output.length < 1) {
        console.log ("No");
    }
    else {
        console.log(output.join('\n')) ;
    }
}

solve(['java..?|basics/*-+=javabasics']);
solve(['Hi, Hi, Hihi']);
solve(['Uni(lo,.ve=I love SoftUni (Soft)']);
solve(['x a ab b aba a hello+java a b aaaaa']);