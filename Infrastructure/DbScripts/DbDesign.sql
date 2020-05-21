GRANT ALL ON *.* TO 'root'@'localhost';
CREATE USER 'user'@'localhost' IDENTIFIED BY 'somepassword';
GRANT ALL ON *.* TO 'user'@'localhost';
FLUSH PRIVILEGES;

CREATE DATABASE IF NOT EXISTS GAJGamesDb;

USE GAJGamesDb;

/* A Company may have many Games and a Game may have been developed by two or more Studios
   so deleting a Studio or a Game should only delete that relationship in the junction table
   because deleting a Game should not delete the Studio and viceversa */

CREATE TABLE IF NOT EXISTS Studios (
    Id INT NOT NULL AUTO_INCREMENT,
    StudioName nvarchar(20) NOT NULL,
    Established DATE NOT NULL,    
    CONSTRAINT PK_Studio PRIMARY KEY (Id)
);


CREATE TABLE IF NOT EXISTS Games (
    Id INT NOT NULL AUTO_INCREMENT,
    Title nvarchar(30) NOT NULL,    
    Genre varchar(30) NOT NULL,
    Platform INT NOT NULL DEFAULT 0,
    Players INT NOT NULL DEFAULT 1,
    IsOnline BIT(1) NOT NULL,
    PEGI INT NOT NULL DEFAULT 3,
    ReleaseDate DATE NULL,
    Price DECIMAL(16,2) NULL DEFAULT 0.0,    
    AvailableZone INT NULL,
    CONSTRAINT PK_Game PRIMARY KEY (Id)
);


CREATE TABLE IF NOT EXISTS StudioGame(
    Id INT NOT NULL AUTO_INCREMENT,
    GameId INT NOT NULL,
    StudioId INT NOT NULL,
    CONSTRAINT PK_GameStudio PRIMARY KEY (Id),
    FOREIGN KEY (StudioId) REFERENCES Studios(Id) ON DELETE CASCADE,
    FOREIGN KEY (GameId) REFERENCES Games(Id) ON DELETE CASCADE  
);

CREATE TABLE IF NOT EXISTS AccountType(
    Id INT NOT NULL AUTO_INCREMENT,
    AccountDesc varchar(10) NOT NULL,
    HasGift BIT(1) NOT NULL,
    CONSTRAINT PK_Account PRIMARY KEY (Id)    
);

/* Only one AccountType per Customer, but deleting one or another 
should delete just that relationship (hence the junction table), not the register. 
Also, deleting an AccountType shouldn't be allowed if a customer has that 
AccountType assigned */

CREATE TABLE IF NOT EXISTS CustomerAccountType(
    Id INT NOT NULL AUTO_INCREMENT,
    CustomerId INT NOT NULL,
    AccountTypeId INT NOT NULL,    
    CONSTRAINT PK_CustomerAccountType PRIMARY KEY (Id),
    FOREIGN KEY (AccountTypeId) REFERENCES AccountType(Id)
);

CREATE TABLE IF NOT EXISTS Customer(
    Id INT NOT NULL AUTO_INCREMENT,
    FirstName varchar(20) NOT NULL,
    LastName varchar(20) NOT NULL,
    NickName nvarchar(40) NOT NULL,
    Age INT NOT NULL,
    CountryZone INT NOT NULL DEFAULT 0,
    CustomerAccountTypeId INT NOT NULL DEFAULT 0,
    CONSTRAINT PK_CustomerId PRIMARY KEY (Id),
    FOREIGN KEY (CustomerAccountTypeId) REFERENCES CustomerAccountType(Id) ON DELETE CASCADE
);



CREATE TABLE IF NOT EXISTS Promotions (
    Id INT NOT NULL AUTO_INCREMENT,
    PromoDesc nvarchar(50) NULL,
    Discount INT NOT NULL,
    IsValid BIT(1) NOT NULL,
    CONSTRAINT PK_Promotion PRIMARY KEY (Id)
);

/* A Game may have multiple discounts / promotions based on AccountType or Season Discount i.e
   Hence, the juntion table. Otherwise GamePromotionId would be a FK property on GameTB */

/* Promotion Based on studio -> StudioId+PromoId then Games-JOIN-StudioGame-JOIN-GamePromotio-JOIN-Promotions*/
CREATE TABLE IF NOT EXISTS GamePromotion (
    Id INT NOT NULL AUTO_INCREMENT,
    GameId INT NULL,
    PromotionId INT NOT NULL, 
    StudioId INT NULL,
    AccountTypeId INT NULL,
    StartDate DATE NOT NULL,
    EndDate DATE NOT NULL,  
    CONSTRAINT PK_GamePromotion PRIMARY KEY (Id),
    FOREIGN KEY (StudioId) REFERENCES Studios(Id) ON DELETE CASCADE,
    FOREIGN KEY (GameId) REFERENCES Games(Id) ON DELETE CASCADE,
    FOREIGN KEY (PromotionId) REFERENCES Promotions(Id) ON DELETE CASCADE,
    FOREIGN KEY (AccountTypeId) REFERENCES AccountType(Id) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS Queries(
    Id INT NOT NULL AUTO_INCREMENT,
    QueryName varchar(30) NOT NULL,
    Query TEXT NOT NULL,
    CONSTRAINT PK_Queries PRIMARY KEY (Id)
);

CREATE UNIQUE INDEX CustomerId_AccountId_IX ON CustomerAccountType(CustomerId, AccountTypeId);
CREATE UNIQUE INDEX GameId_StudioId_IX ON StudioGame(GameId, StudioId);
CREATE UNIQUE INDEX GameId_PromotionId_IX ON GamePromotion(GameId, PromotionId);
CREATE UNIQUE INDEX PromotionId_StudioId_IX ON GamePromotion(PromotionId, StudioId);
CREATE UNIQUE INDEX PromotionId_AccountTypeId_IX ON GamePromotion(PromotionId, AccountTypeId);
CREATE UNIQUE INDEX QueryName_IX ON Queries(QueryName);


