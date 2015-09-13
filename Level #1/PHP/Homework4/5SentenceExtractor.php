<!DOCTYPE html>
<html>
<head>
    <title>Sentence Extractor</title>
</head>
<body>
<form action="" method="POST">
    <textarea name="text"></textarea><br/>
    <label for="word">Word: </label>
    <input type="text" id="word" name="word"></br>
    <input type="submit" name="submit">
</form>
</body>
</html>
<?php
if(isset($_POST['text']) && isset($_POST['word'])){
    $text = $_POST['text'];
    $word = $_POST['word'];

    $sentences = preg_split("/\s*(?<=[.?!])\s+/", $text);

    foreach ($sentences as $sentence) {
        $sentence = trim($sentence);
        if (preg_match('/(\s+)' . $word . '\1(.*)[.?!]/', $sentence)) {
            echo $sentence . "<br />";
        }
    }
}
?>