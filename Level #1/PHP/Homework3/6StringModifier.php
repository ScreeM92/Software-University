<!DOCTYPE html>
<html>
<head>
    <title>String Modifier</title>
</head>
<body>
    <form method="POST">
        <input type="text" name="input">
        <input type="radio" name="radio" id="palindrome" value="palindrome">
        <label for="palindrome">Check Palindrome</label>
        <input type="radio" name="radio" id="reverse" value="reverse">
        <label for="reverse">Reverse String</label>
        <input type="radio" name="radio" id="split" value="split">
        <label for="split">Split</label>
        <input type="radio" name="radio" id="hash" value="hash">
        <label for="hash">Hash String</label>
        <input type="radio" name="radio" id="shuffle" value="shuffle">
        <label for="shuffle">Shuffle String</label>
        <input type="submit" name="submit">
    </form>

    <p><?php
        if(isset($_POST['input']) && isset($_POST['radio']) && isset($_POST['submit'])){

            $text = $_POST['input'];

            if($_POST['radio'] == 'palindrome'){
                $isPalendrome = true;
                for($i = 0; $i < strlen($text) / 2; $i++){
                    if($text[$i] == $text[strlen($text) - $i - 1]){
                        $isPalendrome = true;
                    } else{
                        $isPalendrome = false;
                        break;
                    }
                }
                if($isPalendrome){
                    echo("$text is a palindrome!");
                } else{
                    echo("$text is not a palindrome!");
                }
            }
            else if($_POST['radio'] == 'reverse'){
                $reverse = "";
                for($i = strlen($text) - 1; $i >= 0; $i--){
                    $reverse .= $text[$i];
                }
                echo($reverse);
            }
            else if($_POST['radio'] == 'split'){
//                $arr = [];

//                for($i = 0; $i < strlen($text); $i++){
//                    if($text[$i] != " "){
//                        $arr[$i] = $text[$i];
//                    }
//                }

                $split = implode(' ',str_split($text));
                echo($split);
            }
            else if($_POST['radio'] == 'hash'){
                $hash = crypt($text);
                echo($hash);
            }
            else if($_POST['radio'] == 'shuffle'){
                $shuffled = str_shuffle($text);
                echo $shuffled;
            }
        }
    ?></p>
</body>
</html>