DELIMITER $$
CREATE PROCEDURE GetStudioGames(IN StudioName CHAR(20))                            
            SELECT g.Title, g.Genre, g.PEGI, g.Price FROM Games AS g
			INNER JOIN StudioGame AS relTb ON relTb.GameId = g.Id
			INNER JOIN Studios AS s ON relTb.StudioId = s.Id
			WHERE s.StudioName LIKE StudioName; $$

DELIMITER $$
CREATE PROCEDURE GetGamesByPEGI(IN PEGI INT)
	SELECT g.Title, g.Genre, g.PEGI, g.Price FROM Games AS g
	WHERE g.PEGI = PEGI; $$

DELIMITER $$
CREATE PROCEDURE GetGamesByPromoDesc(IN PrDesc CHAR(50))
	SELECT g.Title, g.Genre, g.PEGI, g.Price FROM Games AS g
	INNER JOIN GamePromotion AS promoRelTb ON promoRelTb.GameId = g.Id
	INNER JOIN Promotions AS p ON promoRelTb.PromotionId = p.Id
	WHERE p.PromoDesc LIKE PrDesc; $$

DELETMITER $$
CREATE PROCEDURE DeleteStudio(IN StudioName CHAR(20))
	WITH studioGames AS (
    SELECT junction.GameId, s.StudioName
	FROM Studios AS s
	INNER JOIN StudioGame AS junction ON junction.StudioId = s.Id
	WHERE s.StudioName = 'Bethesda'
)
SELECT j.GameId AS GameToRemove, COUNT(*)
FROM StudioGame AS j
INNER JOIN studioGames AS cte ON j.GameId = cte.GameId
GROUP BY j.GameId
HAVING COUNT(*) < 2
DELETE FROM Games AS g WHERE g.Id = GameToRemove
DELETE FROM Studios WHERE StudioName = 'Bethesda';
--Si no estan repetidos, borrar tmbn el juego


CREATE TABLE TempTable 
(
	GameId INT,
	CONSTRAINT Pk_GameId PRIMARY KEY (GameId)
);
INSERT INTO TempTable(GameId)
WITH studioGames AS (
SELECT junction.GameId, s.StudioName
FROM Studios AS s
INNER JOIN StudioGame AS junction ON junction.StudioId = s.Id
WHERE s.StudioName = 'Bethesda'
),
gamesToRemove AS (
SELECT j.GameId AS GameToRemove, COUNT(*) AS Duplicated
FROM StudioGame AS j
INNER JOIN studioGames AS cte ON j.GameId = cte.GameId
GROUP BY j.GameId
HAVING COUNT(*) < 2
)
SELECT gtr.GameToRemove FROM gamesToRemove AS gtr;
ALTER TABLE Games
ADD CONSTRAINT FK_TempTable FOREIGN KEY (Id) REFERENCES TempTable(GameId) ON DELETE CASCADE;
DELETE FROM TempTable;
ALTER TABLE Games
DROP CONSTRAINT FK_TempTable;
DROP TABLE TempTable;



gamesCTE AS (
	SELECT * FROM Games AS g
	WHERE g.Id = gamesToRemove.GameToRemove
)
DELETE FROM gamesCTE WHERE GameId IS NOT NULL;



SELECT * FROM Games WHERE Games.Id = games.GameId;
DELETE FROM games;



DELETE FROM Games AS g WHERE (g.Id = GameToRemove AND 1 = CASE Duplicated WHEN Duplicated = 1 THEN 1 ELSE 0 END)	

DELETE FROM Games WHERE Id = GameToRemove
DELETE FROM Studios WHERE StudioName = 'Bethesda';



SELECT * FROM cte_name;
	
	SELECT juntionTb.GameId AS GameId
	FROM StudioGame
	WHERE junctionTb.StudioId = StudioName
	IF 

	
	DELETE FROM Studios AS s WHERE s.StudioName = StudioName
	