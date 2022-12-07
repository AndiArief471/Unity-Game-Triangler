<?php
  $servername = "localhost";
  $username = "root";
  $password = "";
  $dbName = "arrow_head";

   //variables submited by user
   $loginUser = $_POST["loginUser"];
   $loginPass =  $_POST["loginPass"];
  
  $conn = new mysqli($servername, $username, $password, $dbName);

  if($conn->connect_error){
    die("Connection failed : ".$conn->connect_error);
  }

  $sql = "SELECT username FROM user_datas WHERE username = '".$loginUser."'";
  $result = mysqli_query($conn, $sql);

  if(mysqli_num_rows($result) > 0){
    while($row = mysqli_fetch_assoc($result)){
      if($row["username"] == $loginUser){
          echo "Login Success";
      }
      else {
        echo "Creating User.....";
        $sql2 = "INSERT INTO users_datas(user_id, username, password, date_created, total_playtime) VALUES ('1','".$loginUser."','".$loginPass."','".Date("d/m/Y")."','123')";
        if ($conn->query($sql2) === TRUE) {
          echo "New record created successfully";
        } 
        else{
          echo "Error: " . $sql2 . "<br>" . $conn->error;
        } 
        }
    }
  }
  
$conn->close();
?>