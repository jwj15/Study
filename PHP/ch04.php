<?php
# 파일 가져오기
include "./br.php"; // require 는 include와 달리 경로 및 파일에 문제가 있으면 오류발생
require_once "./br.php"; // 뒤에 _once가 붙으면 한번만 호출

# 유효성 검사
echo filter_var("1234@test.com", FILTER_VALIDATE_EMAIL); // 실패시 false, 성공시 해당 데이터리턴
echo br;
// url, ip, 숫자 등 여러가지 필터가 있다

# 폴더
var_dump(is_dir("/test")); // 폴더 존재 여부 확인
echo br;
$opendir = opendir("/test");
echo $opendir; // 성공시 resource 실패시 false
if ($opendir) {
    echo br . "open success" . br;
}
while ($readdir = readdir($opendir)) {
    echo $readdir . br;
}
closedir($opendir);
# 이미 닫았으므로 오류 발생
//while ($readdir = readdir($opendir)) {
//    echo $readdir.br;
//}
$opendir = opendir("/test");
echo readdir($opendir) . br;
echo readdir($opendir) . br;
echo readdir($opendir) . br;
rewinddir($opendir); # 순서를 처음으로 되돌림
echo readdir($opendir) . br;
echo readdir($opendir) . br;
if (!is_dir("/test/test2")) {
    // mkdir("/test/test2",777);  // 폴더 생성
}
// rmdir("/test/test2");  // 폴더 삭제

# 파일 읽기
$fopen = fopen("/test/script.txt", "a+");
# 파일 쓰기
// fwrite($fopen, "내용을 추가\n");
# 파일 닫기
fclose($fopen);
$fopen = fopen("/test/script.txt", "r");
# 파일 읽기
echo fread($fopen, filesize("/test/script.txt")) . br;
fclose($fopen);
$fopen = fopen("/test/script.txt", "r");
# 라인단위로 읽기
while ($fgets = fgets($fopen, filesize("/test/script.txt"))) {
    echo $fgets . br;
}
# 소스 보여주기
highlight_file("ch01.php"); //show_source() 이건 옛날꺼
?>
