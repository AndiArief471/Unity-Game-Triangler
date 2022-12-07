<?php
include('connection.php');

$userId = $_POST['addUserId'];
$userBulletShot = $_POST['addBulletShot'];
$userEnemiesKilled = $_POST['addEnemiesKilled'];

$sql = "UPDATE users_datas SET total_bullet_shot = '".$userBulletShot."', total_enemies_killed = '".$userEnemiesKilled."' WHERE user_Id = '".$userId."'";
$result = mysqli_query($conn, $sql);
?>