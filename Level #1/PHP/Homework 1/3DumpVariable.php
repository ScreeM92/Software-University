<?php

    $hello = array(1,2,3);
    $num = 15.123;

    if(gettype($hello) != "integer" && gettype($hello) != "float" && gettype($hello) != "double"){
        echo(gettype($hello));
    } else{
        var_dump($num);
    }
?>