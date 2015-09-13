function solve(input){
    var text = input[0].split(/\W+/);
    var words = [];

    for (var a = 0; a < text.length; a += 1) {
        for (var b = 0; b < text.length; b += 1) {
            for (var c = 0; c < text.length; c += 1) {
                if (b !== a) {
                    var check = (text[a] + text[b]) === (text[c]);
                    var check02 = text[a]!=='' && text[b]!=='' && text[c]!=='';
                    if (check && check02) {
                        var word = text[a] + "|" + text[b] + "=" + text[c];
                        if (words.indexOf(word) < 0) {
                            words.push(word);
                        }
                    }
                }
            }
        }
    }
    if(words.length < 1){
        console.log('No');
    }
    else{
        console.log(words.join('\n'));
    }
}

//solve(['java..?|basics/*-+=javabasics']);
//solve(['Hi, Hi, Hihi']);
//solve(['Uni(lo,.ve=I love SoftUni (Soft)']);
solve(['x a ab b aba a hello+java a b aaaaa']);
