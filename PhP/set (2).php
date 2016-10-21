<?php
$hostname = 'mysql.hostinger.com.br';
 $username = 'u143324494_lucas';
 $password = '25842288';


 $con = mysqli_connect($hostname, $username, $password, 'u143324494_defen') or die ("no DB Connection");

           $name = $_POST['Name'];
           $score = $_POST['Record'];
  
           $query = "INSERT INTO u143324494_defen.Defensor  (ID, Name, Record) VALUES (NULL, '$name', $score);";
   
           mysqli_query($con, $query);
			




?>