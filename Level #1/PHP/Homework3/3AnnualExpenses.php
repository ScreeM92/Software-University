<!DOCTYPE html>
<html>
<head>
    <title>Annual Expenses</title>
    <meta charset="utf-8">
    <style>
        table{
            border: 1px solid black;
        }
        table thead tr th{
            border: 1px solid black;
        }
        table tbody tr td{
            border: 1px solid black;
        }
    </style>
</head>
<body>
<form action="" method="POST">
    <label for="years">Enter number of years: </label>
    <input type="text" id="years" name="years">
    <input type="submit" name="submit" value="Show costs">
</form>

<br/>
<?php
$months = ['Януари', 'Февруари', 'Март', 'Април', 'Май', 'Юни',
    'Юли', 'Август', 'Септември', 'Октомври', 'Ноември', 'Декември'];

        if(isset($_POST['submit'])){
            $years = $_POST['years'];

            echo("<table><thead><tr><th>Година</th>");

            foreach($months as $value){
                echo("<th>" . $value . "</th>");
            }

            echo("<th>Общо:</th></tr></thead>");

            echo("<tbody>");
            $total = 0;

            for($i = 2014; $i > 2014 - $years; $i--){
                echo("<tr><td>". $i . "</td>");
                for($j = 0; $j < 12; $j++){
                    $number = mt_rand(0,999);
                    $total += $number;
                    echo("<td>". $number . "</td>");
                }
                echo("<td>". $total . "</td></tr>");
                $total = 0;
            }
            echo("</tbody></table>");


        }
?>
</body>
</html>