USE [master]
GO

if exists(select * from sys.databases where name = 'db_Dating')
begin
ALTER DATABASE [db_Dating] SET SINGLE_USER
end
go


if exists(select * from sys.databases where name = 'db_Dating')
begin
DROP DATABASE [db_Dating]
end
go

CREATE DATABASE [db_Dating]
GO

 use [db_Dating]
 go

 
CREATE TABLE tbl_Users(
	ID int IDENTITY,
	Fornavn nvarchar(30) not null,
	Efternavn nvarchar(30) not null,
	Brugernavn nvarchar(30) not null,
	[Password] nvarchar(30) not null,
	Email nvarchar(50) not null default 'Ingen email',
	isAdmin bit not null,
	PRIMARY KEY (ID)
)

CREATE TABLE tbl_Gender(
	ID int IDENTITY,
	Genders nvarchar(30)
	PRIMARY KEY (ID)
)
Go

CREATE TABLE tbl_Profile(
	ID int IDENTITY,
	fk_User int,
	fk_Gender int,
	Smoker bit not null,
	Birthday smalldatetime,
	Profiltekst nvarchar(250),
	Profil_Aktiv bit not null,
	PRIMARY KEY (ID)
)

CREATE TABLE tbl_Search_Profile(
	ID int IDENTITY,
	fk_User int,
	Smoker tinyint not null,
	fk_Gender int,
	min_Birthday smalldatetime not null,
	[max_Birthday] smalldatetime not null,
	PRIMARY KEY (ID)
)

CREATE TABLE tbl_Match(
	ID int IDENTITY,
	fk_User_Judge int,
	fk_User_Victim int,
	[Match] bit not null,
	PRIMARY KEY (ID)
)

CREATE TABLE tbl_Chat(
	ID int IDENTITY,
	fk_User_From int,
	fk_User_Too int,
	Chat nvarchar(30) not null,
	PRIMARY KEY (ID)
)
Go

ALTER TABLE tbl_Profile
ADD CONSTRAINT Profile_fk_user
FOREIGN KEY (fk_User) REFERENCES tbl_Users (ID)
GO

ALTER TABLE tbl_Profile
ADD CONSTRAINT Profile_fk_gender
FOREIGN KEY (fk_Gender) REFERENCES tbl_Gender (ID)
GO

ALTER TABLE tbl_Search_Profile
ADD CONSTRAINT SearchProfile_fk_User
FOREIGN KEY (fk_User) REFERENCES tbl_Users (ID)
GO

ALTER TABLE tbl_Search_Profile
ADD CONSTRAINT SearchProfile_fk_Gender
FOREIGN KEY (fk_Gender) REFERENCES tbl_Gender (ID)
GO

ALTER TABLE tbl_Match
ADD CONSTRAINT Match_fk_User
FOREIGN KEY (fk_User_Judge) REFERENCES tbl_Users (ID)
GO

ALTER TABLE tbl_Match
ADD CONSTRAINT Match_fk_victim
FOREIGN KEY (fk_User_Victim) REFERENCES tbl_Users (ID)
GO

ALTER TABLE tbl_Chat
ADD CONSTRAINT Chat_From
FOREIGN KEY (fk_User_From) REFERENCES tbl_Users (ID)
GO

ALTER TABLE tbl_Chat
ADD CONSTRAINT Chat_too
FOREIGN KEY (fk_User_Too) REFERENCES tbl_Users (ID)
GO

