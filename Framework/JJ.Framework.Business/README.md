JJ.Framework.Business.Legacy
----------------------------

Classes to support a business logic layer.

- `EntityStatusManager`

    - Simple in-memory holder for entity/storage state like `New`, `Dirty` and `Deleted`.
    - The goal: let business logic ask "does this object look new/dirty/deleted? without depending on a database or a large persistence framework. You can fill this object from wherever is convenient (service code, UI, or persistence layer) and pass it around. Business rules can then react to those flags (for example: update `LastModified`) without being tied to how the data is stored.

-----

- `ISideEffect`

    - Used for some polymorphism between small pieces of business logic that go off as a result of altering or creating data. For instance storing the date time modified or setting default values or automatically generating a name might all be wrapped in side-effects, that are executed upon calling methods, like `Create`, `Update` and `Delete`. Using separate classes for side-effects, creates overview over those pieces of business logic, that are the most creative of all, and prevents those special things that need to happen from being entangled with other code.

-----

- `EntityStatusHelper.GetListIsDirty`

    - Compares two lists (a source list of data and a destination list of data). Determines whether a list is dirty. This means that it checks whether items were removed, added or changed. (The changing of items does not mean that the entities themselves are dirty, it means that a list position now points to another object.)

A historic version released in aid of older apps, that still hold value. Now targets `.NET 10` and `.NET Standard` supporting native code with code trimming for wide compatibility, tested with `100%` code coverage, doc pop-ups everywhere.

Release Notes
-------------

|         |                    |     |
|---------|--------------------|-----|
| `0.250` | __Legacy Release__ | Release of historic version. Full test coverage. Features:
|         |                    | `EntityStatusManager` and `GetListIsDirty`: 
|         |                    | framework-agnostic `New`/`Deleted`/`Dirty` flagging.
|         |                    | `ISideEffect` for keeping business logic units separated.
|         |                    | Bug fix: Entity status `New` and `Deleted` were accidentally stored as `Dirty`.

💬 Feedback 
------------

Got feedback or questions? You can reach me [here.](https://jjvanzon.github.io/#-how-to-reach-me)