
delimiter |
	DROP PROCEDURE IF EXISTS newemploye |
	CREATE PROCEDURE newemploye(string nom,string prenom,string sexe, byte cadre,decimal salaire,int emp_service)
	BEGIN
		insert into Employe(emp_nom,emp_prenom,emp_sexe,emp_cadre,emp_salaire,emp_service) values('totdho','tifrgti','M',1,80500,1);
	END
	|
	CALL newemploye() |
	/*SELECT @A|*/
	delimiter ;



delimiter |
DROP PROCEDURE if EXISTS baclic |
CREATE PROCEDURE baclic ()
BEGIN
	SELECT emp_nom, emp_prenom from employe e inner join posseder p on e.emp_id=p.pos_employe inner join diplome d on p.pos_diplome=d.dip_id and dip_libelle = "Bac" and emp_id in (SELECT emp_id from employe e inner join posseder p on e.emp_id=p.pos_employe inner join diplome d on p.pos_diplome=d.dip_id and dip_libelle = "Licence") ;
END
|
CALL baclic()|
delimiter ;


delimiter |
DROP PROCEDURE if EXISTS borne |
CREATE PROCEDURE borne (IN borneInf int, IN borneSup int)
BEGIN
	select emp_nom, emp_prenom from employe where emp_salaire <= borneSup and emp_salaire >= borneInf ;
END
|
CALL borne(2400,3000)|
delimiter ;


delimiter |
DROP PROCEDURE if EXISTS updateService |
CREATE PROCEDURE updateService (IN numero int, IN pourcentage double)
BEGIN
	update service set ser_budget = (ser_budget + ser_budget * pourcentage) where ser_id = numero ;
END
|
CALL updateService(3,0.3)|
delimiter ;


delimiter |
DROP PROCEDURE if EXISTS diplome |
CREATE PROCEDURE MoyenneDiplome ()
BEGIN
	select emp_nom, emp_prenom from employe e inner join qtédiplome on e.emp_id=qtédiplome.pos_employe where compte > (select avg(compte) from qtédiplome);
END
|
CALL diplome()|
delimiter ;

create view qtéDiplome as select pos_employe, count(distinct pos_diplome) as compte from posseder group by pos_employe ;

select emp_nom, emp_prenom from employe e inner join qtédiplome on e.emp_id=qtédiplome.pos_employe where compte > (select avg(compte) from qtédiplome);

CA COMMENCE ICIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII
ICIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII
ICIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII
IIIIII

delimiter |
DROP PROCEDURE if EXISTS MajSalaire |
CREATE PROCEDURE MajSalaire (In nom varchar(55), In pourcentage double)
BEGIN
	update employe set emp_salaire = emp_salaire + emp_salaire * pourcentage where emp_nom = nom;
END
|
delimiter ;


delimiter |
DROP PROCEDURE if EXISTS MasseSalariale |
CREATE PROCEDURE MasseSalariale (IN unService varchar(55), OUT masse double)
BEGIN
	select sum(emp_salaire) into masSalar FROM employe e inner join service s on e.emp_service = s.ser_id where ser_designation = nomservice;
END
|
delimiter ;

create view Cadre as select * from employe where emp_cadre = 1;

CALL MasseSalariale("Atelier A", @masSalar);

select @masSalar;