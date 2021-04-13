DROP PROCEDURE sp_FizzBuzzAdd
GO

CREATE PROCEDURE[dbo].[sp_FizzBuzzAdd]
	@input INT,
	@output NCHAR(10),
	@date DATETIME,
	@Id INT OUTPUT
AS
	INSERT INTO FizzBuzzRecent(input, output, date) VALUES (@input, @output, @date)
	SET @Id = @@IDENTITY