<hr>
<div class="container">
<div class="row">
<div class="panel panel-primary">
        <div class="panel-heading">Fiche de frais du mois 
            <?php echo $leMois."-".$Annee?> :
        </div>
            <div class="panel-body">
                <?php
                foreach ( $lesFrais as $unFraisForfait )
                {
                $nom = $unFraisForfait['nom'];
                $prenom = $unFraisForfait['prenom'];
                $montant = $unFraisForfait['montantValide'];
                $date = $unFraisForfait['dateModif'];
                $libelle = $unFraisForfait['libelle'];
                $idVisiteur = $unFraisForfait['id'];
                ?>
                    <div class="container">
                        <div class="row1">

                            <table class="listeLegere table table-bordered table-responsive">
                                <tr>
                                    <th>Nom</th>
                                    <th>Prenom</th>
                                    <th>Montant</th>
                                    <th>Date</th>
                                    <th>Etat</th>
                                </tr>
                                <tr>
                                    <td><?php echo $nom ?></td>
                                    <td><?php echo $prenom ?></td>
                                    <td><?php echo $montant ?></td>
                                    <td><?php echo $date ?></td>
                                    <td>
                                        <form method="post" action="index.php?uc=validFrais&action=recherche&idvisiteur=<?=$idVisiteur?>&mois=<?=$Annee.$leMois?>">
                                            <select name="value">
                                                <option value="<?=$libelle?>"><?=$libelle?></option>
                                                <option value="CL">CL - Saisie clôturée</option>
                                                <option value="CR">CR - Fiche créée, saisie en cours</option>
                                                <option value="RB">RB - Remboursée</option>
                                                <option value="VA">VA - Validée et mise en paiement</option>
                                                <option value="RE">RE - Refusé</option>
                                                <input type="submit" value="modifier">
                                            </select>
                                        </form>
                                    </td>
                                    <a href="index.php?uc=validFrais&action=voir&idvisiteur=<?=$idVisiteur ?>&mois=<?=$Annee.$leMois?>" title="valider fiche de frais ">Voir les fiches hors forfait</a>
                                </tr>
                            </table>
                        </div>
                    </div>
                <?php
                }
                ?>
            </div>
        </div>
    </div>
</div>

