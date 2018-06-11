using System;
using System.Data.Entity.SqlServer;
using JetBrains.Annotations;

namespace JJ.Framework.Data.EntityFramework
{
    internal static class AssemblyReferenceEnsurer
    {
        [UsedImplicitly] private static readonly Type[] _ensuredReferences = { typeof(SqlProviderServices) };
    }
}