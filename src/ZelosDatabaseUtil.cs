using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Soenneker.Utils.MemoryStream.Abstract;
using Soenneker.Utils.SingletonDictionary;
using Soenneker.Zelos.Abstract;
using Soenneker.Zelos.Database.Util.Abstract;
using Soenneker.Extensions.String;

namespace Soenneker.Zelos.Database.Util;

///<inheritdoc cref="IZelosDatabaseUtil"/>
public sealed class ZelosDatabaseUtil : IZelosDatabaseUtil
{
    private readonly ILogger<ZelosDatabaseUtil> _logger;
    private readonly SingletonDictionary<ZelosDatabase> _databases;

    public ZelosDatabaseUtil(IMemoryStreamUtil memoryStreamUtil, ILogger<ZelosDatabaseUtil> logger)
    {
        _logger = logger;

        _databases = new SingletonDictionary<ZelosDatabase>((id, _) =>
        {
            // Ensure the correct number of arguments
            if (id.IsNullOrEmpty())
                throw new ArgumentException("A file path is required");

            // Create and return a new ZelosDatabase instance
            return new ZelosDatabase(id, memoryStreamUtil, logger);
        });
    }

    public async ValueTask<IZelosDatabase> Get(string filePath, CancellationToken cancellationToken = default)
    {
        return await _databases.Get(filePath, cancellationToken);
    }

    /// <summary>
    /// Disposes of the resources used by the ZelosDatabaseUtil.
    /// </summary>
    public void Dispose()
    {
        _logger.LogDebug("Disposing of ZelosDatabaseUtil...");

        _databases.Dispose();
    }

    /// <summary>
    /// Asynchronously disposes of the resources used by the ZelosDatabaseUtil.
    /// </summary>
    /// <returns>A ValueTask representing the asynchronous dispose operation.</returns>
    public ValueTask DisposeAsync()
    {
        _logger.LogDebug("Disposing of ZelosDatabaseUtil...");

        return _databases.DisposeAsync();
    }
}