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
$memList = ["김미유","김유나","김민후","김해윤"];
foreach($memList as $m) {
    echo $m;
    echo br;
}
foreach($memList as $index => $value) {
    echo $index.'=>'.$value;
    echo br;
}

# string 함수들
$testStr = "  test  ";
echo trim($testStr),br; // trim
echo ltrim($testStr),br; // 왼쪽 트림
echo rtrim($testStr),br; // 오른쪽 트림
echo strtoupper($testStr),br; // 대문자 변환
echo strtolower($testStr),br; // 소문자 변환
echo strlen($testStr),br; // 문자열 수
echo str_replace("치환대상", "대체할 문자", "원본 : 치환대상"),br; // replace
echo substr("hello world", 0, 5), br; // 문자 자르기
echo ucfirst("abcdef"),br; // 첫글자 대문자
echo ucwords("hello world"),br; // 단어별 첫글자 대문자변경
echo strpos("hello world", "l"),br; //찾는 문자 index 표시, 중복인경우 처음글자 인덱스 리턴
echo isset($testStr),br; // 변수 존재하는지 리턴 bool
echo empty(''),br; // 빈값확인 '', null, array(), [], 0, '0' 등

# 시간
echo time(),br; // timestamp 출력
echo date("Y-m-d h:i:s", time()),br;
echo mktime(9, 15,10,1,1,2022),br; // timestamp로 변환, 시 분 초 월 일 년 순서
var_dump(getdate()); // 현재 시간 정보 배열
echo br;
echo var_dump(checkdate(2,29,2019)),br; // 해당 날짜가 유효한 날짜인지 체크

# 숫자 3자리 컴마표시
echo number_format(10000000, 2),br; // string 리턴


?> 