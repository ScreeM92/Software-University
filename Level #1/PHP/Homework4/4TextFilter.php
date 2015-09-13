<?php
header("Content-Type: text/html; charset=utf-8");
mb_internal_encoding("utf-8");
?>
    <!DOCTYPE html>
    <html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <title>Text Filter</title>
        <style type="text/css">
            .error {
                color: #ff0000;
                font-weight: bold;
            }
        </style>
    </head>
    <body>
    <form method="post">
        <label for="text">Text: </label>
        <textarea name="text" id="text" rows="4" cols="50"></textarea><br/>
        <label for="banList">Ban list: </label>
        <input type="text" name="banList" id="banList"/><br/>
        <input type="submit" value="Filter"/>
    </form>
    <br/>
    <?php
    if (isset($_POST["text"]) && isset($_POST["banList"])) {
        if (!empty($_POST["text"]) && !empty($_POST["banList"])) {
            $text = $_POST["text"];
            $bannedWords = preg_split('/[,\s+]+/', $_POST["banList"], -1, PREG_SPLIT_NO_EMPTY);
            foreach ($bannedWords as $bannedWord) {
                $text = preg_replace_callback('/' . $bannedWord . '/', function ($elements) {
                    $length = mb_strlen($elements[0]);
                    return str_repeat("*", $length);
                }, $text);
            }

            echo $text;
        } else {
            echo "<div class=\"error\">Not all fields have been filled in.</div>";
        }
    }
    ?>
  </body>
</html>


<!--<!DOCTYPE html>-->
<!--<html>-->
<!--<head>-->
<!--    <title>Text Filter</title>-->
<!--</head>-->
<!--<body>-->
<!--<form action="" method="POST">-->
<!--    <textarea name="text"></textarea><br/>-->
<!--    <label for="banned">Banned words: </label>-->
<!--    <input type="text" id="banned" name="banned"></br>-->
<!--    <input type="submit" name="submit">-->
<!--</form>-->
<!--</body>-->
<!--</html>-->
<?php
                                       //second way

//if(isset($_POST['text']) && isset($_POST['banned'])){
//    $text = $_POST['text'];
//    $banned = $_POST['banned'];
//
//    $banWord = explode(", ", $banned);
//    for($i = 0; $i < count($banWord); $i++){
//        $pattern =  '/\b' . $banWord[$i] . '\b/';
//        $count = preg_match_all($pattern,$text,$result);
//
//        $stars = "";
//        $word = $banWord[$i];
//        for($j = 0; $j < strlen($word); $j++){
//        $stars .= "*";
//         }
//        if($count > 0){
//            $text = str_replace($result[0],$stars,$text);
//        }
//    }
//    echo($text);
//                                          third way
//    $textEnd = "";
//
//    for($i = 0; $i < count($banWord); $i++){
//
//    $stars = "";
//    $word = $banWord[$i];
//    for($j = 0; $j < strlen($word); $j++){
//    $stars .= "*";
//     }
//        $text = str_replace($word, $stars, $text);
// }
//    echo($text);
//}
?>