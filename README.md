# Coronavirus-API
This is my First API. I created this API using .Net Framework, Entity Framework, and SQL Server Management Studio.



I first created my database and entered Covid 19 data in manually.

I then connected my API with my database using Entity Framework (Database First).



Then I created my mapper class and my repository class (This class has methods which call entity framework's methods to perform CRUD operations).

Finally, I created my three controllers which map to different tables in the database. The Global Cases Controller performs all CRUD operations. 

The other controllers only have get operations.
