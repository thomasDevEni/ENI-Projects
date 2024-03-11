USE [Sortie]
GO
/****** Object:  StoredProcedure [dbo].[Creation]    Script Date: 13/02/2024 11:49:00 ******/
begin

CREATE TABLE Role(
Id Int Identity primary key,
Libelle varchar(255) not null,
IsActive bit not null,
Protected bit not null
);

INSERT INTO Role(Libelle,IsActive,Protected)
VALUES ('Admin','1','1');
INSERT INTO Role(Libelle,IsActive,Protected)
VALUES ('Utilisateur','1','1');
INSERT INTO Role(Libelle,IsActive,Protected)
VALUES ('Visiteur','1','1');

CREATE TABLE Lieu(
Id Int Identity primary key,
Etablissement varchar(255) not null,
Adresse varchar(255) not null,
Ville varchar(255) not null,
CodePostal varchar(5) not null,
CoordonneeGPS varchar(255) not null,
IsActive bit not null
);

CREATE TABLE Participant(
Id Int Identity primary key,
Nom varchar(255) not null,
Prenom varchar(255) not null,
Mail varchar(255) not null,
RoleId int not null,
IsActive bit not null,
Protected bit not null,

constraint FK_Participant_Role foreign key (RoleId) references Role(Id),
);

INSERT INTO Participant(Nom,Prenom,Mail,RoleId,IsActive,Protected)
VALUES ('SuperAdmin','Unique','super.admin@mail.com','1','0','1');

CREATE TABLE Utilisateur (
Id Int Identity primary key,
Username varchar(255) not null,
Password varchar(255) not null,
LastName varchar(255) not null,
FirstName varchar(255) not null,
Mail varchar(255) not null,
RoleId int not null,
IsActive bit not null,
Protected bit not null,

constraint FK_Utilisateur_Role foreign key (RoleId) references Role(Id),
);

CREATE TABLE Etat(
Id Int Identity primary key,
Libelle varchar(255) not null,
IsActive bit not null,
Protected bit not null
);

INSERT INTO Etat(Libelle,IsActive,Protected)
VALUES ('Initial','1','1');

CREATE TABLE Sortie(
Id Int Identity primary key,
Nom varchar(255) not null,
DateDebut date,
DateFin date,
OrganisateurId int not null,
LieuId int not null,
EtatId int not null,
IsActive bit not null

constraint FK_Sortie_Participant foreign key (OrganisateurId) references Participant(Id),
constraint FK_Sortie_Lieu foreign key (LieuId) references Lieu(Id),
constraint FK_Sortie_Etat foreign key (EtatId) references Etat(Id),
);

CREATE TABLE Inscription(
Id Int Identity primary key,
SortieId int,
ParticipantId int,
IsActive bit not null

constraint FK_Inscription_Sortie foreign key (SortieId) references Sortie(Id),
constraint FK_Inscription_Participant foreign key (ParticipantId) references Participant(Id)
);

end