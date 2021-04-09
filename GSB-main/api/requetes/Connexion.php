<?php
    require 'conf.php';
    $name= filter_input(INPUT_GET, "name");
    $req = "SELECT * FROM visiteur WHERE VIS_NOM = ?";
    $stmt=$connex->prepare($req);
    $stmt->bindParam(1, $name, PDO::PARAM_STR);
    $stmt->execute();
    $InfosVis=$stmt->fetch(PDO::FETCH_ASSOC);
    echo json_encode($InfosVis);
?>

