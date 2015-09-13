var tags = ['html', 'head', 'title', 'base', 'link', 'meta', 'style', 'script', 'noscript', 'template', 'body', 'section', 'nav', 'article', 'aside', 'h1', 'h2', 'h3', 'h4', 'h5', 'h6', 'header', 'footer', 'address', 'main', 'p', 'hr', 'pre', 'blockquote', 'ol', 'ul', 'li', 'dl', 'dt', 'dd', 'figure', 'figcaption', 'div', 'span', 'a', 'em', 'strong', 'small', 's', 'cite', 'q', 'dfn', 'abbr', 'data', 'time', 'code', 'var', 'samp', 'kbd', 'sup', 'sub', 'i', 'b', 'u', 'mark', 'ruby', 'rt', 'rp', 'bdi', 'bdo', 'br', 'wbr', 'ins', 'del', 'img', 'iframe', 'embed', 'object', 'param', 'video', 'audio', 'source', 'track', 'canvas', 'map', 'area', 'svg', 'math', 'table', 'caption', 'colgroup', 'col', 'tbody', 'thead', 'tfoot', 'tr', 'td', 'th', 'form', 'fieldset', 'legend', 'label', 'input', 'button', 'select', 'datalist', 'optgroup', 'option', 'textarea', 'keygen', 'output', 'progress', 'meter', 'details', 'summary', 'menu', 'menuitem'];

function startGame() {
    $('#start').css('display', 'none');
    $('#input').css('display', 'initial');
    $('meter').css('display', 'initial');
    $('#guessedTags').css('display', 'block');
    console.log(Date.now());
    var tick = 1;
    var guessed = 0;
    var timeEnded = false;
    function checkTag(tag) {
        var index = tags.indexOf(tag);
        if (index != -1) {
            return true;
        }
        return false;
    }
    function checkIfGuessed(tag) {
        if (checkTag(tag) == true) {
            document.getElementById('guessedTags').innerHTML += tag + ", ";
            $('#reset').click();
            guessed++;
            tags.splice(tags.indexOf(tag), 1);
        }
    }
    function timeEnd() {
        var missedTags = '';
        for (var i = 0; i < tags.length; i++) {
            missedTags += tags[i] + ", ";
        }
        missedTags = missedTags.substring(0, missedTags.length - 2);
        $('#reset').click();
        $('#remaining').text('You have missed ' + tags.length + ' tags!');
        $('#guessedTags').text(missedTags);
    }
    function change() {
        $('meter').attr('value', tick);
        tick += 1;
        if (tick >= 300) {
            tick = 0;
            timeEnded = true;
            clearTimeout(change);
            console.log(Date.now());
            timeEnd();
        }
        else {
            var input = $('input')[0];
            $('#remaining').text(tags.length);
            input.onkeyup = function () { checkIfGuessed(this.value); };
            setTimeout(change, 1000);
        }
    }
    setTimeout(change, 1000);
}