<?php
include('connection.php');

$userId = $_POST['addUserId'];
$userTimePlay = $_POST['addTimePlay'];

$sql = "UPDATE player_activity SET play_time= '".$userTimePlay."' WHERE user_Id = '".$userId."'";
$result = mysqli_query($conn, $sql);
?>