INSERT INTO tbl_Users (Fornavn, Efternavn, Brugernavn, [Password], Email, isAdmin)
VALUES
('Admin', 'Administrator', 'admin', '123', 'Admin@email.com', 1),
('Jens', 'Hansen', 'Jens86', 'Passsw0rd', 'Jens86@email.com', 0),
('Adam', 'Domsen', 'Adam72', 'Passsw0rd', 'Adam72@email.com', 0),
('Jørgen', 'Mogensen', 'Jørgen92', 'Passsw0rd', 'Jørgen92@email.com', 0),
('Billy', 'Nielsen', 'Billy85', 'Passsw0rd', 'Billy85@email.com', 0),
('Rasmus', 'Jensen', 'Rasmus87', 'Passsw0rd', 'Rasmus87@email.com', 0),
('Jesper', 'Larsen', 'Jesper59', 'Passsw0rd', 'Jesper59@email.com', 0),
('Frans', 'Mikkelsen', 'Frans01', 'Passsw0rd', 'Frans01@email.com', 0),
('Lukas', 'Nielsen', 'Lukas18', 'Passsw0rd', 'Lukas18@email.com', 0),
('Tim', 'Hiersprung', 'Tim89', 'Passsw0rd', 'Tim89@email.com', 0),
('Henrik', 'Teglborg', 'Henrik49', 'Passsw0rd', 'Henrik49@email.com', 0),
('Tobias', 'Dybvad', 'Tobias90', 'Passsw0rd', 'Tobias90@email.com', 0),
('Carsten', 'Hjørvard', 'Hjørvard47', 'Passsw0rd', 'Hjørvard49@email.com', 0),
('Nanna', 'Andersen', 'Nanna87', 'Passsw0rd', 'Nanna87@email.com', 0),
('Ida', 'Boesen', 'Ida78', 'Passsw0rd', 'Ida78@email.com', 0),
('Isa', 'Mogensen', 'Isa92', 'Passsw0rd', 'Jørgen92@email.com', 0),
('Helene', 'Nielsen', 'Helene85', 'Passsw0rd', 'Billy85@email.com', 0),
('Karen', 'Jensen', 'Karen87', 'Passsw0rd', 'Rasmus87@email.com', 0),
('Futte', 'Larsen', 'Futte59', 'Passsw0rd', 'Jesper59@email.com', 0),
('Karina', 'Mikkelsen', 'Karina01', 'Passsw0rd', 'Frans01@email.com', 0),
('Ota', 'Nielsen', 'Ota18', 'Passsw0rd', 'Lukas18@email.com', 0),
('Gurli', 'Hiersprung', 'Girli89', 'Passsw0rd', 'Tim89@email.com', 0),
('Eva', 'Teglborg', 'Eva49', 'Passsw0rd', 'Henrik49@email.com', 0),
('Anna', 'Dybvad', 'Anna90', 'Passsw0rd', 'Tobias90@email.com', 0),
('Irene', 'Svendsen', 'Irene16', 'Passsw0rd', 'Tobias90@email.com', 0),
('Ann', 'Hjørvard', 'Hjørvard47', 'Passsw0rd', 'Hjørvard49@email.com', 0);

INSERT INTO tbl_Gender (Genders)
VALUES
('Mand'),
('Kvinde'),
('Transseksuel Mand'),
('Transseksuel Kvinde'),
('Flydende'),
('Intetkøn'),
('Rumraket');
GO

