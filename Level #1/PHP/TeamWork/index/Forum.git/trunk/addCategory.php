<?php
include_once('db.php');
session_start();
class AddCategory extends dbConn{
    //var contains value of $_SESSION['admin'] if it exists
    protected $admUser;
    public function __construct(){
        parent::connect();
    }
    //setter for admin user
    public function setAdm(){
        if(isset($_SESSION['admin'])){
            $this->admUser=$_SESSION['admin'];
        }
    }
    //add posting private function
    private function add($name){
        if(is_numeric($this->admUser)){
            parent::addSomething(
                'categories',
                array('name'),
                array($name)
            );
        }
    }
    //function that we use to add category
    public function doAdd($name){
        $this->add($name);
    }
}
?>
