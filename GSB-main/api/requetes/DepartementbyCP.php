<?php
    require 'conf.php';
    $cp= filter_input(INPUT_GET, "cp");
    $req = "SELECT distinct PRA_CP FROM praticien where PRA_CP like '%".$cp."%'";
    $stmt=$connex->prepare($req);
    $stmt->execute();
    $InfosCp=$stmt->fetchALL(PDO::FETCH_ASSOC);
    foreach ($InfosCp as $key){
        echo json_encode($key);
    }
?>