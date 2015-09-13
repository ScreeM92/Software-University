<?php
    if(isset($_POST['text'])){
        $text = $_POST['text'];
        $words = preg_split("/[\W+]+/", $text);
        $repeatWords = array();

        foreach($words as $value){
            if(isset($repeatWords[$value])){
                $repeatWords[strtolower($value)]++;
            } else{
                $repeatWords[strtolower($value)] = 1;
            }
        }
         // Sorted array
        //array_multisort($repeatWords, SORT_DESC);
        echo("<table><tbody>");
        foreach($repeatWords as $key => $value){
            if($key == null || $key == " " || $key == ""){
                //array_pop($repeatWords);
                 // or
//                array_splice($repeatWords, -1, 1);
                //or
                array_splice($repeatWords, $value, 1);

            } else{
            echo("<tr><td>$key</td>");
            echo("<td>$value</td></tr>");
            }
        }
        echo("</tbody></table>");
    }
?>
<!DOCTYPE html>
<html>
<head>
    <title>Word Mapper</title>
    <style>
        td{
            border: 1px solid black;
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