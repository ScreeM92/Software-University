<?php
    date_default_timezone_set('Europe/Sofia');
    $today = time();
    $newYear = mktime(0,0,0,1,1,2015,0);

    $difference = $newYear - $today;

    $days = floor($difference/60/60/24);
    $hours = floor($difference/60/60);
    $minutes = floor($difference/60);
    $second = floor($difference);

echo("Hours until new year : " . $hours . "\n");
echo("Minutes until new year : " . $minutes . "\n");
echo("Seconds until new year : " . $second . "\n");
echo "Days:Hours:Minutes:Seconds  ". $days. ":". $hours%24 . ":". $minutes%60 . ":". $second%60;
?>
