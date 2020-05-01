SET FOREIGN_KEY_CHECKS=0;

INSERT INTO Studios(StudioName,Established)
VALUES
("Electronic Arts", '1982-05-27'),
("Bethesda", '1986-06-28'),
("Activision",'1978-10-01'),
("2KGames",'2005-01-25'),
("CD Projekt", '1994-05-01'),
("IdSoftware", '1991-02-01'),
("Konami", '1969-03-21'),
("Arkane Studios", '1999-10-12'),
("Avalanche Studios", '2003-03-01'),
("Gearbox", '1999-02-16'),
("4A Games", '2006-01-01'),
("Ubisoft", '1986-03-28'),
("Cloud Imperium Games", '2012-04-01'),
("MachineGames", '2009-05-14'),
("Naughty Dog", '1984-01-01'),
("Sony Computer Ent.", '1993-11-16'),
("Deep Silver", '2002-01-01');


INSERT INTO Games(Title, Genre, PEGI, Players, IsOnline, ReleaseDate, Price, AvailableZone)
VALUES
("Battlefield 1", "Action/FPS", 16, 64 ,1 ,'2017-03-28', 39.45, 1),
("Battlefront II", "Action/FPS", 16, 40, 1,'2017-11-17', 26.95, 1),
("Fallout 3", "Action/RPG", 18, 1, 0, '2008-10-30', 19.95, 1),
("Fallout 4", "Action/RPG", 18, 1, 0, '2015-11-10', 14.95, 1),
("Wolfenstein New Order", "Action/FPS", 18, 1, 0, '2014-05-20', 10.0, 1),
("Call of Duty Warzone", "Action/FPS", 18, 150 ,1,'2020-03-10', 0.0, 1),
("Borderlands 3", "Shooter/RPG", 16, 4, 1, '2019-09-13', 19.90, 1),
("The Witcher 3", "Action/RPG", 16, 1, 0, '2015-05-19', 39.95, 1),
("Cyberpunk 2077", "Action/RPG", 18, 1, 0, '2020-09-17',59.95, 1),
("RAGE", "Shooter/RPG", 18, 4, 1, '2011-10-07', 4.95, 1),
("RAGE 2", "Shooter/RPG", 18, 1, 0, '2019-05-19', 49.95, 1),
("Metal Gear Solid 3", "Action/Stealth", 16, 1, 0, '2004-11-09', 4.95, 1),
("Metal Gear Solid V", "Action/Stealth", 18, 16, 1, '2015-09-01', 26.95, 1),
("Mad Max", "Adventure/Action", 18, 1, 0,  '2015-10-04', 19.90, 1),
("Metro Redux", "Survival/Shooter", 18, 1, 0, '2014-08-29', 12.90, 1),
("StarCitizen", "RPG/Syfy", 16, 64, 1, NULL, NULL, 1),
("Uncharted", "Action/TPS", 16,0 ,1, '2007-12-05', 19.99, 1),
("Rainbow Six Siege", "FPS", 18, 10, 1, '2015-12-01', 19.90, 1),
("Dead Island", "Survival/Horror", 18, 4, 0, '2011-09-09', 19.90, 1),
("Farcry 3", "FPS", 18, 16, 1, '2012-11-29', 19.99, 1),
("Dishonored", "Action/Stealth", 18, 1, 0, '2012-10-12', 56.95, 1),
("Dishonored 2", "Action/Stealth", 18, 1, 0,'2016-11-11', 14.95, 1),
("Bioshock Infinite", "Action RPG/FPS", 18, 1, 0, '2013-03-26', 26.95, 1);

INSERT INTO AccountType(AccountDesc, HasGift)
VALUES
('Regular', 0),
('Bronze', 0),
('Silver', 0),
('Gold', 1),
('Temporary', 0);

INSERT INTO Promotions(Discount, IsValid, PromoDesc)
VALUES
(25, 1, '25% Off'),
(50,  1, '50% Off'),
(75,  1, '75% Off'),
(100, 1, 'Free'),
(100, 1, '2x1'),
(0, 1, 'No Promotion');

INSERT INTO Customer(FirstName, LastName, NickName, Age, CountryZone, CustomerAccountTypeId)
VALUES
('Fulano', 'Gomez', 'KillingFulano101', 24, 1, 1),
('Mengano', 'Gonzalez', 'Tommyknocker7483', 15, 1, 2),
('Zungano', 'Garcia', 'Tommyknocker215345', 16, 1, 3),
('John', 'Doe', 'UnknownPal', 28, 2, 4),
('Another', 'Player', 'Whatever', 30, 3, 6),
('Pepito', 'Perez', 'NiñoRata2009', 11, 1, 7),
('Juanita', 'Martinez', 'UnPibaQueJuegaAlaPlay', 17, 1, 8);


