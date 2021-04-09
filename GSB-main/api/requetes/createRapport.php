<?php
require 'conf.php';
$visMat=filter_input(INPUT_GET,"visMat");
$praNum= filter_input(INPUT_GET, "praNum");
$date= filter_input(INPUT_GET, "date");
$motif= filter_input(INPUT_GET, "motif");
$bilan= filter_input(INPUT_GET, "bilan");

$req = 'INSERT INTO rapport_visite (VIS_MATRICULE, PRA_NUM, RAP_DATE, RAP_BILAN, RAP_MOTIF) values (?,?,?,?,?)';
$stmt=$connex->prepare($req);
$stmt->bindParam(1, $visMat, PDO::PARAM_STR);
$stmt->bindParam(2, $praNum, PDO::PARAM_STR);
$stmt->bindParam(3, $date, PDO::PARAM_STR);
$stmt->bindParam(4, $bilan, PDO::PARAM_STR);
$stmt->bindParam(5, $motif, PDO::PARAM_STR);
$stmt->execute();

echo "<p>Visiteur matricule  = ".$visMat."</p>";
echo "<p>Praticien matricule = ".$praNum."</p>";
echo "<p>Date = ".$date."</p>";
echo "<p>Motif = ".$motif."</p>";
echo "<p>Bilan = ".$bilan."</p>";
echo "<h1>les donnees ont bien ete enregistre !</h1>"
?>