<!DOCTYPE html>
<html>
<head>
    <title>MostFrequentTag</title>
</head>
<body>
<form action="" method="post">
    <input type="text" name="tags" >
    <input type="submit" name="submit">
</form>
<br />
<?php
if($_POST){
    $tagsMap = array();
    $tagsAsString = $_POST["tags"];
    $tags = explode(", ", $tagsAsString);

    foreach($tags as $value){
        if( isset($tagsMap[$value])){
            $tagsMap[$value]++;
        } else{
            $tagsMap[$value] = 1;
        }
    }
    $max = 0;
    $currentKey = 0;

    array_multisort($tagsMap, SORT_DESC);
    foreach($tagsMap as $key => $value){
        echo("$key: $value times<br />");
        if($tagsMap[$key] > $max){
            $max = $tagsMap[$key];
            $currentKey = $key;
        }
    }

    echo("Most Frequent Tag is:" . $currentKey);
} ?>
</body>
</html>