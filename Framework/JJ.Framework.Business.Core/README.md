JJ.Framework.Business.Core
==========================

Result Types
------------

An elegant way to return data, status and messages from your operations:

- `IResult`  
    - Common interface for result types.
- `ResultBase`
    - Base class with core properties: `Successful` and `Messages`.
- `VoidResult`
    - Use when there's no return value, just success / failure info.
- `Result<T>`  
    - Returns data along with the status metadata.
