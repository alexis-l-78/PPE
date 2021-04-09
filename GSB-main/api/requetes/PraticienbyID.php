<?php
require 'conf.php';
$id= filter_input(INPUT_GET, "id");
if (isset($id)){
    $req = 'SELECT * FROM praticien where PRA_NUM = ?';
    $stmt=$connex->prepare($req);
    $stmt->bindParam(1, $id, PDO::PARAM_STR);
    $stmt->execute();
    $InfosPra=$stmt->fetch(PDO::FETCH_ASSOC);
    echo json_encode($InfosPra);
}
else{
    $req = 'SELECT PRA_NOM FROM praticien';
    $stmt=$connex->prepare($req);
    $stmt->execute();
    $InfosPra=$stmt->fetchAll(PDO::FETCH_ASSOC);
    echo json_encode($InfosPra);
}

?>

