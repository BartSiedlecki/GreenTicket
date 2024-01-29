IF OBJECT_ID('GetNextOrderNo', 'FN') IS NULL
	BEGIN
		EXEC('CREATE FUNCTION GetNextOrderNo()
				RETURNS VARCHAR(10)
				AS
					BEGIN
						DECLARE @nextOrderNo VARCHAR(10)
						SELECT @nextOrderNo = ''Z00'' + RIGHT(''0000'' + CAST((COUNT(*) + 1) AS VARCHAR), 4)
					FROM [Order]
					RETURN @nextOrderNo
				END')
	END