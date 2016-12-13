JJ.Framework.Business contains classes to support a business logic layer or API's.

One thing in here is the ManyToOneRelationship and OneToManyRelationship classes, which makes it easier to keep parent-child relationships in your model in sync. If you add a child, its parent immediately changes too, and if you assign a child's parent, the parent's children collection is updated automatically.