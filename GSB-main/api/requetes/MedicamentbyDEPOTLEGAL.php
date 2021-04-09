<?php
require 'conf.php';
$depotLegal= filter_input(INPUT_GET, "depotLegal");
if (isset($depotLegal)){
    $req = 'SELECT * FROM medicament where MED_DEPOTLEGAL = ?';
    $stmt=$connex->prepare($req);
    $stmt->bindParam(1, $depotLegal, PDO::PARAM_STR);
    $stmt->execute();
    $InfosPra=$stmt->fetch(PDO::FETCH_ASSOC);
    echo json_encode($InfosPra);
}
else{
    $req = 'SELECT MED_NOMCOMMERCIAL FROM medicament';
    $stmt=$connex->prepare($req);
    $stmt->execute();
    $InfosPra=$stmt->fetchAll(PDO::FETCH_ASSOC);
    echo json_encode($InfosPra);
}

?>