using System;
using System.Threading;
using System.Threading.Tasks;
using Soenneker.Zelos.Abstract;

namespace Soenneker.Zelos.Database.Util.Abstract;

/// <summary>
/// A DI utility that simplifies Zelos database access
/// </summary>
public interface IZelosDatabaseUtil : IAsyncDisposable, IDisposable
{
    ValueTask<IZelosDatabase> Get(string filePath, CancellationToken cancellationToken = default);
}