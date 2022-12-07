<?php
include('connection.php');

date_default_timezone_set('Asia/Jakarta');

$userId = $_POST['addUserId'];
$username = $_POST['addUsername'];
$score = $_POST['addScore'];

$sql = "INSERT INTO scoreboard(user_Id, username, date, score) VALUES ('".$userId."','".$username."','".date('d/m/Y')."','".$score."')";
$result = mysqli_query($conn, $sql);
?>