<?php
require_once "./br.php";

extension_loaded('mysqli');
$db = mysqli_connect("localhost", "phpadmin", "test1234", "php");

if ($db) {
    echo "connect: success" . br;
} else {
    echo "connect: failure" . br;
}

?>
