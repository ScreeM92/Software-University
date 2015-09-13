<!doctype html>
<html lang="en">
<head>
    <style>
        input[type="submit"]{
            padding: 2px 5px 2px 5px;
            font-weight: bold;
        }
    </style>
    <meta charset="UTF-8">
    <title>Form Data</title>
</head>
<body>
<form method="post" action="">
    <input type="text" placeholder="Name.." name="name"><br />
    <input type="text" placeholder="Age.." name="age"><br />
    <label for="male"><input type="radio" id="male" name="sex" value="male">Male</label><br />
    <label for="female"><input type="radio" id="female" name="sex" value="female">Female</label><br />
    <input type="submit" name="submit" value="Изпращане">
</form>
</body>
</html>

<?php
if ((count($_POST) == 4)&& isset($_POST['submit'])) {
    $name = htmlentities($_POST['name']);
    $age = htmlentities($_POST['age']);
    $sex = htmlentities($_POST['sex']);

    echo "My name is $name. I am $age years old. I am $sex.";
}
?>