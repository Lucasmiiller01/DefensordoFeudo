<?php
$hostname = 'mysql.hostinger.com.br';
 $username = 'u143324494_lucas';
 $password = '25842288';
 $port = '3306';

 $con = mysqli_connect($hostname, $username, $password, 'u143324494_defen') or die ("no DB Connection");


    $query = "SELECT * FROM u143324494_defen.Defensor ORDER by Record DESC LIMIT 50;";
    $result = mysqli_query($con, $query);
    $num_results = mysqli_num_rows($result);  
    for($i = 0; $i < $num_results; $i++) {
         $row = mysqli_fetch_array($result);
         echo $row['Name'] . "|" . $row['Record'] . "|";
}


    mysqli_close($con);
?>