<!DOCTYPE html>
<html>
<head>
    <title>Sum Of Digits</title>
    <style>
        table{
            border: 1px solid black;
        }
        table tbody tr td{
            border: 1px solid black;
        }
    </style>
</head>
<body>
    <form method="POST">
        <label for="input">Input string: </label>
        <input type="text" id="input" name="input">
        <input type="submit">
    </form>

    <?php
        if(isset($_POST['input'])){
            $numbers = explode(", ", $_POST['input']);

            echo("<table><tbody>");

            for($i = 0; $i < strlen($numbers); $i++){
                echo("<tr>");

                echo("<td>$numbers[$i]</td>");
                if(is_numeric($numbers[$i])){
                    $sum = 0;

                    for($j = 0; $j < count($numbers[$i]); $j++){
                        $sum += $numbers[$i][$j];
                    }
                    echo("<td>$sum</td>");

                } else{
                    echo("<td>I cannot sum that</td>");
                }
                echo("</tr>");
            }

            echo("</tbody></table>");
        }
    ?>
</body>
</html>