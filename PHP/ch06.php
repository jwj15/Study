<?php
namespace df;
require_once "./br.php";

# 클래스
// 접근제어 생략시 기본 public 인듯
class pen
{
    private $color = "blue";
    protected $bold;
    public $price;

    function __construct($color)
    {
        echo "인스턴스 생성" . br;
        $this -> bold = "thin";
        $this -> price = 5000;
        $this -> color = $color;
    }

    function __destruct()
    {
        echo "인스턴스 소멸" . br;
    }

    function write($contents)
    {
        echo "{$contents}을 쓰다" . br;
    }

    function draw($image)
    {
        echo "{$image}를 그리다" . br;
    }

    public function getColor() {
        echo $this->color.br;
    }

    static function staticTest() {
        echo "static 메소드 호출".br;
    }
}
// namespace 사용법 \네임스페이스\해당 클래스 혹은 메소드 식으로 사용
namespace ntest;
class b extends \df\pen {}

$pen = new \df\pen("red");
$pen->write("젠장");
$pen->draw("그림");
echo $pen->price.br;
echo $pen->getColor();
\df\pen::staticTest();
b::staticTest();
use \df\pen as pen; // 축약
pen::staticTest();
?>
