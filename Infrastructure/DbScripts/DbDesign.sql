CREATE DATABASE IF NOT EXISTS GAJGamesDb;

USE GAJGamesDb;

/* A Company may have many Games and a Game may have been developed by two or more Studios
   so deleting a Studio or a Game should only delete that relationship in the junction table
   because deleting a Game should not delete the Studio and viceversa */

CREATE TABLE IF NOT EXISTS Studios (
    Id INT NOT NULL AUTO_INCREMENT,
    StudioName nvarchar(10) NOT NULL,
    Established DATE NOT NULL    
    CONSTRAINT PK_Studio (Id) PRIMARY KEY
);

CREATE TABLE IF NOT EXISTS StudioGame(
    Id INT NOT NULL AUTO_INCREMENT,
    GameId INT NOT NULL,
    StudioId INT NOT NULL,
    CONSTRAINT PK_GameStudio (Id) PRIMARY KEY,
    FOREIGN KEY StudioId REFERENCES Studios(Id) ON DELETE CASCADE,
    FOREIGN KEY GameId REFERENCES Games(Id) ON DELETE CASCADE  
);

CREATE TABLE IF NOT EXISTS Games (
    Id INT NOT NULL AUTO_INCREMENT,
    Title nvarchar(30) NOT NULL,    
    Genre varchar(10) NOT NULL,
    PEGI INT NOT NULL DEFAULT 3,
    ReleaseDate DATE NOT NULL,
    Price DECIMAL NOT NULL DEFAULT 0,    
    AvailableZone INT NULL,
    PromotionId INT NULL,
    CONSTRAINT PK_Game (Id) PRIMARY KEY
);



/* A Game may have multiple discounts / promotions based on AccountType or Season Discount i.e
   Hence, the juntion table. Otherwise GamePromotionId would be a FK property on GameTB */

CREATE TABLE IF NOT EXISTS GamePromotion (
    Id INT NOT NULL AUTO_INCREMENT,
    GameId INT NULL,
    PromotionId IN NOT NULL, 
    StudioId INT NULL,   
    CONSTRAINT PK_GamePromotion (Id) PRIMARY KEY,
    FOREIGN KEY FK_StudioId REFERENCES Studios(Id) ON DELETE CASCADE,
    FOREIGN KEY FK_GameId REFERENCES Games(Id) ON DELETE CASCADE,
    FOREIGN KEY FK_PromotionId REFERENCES Promotions(Id) ON DELETE CASCADE,

);

CREATE TABLE IF NOT EXISTS Promotions (
    Id INT NOT NULL AUTO_INCREMENT,
    'Description' nvarchar(50) NULL,
    Discount INT NOT NULL
    AccountTypeId INT DEFAULT 0,
    StartDate DATE NOT NULL,
    EndDate DATE,
    BIT IsValid NOT NULL DEFAULT 0,
    CONSTRAINT PK_Promotion (Id) PRIMARY KEY,
    FOREIGN KEY FK_AccountId REFERENCES Account(Id) ON DELETE CASCADE;
    FOREIGN KEY FK_StudioId REFERENCES Account(Id) ON DELETE CASCADE;
);

/* Only one AccountType per Customer, but deleting one or another 
should delete just that relationship (hence the junction table), not the register. 
Also, deleting an AccountType shouldn't be allowed if a customer has that 
AccountType assigned */

CREATE TABLE IF NOT EXISTS CustomerAccountType(
    Id INT NOT NULL AUTO_INCREMENT,
    CustomerId INT NOT NULL,
    AccountTypeId INT NOT NULL,    
    CONSTRAINT PK_Account (Id) PRIMARY KEY,
    FOREIGN KEY FK_CustomerId REFERENCES Account(Id)
);

CREATE TABLE IF NOT EXISTS AccountType(
    Id INT NOT NULL AUTO_INCREMENT,
    'Description' varchar(10) NOT NULL,
    BIT HasGift NOT NULL DEFAULT 0,
    CONSTRAINT PK_Account (Id) PRIMARY KEY    
);

CREATE TABLE IF NOT EXISTS Customer(
    Id INT NOT NULL AUTO_INCREMENT,
    FirstName varchar(20) NOT NULL,
    LastName varchar(20) NOT NULL,
    NickName nvarchar(20) NOT NULL,
    Age INT NOT NULL,
    CountryZone INT NOT NULL DEFAULT 0,
    CustomerAccountTypeId INT NOT NULL DEFAULT 0
    CONSTRAINT PK_CustomerId (Id) PRIMARY KEY,
    FOREIGN KEY CustomerAccountTypeId REFERENCES CustomerAccountType(Id) ON DELETE CASCADE
);


