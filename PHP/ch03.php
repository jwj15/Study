<?php

define("br", "<br>");

# 함수
function test_function($param1 = 10) {
    echo "test function 실행".$param1,br;
}
test_function();
test_function(20);
echo "=========== _SERVER 정보 ============",br;
foreach($_SERVER as $index => $val)  {
    echo $index,"=>",$val,br;
}
echo "=========== END ============";

?> 