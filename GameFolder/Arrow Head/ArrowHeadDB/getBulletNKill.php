<?php
include('connection.php');

$loginUserId = $_POST['addUserId'];

$sql = "SELECT user_Id, total_bullet_shot, total_enemies_killed FROM users_datas WHERE user_Id = '".$loginUserId."'";
$result = mysqli_query($conn, $sql);

if(mysqli_num_rows($result) > 0){
    while($row = mysqli_fetch_assoc($result)){
        if($row["user_Id"] == $loginUserId){
            echo $row['total_bullet_shot']."/".$row['total_enemies_killed'];
        }
        else{
            echo "Error";
        }
    }
}else{
    echo "User ID Not Found";
}
?>