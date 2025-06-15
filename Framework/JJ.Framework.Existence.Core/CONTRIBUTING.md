Contributing to Existence.Core
==============================

### Magic Boolean Pattern

Instead of a bool flag, you can use a single-valued enum e.g.,

```cs
enum SpaceMatters { spaceMatters = 1 }
```

This lets callers write:

```cs
`Has(text, spaceMatters)`
```

without `: true`, plus: it avoids unnecessary true/false logic in the method itself, making it slightly faster.