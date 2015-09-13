<?php
include 'nationality.php';
session_start();
function validateFields()
{
    $passedValidation = true;
    $namePattern = '/[A-Za-z]{2,20}/';
    $companyNamePattern = '/^[A-Za-z0-9 ]{2,20}$/';
    $phonePattern = '/^(\+{0,}[\d- ]+)$/';
    $emailPattern = '/^\w+@\w+\.[a-z]+$/';

    if (!preg_match($namePattern, $_POST["firstName"])) {
        echo "<div class=\"error\">The first name is invalid.</div>";
        $passedValidation = false;
    }

    if (!preg_match($namePattern, $_POST["lastName"])) {
        echo "<div class=\"error\">The last name is invalid.</div>";
        $passedValidation = false;
    }

    foreach ($_POST["otherLanguages"] as $lang) {
        if (!preg_match($namePattern, $lang)) {
            echo "<div class=\"error\">The language is invalid: $lang.</div>";
            $passedValidation = false;
        }
    }

    if (!preg_match($companyNamePattern, $_POST["company"])) {
        echo "<div class=\"error\">The company name is invalid.</div>";
        $passedValidation = false;
    }

    if (!preg_match($phonePattern, $_POST["phone"])) {
        echo "<div class=\"error\">The phone is invalid.</div>";
        $passedValidation = false;
    }

    if (!preg_match($emailPattern, $_POST["email"])) {
        echo "<div class=\"error\">The email is invalid.</div>";
        $passedValidation = false;
    }
    return $passedValidation;
}

?>

<!DOCTYPE html>
<html>
<head>
    <style>
        fieldset {
            width: 50%;
        }

        .error {
            color: red;
            font-weight: bold;
        }
    </style>
    <title>CV Generator</title>
    <script src="cv-gen-scripts.js"></script>
</head>
<body>
<?php
include "nationality.php";
if ($_POST && validateFields()) {
    $_SESSION = $_POST;
    header("location: 5CV.php");
}
?>
<form method="POST">
    <fieldset>
        <legend>Personal Information</legend>

        <input type="text" name="firstName" placeholder="First Name"><br/>
        <input type="text" name="lastName" placeholder="Last Name"><br/>
        <input type="text" name="email" placeholder="Email"><br/>
        <input type="text" name="phone" placeholder="Phone Number"><br/>
        <label for="female">Female</label>
        <input type="radio" id="female" name="gender" value="female">
        <label for="male">Male</label>
        <input type="radio" id="male" name="gender" value="male"><br/>
        <label for="date">Birth Date</label><br/>
        <input type="date" id="date" name="birthDay"><br/>
        <label for="nationality">Nationality</label><br/>
        <?php
        echo("<select id='nationality' name='nationality'>");
        foreach ($nationality as $key => $value) {
            echo("<option value=\"$key\"" . ($value == "Bulgarian" ? " selected" : "") . ">$value</option>");
        }
        echo("</select>");
        ?>

    </fieldset>

    <fieldset>
        <legend>Last Work Position</legend>

        <label for="companyName">Company Name</label>
        <input type="text" id="companyName" name="company"><br/>
        <label for="fromDate">From</label>
        <input type="date" id="fromDate" name="from"><br/>
        <label for="toDate">To</label>
        <input type="date" id="toDate" name="to"><br/>

    </fieldset>

    <fieldset>
        <legend>Computer Skills</legend>
        <div id="parent">
            <div id="language1">
                <label for="languages">Programming Languages</label><br/>
                <input type="text" id="languages" name="languages[]">
                <select name="progLangLevels[]">
                    <option value="Beginner">Beginner</option>
                    <option value="Programmer">Programmer</option>
                    <option value="Ninja">Ninja</option>
                </select>
            </div>
        </div>
        <input type="submit" id="remove" name="remove" value="Remove Language">
        <input type="submit" id="add" name="add" value="Add Language">

    </fieldset>

    <fieldset>
        <legend>Other Skills</legend>
        <div id="parent1">
            <div id="otherLanguages0">
                <label for="otherLanguages1">Languages</label><br/>
                <input type="text" id="otherLanguages1" name="otherLanguages[]">
                <select name="comprehension[]">
                    <option value="comprehension" disabled="disabled" selected="selected">-Comprehension-</option>
                    <option value="intermediate">intermediate</option>
                    <option value="advanced">advanced</option>
                    <option value="beginner">beginner</option>
                </select>
                <select name="reading[]">
                    <option value="reading" disabled="disabled" selected="selected">-Reading-</option>
                    <option value="intermediate">intermediate</option>
                    <option value="advanced">advanced</option>
                    <option value="beginner">beginner</option>
                </select>
                <select name="writing[]">
                    <option value="writing" disabled="disabled" selected="selected">-Writing-</option>
                    <option value="intermediate">intermediate</option>
                    <option value="advanced">advanced</option>
                    <option value="beginner">beginner</option>
                </select>
            </div>
        </div>
        <input type="submit" id="removeOther" name="removeOther" value="Remove Language">
        <input type="submit" id="addOther" name="addOther" value="Add Language">

        <p>Driver's License</p>
        <label for="B">B</label>
        <input type="checkbox" id="B" value="B" name="category[]">
        <label for="A">A</label>
        <input type="checkbox" id="A" value="A" name="category[]">
        <label for="C">C</label>
        <input type="checkbox" id="C" value="C" name="category[]">
    </fieldset>
    <input type="submit" value="Generate CV" name="generate"/>
</form>
</body>
</html>