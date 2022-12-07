<?php
include('connection.php');

$loginUser = $_POST['addUsername'];


$sql = "SELECT username, user_id FROM users_datas WHERE username = '".$loginUser."'";
$result = mysqli_query($conn, $sql);

if(mysqli_num_rows($result) > 0){
    while($row = mysqli_fetch_assoc($result)){
        if($row["username"] == $loginUser){
            echo $row['user_id'];
        }
        else{
            echo "Error";
        }
    }
}else{
    echo "Username not found";
}
?>