<!DOCTYPE html>
<html>
<head>
    <title>HTML Tags Counter</title>
</head>
<body>
<label for="text">Enter HTML tags:</label><br/><br/>

<form action="" method="POST">
    <input type="text" id="text" name="tag">
    <input type="submit" name="submit">
</form>
<h4>
    <?php

    session_start();
    $tags = ['!DOCTYPE', 'a', 'abbr', 'address', 'area', 'article', 'aside', 'audio', 'b', 'base', 'bdi', 'bdo', 'blockquote', 'body', 'br', 'button', 'canvas', 'caption', 'cite', 'code', 'col',
        'colgroup', 'command', 'datalist', 'dd', 'del', 'details', 'dfn', 'dir', 'div', 'dl', 'dt', 'em', 'embed', 'fieldset', 'figcaption', 'figure', 'footer', 'form', 'h1', 'h2', 'h3', 'h4', 'h5', 'h6',
        'head', 'header', 'hgroup', 'hr', 'html', 'i', 'iframe', 'img', 'input', 'ins', 'kbd', 'keygen', 'label', 'legend', 'li', 'link', 'map', 'mark', 'menu', 'meta', 'meter', 'nav', 'noscript',
        'object', 'ol', 'optgroup', 'option', 'output', 'p', 'param', 'pre', 'progress', 'q', 'rp', 'rt', 'ruby', 's', 'samp', 'script', 'section', 'select', 'small', 'source', 'span', 'strong',
        'style', 'sub', 'summary', 'sup', 'table', 'tbody', 'td', 'textarea', 'tfoot', 'th', 'thead', 'time', 'title', 'tr', 'track', 'u', 'ul', 'var', 'video', 'wbr'];

    if (!isset($_SESSION['count']) || !isset($_SESSION['tagsLeft'])) {
        $_SESSION['count'] = 0;
        $_SESSION['tagsLeft'] = $tags;
    }
    $rightTag = false;
    if (isset($_POST['submit'])) {
        $tag = $_POST['tag'];

        for ($i = 0; $i < sizeof($tags); $i++) {
            if ($tag == $tags[$i]) {
                $rightTag = true;
                break;
            }
        }
        if ($rightTag) {
            echo("Valid HTML tag!<br/>");
            $key = array_search($tag, $_SESSION['tagsLeft']);
            if ($key !== false) {
                unset($_SESSION['tagsLeft'][$key]);
                $_SESSION['count']++;
            }

        } else {
            echo("Invalid HTML tag!<br/>");
        }
        echo("Score:" . $_SESSION['count']);
    }
    ?>
</h4>
</body>
</html>