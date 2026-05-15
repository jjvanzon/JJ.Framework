/// <summary>
/// Substitute for <c>System.Threading.Lock</c> (introduced in .NET 9).
/// Lightweight lock with a <c>using</c>-scoped entry via <c>EnterScope()</c>.
/// </summary>
public struct _lock;

