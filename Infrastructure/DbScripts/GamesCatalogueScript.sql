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