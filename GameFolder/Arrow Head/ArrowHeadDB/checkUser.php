<?php
include('connection.php');

$loginUser = $_POST['addUsername'];
$loginPass = $_POST['addPassword'];

$sql = "SELECT username, password FROM users_datas WHERE username = '".$loginUser."'";
$result = mysqli_query($conn, $sql);

if(mysqli_num_rows($result) > 0){
    while($row = mysqli_fetch_assoc($result)){
        if($row["username"] == $loginUser && $row["password"] == $loginPass){
            echo "Login Success";
        }
        else{
            echo "Invalid Credentials";
        }
    }
}else{
    echo "Username Doesnt Exist";
}
?>