INSERT INTO tbl_Profile (fk_User, fk_Gender, Smoker, Birthday, Profiltekst, Profil_Aktiv)
VALUES
(1, 1, 0, '1986-12-28', 'This is my profile tekst wohoo', 1),
(2, 1, 1, '1987-12-28', 'This is my profile tekst wohoo', 1),
(3, 1, 0, '1986-12-28', 'This is my profile tekst wohoo', 1),
(4, 1, 0, '1986-12-28', 'This is my profile tekst wohoo', 1),
(5, 1, 0, '1986-12-28', 'This is my profile tekst wohoo', 1),
(6, 1, 0, '1986-12-28', 'This is my profile tekst wohoo', 1),
(7, 1, 0, '1986-12-28', 'This is my profile tekst wohoo', 1),
(8, 1, 0, '1986-12-28', 'This is my profile tekst wohoo', 1),
(9, 1, 1, '1986-12-28', 'This is my profile tekst wohoo', 1),
(10, 1, 0, '1986-12-28', 'This is my profile tekst wohoo', 1),
(11, 1, 0, '1986-12-28', 'This is my profile tekst wohoo', 1),
(12, 1, 1, '1986-12-28', 'This is my profile tekst wohoo', 1),
(13, 1, 0, '1986-12-28', 'This is my profile tekst wohoo', 1),
(14, 2, 0, '1986-12-28', 'This is my profile tekst wohoo', 1),
(15, 2, 0, '1986-12-28', 'This is my profile tekst wohoo', 1),
(16, 2, 1, '1986-12-28', 'This is my profile tekst wohoo', 1),
(17, 2, 0, '1986-12-28', 'This is my profile tekst wohoo', 1),
(18, 2, 0, '1986-12-28', 'This is my profile tekst wohoo', 1),
(19, 2, 0, '1986-12-28', 'This is my profile tekst wohoo', 1),
(20, 2, 1, '1986-12-28', 'This is my profile tekst wohoo', 1),
(21, 2, 0, '1986-12-28', 'This is my profile tekst wohoo', 1),
(22, 2, 1, '1986-12-28', 'This is my profile tekst wohoo', 1),
(23, 2, 0, '1986-12-28', 'This is my profile tekst wohoo', 1),
(24, 2, 0, '1986-12-28', 'This is my profile tekst wohoo', 1),
(25, 2, 0, '1986-12-28', 'This is my profile tekst wohoo', 1),
(26, 2, 1, '1986-12-28', 'This is my profile tekst wohoo', 1);

INSERT INTO tbl_Search_Profile(fk_User, Smoker, fk_Gender, min_Birthday, [max_Birthday])
VALUES
(1, 0, 1, '1996-12-28', '1986-12-28'),
(2, 2, 1, '1996-12-28', '1986-12-28'),
(3, 0, 1, '1996-12-28', '1986-12-28'),
(4, 0, 1, '1996-12-28', '1986-12-28'),
(5, 0, 1, '1996-12-28', '1986-12-28'),
(6, 0, 1, '1996-12-28', '1986-12-28'),
(7, 0, 1, '1996-12-28', '1986-12-28'),
(8, 0, 1, '1996-12-28', '1986-12-28'),
(9, 1, 1, '1996-12-28', '1986-12-28'),
(10, 0, 1, '1996-12-28', '1986-12-28'),
(11, 0, 1, '1996-12-28', '1986-12-28'),
(12, 1, 1, '1996-12-28', '1986-12-28'),
(13, 0, 1, '1996-12-28', '1986-12-28'),
(14, 0, 2, '1996-12-28', '1986-12-28'),
(15, 0, 2, '1996-12-28', '1986-12-28'),
(16, 2, 2, '1996-12-28', '1986-12-28'),
(17, 0, 2, '1996-12-28', '1986-12-28'),
(18, 0, 2, '1996-12-28', '1986-12-28'),
(19, 0, 2, '1996-12-28', '1986-12-28'),
(20, 1, 2, '1996-12-28', '1986-12-28'),
(21, 0, 2, '1996-12-28', '1986-12-28'),
(22, 2, 2, '1996-12-28', '1986-12-28'),
(23, 0, 2, '1996-12-28', '1986-12-28'),
(24, 0, 2, '1996-12-28', '1986-12-28'),
(25, 0, 2, '1996-12-28', '1986-12-28'),
(26, 1, 2, '1996-12-28', '1986-12-28');

-- Vores Database er så lille at det ikke giver mening på nuværende tidspunkt at lave non-clustered indexering. Et tænkt eksempel som databasen
-- vokser kunne dog være at man vil foretage mange forespørgsler på folks føldselsdage(hvor gamle er dem du er interesserede i at se profiler fra)
-- og derfor laver jeg preemptively et index på min profil tabel på Birthday kolonnen
CREATE INDEX tbl_Profil_Birthday
ON tbl_Profile (Birthday)


ALTER DATABASE [db_Dating] SET MULTI_USER
GO