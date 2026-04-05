# Copilot Instructions

## General Guidelines
- Avoid automatic builds unless the user requests them (the user runs NCrunch locally and may deny build requests).
- Please stop over-engineering. Lean code is important for the system.

## Code Style
- Use file-scoped namespace
- Prefer global usings in `Usings.cs`.
- Use parameter name `x` for short lambdas.

## Docs
- Keep documentation tone friendly and accessible.
- Centralize XML documentation into small unobtrusive `struct` entries in `docs.cs` and use `<inheritdoc cref="_..." />` in implementation files.

## Tests
- Prefer `AssertCore` over `Assert` (using static in Usings.cs)

## Legacy Test Upgrades
- Expand for full code coverage.
    - Avoid changing production code.
    - Create or update matching `*_CoreTests.cs`s in `*.Legacy.Tests.csproj`s
-

