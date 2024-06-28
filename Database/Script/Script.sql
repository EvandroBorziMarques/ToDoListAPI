CREATE DATABASE toDoList;

USE toDoList;

CREATE TABLE notes (
	id int NOT NULL PRIMARY KEY IDENTITY,
    note ntext,
    concluded bit
);

IF EXISTS(SELECT name FROM sys.procedures WHERE name = 'ToDoCreate')
	        DROP PROCEDURE dbo.ToDoCreate
            GO
            
            CREATE PROCEDURE dbo.ToDoCreate(@note ntext, @concluded bit)
            AS  
            BEGIN  
            	INSERT INTO
            	notes
            	(note, concluded)
            	VALUES
            	(@note, @concluded)
            END  
            GO

-----------------------------------------------------------------------

IF EXISTS(SELECT name FROM sys.procedures WHERE name = 'ToDoList')
	        DROP PROCEDURE dbo.ToDoList
            GO
            
            CREATE PROCEDURE dbo.ToDoList
           	AS  
            BEGIN  
            	SELECT 
            	id as [id],
            	note as [note],
            	concluded as [concluded]
            	FROM notes
            END  
            GO
            
-----------------------------------------------------------------------

IF EXISTS(SELECT name FROM sys.procedures WHERE name = 'ToDoGetById')
	        DROP PROCEDURE dbo.ToDoGetById
            GO            
            CREATE PROCEDURE dbo.ToDoGetById(@id int)
            AS  
            BEGIN  
            	Select
            	id as [id],
            	note as [note],
            	concluded as [concluded]
            	FROM
            	notes
            	WHERE
            	id = @id
            END  
            GO
            
-----------------------------------------------------------------------

IF EXISTS(SELECT name FROM sys.procedures WHERE name = 'ToDoUpdate')
	        DROP PROCEDURE dbo.ToDoUpdate
            GO
            
            CREATE PROCEDURE dbo.ToDoUpdate(@id int, @note ntext, @concluded bit)
            AS  
            BEGIN  
            	UPDATE
            	notes
            	SET
            	note = @note,
            	concluded = @concluded
            	where
            	id = @id
            END  
            GO

-----------------------------------------------------------------------
            
IF EXISTS(SELECT name FROM sys.procedures WHERE name = 'ToDoDelete')
	        DROP PROCEDURE dbo.ToDoDelete
            GO
            
            CREATE PROCEDURE dbo.ToDoDelete(@id int)
            AS  
            BEGIN  
            	DELETE
            	FROM
            	notes
            	where
            	id = @id
            END  
            GO