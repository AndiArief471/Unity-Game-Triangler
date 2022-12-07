<?php
include('connection.php');

$loginUserId = $_POST['addUserId'];

$sql = "SELECT user_Id, score FROM scoreboard WHERE user_Id = '".$loginUserId."'";
$result = mysqli_query($conn, $sql);

if(mysqli_num_rows($result) > 0){
    while($row = mysqli_fetch_assoc($result)){
        if($row["user_Id"] == $loginUserId){
            echo $row['score'];
        }
        else{
            echo "Error";
        }
    }
}else{
    echo "User ID Not Found";
}
?>