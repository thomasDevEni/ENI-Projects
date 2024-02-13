create procedure Creation as
begin

CREATE TABLE Role(
Id Int Identity primary key,
Libelle varchar(255) not null,
);

CREATE TABLE Lieu(
Id Int Identity primary key,
Etablissement varchar(255) not null,
Adresse varchar(255) not null,
Ville varchar(255) not null,
CodePostal varchar(5) not null,
CoordonneeGPS varchar(255) not null,
);

CREATE TABLE Participant(
Id Int Identity primary key,
Nom varchar(255) not null,
Prenom varchar(255) not null,
Mail varchar(255) not null,
RoleId int not null,

constraint FK_Participant_Roles foreign key (RoleId) references Role(Id),
);

CREATE TABLE Etat(
Id Int Identity primary key,
Libelle varchar(255) not null,
);

CREATE TABLE Sortie(
Id Int Identity primary key,
Nom varchar(255) not null,
DateDebut date,
DateFin date,
OrganisateurId int not null,
LieuId int not null,
EtatId int not null

constraint FK_Sortie_Participant foreign key (OrganisateurId) references Participant(Id),
constraint FK_Sortie_Lieu foreign key (LieuId) references Lieu(Id),
constraint FK_Sortie_Etat foreign key (EtatId) references Etat(Id),
);

CREATE TABLE Inscription(
Id Int Identity primary key,
SortieId int,
ParticipantId int,

constraint FK_Inscription_Sortie foreign key (SortieId) references Sortie(Id),
constraint FK_Inscription_Participant foreign key (ParticipantId) references Participant(Id)
);

end