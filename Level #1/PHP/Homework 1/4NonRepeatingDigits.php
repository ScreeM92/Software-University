<?php

$num = 1555;
$result = array();
for($i = 102; $i < $num; $i++){
    if($i < 988){
        $current = strval($i);
        if($current[0] != $current[1] && $current[1] != $current[2] && $current[0] != $current[2]){
            array_push($result, $i);
        }
    } else{
        break;
    }
}

if(sizeof($result) < 1 ){
    echo("no");
} else{
    echo join(" ,",$result);
}
?>