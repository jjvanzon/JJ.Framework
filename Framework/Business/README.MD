# JJ.Framework.Business

Classes to support a business logic layer or an API.

* `OneToManyRelationship` / `ManyToOneRelationship`
	* Makes it easier to keep parent-child relationships in your model in sync. If you add a child, its parent immediately changes too, and if you assign a child's parent, the parent's children collection is updated automatically.
* `Result`<`T`> / `VoidResult` / `ResultBase` / `IResult`
	* An elegant way of returning data, along with a `Successful` flag and a list of messages.
* `EntityStatusHelper.GetListIsDirty`
	* Determines whether a list is dirty. This means that it checks whether items were removed, added or changed. The changing of items does not mean that the entities themselves are dirty, it means that a list position now points to another object.
* `ISideEffect`
    * Used for some polymorphism between small pieces of business logic that go off as a result of altering or creating data. For instance storing the date time modified or setting default values or automatically generating a name might all be wrapped in side-effects, that are executed upon calling methods, like Create, Update and Delete. Using separate classes for side effects, creates overview over those pieces of business logic, that are the most creative of all, and prevents those special things that need to happen from being entangled with other code.
