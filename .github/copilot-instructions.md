# Copilot Instructions

## General Guidelines
- Avoid automatic builds unless the user requests them (the user runs NCrunch locally and may deny build requests).
- Please stop over-engineering. Lean code is important for the system.

## Code Style
- Use file-scoped namespace.
- Prefer global usings in `Usings.cs`.
- Use parameter name `x` for short lambdas.
- Use file-scoped namespaces and `using static` imports for methods (e.g., `using static NumberingSystems;` and `using static AssertCore;`).
- Use collection expressions `[]` instead of `new[]`.

## Docs
- Keep documentation tone friendly and accessible.
- Centralize XML documentation into small unobtrusive `struct` entries in `docs.cs` and use `<inheritdoc cref="_..." />` in implementation files.
- Add `README.md` in the same folder as the csproj.
- Set `<GenerateDocumentationFile>` in csproj
- Add `<PackageTags>`, `<Description>`, `<RepositoryUrl>`, `<PackageProjectUrl>` to csproj

## Tests
- Prefer `AssertCore` over `Assert` (using static in Usings.cs).
- Use parameterized assertions without `Assert.` prefix (e.g., `AreEqual` not `Assert.AreEqual`).
- Ensure tests reflect intended mathematical behavior/specification, not merely current implementation behavior.

## Legacy Tests
- Expand for full code coverage.
- Avoid changing legacy code.
- Only critical, local fixes.
- Check legacy branch first (`D:\Repositories\JJ.Framework.LEGACY`).
  Copy paste meaningful additions or sparse changes.
- Add or extend matching `*_CoreTests.cs`s in `*.Legacy.Tests.csproj`s.
- Functionally meaningful.
- Project properties:
    - Main lib TFMs: `net10.0;net9.0;net8.0;net7.0;net6.0;netstandard2.1;netstandard2.0`.
    - Test proj TFMs: `net10.0;net9.0;net8.0;net7.0;net6.0;net5.0;net461`.
