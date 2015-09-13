<?php
date_default_timezone_set('UTC');
$month = "8"; // 8 = August
$year = "2014";
//don't catch the last sunday only in August
//function getSunday($y, $m)
//{
//    return new DatePeriod(
//        new DateTime("first sunday of $y-$m"),
//        DateInterval::createFromDateString('next sunday'),
//        new DateTime("last day of $y-$m")
//    );
//}
//
//var_dump(getSunday(2014,8));
//foreach (getSunday(2014, $month) as $sunday) {
//    echo $sunday->format("jS F,Y\n");
//}

                                   //second way

$firstSunday  = strtotime("first sunday $year-$month-01");
$lastSunday  = strtotime("last sunday of this month $year-$month");
$start = date("j" , $firstSunday);
$end = date("j" , $lastSunday);

for($i = $start; $i <= $end; $i += 7){
     $date = mktime(0,0,0, $month,$i, $year);
     echo(date("jS F,Y\n" , $date));
}
//echo(date("j" , $firstSunday));
//echo(date("d" , $lastSunday));
?>