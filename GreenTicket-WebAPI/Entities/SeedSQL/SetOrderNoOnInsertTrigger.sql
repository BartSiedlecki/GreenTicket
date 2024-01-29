CREATE TRIGGER SetOrderNoOnInsert
        ON [Order]
        AFTER INSERT
        AS
        BEGIN
            SET NOCOUNT ON;
            
			DECLARE @newOrderNo AS VARCHAR(10) = (SELECT [dbo].[GetNextOrderNo]());

            UPDATE [Order]
            SET [OrderNo] = @newOrderNo 
            FROM INSERTED
            WHERE [Order].ID = INSERTED.ID;
        END
