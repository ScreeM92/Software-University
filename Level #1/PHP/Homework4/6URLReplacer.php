<?php
header("Content-Type: text/html; charset=utf-8");
mb_internal_encoding("utf-8");
?>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>URL Replacer</title>
    <style type="text/css">
        .error {
            color: #ff0000;
            font-weight: bold;
        }
    </style>
</head>
<body>
<form method="post">
    <label for="text">Text: </label><br/>
    <textarea name="text" id="text" rows="4" cols="50"></textarea><br/>
    <input type="submit" value="Extract sentences"/>
</form>
<br/>
<?php
if (isset($_POST["text"])) {
    if (!empty($_POST["text"])) {
        $text = preg_replace('/<\s*\/\s*a\s*>/', '[/URL]', $_POST["text"]);
        echo htmlentities(preg_replace('/<a(.*?)href=(\'|")([^>]+)(\'|")(.*?)>/', '[URL=\3]', $text));
    } else {
        echo "<div class=\"error\">No text provided.</div>";
    }
}
?>
</body>
</html>