<!DOCTYPE html>
<html>
<head>
    <title>Sidebar Biulder</title>
    <style>
        div{
            width: 130px;
            background-color: #c1d2ea;
            border-radius: 10px;
            font-family: Arial;
            border: 1px solid darkblue;
            margin: 5px;
        }
        h3{
            margin: 5px;
            padding:15px 5px 0 0;
            border-bottom: 1px solid black;
        }
        a{
            color: black;
        }
        ul{
            list-style-type: circle;
        }
    </style>
</head>
<body>
<form method="POST">
    <label for="categories">Categories:</label>
    <input type="text" id="categories" name="categories"><br/>
    <label for="tags">Tags:</label>
    <input type="text" id="tags" name="tags"><br/>
    <label for="months">Months:</label>
    <input type="text" id="months" name="months"><br/>
    <input type="submit" name="submit" value="Generate">
</form>
</body>
</html>
<?php
if(isset($_POST['categories']) && isset($_POST['tags']) && isset($_POST['months'])){
    $categories = $_POST['categories'];
    $tags = $_POST['tags'];
    $months = $_POST['months'];

    $category = explode(", ", $categories);
    $tag = explode(", ", $tags);
    $month = explode(", ", $months);

    echo("<div>");
    echo("<h3>Categories</h3>");
    echo("<ul>");
    for($i = 0; $i < count($category); $i++){
      echo("<li><a href='#'>$category[$i]</a></li>");
    }
    echo("</ul>");
    echo("</div>");

    echo("<div>");
    echo("<h3>Tags</h3>");
    echo("<ul>");
    for($i = 0; $i < count($tag); $i++){
        echo("<li><a href='#'>$tag[$i]</a></li>");
    }
    echo("</ul>");
    echo("</div>");

    echo("<div>");
    echo("<h3>Months</h3>");
    echo("<ul>");
    for($i = 0; $i < count($month); $i++){
        echo("<li><a href='#'>$month[$i]</a></li>");
    }
    echo("</ul>");
    echo("</div>");
}
?>