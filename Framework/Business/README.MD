JJ.Framework.Business
---------------------

Classes to support a business logic layer or an API.

- `OneToManyRelationship` / `ManyToOneRelationship`
    - Makes it easier to keep parent-child relationships in your model in sync. If you add a child, its parent immediately changes too, and if you assign a child's parent, the parent's children collection is updated automatically.
- `Result<T>` / `VoidResult` / `ResultBase` / `IResult`
    - An elegant way of returning data, along with a `Successful` flag and a list of messages.
- `ISideEffect`
    - Used for some polymorphism between small pieces of business logic that go off as a result of altering or creating data. For instance storing the date time modified or setting default values or automatically generating a name might all be wrapped in side-effects, that are executed upon calling methods, like `Create`, `Update` and `Delete`. Using separate classes for side-effects, creates overview over those pieces of business logic, that are the most creative of all, and prevents those special things that need to happen from being entangled with other code.
- `EntityStatusHelper.GetListIsDirty`
    - Compares two lists (a source list of data and a destination list of data). Determines whether a list is dirty. This means that it checks whether items were removed, added or changed. (The changing of items does not mean that the entities themselves are dirty, it means that a list position now points to another object.)

## OneToManyRelationship / ManyToOneRelationship

Makes it easier to keep parent-child relationships in your model in sync. If you add a child, its parent immediately changes too, and if you assign a child's parent, the parent's children collection is updated automatically.

You start doing this by implementing `OneToManyRelationship` and `ManyToOneRelationship` classes:

```cs
class ChildrenRelationship : OneToManyRelationship<Element, Element> { }
class ParentRelationship   : ManyToOneRelationship<Element, Element> { }
```

These two classes basically wrap a collection of children and a reference to a parent.

You may have noticed the `Element` class in the example above. This would be your own class. You can use your `Relationship` classes in your `Element` class:

```cs
class Element
{
    private ParentRelationship _parentRelationship;

    public Element Parent
    {
        get => _parentRelationship.Parent;
        set => _parentRelationship.Parent = value;
    }

    public ChildrenRelationship Children { get; }

    public Element()
    {
        _parentRelationship = new ParentRelationship(this);
        Children = new ChildrenRelationship(this);
    }
}
```

The code above works, because `ChildrenRelationship` class can be accessed, as if it is a collection:

```cs
foreach (var x in element.Children) { }
```

The `ChildToParentRelationship` wraps the parent, which can be accessed as follows:

```cs
_parentRelationship.Parent
```

The `Relationship` classes need some more work. Some methods should be implemented. Their implementation may be trivial:

```cs
class ChildrenRelationship : OneToManyRelationship<Element, Element>
{
    public ChildrenRelationship(Element parent) 
        : base(parent) { }

    protected override void SetParent(Element child) 
        => child.Parent = _parent;

    protected override void NullifyParent(Element child)
        => child.Parent = null;
}

class ParentRelationship : ManyToOneRelationship<Element, Element>
{
    public ParentRelationship(Element child)
        : base(child) { }

    protected override bool Contains(Element parent) 
        => parent.Children.Contains(_child);

    protected override void Add(Element parent) 
        => parent.Children.Add(_child);

    protected override void Remove(Element parent) 
        => parent.Children.Remove(_child);
}
```

So perhaps a little boilerplating to get it done. But it shouldn't too be much code. Internally the `ChildrenRelationship` and `ParentRelationship` classes override methods, delegating to navigation properties. The base classes `OneToManyRelationship` and `ManyToOneRelationship` classes ae not too much code either. To keep inverse properties in sync, this provides what's needed, without being too obscure about what is going on.

There are also some edge cases under which the `OneToManyRelationship` and `ManyToOneRelationship` classes still work:

- Non-nullable parents.
- Parent and child not the same class.
- Multiple relationships between the same classes.
- Side-effects going off upon assigning parent or removing children.
- You can control the underlying collection type of the children.
- Using different property names than Parent and Children in your model.

They all require a slightly different code. The above should be the simplest example.