CREATE UNIQUE INDEX CustomerId_AccountId_IX ON CustomerAccountType(CustomerId, AccountId);
CREATE UNIQUE INDEX GameId_StudioId_IX ON StudioGame(GameId, StudioId);
CREATE UNIQUE INDEX GameId_StudioId_IX ON GamePromotion(GameId, PromotionId);
CREATE UNIQUE INDEX GameId_StudioId_IX ON GamePromotion(PromotionId, StudioId);


INSERT INTO Studio(StudioName,Established)
VALUES
("Electronic Arts", GETDATE()),
("Bethesda", GETDATE()),
("Activision",GETDATE()),
("2KGames",GETDATE()),
("CD Project",GETDATE()),
("IdSoftware",GETDATE()),
("Konami", GETDATE()),
("Arkane Studios", GETDATE()),
("Avalanche", GETDATE()),
("AnIndieStudio",GETDATE()),
("IndieProductions",GETDATE());


INSERT INTO Games(Title, Genre, PEGI, ReleaseDate, Price, AvailableZone)
VALUES
("Battlefield 1", "Action/FPS", 16, GETDATE(), 69.0, 1),
("Battlefront II", "Action/FPS", 16, GETDATE(), 40.0, 1),
("Fallout 3", "Action/RPG", 16, GETDATE(), 10.0, 1),
("Fallout 4", "Action/RPG", 16, GETDATE(), 10.0, 1),
("Wolfenstein New Order", "Action/FPS", 16, GETDATE(), 10.0, 1),
("Call of Duty MW", "Action/FPS", 16, GETDATE(), 10.0, 1),
("Borderlands 2", "Shooter/RPG", 16, GETDATE(), 10.0, 1),
("The Witcher 3", "Fantasy/RPG", 16, GETDATE(), 10.0, 1),
("Cyberpunk 2077", "Fantasy/RPG", 16, NULL, 10.0, 1),
("RAGE", "Shooter/RPG", 16, GETDATE(), 10.0, 1),
("RAGE 2", "Shooter/RPG", 16, GETDATE(), 10.0, 1),
("Metal Gear Solid 3", "Action/Stealth", 16, GETDATE(), 10.0, 1),
("Metal Gear Solid V", "Action/Stealth", 16, GETDATE(), 10.0, 1),
("Mad Max", "Driving/Action", 16, GETDATE(), 10.0, 1),
("Metro Redux", "Survival/Shooter", 16, GETDATE(), 10.0, 1),
("StarCitizen", "RPG/Syfy", 16, NULL, 10.0, 1),
("Uncharted", "Action/TPS", 16, GETDATE(), 10.0, 1),
("Rainbow Six Siege", "FPS", 16, GETDATE(), 10.0, 1),
("Dead Island", "Survival/Horror", 16, GETDATE(), 10.0, 1),
("Farcry 3", "FPS", 16, GETDATE(), 10.0, 1),
("Dishonored", "Action/Stealth", 16, GETDATE(), 10.0, 1),
("Dishonored 2", "Action/Stealth", 16, GETDATE(), 10.0, 1),
("Bioshock", "Action RPG/FPS", 16, GETDATE(), 10.0, 1)

INSERT INTO AccountType('Description', HasGift)
VALUES
('Regular'),
('Bronze'),
('Silver'),
('Gold', 1),
('Temporary');

INSERT INTO Promotions(Discount, StartDate, EndDate, IsValid, 'Description', AccountTypeId)
VALUES
(25, GETDATE(), GETDATE(),1, '25% Off', 1),
(50, GETDATE(), GETDATE(),1, '50% Off', 2),
(75, GETDATE(), GETDATE(),1, '75% Off', 3),
(100, GETDATE(), GETDATE(),1, 'Free', 3),
(100, GETDATE(), GETDATE(),1, '2x1', 2);

INSERT INTO Customer(FirstName, LastName, NickName, Age, CountryZone, CustomerAccountTypeId)
VALUES
('Fulano', 'Gomez', 'KillingFulano101', 24, 1, 1),
('Mengano', 'Gonzalez', 'Tommyknocker7483', 15, 1, 2),
('Zungano', 'Garcia', 'Tommyknocker215345', 16, 1, 3),
('John', 'Doe', 'UnknownPal', 28, 2, 4),
('John', 'Smith', 'JudgeDreddWannaBe', 18, 2, 5),
('Another', 'Player', 'Whatever', 30, 3, 6)
