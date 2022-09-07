<?php
require_once "./br.php";
# 쿠키
// 등록
setcookie("name","hong kil dong",time()+300,"/");
echo $_COOKIE["name"].br;
// 삭제
setcookie("name2","hong kil dong2",time()-1,"/");
echo $_COOKIE["name2"].br;
# 세션
session_start(); // 최상단에 써야 한다는데 중간에 써도 잘되네?
$_SESSION["name"] = "jwj";
echo $_SESSION["name"].br;
if (isset($_SESSION["name"])) { // 확인
    unset($_SESSION["name"]); // 삭제
}
echo $_SESSION["name"].br;
session_destroy(); // 세션 모두 삭제
?>
