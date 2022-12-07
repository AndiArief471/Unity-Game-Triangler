<?php
include('connection.php');

date_default_timezone_set('Asia/Jakarta');

$loginUser = $_POST['addUsername'];
$loginPass = $_POST['addPassword'];

$sql = "INSERT INTO users_datas(username, password, date_created) VALUES ('".$loginUser."','".$loginPass."','".date('d/m/Y')."')";
$result = mysqli_query($conn, $sql);
?>