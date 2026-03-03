# Copilot Instructions

## General Guidelines
- Keep documentation tone friendly and accessible.
- Avoid automatic builds unless the user requests them (the user runs NCrunch locally and may deny build requests).

## Code Style
- Use short lambda parameter name 'x' for short lambdas.
- Centralize XML documentation into small unobtrusive `struct` entries in `docs.cs` and use `<inheritdoc cref="_..." />` in implementation files.
- Prefer `AssertCore` helpers in tests.

## Project-Specific Rules
- Reuse mock models from `Mocks.cs` (Question/Category/Link/Flag and `EntityFactory`).
- Create new test projects under `Framework\JJ.Framework.IO.Core.Tests` for Core tests.

## Misc
- Prefer regular Command Prompt over PowerShell.
- Please stop over-engineering. Lean code is important for the system.