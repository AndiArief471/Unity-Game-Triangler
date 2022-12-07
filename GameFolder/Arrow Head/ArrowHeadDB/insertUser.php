<?php
include('connection.php');

$userId = $_POST['addUserId'];
$username = $_POST['addUsername'];
$score = $_POST['addScore'];

$sql = "INSERT INTO user_datas(user_Id, username, score) VALUES('".$userId."','".$username."','".$score."')";
$result = mysqli_query($conn, $sql);
?>