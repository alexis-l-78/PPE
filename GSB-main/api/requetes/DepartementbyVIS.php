<?php
require 'conf.php';
$visCp= filter_input(INPUT_GET, "visCp");
$req = "SELECT * FROM visiteur where VIS_CP like '%".$visCp."%'";
$stmt=$connex->prepare($req);
$stmt->execute();
$InfosCp=$stmt->fetchALL(PDO::FETCH_ASSOC);
echo json_encode($InfosCp);
?>