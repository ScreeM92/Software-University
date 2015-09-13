<?php
include_once("db.php");
session_start();
class AddQuestions extends dBconn{
    //variable that we will use for the id of logged user
    protected $regUser;
    //variable that we will to know which is the current posted question (it's id) and give it to function that will add
    //tha tags for current question
    protected $currentQuestion;
    public function __construct(){
        parent::connect();
    }
    //if there is a logged user we set it id to $this->regUser
    public function setUser(){
        if(isset($_SESSION['user'])){
            $this->regUser=$_SESSION['user'];
        }
    }
    //add posting private function
    private function add($name, $content, $cat_id, $tags){
        if(is_numeric($this->regUser)){
            parent::addSomething(
                'posts',
                array('name', 'content', 'user_id', 'timeadded', 'cat_id', 'lastanswer'),
                array($name, $content, $this->regUser, time(), $cat_id, time())
            );
            $this->currentQuestion=mysqli_insert_id($this->db);
            $this->insertTags($tags);
        }
    }
    //function which will insert tha tags for current question
    //it use the id from the current query contained in variable ($this->currentQuestion)
    private function insertTags($fullTags){
        $separatedTag=explode(',', $fullTags);
        for($i=0; $i<count($separatedTag); $i++){
            $separatedTag[$i]=trim($separatedTag[$i]);
            parent::addSomething('tags',
                array('tagname', 'post_id'),
                array($separatedTag[$i], $this->currentQuestion)
            );
        }
    }
    //function that we use to add posting
    public function doAdd($name, $content, $cat_id, $tags){
        $this->add($name, $content, $cat_id, $tags);
    }
}
?>
