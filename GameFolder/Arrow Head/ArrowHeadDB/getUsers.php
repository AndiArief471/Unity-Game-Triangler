<?php
  $servername = "localhost";
  $username = "root";
  $password = "";
  $dbName = "arrow_head";
  
  $conn = new mysqli($servername, $username, $password, $dbName);

  if($conn->connect_error){
    die("Connection failed : ".$conn->connect_error);
  }

  $sql = "SELECT user_Id, username, password FROM user_datas";
  $result = $conn->query($sql);

  if ($result->num_rows > 0) {
    // output data of each row
    while($row = $result->fetch_assoc()) {
      echo "Users ID: " . $row["user_Id"]. " - Username: " . $row["username"]. " - Password: " . $row["password"]."<br>";
    }
  }
  else {
    echo "0 results";
  }
$conn->close();

/*
include('connection.php');


$sql = "SELECT * FROM user_datas";
$result = mysqli_query($conn, $sql);

if(mysqli_num_rows($result) > 0){
  while($row = mysqli_fetch_assoc($result)){
    echo "User ID: ".$row['userId']."|Username: ".$row['username']."|Score: ".$row['score'].";";
  }
}
//////////////////////////////////////////////////////
// Check connection

if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}


*/
?>