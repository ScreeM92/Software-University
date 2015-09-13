<!DOCTYPE html>
<html>
<head>
    <title>Primes In Range</title>
    <style>
        span.prime{
            font-weight: bold;
        }
    </style>
</head>
<body>
<form method="post">
    <label for="start">Starting Index: </label>
    <input type="text" id="start" name="start">
    <label for="end">End: </label>
    <input type="text" id="end" name="end">
    <input type="submit" name="submit">
</form>

<?php

if(isset($_POST['start']) && isset($_POST['end'])){

    $start = $_POST['start'];
    $end = $_POST['end'];
    $numbers = "";

    for($i = $start; $i <= $end; $i++){
        $divider = 2;
        $maxDivider = floor(sqrt($i));
        $isPrime = false;

        for($j = $divider; $j < $maxDivider; $j++){
            if($i % $j == 0){
                $isPrime = false;
                break;
            } else{
                $isPrime = true;
            }
        }
        if ($i == $end) {
            if($isPrime){
                $numbers .= "<span class='prime'>" . "$i" . "</span>";
            }
            else{
                $numbers .= "<span>" . "$i" . "</span>";
            }
        }else{
            if($isPrime){
                $numbers .= "<span class='prime'>" . "$i, " . "</span>";
            } else{
                $numbers .= "<span>" . "$i, " . "</span>";
            }
        }
    }
    echo($numbers);
}
?>

</body>
</html>