/* STUDIOGAME*/
INSERT INTO StudioGame(GameId, StudioId)
VALUES
(1,1),
(2,1),
(3,2),
(4,2),
(5,2),
(5,14),
(6,3),
(7,10),
(8,5),
(9,5),
(10,6),
(11,6),
(12,7),
(13,7),
(14,9),
(15,11),
(15,17),
(16,13),
(17,15),
(17,16),
(18,12),
(19,17),
(20,12),
(21,2),
(21,8),
(22,4);

INSERT INTO GamePromotion(GameId, PromotionId, StudioId, AccountTypeId, StartDate, EndDate)
VALUES
(NULL, 2, 2, NULL, NOW(), DATE_SUB(NOW(), INTERVAL 1 MONTH)),
(NULL, 2, 1, 3, NOW(), DATE_SUB(NOW(), INTERVAL  1 MONTH)),
(NULL, 1, 6, 2, NOW(), DATE_SUB(NOW(), INTERVAL  1 MONTH)),
(NULL, 3, 12, 4, NOW(), DATE_SUB(NOW(), INTERVAL  1 MONTH)),
(1, 3, NULL, NULL, NOW(), DATE_SUB(NOW(), INTERVAL 15 DAY)),
(7, 1, NULL, NULL , NOW(), DATE_SUB(NOW(), INTERVAL  15 DAY)),
(12, 5, NULL,NULL , NOW(), DATE_SUB(NOW(), INTERVAL  15 DAY)),
(10, 4, NULL, 1 , NOW(), DATE_SUB(NOW(), INTERVAL 1 Month)),
(22, 3, NULL,NULL , NOW(), DATE_SUB(NOW(), INTERVAL  1 Month));



INSERT INTO CustomerAccountType(CustomerId, AccountTypeId)
VALUES
(1,1),
(2,2),
(3,3),
(4,4),
(5,5),
(6,1),
(7,5);

SET FOREIGN_KEY_CHECKS=1;

INSERT INTO Queries(QueryName, Query)
VALUES
('GetStudioGamesByName', 'SELECT g.Title, g.Genre, g.PEGI, g.Price, p.PromoDesc AS Promotion FROM Games AS g INNER JOIN StudioGame AS relTb ON relTb.GameId = g.Id INNER JOIN Studios AS s ON relTb.StudioId = s.Id INNER JOIN GamePromotion AS promoJoin ON (promoJoin.GameId = g.Id OR promoJoin.GameId IS NULL) INNER JOIN Promotions AS p ON promoJoin.PromotionId = p.Id WHERE s.StudioName LIKE {studioName}%\';'),
('GetGamesByPEGI', 'SELECT g.Title, g.Genre, g.PEGI, g.Price FROM Games AS g WHERE g.PEGI = {PEGI};'),
('GetGamesByPromoDesc', 'SELECT g.Title, g.Genre, g.PEGI, g.Price, p.PromoDesc AS Promotion FROM Games AS g INNER JOIN GamePromotion AS promoRelTb ON promoRelTb.GameId = g.Id INNER JOIN Promotions AS p ON promoRelTb.PromotionId = p.Id WHERE p.PromoDesc LIKE {promoDesc}%\';'),
('GetPromotedGamesByStudioName','SELECT g.Title, g.Genre, g.PEGI, g.Price, p.PromoDesc AS Promotion FROM Studios AS s INNER JOIN GamePromotion AS joinTb ON joinTb.StudioId = s.Id INNER JOIN Promotions AS p ON joinTb.PromotionId = p.Id INNER JOIN StudioGame AS sg ON sg.StudioId = joinTb.StudioId INNER JOIN Games AS g ON sg.GameId = g.Id WHERE s.StudioName = {studioName};');


SELECT g.Title, g.Genre, g.PEGI, g.Price, HasPromo =
CASE WHEN EXISTS
(
    SELECT 1 FROM Promotions AS p
    INNER JOIN GamePromotion AS promoJoin ON promoJoin.GameId = g.Id
    INNER JOIN Promotions AS pr ON pr.Id = promoJoin.PromotionId
) THEN 1 ELSE 0 END
FROM Games AS g 
INNER JOIN StudioGame AS relTb ON relTb.GameId = g.Id 
INNER JOIN Studios AS s ON relTb.StudioId = s.Id 
WHERE s.StudioName LIKE 'Bethesda';