<?php // 시작Tag
// echo 출력 명령어
echo "이곳에 코드 작성";
echo "나눠서 적어도 바로 글자는 이어진다";
echo "<br>";
echo 1234;
echo "<br>";
echo true; // true는 1로 표시되네?
echo "<br>";

// 주석 스타일1
/* 주석 스타일2*/
# 주석 스타일3
echo "<!-- html주석 표시-->";

//echo phpinfo(); // php 정보를 표시

# 변수 사용
$변수 = 10;
$Val = "한글";
$test1 = false; // false는 빈칸으로 표시되네??
$br = "<br>";
echo $변수;
echo "$Val"; // 변수는 대소문자 구분
echo "{$test1}";
echo $br;
echo $Val.$변수. $br; // . 변수 연결연산자 띄어써도 상관없음
echo gettype($변수);
echo $br;
var_dump($Val);
echo $br;

# 상수
define("TEST", "test");
define("TEST", "test"); // 중복대입 불가
echo TEST;
define("br", "<br>");
echo br;

# 배열
$array = array();
$array[0] = "earth";
$array[1] = true;
$array[4] = 55;
$array["문자"] = "넴넴";
echo "{$array[4]}";
echo br;
echo "{$array["문자"]}";
var_dump($array);
echo br;

$array2 = array(3 => "asdf"); // 초기값 넣어서 생성
echo $array2[3];
echo br;

$array["문자"] = array(); // 배열안에 배열 생성
$array["문자"][0] = "배열안에 배열";
var_dump($array);
array_push($array, "추가값1", "추가값2"); // 기존값이 있다면 숫자 인덱스 다음 인덱스부터 자동 증가
echo br;
var_dump($array);
echo br;

$array3 = ["test1", "test2", 1, true, "test3"];
var_dump($array3);
echo br;

list($val1, $val2) = $array3; // [$val1, $val2] = $array3;
echo $val1;
echo br;
echo $val2;
echo br;
echo count($array3);
echo br;

# 형변환
$str = (string) true; // 1
$str1 = (string) 22;
echo $str.$str1;
echo br;

// 종료 Tag 생략가능 
?> 