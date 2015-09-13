<?php
//klas(adminFns), sadarjasht administratorkite funkcii i powerqwane na adminskite prawa kam admina
//$user - promenliva, sadarjashta sesiinata promenliva sadarjashta imeto na admina
//__construct() - konstruktor, usigorqvsht ni barz dostap do bazata danni
//amIAdmin() - функция, връщаща $_SESSION['admin'], ако влезлия потребител е администратор
//ВСИЧКО ДО ТУК Е ТЕСТВАНО И РАБОТИ
session_start();
include('config.php');
class adminFns extends dbConn{
    private $prefix='';
    private $user;
    private $query;
    private $result;
    private $row;
    private $num;
    private $table;
    public function __construct(){
        parent::connect();
    }
    private function chooseLangTable(){
        if($_COOKIE['bioUniLang']=='English'){
            $this->prefix='eng_';
        }
    }
    private function setTable($value, $var){
        $this->$var=$value;
    }
    private function getTable(){
        return $this->table;
    }
    private function amIAdmin(){
        @$this->setTable($_SESSION['user'], 'user');
        $this->setTable('user', 'table');
        $admin=parent::selectSomething(
            "*",
            $this->getTable(),
            "id",
            "=",
            $this->user,
            array('admin', '='),
            array(1, '='));
        $this->num=mysqli_num_rows($admin);
        if($this->num>0){
            $_SESSION['admin']=$this->user;
            return $_SESSION['admin'];
        }
        else{
            unset($_SESSION['admin']);
        }
    }
    private function addMenu($name){
        $this->setTable($this->prefix.'menus', 'table');
        parent::addSomething(
            $this->getTable(),
            array('name', 'addfrom', 'timeadded', 'visibility'),
            array($name, $_SESSION['admin'], time(), 0));
    }
    private function someMenuEdit($whereToChange, $whatToChange, $changeValues, $whichWeChange, $whereValues){
        parent::updateSomething(
            $whereToChange,
            array($whatToChange),
            array($changeValues),
            array($whichWeChange, '='),
            array($whereValues, '=')
        );
    }
    private function addPost($name, $content, $id){
        //$this->setTable('posts', 'table');
        parent::addSomething(
            $this->prefix.'posts',
            array('name', 'content', 'addfrom', 'timeadded', 'visibility', 'fromcat'),
            array($name, $content, $_SESSION['admin'], time(), 0, $id));
    }
    private function getFromMenuToAddSubCat($id){
        $selector=parent::selectSomething('*', $this->prefix.'categories', 'id', '=', $id);
        $row=mysqli_fetch_object($selector);
        echo $row->frommenu;
    }
    private function addSubCat($id, $name, $fromMenu){
        parent::addSomething(
            $this->prefix.'categories',
            array('subcat', 'name', 'visibility', 'timeadded', 'addfrom', 'frommenu'),
            array($id, $name, 0, time(), $_SESSION['admin'], $fromMenu));
    }
    private function letsAdminChangeSomething($whatToChange, $value){
        parent::updateSomething('cpanel', array($whatToChange), array($value), array('id', '!='), array(0, '!='));
    }
    public function isThareEngLang(){
        if(isset($_COOKIE['bioUniLang'])){
            $this->chooseLangTable();
        }
    }
    public function amIAdminPublic(){
        $this->amIAdmin();
    }
    public function addMenuPublic($name){
        $this->addMenu($name);
    }
    public function addSomePost($name, $content, $id){
        $this->addPost($name, $content, $id);
    }
    public function menuEditings($whereToChange, $menusWhatToChange, $menusChangeValues, $menusWhereToChange, $menusWhereValues){
        $this->someMenuEdit($whereToChange, $menusWhatToChange, $menusChangeValues, $menusWhereToChange, $menusWhereValues);
    }
    public function addSubCategory($id, $name, $fromMenu){
        $this->addSubCat($id, $name, $fromMenu);
    }
    public function getFromMenuToAddSubCatPublic($id){
        $this->getFromMenuToAddSubCat($id);
    }
    public function admUpdateSomething($what, $val){
        $this->letsAdminChangeSomething($what, $val);
    }
}
class admRegAndLog extends dbConn{
    private $password;
    private $mail;
    private $firstName;
    private $lastName;
    private $cpanelPath='http://localhost/BioUni/cPanel.php';
    public function __construct() {
        parent::connect();
    }
    private function setVars($var, $value){
        $this->$var=$value;
    }
    private function getVars($var){
        return $this->$var;
    }
    private function logIn($mail, $pass){
        if(!$this->checkMail($mail)){
            echo "Невалиден имейл";
            return false;
        }
        if(!$this->checkPass($pass)){
            echo "Тази парола е невалидна";
            return false;
        }
        return true;
    }
    private function checkUser($mail, $pass){
        $this->setVars('mail', strtolower($mail));
        $this->setVars('password', md5($pass));
        if($this->logIn($this->getVars('mail'), $this->getVars('password'))===false){
            return false;
        }
        if(mysqli_num_rows($this->isThareAUser($this->getVars('mail'), $this->getVars('password')))<1){
            if(mysqli_num_rows($this->isValidMail($this->getVars('mail')))>0){
                echo 'неправилна парола';
                return false;
            }
            echo 'няма такъв имейл';
            return false;
        }
        $_SESSION['user']=$this->getUserId(
            $this->isThareAUser($this->getVars('mail'), $this->getVars('password')));
        echo 'Пренасочваме ви!';
    }
    private function getUserId($result){
        $getId=mysqli_fetch_object($result);
        return $getId->id;
    }
    private function isThareAUser($mail, $pass){
        $isThare=parent::selectSomething(
            'id',
            'user',
            'mail',
            '=',
            $mail,
            array('pass', '='),
            array($pass, '='));
        return $isThare;
    }
    private function isValidMail($mail){
        $isValidMail=parent::selectSomething(
            '*',
            'user',
            'mail',
            '=',
            $mail);
        return $isValidMail;
    }
    private function getData($mail, $pass, $firstName, $lastName, $mainPass){
        if(!$this->checkMail($mail)){
            echo "невалиден имейл";
            return false;
        }
        if(!$this->checkPass($pass)){
            echo "паролата трябва да е поне 6 символа";
            return false;
        }
        if(!$this->checkFirstName($firstName)){
            echo 'Първото име трябва да е поне 2 символа';
            return false;
        }
        if(!$this->checkLastName($lastName)){
            echo "фамилията трябва да е поне 2 символа";
            return false;
        }
        if(mysqli_num_rows($this->busyMail($mail))>0){
            echo "Този имейл вече е зает";
            return false;
        }
        if($this->checkMainPass($mainPass)==false){
            echo "Администраторската парола ви е грешна";
            return false;
        }
        $this->register($mail, $pass, $firstName, $lastName);
    }
    private function checkMail($mail){
        $partsOfMail=explode('@', $mail);
        if(!@$partsOfMail[1]){
            return false;
        }
        if(strlen($partsOfMail[0])<3 || strlen($partsOfMail[1])<5){
            return false;
        }
        $secondPartOfMail=explode('.', $partsOfMail[1]);
        if(!$secondPartOfMail[1]){
            return false;
        }
        if(strlen($secondPartOfMail[0])<2 || strlen($secondPartOfMail[1])<2){
            return false;
        }
        return true;
    }
    private function checkMainPass($mainPass){
        $mainPassDownload=parent::selectSomething('*', 'cpanel');
        $theMainPass=mysqli_fetch_object($mainPassDownload);
        if(md5($mainPass)==$theMainPass->mainpass){
            return true;
        }
        return false;
    }
    private function checkPass($pass){
        if(strlen($pass)<6){
            return false;
        }
        return true;
    }
    private function checkFirstName($name){
        if(strlen($name)<2){
            return false;
        }
        return true;
    }
    private function checkLastName($name){
        if(strlen($name)<2){
            return false;
        }
        return true;
    }
    private function busyMail($mail){
        $this->setVars('mail', strtolower($mail));
        $busyMail=parent::selectSomething("id", 'user', 'mail', '=', $this->getVars('mail'));
        return $busyMail;
    }
    private function register($mail, $pass, $firstName, $lastName){
        parent::addSomething(
            'user',
            array('mail', 'pass', 'firstname', 'lastname', 'admin'),
            array(strtolower($mail), md5($pass), $firstName, $lastName, 1));
        $_SESSION['user']=mysqli_insert_id($this->db);
        echo 'Пренасочваме ви!';
    }
    private function logOut(){
        unset($_SESSION['user']);
        unset($_SESSION['admin']);
        session_destroy();
    }
    private function cPass($oldPass, $newPass, $newPass2){
        if($this->checkOldPass($oldPass)<1){
            echo 'Старата парола не е вярна!';
            return false;
        }
        if($this->checkAreTheyEqual($newPass, $newPass2)===false){
            echo 'Паролите не съвпадат!';
            return false;
        }
        $this->updatePass($newPass);
        echo 'Паролата ви е променена успешно!';
    }
    private function checkOldPass($oldPass){
        $selector=parent::selectSomething('*', 'user', 'id', '=', $_SESSION['admin'], array('pass', '='), array(md5($oldPass), '='));
        $num=mysqli_num_rows($selector);
        return $num;
    }
    private function checkAreTheyEqual($newPass, $newPass2){
        if($newPass==$newPass2){
            return true;
        }
        else return false;
    }
    private function updatePass($pass){
        parent::updateSomething('user', array('pass'), array(md5($pass)), array('id', '='), array($_SESSION['admin']), array('='));
    }
    public function doLogOut(){
        $this->logOut();
        header('Location: index.php');
    }
    public function doReg($mail, $pass, $firstName, $lastName, $mainPass){
        $this->getData($mail, $pass, $firstName, $lastName, $mainPass);
    }
    public function doLog($mail, $pass){
        $this->checkUser($mail, $pass);
    }
    public function doCPass($oldPass, $newPass, $newPass2){
        $this->cPass($oldPass, $newPass, $newPass2);
    }
}
$adm=new admRegAndLog();
$admFns=new adminFns();
$admFns->isThareEngLang();
if(isset($_GET['logButton'])){
    $adm->doLog($_GET['mail'], $_GET['pass']);
}
if(isset($_GET['regButton'])){
    $adm->doReg($_GET['mail'], $_GET['pass'], $_GET['firstName'], $_GET['lastName'], $_GET['mainPass']);
}
if(isset($_GET['addPostName']) && isset($_GET['addPostContent'])){
    $admFns->addSomePost($_GET['addPostName'], $_GET['addPostContent'], $_GET['addPostId']);
}
if(isset($_GET['singleMenuEdit'])){
    $admFns->menuEditings($_GET['whereToChange'], $_GET['menusWhatToChange'],
        $_GET['menusChangeValues'], $_GET['menusWhereToChange'], $_GET['menusWhereValues']
    );
}
if(isset($_GET['addMenu'])){
    $admFns->addMenuPublic($_GET['addMenu']);
}
if(isset($_GET['addSubCat'])){
    $admFns->addSubCategory($_GET['subCatId'], $_GET['subCatName'], $_GET['subCatFromMenu']);
}
if(isset($_GET['addCategory'])){
    $admFns->addSubCategory(0, $_GET['categoryName'], $_GET['menuId']);
}
if(isset($_GET['subCatIdForAdding'])){
    $admFns->getFromMenuToAddSubCatPublic($_GET['subCatIdForAdding']);
}
if(isset($_GET['cPassOldPass']) && isset($_GET['cPassNewPass']) && isset($_GET['cPassNewPass2'])){
    $adm->doCPass($_GET['cPassOldPass'], $_GET['cPassNewPass'], $_GET['cPassNewPass2']);
}
if(isset($_GET['cPassOldPass']) && isset($_GET['cPassNewPass']) && isset($_GET['cPassNewPass2'])){
    if(isset($_GET['exit'])){
        $adm->doLogOut();
    }
}
if(isset($_GET['cpanelUpdate'])){
    $admFns->admUpdateSomething($_GET['column'], $_GET['value']);
}
?>