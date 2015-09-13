<!DOCTYPE html>
<html>
<head>
    <title>Text Colorer</title>
    <style>
        .red{
            color: red;
        }
        .blue{
            color: blue;
        }
    </style>
</head>
<body>
<form action="" method="POST">
    <textarea name="text"></textarea><br/>
    <input type="submit" name="submit" value="Count words">
</form>
</body>
</html>
<?php

if(isset($_POST['text'])){
    $text = $_POST['text'];
    $letters = implode(' ',str_split($text));

    $letter = array();

    for($i = 0; $i < strlen($letters); $i++){
        if(ord($letters[$i]) % 2 == 0){
            echo("<span class='red'>$letters[$i]</span>");
        } else{
            echo("<span class='blue'>$letters[$i]</span>");
        }
    }

 }
?>