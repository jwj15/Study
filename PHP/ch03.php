<?php

define("br", "<br>");

# 함수
function test_function($param1 = 10) { //default 값 설정 가능
    echo "test function 실행".$param1,br;
}
test_function();
test_function(20);

function refVsValue($param1, &$param2) { // &는 ref 값 전달
    $param1++;
    $param2++;
}
$int1 = 1;
$int2 = 1;
refVsValue($int1, $int2);
echo $int1.br;
echo $int2.br; // param2에 reference 값을 전달받아 값이 변했다

function sum(...$num) {
    $sum = 0;
    foreach($num as $n) {
        $sum += $n;
    }
    echo $sum.br;
}
sum(1,2,3,4,5);

$func = "sum";
$func(10,20,30); // 가변함수, 변수 이름에 ()를 붙여 해당 함수 사용가능

echo "=========== _SERVER 정보 ============",br;
foreach($_SERVER as $index => $val)  {
    echo $index,"=>",$val,br;
}
echo "=========== END ============";

?> 