<?php
class misc extends dbConn{
    public function __construct(){
        parent::connect();
    }
    //function that we will use often in our project
    //it can make for us a single selection from the database.
    //For example it can say us from which user is added the current question

    //How it works
    /*
     * if we need to select the NAME of USER that is added the current questions we can do this:
     * $this->singleSelection('name', 'users', 'user_id', '=', $id);
     * the we will download from the database the "name" of "user" which "user_id" is "equal" to "$id", that we know
     */

    public function singleSelection($searched, $whereToSearch, $whatToUse, $isEqual='=', $whatWeKnow){
        $result=parent::selectSomething($searched, $whereToSearch, $whatToUse, $isEqual, $whatWeKnow);
        $row=mysqli_fetch_object($result);
        return $row->$searched;
    }
}
?>
