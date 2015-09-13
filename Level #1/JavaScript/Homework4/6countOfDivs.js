//                               first way[array]
//function countDivs(input){
//    var word = '';
//    var count = 0;
//
//    for(var i in input){
//        word = input[i];
//        for(var k = 0; k <= word.length - 3; k += 1){
//            if(word[k] == 'd' && word[k + 1] == 'i' && word[k + 2] == 'v'){
//                if(word[k - 1] == '<' || word[k + 3] == '>'){
//                    count++;
//                }
//            }
//            else{
//                continue;
//            }
//        }
//    }
//    var rightCount = count / 2;
//    return rightCount;
//}
//
//console.log(countDivs(['div', 'diiiiv', 'div']));
//console.log(countDivs(['<div>', 'diiiiv', '</div>']));
//console.log(countDivs(['<!DOCTYPE html>',
//    '<html>',
//    '<head lang="en">',
//    '<meta charset="UTF-8">',
//    '<title>index</title>',
//    '<script src="/yourScript.js" defer></script>',
//    '</head>',
//    '<body>',
//    '<div id="outerDiv">',
//    '<div',
//    'class="first">',
//    '<div><div>hello</div></div>',
//    '</div>',
//    '<div>hi<div></div></div>',
//    '<div>I am a div</div>',
//    '</div>',
//    '</body>',
//    '</html>']));

//                                                  second way[array]
function countDivs(html) {
    var word = '';
    var result = 0;
    var index = 0;

    for(var i = 0; i < html.length; i += 1){
        word = html[i];
        for(var k = 0; k < word.length; k += 1){
            if(word.indexOf('<div', index) != -1){
                result++;
                index = word.indexOf('<div', index) + 1;
            }
            else{
                break;
            }
        }
    }
    return result;
}

console.log(countDivs(['div', 'diiiiv', 'div']));
console.log(countDivs(['<div>', 'diiiiv', '</div>']));
console.log(countDivs(['<!DOCTYPE html>',
    '<html>',
    '<head lang="en">',
    '<meta charset="UTF-8">',
    '<title>index</title>',
    '<script src="/yourScript.js" defer></script>',
    '</head>',
    '<body>',
    '<div id="outerDiv">',
    '<div',
    'class="first">',
    '<div><div>hello</div></div>',
    '</div>',
    '<div>hi<div></div></div>',
    '<div>I am a div</div>',
    '</div>',
    '</body>',
    '</html>']));

//                                                      third way[string]

//function countDivs(html) {
//    var result = 0;
//    var index = 0;
//    while (html.indexOf('<div', index) != -1) {
//        result++;
//        index = html.indexOf('<div', index) + 1;
//    }
//    return result;
//}
//console.log(countDivs(  '<!DOCTYPE html>' +
//    '<html>' +
//    '<head lang="en">' +
//    '<meta charset="UTF-8">' +
//    '<title>index</title>' +
//    '<script src="/yourScript.js" defer></script>' +
//    '</head>' +
//    '<body>' +
//    '<div id="outerDiv">' +
//    '<div' +
//    'class="first">' +
//    '<div><div>hello</div></div>' +
//    '</div>' +
//    '<div>hi<div></div></div>' +
//    '<div>I am a div</div>' +
//    '</div>' +
//    '</body>' +
//    '</html>'));