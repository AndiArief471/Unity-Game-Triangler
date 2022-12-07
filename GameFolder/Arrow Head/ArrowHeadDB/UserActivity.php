<?php
include('connection.php');

$userId = $_POST['addUserId'];
//$playTime = $_POST['addPlayTime'];

date_default_timezone_set('Asia/Jakarta');
$sql = "INSERT INTO player_activity(date, time, user_Id) VALUES('".date('d/m/Y')."','".date("G:i:s")."','".$userId."')";
$result = mysqli_query($conn, $sql);
?>