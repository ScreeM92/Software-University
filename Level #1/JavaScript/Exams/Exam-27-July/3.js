function solve(input) {

    var text = [];
    for (var i = 0; i < input.length; i++) {
        for (var j = 0; j < input[i].length; j++) {
            text.push(input[i][j]);
        }
}
//console.log(text);
    var right = [];
    var cc = 0;

    for (var i = 100; i < text.length - 1; i++) {
        var isCorrect = true;

        if (text[i] == '<' && text[i + 1] == 'a') {
            for (var j = i + 2; j < text.length; j++) {

                if(isCorrect == false){
                    break;
                }
                i = j;
                if(text[j] == '>'){
                    break;
                }
                if (text[j] == 'h' && text[j + 1] == 'r' && text[j + 2] == 'e' && text[j + 3] == 'f') {
                    for (var k = j + 4; k < text.length; k++) {

                        if(isCorrect == false){
                            break;
                        }
                        j = k;
                        i = k;
                        if (text[k] == '=') {
                            for (var l = k + 1; l < text.length; l++) {
                                k = l;
                                j = l;
                                i = l;


                                if (text[l] == '"' || text[l] == '\'') {
                                    if(cc == 0){
                                        cc++;
                                        continue;
                                    }
                                    right.push("\n");
                                    isCorrect = false;
                                    break;
                                }
                                else if(text[l] == '>'){
                                    isCorrect = false;
                                    break;
                                }
                                else {

                                    right.push(text[l]);
                                    isCorrect = true;
                                }
                            }
                        }
                        else if(text[k] == '>'){
                            break;
                        }
                    }
                }
            }
         }
    }
    console.log(right.join(""));
}
//solve(['<a href="http://softuni.bg" class="new"></a>']);
//solve(['<p>This text has no links</p>']);
solve(['<!DOCTYPE html>',
   '<html>',
    '<head>',
        '<title>Hyperlinks</title>',
        '<link href="theme.css" rel="stylesheet" />',
    '</head>',
    '<body>',
    '<ul><li><a   href="/"  id="home">Home</a></li><li><a',
    'class="selected" href="/courses">Courses</a>',
    '</li><li><a href =',
    '/forum\' >Forum</a></li><li><a class="href"',
    'onclick="go()" href= "#">Forum</a></li>',
        '<li><a id="js" href =',
        '"javascript:alert(\'hi yo\')" class="new">click</a></li>',
        '<li><a id=\'nakov\' href =',
        '"http://www.nakov.com" class=\'new\'>nak</a><\/li></ul>',
    '<a href="#empty"></a>',
    '<a id="href">href=\'fake\'<img src=\'http://abv.bg/i.gif',
    'alt=\'abv\'/></a><a href="#">&lt;a href=\'hello\'&gt;</a>',
    '<!-- This code is commented:',
      '<a href="#commented">commentex hyperlink</a> -->',
'<\/body>']);