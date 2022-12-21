JJ.Framework.Data
=================

Allows programming data access in one way, but switch between different types of data storage technology, without changing the application code.


Generic Interfaces
------------------

Data access might be favored behind generic interfaces, through which you cannot see what the underlying data access technology is. From the outside you would see entity models, repository interfaces and methods that say 'save it' and such. It's not visible from the outside that it's a database, `ORM`, `SQL Server`, `NHibernate`, `Entity Framework` or otherwise.

Basic interfaces for this are defined in:

[`JJ.Framework.Data`](https://dev.azure.com/jjvanzon/JJs-Software/_artifacts/feed/JJs-Pre-Release-Package-Feed/NuGet/JJ.Framework.Data/overview)

There are implementations for those interfaces here:

[`JJ.Framework.Data.EntityFramework`](https://dev.azure.com/jjvanzon/JJs-Software/_artifacts/feed/JJs-Pre-Release-Package-Feed/NuGet/JJ.Framework.Data.EntityFramework/overview)  
[`JJ.Framework.Data.Memory`](https://dev.azure.com/jjvanzon/JJs-Software/_artifacts/feed/JJs-Pre-Release-Package-Feed/NuGet/JJ.Framework.Data.Memory/overview)  
[`JJ.Framework.Data.NHibernate`](https://dev.azure.com/jjvanzon/JJs-Software/_artifacts/feed/JJs-Pre-Release-Package-Feed/NuGet/JJ.Framework.Data.NHibernate/overview)  
[`JJ.Framework.Data.SqlClient`](https://dev.azure.com/jjvanzon/JJs-Software/_artifacts/feed/JJs-Pre-Release-Package-Feed/NuGet/JJ.Framework.Data.SqlClient/overview)  
[`JJ.Framework.Data.Xml`](https://dev.azure.com/jjvanzon/JJs-Software/_artifacts/feed/JJs-Pre-Release-Package-Feed/NuGet/JJ.Framework.Data.Xml/overview)  
[`JJ.Framework.Data.Xml.Linq`](https://dev.azure.com/jjvanzon/JJs-Software/_artifacts/feed/JJs-Pre-Release-Package-Feed/NuGet/JJ.Framework.Data.Xml.Linq/overview)

Note these are pre-release packages and might not be fully polished.

The other interfaces you would define yourself, by implementing repositories and defining methods for each of the queries you might want to launch against the data store. There are base implementations for these repositories in `JJ.Framework`.

Here follow some outlines of what to find in these libraries and what could be done set up, to make a data access layer work like this.


Context
-------

`JJ.Framework.Data` includes an interface `IContext`, which represents the data store and allows basic operations such as `Get` an entity, `Create`, `Update` or `Delete` entities, and `Commit` and `RollBack` for transactions.

`JJ.Framework.Data.EntityFramework` and `JJ.Framework.Data.NHibernate` for instance implement specific `Contexts` to work with each of these technologies.


Repository
----------

`JJ.Framework.Data` has base types for repositories. Each repository would be about a single entity type. Also containing the basic operations `Create`, `Get`, `Update` and `Delete`.

The idea is that you can implement a `Repository` for each of your entity types (e.g. `Question`, `Category`). `JJ.Framework` provides the base and you can extended with additional methods for specialized queries.

It is advisable for these methods not to expose types from the underlying data access technology. It might be better make the parameters / return values either *entity types* like `Question`and `Category` or *simple types* like `int` and `string`. Then it would still be possible to switch to a different data acces technology without changing the other application code.


Mappings
--------

`ORM` technology like `Entity Framework` or `NHibernate` might require mappings to specify how to map your entity class to a database table. The way to do this is dictated by these respective technologies.


Config
------

Settings for a data access, can be configured in the `web.config` or `app.config`:

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <configSections>
    <section name="jj.framework.data" type="JJ.Framework.Configuration.ConfigurationSectionHandler, JJ.Framework.Configuration" />
  </configSections>

  <jj.framework.data
    contextType="NHibernate"
    dialect="SqlServer2008"
    location="Data Source=.;Initial Catalog=DEV_QuestionAndAnswerDB;User ID=...;Password=...;Persist Security Info=True"
    modelAssembly="JJ.Data.QuestionAndAnswer"
    mappingAssembly="JJ.Data.QuestionAndAnswer.NHibernate">
    <repositoryAssemblies>
      <repositoryAssembly>JJ.Data.QuestionAndAnswer.NHibernate</repositoryAssembly>
      <repositoryAssembly>JJ.Data.QuestionAndAnswer.DefaultRepositories</repositoryAssembly>
    </repositoryAssemblies>
  </jj.framework.data>
</configuration>
```

It specifies where things are: the database location, `ORM` tech, entities, mappings, repositories.

`JJ.Framework.Data` would then be able find all of these things when you call `ContextFactory` or `RepositoryFactory`.
