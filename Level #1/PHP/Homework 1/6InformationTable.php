<?php
$name = "Gosho";
$phoneNumber = "0882-321-423";
$age = 24;
$address = "Hadji Dimitar";


?>
<!DOCTYPE html>
<html>
<head>
    <style>
        table tr td{
            border: 1px solid black;
            padding: 5px;
        }
        table tr td:first-child{
            background-color: orange;
            font-weight: bold;
            width: 110px;
        }
        table tr td:last-child{
            text-align: right;
            width: 100px;
        }
        table{
            border-collapse: collapse;
        }
    </style>
    <title>InformationTable</title>
</head>
<body>
<table>
    <tbody>
    <tr><td>Name</td><td><?php echo $name ?></td></tr>
    <tr><td>Phone number</td><td><?php echo $phoneNumber ?></td></tr>
    <tr><td>Age</td><td><?php echo $age ?></td></tr>
    <tr><td>Address</td><td><?php echo $address ?></td></tr>
    </tbody>
</table>
</body>
</html>