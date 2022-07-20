<?php
# 파일 가져오기
include "./br.php"; // require 는 include와 달리 경로 및 파일에 문제가 있으면 오류발생
require_once "./br.php"; // 뒤에 _once가 붙으면 한번만 호출

# 유효성 검사
echo filter_var("1234@test.com", FILTER_VALIDATE_EMAIL); // 실패시 false, 성공시 해당 데이터리턴
// url, ip, 숫자 등 여러가지 필터가 있다

# 폴더 생성

?> 