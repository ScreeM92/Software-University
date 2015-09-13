<!DOCTYPE html>
<html>
<head>
    <title>PrintTags</title>
</head>
<body>
    <form action="" method="post">
        <input type="text" name="tags" >
        <input type="submit" name="submit">
    </form>
    <br />
    <?php
    if($_POST){
        $tagsAsString = $_POST["tags"];
        $tags = explode(", ", $tagsAsString);

        foreach($tags as $key => $value){
            echo("$key: $value <br />");
        }
    } ?>
</body>
</html>