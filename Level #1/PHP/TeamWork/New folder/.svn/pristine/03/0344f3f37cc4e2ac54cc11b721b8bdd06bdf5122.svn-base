<?php
class dbConn
{
    private $user='root';
    private $pass='vertrigo';
    private $host='localhost';
    private $dbname='forum';

    private $query;
    private $result;
    private $row;
    private $num;
    protected $db;
    protected function connect()
    {
        $this->db = mysqli_connect($this->host, $this->user, $this->pass, $this->dbname) or die("No database connection!");
        mysqli_set_charset($this->db, 'utf8');
        if(!get_magic_quotes_gpc())
        {
            $_GET = array_map(array($this, 'array_map_callback'), $_GET);
            $_POST = array_map(array($this, 'array_map_callback'), $_POST);
            $_COOKIE = array_map(array($this, 'array_map_callback'), $_COOKIE);
            $_REQUEST = array_map(array($this, 'array_map_callback'), $_REQUEST);
        }
        else
        {
            $_GET = array_map('stripslashes', $_GET);
            $_POST = array_map('stripslashes', $_POST);
            $_COOKIE = array_map('stripslashes', $_COOKIE);
            $_REQUEST = array_map('stripslashes', $_REQUEST);
            $_GET = array_map(array($this, 'array_map_callback'), $_GET);
            $_POST = array_map(array($this, 'array_map_callback'), $_POST);
            $_COOKIE = array_map(array($this, 'array_map_callback'), $_COOKIE);
            $_REQUEST = array_map(array($this, 'array_map_callback'), $_REQUEST);
        }
    }
    //funkciq, pomoshtnik, da se zashtitim ot ataki
    private function array_map_callback($a)
    {
        return mysqli_real_escape_string($this->db, htmlspecialchars($a));
    }

    protected function addSomething($table, array $whereToAdd, array $whatToAdd){
        $this->query="insert into ".$table." (".$this->extractor($whereToAdd).") values (".$this->extractor($whatToAdd, '\'').")";
        $this->MySQLResult($this->db, $this->query);
    }
    protected function updateSomething($table, array $newCol, array $newValue, array $oldCol, array $oldValue){
        $this->query="update ".$table." set ";
        for($i=0; $i<count($newCol); $i++){
            $this->query.=$newCol[$i]."='".$newValue[$i]."'";
            if($i<count($newCol)-1){
                $this->query.=', ';
            }
        }
        $this->query.="where ";
        for($i=0; $i<count($oldCol)-1; $i++){
            $this->query.=$oldCol[$i].$this->eqOrNot($oldCol[$i+1])."'".$oldValue[$i]."'";
        }
        $this->MySQLResult($this->db, $this->query);
    }
    protected function selectSomething(
        $which,
        $from,
        $col='',
        $eqOrNot='',
        $colValue='',
        array $andCol=null,
        array $andValue=null,
        array $orCol=null,
        array $orValue=null,
        $orderCol='',
        $orderWay='',
        $limit=''){
        $this->query="select ".$which." from ".$from;
        if($col!=''){
            $whereOption=" where ".$col;
            $whereOption.=$this->eqOrNot($eqOrNot);
            $whereOption.="'".$colValue."' ";
            $this->query.=$whereOption;
        }
        if(count($andCol)>0){
            $this->query.=$this->andColValExtractor($andCol, $andValue);
        }
        if(count($orCol)>0){
            $this->query.=$this->orColValExtractor($orCol, $orValue);
        }
        if($orderCol!=''){
            $this->query.=" order by ".$orderCol;
        }
        if($orderWay!=''){
            $this->query.=" ".$orderWay;
        }
        if($limit!=''){
            $this->query.=" limit ".$limit;
        }
        $this->result=$this->MySQLResult($this->db, $this->query);
        return $this->result;
    }
    private function extractor(array $data, $quotes=''){
        $extracted="";
        for($i=0; $i<count($data); $i++){
            $extracted.=$quotes.$data[$i].$quotes;
            if($i!=count($data)-1){
                $extracted.=', ';
            }
        }
        return $extracted;
    }
    private function MySQLResult($db, $query){
        $this->result=mysqli_query($db, $query);
        return $this->result;
    }
    private function eqOrNot($eqOrNot){
        switch($eqOrNot){
            case '=':
                return '=';
                break;
            case '!=':
                return '!=';
                break;
            case '>':
                return '>';
                break;
            case '<':
                return '<';
                break;
            case '<=':
                return '<=';
                break;
            case '>=':
                return '>=';
                break;
            default:
                return '=';
                break;
        }
    }
    private function orColValExtractor($col, $val){
        //razbirame kolko vlojueni masiwa imame
        $result="";
        for($i=0; $i<count($col); $i++){
            $result.=" or ";
            $result.=$this->nestedCycle(0, count($col[$i]), $i, $col, $val);
        }
        return $result;
    }
    private function nestedCycle($min, $max, $upCycle, $arr1, $arr2){
        $result="";
        for($j=$min; $j<$max; $j++){
            if($j%2!=0){
                continue;
            }
            $result.=$arr1[$upCycle][$j].$this->eqOrNot($arr1[$upCycle][$j+1])."'".$arr2[$upCycle][$j]."' ";
            if($j!=count($arr1[$upCycle])-2){
                $result.=" and ";
            }
        }
        return $result;
    }
    private function andColValExtractor($col, $val){
        $result="";
        for($i=0; $i<count($col); $i++){
            if($i%2!=0){
                continue;
            }
            if($i!=count($col[$i])-2){
                $result.=' and ';
            }
            $result.=" ".$col[$i].$this->eqOrNot($col[$i+1])."'".$val[$i]."' ";
        }
        return $result;
    }
}
?>
