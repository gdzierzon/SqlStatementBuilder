# SqlStatementBuilder

The SqlStatementBuilder project began out of a need to quickly generate SQL syntax in C#. I wanted a generic and fluent way to create SQL expressions for testing purposes and I did not want to be tied to a full ORM such as Entity Framework. I simply needed to quickly generate SQL, and I wanted it to feel like SQL.

## Getting Started

This solution has 2 projects: SqlStqatementBuilder and SqlStatementBuilder.Test. 

### Prerequisites

This solution was built using Visual Studio 2017 (any edition will work).

The test project uses MSTest and Specificity for MSTest. The Specificity package will download from NuGet when the project is compiled.

### Using the SqlStatementBuilder

The entry point of each statment is the **SqlBuilder**. In order to make the syntax as fluent as possible, the SqlBuilder was designed using static classes and methods. This is to avoid, as much as possible, the interruption of a statement due to a new object construction.

The initial commit of the **SqlStatementBuilder** includes basic implementation of 2 SQL DML statement types: **INSERT** and **SELECT**.

### Examples
**Select**
```
var query = new Select("*")
                .From("TableName")
				.ToString();
				
var query = new Select("Id, Name, Phone")
                .From("TableName")
				.ToString();
				
var query = new Select()
                .Columns("Id, Name, Phone")
                .From("TableName")
				.ToString();
```
If you prefer to keep your columns on separate lines you can also pass a comma separated list of names/expressions as the input parameters.
```				
 var query = new Select(
                    "Id", 
                    "Name", 
                    "Phone"
                )
                .From("TableName")
                .ToString();
```



