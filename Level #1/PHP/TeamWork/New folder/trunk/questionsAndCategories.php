<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<?php
include_once('db.php');
include('miscFunctions.php');
class questionsAndCategories extends dbConn{
    private $questionsPerPage;
    private $arrResultQuestions;
    public function __construct(){
        parent::connect();
    }
    //select from database and return the limit for paging the questions per page
    private function selectLimit(){
        $result=parent::selectSomething('*', 'config');
        $row=mysqli_fetch_object($result);
        $this->questionsPerPage=$row->questionsperpage;
    }
    //select from db the questions in order from new to older
    private function selectQuestions(){
        $this->selectLimit();
        $this->arrResultQuestions=parent::selectSomething('*', 'posts', '', '', '', null, null, null, null, 'lastanswer', 'desc', $this->questionsPerPage);
    }
    //extract the database results from "selectQuestions()" and use them
    private function extractQuestions(){
        $this->selectQuestions();
        $num=mysqli_num_rows($this->arrResultQuestions);
        for($i=0; $i<$num; $i++):
            $row=mysqli_fetch_object($this->arrResultQuestions);
            $misc=new misc();
            $fromWho=$misc->singleSelection('username', 'users', 'user_id', '=', $row->user_id);
            ?>
            <article class="homePageQuestions">
                <h3 class="homePageQuestionHeading"><a href="?questionId=<?php echo $row->post_id; ?>"><?php echo $row->name; ?></a></h3>
                <span class="homePageQuestionAddFrom"><a href="?user=<?php echo $row->user_id; ?>"><?php echo $fromWho; ?></a></span>
                <span class="homePageQuestionAddTime"><?php echo date('d.m.Y в H:i', $row->timeadded); ?></span>
                <span class="homePageQuestionVisits"><?php echo $row->visits ?></span>
                <?php echo $row->content; ?>
                <?php
                $this->showingQuestionsFooter($row->lastanswered, $row->lastanswer, $row->post_id);
                ?>
            </article>
            <?php
        endfor;
    }
    //function that will show which user is last answered the current question, when and how much answers are there
    private function showingQuestionsFooter($lastAnswered, $lastAnswer, $post_id){
        if($lastAnswered!=0):
            ?>
            <div class="homePageQuestionFooter">
                <span class="homePageQuestionLastAnswered"><?php echo $lastAnswered; ?></span>
                <span class="homePageQuestionLastAnswer"><?php echo $lastAnswer; ?></span>
                <span class="homePageQuestionAllAnswers"><?php echo $this->allAnsweres($post_id); ?></span>
            </div>
            <?php
        endif;
    }
    //function which will say us how many answeres are there for current question
    private function allAnsweres($post_id){
        $selectAllAnswers=parent::selectSomething('*', 'answers', 'post_id', '=', $post_id);
        $num=mysqli_num_rows($selectAllAnswers);
        return $num;
    }
    public function showResults(){
        $this->extractQuestions();
    }
}
$posts=new questionsAndCategories();
$posts->showResults();
?>
