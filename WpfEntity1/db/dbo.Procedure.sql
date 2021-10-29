CREATE PROCEDURE [dbo].[Procedure]
	/*@param1 int = 0,
	@param2 int*/
AS
	--SELECT @param1, @param2
	SELECT * FROM Movies  order by Название
RETURN 0
