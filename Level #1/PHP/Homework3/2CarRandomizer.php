<!DOCTYPE html>
<html>
<head>
    <title>Car Randomizer</title>
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
    <label for="cars">Enter cars</label>
    <input type="text" id="cars" name="cars">
    <input type="submit" name="submit" value="Show result">
    </form>
    <br/>
        <?php
        if(isset($_POST['submit'])){
            echo("<table><thead>
        <tr>
            <th>Car</th>
            <th>Color</th>
            <th>Count</th>
        </tr>
        </thead>

        <tbody>");
            $car = explode(", ", $_POST['cars']);


        for($i = 0; $i < count($car); $i++){
            $count = mt_rand(1,5);
            $colors = array("red","green","blue","yellow","brown");;
            $colorsRandom = array_rand($colors, 5);

            echo("<tr>");
            echo("<td>" . $car[$i] . "</td>");
            echo("<td>" . $colors[$colorsRandom[$i]] . "</td>");
            echo("<td>" . $count . "</td>");
            echo("</tr>");
         }
        }
        echo("</tbody>
    </table>");
        ?>


</body>
</html>