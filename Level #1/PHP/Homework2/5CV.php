<!DOCTYPE html>
<html>
<head>
    <title>CV</title>
    <style>
        table {
            border: 1px solid black;
        }

        table tr td {
            border: 1px solid black;
        }
        table tr th{
            border: 1px solid black;
        }
    </style>
</head>
<body>
<?php
include "nationality.php";
session_start();
//var_dump($_SESSION);
//$_SESSION['firstName'] = $_POST['firstName'];
//$_SESSION['email'] = $_POST['email'];
//$_SESSION['phone'] = $_POST['phone'];
//$_SESSION['lastName'] = $_POST['lastName'];
//$_SESSION['gender'] = $_POST['gender'];
//$_SESSION['birthDay'] = $_POST['birthDay'];
//$_SESSION['nationality'] = $_POST['nationality'];
//$_SESSION['company'] = $_POST['company'];
//$_SESSION['from'] = $_POST['from'];
//$_SESSION['to'] = $_POST['to'];
//$_SESSION['languages[]'] = $_POST['languages[]'];
//$_SESSION['progLangLevels[]'] = $_POST['progLangLevels[]'];
//$_SESSION['remove'] = $_POST['remove'];
//$_SESSION['add'] = $_POST['add'];
//$_SESSION['otherLanguages'] = $_POST['otherLanguages'];
//$_SESSION['comprehension[]'] = $_POST['comprehension[]'];
//$_SESSION['reading[]'] = $_POST['reading[]'];
//$_SESSION['writing[]'] = $_POST['writing[]'];
//$_SESSION['removeOther'] = $_POST['removeOther'];
//$_SESSION['addOther'] = $_POST['addOther'];
//$_SESSION['category[]'] = $_POST['category[]'];
//$_SESSION['generate'] = $_POST['generate'];
?>
<table>
    <thead>
    <tr>
        <th colspan='2'>Personal Information</th>
    </tr>
    </thead>
    <tbody>
    <tr>
        <td>First Name</td>
        <td><?php echo $_SESSION['firstName']; ?></td>
    </tr>
    <tr>
        <td>Last Name</td>
        <td><?php echo $_SESSION['lastName']; ?></td>
    </tr>
    <tr>
        <td>Email</td>
        <td><?php echo $_SESSION['email']; ?></td>
    </tr>
    <tr>
        <td>Phone Number</td>
        <td><?php echo $_SESSION['phone']; ?></td>
    </tr>
    <tr>
        <td>Gender</td>
        <td><?php echo ucfirst($_SESSION['gender']); ?></td>
    </tr>
    <tr>
        <td>Birth Date</td>
        <td><?php echo $_SESSION['birthDay']; ?></td>
    </tr>
    <tr>
        <td>Nationality</td>
        <td><?php echo $nationality[$_SESSION['nationality']]; ?></td>
    </tr>
    </tbody>
</table>
<br/>
<table>
    <thead>
    <tr>
        <th colspan='2'>Last Work Position</th>
    </tr>
    </thead>
    <tbody>
    <tr>
        <td>Company Name</td>
        <td><?php echo $_SESSION['company']; ?></td>
    </tr>
    <tr>
        <td>From</td>
        <td><?php echo $_SESSION['from']; ?></td>
    </tr>
    <tr>
        <td>To</td>
        <td><?php echo $_SESSION['to']; ?></td>
    </tr>
    </tbody>
</table>
<br/>
<table>
    <thead>
    <tr>
        <th colspan='2'>Computer Skills</th>
    </tr>
    </thead>
    <tbody>
    <tr>
        <td>Programming Languages</td>
        <td>
            <table>
                <thead>
                <tr>
                    <th>Language</th>
                    <th>Skill Level</th>
                </tr>
                </thead>
                <tbody>
                    <?php
                     for($i = 0; $i < count($_SESSION['languages']); $i++){
                        echo("<tr>");
                        echo("<td>" . $_SESSION['languages'][$i] . "</td>");
                        echo("<td>" . $_SESSION['progLangLevels'][$i] . "</td>");
                        echo("</tr>");
                     }
                    ?>
                </tbody>
            </table>
        </td>
    </tr>
    </tbody>
</table>
<br/>
<table>
    <thead>
    <tr>
        <th colspan='2'>Other Skills</th>
    </tr>
    </thead>
    <tbody>
        <tr>
            <td>Languages</td>
            <td><table>
                    <thead>
                    <tr>
                        <th>Language</th>
                        <th>Comprehension</th>
                        <th>Reading</th>
                        <th>Writing</th>
                    </tr>
                    </thead>
                    <tbody>
                    <?php
                    for($i = 0; $i < count($_SESSION['otherLanguages']); $i++){
                        echo("<tr>");

                        echo("<td>" . $_SESSION['otherLanguages'][$i] . "</td>");
                        echo("<td>" . $_SESSION['comprehension'][$i] . "</td>");
                        echo("<td>" . $_SESSION['reading'][$i] . "</td>");
                        echo("<td>" . $_SESSION['writing'][$i] . "</td>");

                        echo("</tr>");
                    }
                    ?>
                    </tbody>
            </table></td>
        </tr>
    <tr>
        <td>Driver's license</td>
        <td><?php
            echo implode(", ", $_SESSION['category']);
            ?></td>
    </tr>
    </tbody>
</table>
</body>
</html>