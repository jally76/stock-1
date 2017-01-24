1. Steps to create and initialize the database
 - create an empty database 
 - run script \Source\database-setup.sql on the database
 
2. Steps to prepare the source code to build properly
 - open solution \Source\Stock.sln and run build
For starting application:
 - set correct connection string for created database. String placed in file \Source\Stock.Client.Web\Web.config
 - set startup projects: Stock.WebService and Stock.Client.Web 
 
3. Any assumptions made and missing requirements that are not covered in the requirements
 - asmx service is not securable

5. Any feedback you may wish to give about improving the assignment.

