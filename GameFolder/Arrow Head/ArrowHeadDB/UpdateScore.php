<?php
include('connection.php');

$userId = $_POST['addUserId'];
$userScore = $_POST['addScore'];

$sql = "UPDATE Scoreboard SET score= '".$userScore."' WHERE user_Id = '".$userId."'";
$result = mysqli_query($conn, $sql);
?>