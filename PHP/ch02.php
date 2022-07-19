<?php

define("br", "<br>");
# if문
if ("1" == 1) { // 타입까지 비교하려면 === 사용
    echo "1과 \"1\"은 같은것으로 취급";
}
echo br;
$str = "test";
$str2 = "test";
if ($str == $str2) {
    echo "문자열 비교도 가능";
}
echo br;

# switch문
$age = 24;
switch($age) {
    case ($age >= 10 && $age <= 30):
        echo "case문에 조건을 줄 수 있다.";
        break;
    case 9 :
        echo "9살!!";
        break;
}
echo br;

# for문
for($i = 0; $i < 10; $i++) {
    echo $i.',';
}
echo br;
echo $i; // 다른 언어와 다르게 가져올 수 있음
echo br;

?> 