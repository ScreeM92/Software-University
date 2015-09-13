<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <title>Calculate Interest</title>
</head>
<body>
    <form action="" method="POST">
        Enter Amount <input type="text" name="amount"> </br>
        <input type="radio" id="USD" name="currency" value="USD">
        <label for="USD">USD</label>
        <input type="radio" id="EUR" name="currency" value="EUR">
        <label for="EUR">EUR</label>
        <input type="radio" id="BGN" name="currency" value="BGN">
        <label for="BGN">BGN</label> </br>
        Compound Interest Amount <input type="text" name="InterestAmount"></br>
        <select name="time">
            <option value="6">6 Months</option>
            <option value="12">1 Year</option>
            <option value="24">2 Years</option>
            <option value="60">5 Years</option>
        </select>
        <input type="submit" name="submit" value="Calculate"/>
    </form>

<p>
    <?php
    if(isset($_POST["amount"]) && isset($_POST["currency"]) && isset($_POST["InterestAmount"]) && isset($_POST["time"])){
        $amount = (int)$_POST['amount'];
        $currency = $_POST['currency'];
        $InterestAmount = (double)$_POST['InterestAmount'] / 12;
        $time = (int)$_POST['time'];
        $percent = 100 + $InterestAmount;
        $symbol = "";
        if($currency == 'USD'){
            $symbol = "$";
        }
        else if($currency == "EUR"){
            $symbol = "&#128;";
        }
        else if($currency == "BGN"){
            $symbol = "лв.";
        }
        if (is_numeric($amount) && is_numeric($InterestAmount) && is_numeric($time)) {
            if ($InterestAmount > 0 && $InterestAmount <= 100) {
                for($i = 0; $i < $time; $i++){
                    $amount *= $percent / 100;
                }
                $floatAmount = sprintf ("%.2f", $amount);
                echo($symbol . $floatAmount);
            } else {
                echo "Invalid interest rate. It should be a number between 0 and 100.";
            }
        } else {
            echo "The data you entered is invalid.";
        }
    }
     else {
        echo "You have not filled in all required fields.";
       }
    ?>
</p>
</body>
</html>