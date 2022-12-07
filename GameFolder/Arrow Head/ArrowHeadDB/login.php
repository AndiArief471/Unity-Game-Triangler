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

  $sql = "SELECT password FROM user_datas WHERE username = '".$loginUser."'";
  $result = $conn->query($sql);

  if ($result->num_rows > 0) {
    // output data of each row
    while($row = $result->fetch_assoc()) {
      if($row["password"] == $loginPass){
        echo "Login Success";
      }
      else{
        echo "Wrong Credentials";
      }
    }
  }
  else {
    echo "Username Doesnt Exist";
  }
$conn->close();
?>