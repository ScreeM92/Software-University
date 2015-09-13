<?php
$days = array("По", "Вт", "Ср", "Чт", "Пе", "Сб", "Не");
$months = array("Януари", "Февруари", "Март", "Април", "Май", "Юни", "Юли",
    "Август", "Септември", "Октомври", "Ноември", "Декември");
function printMonth($month, $year)
{
    global $days, $months;
    $daysInMonth = cal_days_in_month(CAL_GREGORIAN, $month, $year);
    $firstDayOfMonth = mktime(0, 0, 0, $month, 1, $year);
    $firstDay = getdate($firstDayOfMonth)["wday"] - 1;
    $result = "<table><caption>" . $months[$month - 1] . "</caption><thead><tr>";
    for ($i = 0; $i < count($days); $i++) {
        $result .= "<th>" . $days[$i] . "</th>";
    }

    $result .= "</tr></thead><tbody><tr>";
    $currentDayOfWeekIndex = $firstDay;
    if ($currentDayOfWeekIndex > 0) {
        $result .= "<td colspan=\"" . $currentDayOfWeekIndex . "\"></td>";
    }

    for ($currentDay = 1; $currentDay <= $daysInMonth; $currentDay++, $currentDayOfWeekIndex++) {
        if ($currentDayOfWeekIndex == 7) {
            $currentDayOfWeekIndex = 0;
            $result .= "</tr><tr>";
        }

        $result .= "<td>" . $currentDay . "</td>";
    }

    if ($currentDayOfWeekIndex < 7) {
        $result .= "<td colspan=\"" . (7 - $currentDayOfWeekIndex) . "\"></td>";
    }

    $result .= "</tr></tbody></table>";
    return $result;
}

?>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8">
    <title>Awesome Calendar</title>
    <style type="text/css">
        .wrapper {
            text-align: center;
        }

        table {
            display: inline-block;
            vertical-align: top;
            margin: 10px;
            font-weight: bold;
        }
        table th:last-child{
            color: red;
        }

        table caption {
            border-bottom: 1px solid gray;
        }

        th {
            border-bottom: 1px solid gray;
        }

        .year {
            font-size: 5em;
            font-weight: bold;
            font-family: Arial;
        }
    </style>
</head>
<body>
<?php
echo "<div class=\"wrapper\"><div class=\"year\">" . date("Y") . "</div><hr />";
for ($month = 1; $month <= 12; $month++) {
    echo printMonth($month, date("Y"));
    if ($month % 4 == 0) {
        echo "<br />";
    }
}
echo "</div>";
?>
</body>
</html>