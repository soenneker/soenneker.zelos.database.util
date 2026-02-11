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
    /// <summary>
    /// Asynchronously retrieves a database instance for the specified file path.
    /// </summary>
    /// <param name="filePath">The path to the database file to open or create. Cannot be null or empty.</param>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the asynchronous operation.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="IZelosDatabase"/>
    /// instance associated with the specified file path.</returns>
    ValueTask<IZelosDatabase> Get(string filePath, CancellationToken cancellationToken = default);
}