<!DOCTYPE html>
<html>
<head>
    <title>Square Root Sum</title>
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
        #bold{
            font-weight: bold;
        }
    </style>
</head>
<body>
    <table>
        <thead>
        <tr>
            <th>Number</th>
            <th>Square</th>
        </tr>
        </thead>
        <tbody>
        <?php
        $sum = 0;

        for($i = 0; $i <= 100; $i++){
            if($i % 2 == 0){
                echo("<tr>");
                $sqr = round(sqrt($i), 2);
                echo("<td>" . $i . "</td>");
                echo("<td>" . $sqr . "</td>");
                $sum += $sqr;
                echo("</tr>");
            }
        }
        echo("<tr>");

        echo("<td id='bold'>Total:</td>");
        echo("<td>" . $sum . "</td>");

        echo("<tr>");
        ?>
        </tbody>
    </table>
</body>
</html>