using Microsoft.Extensions.Logging;
using Soenneker.Dictionaries.Singletons;
using Soenneker.Extensions.String;
using Soenneker.Utils.MemoryStream.Abstract;
using Soenneker.Zelos.Abstract;
using Soenneker.Zelos.Database.Util.Abstract;
using System;
using System.Threading;
using System.Threading.Tasks;
using Soenneker.Utils.File.Abstract;

namespace Soenneker.Zelos.Database.Util;

///<inheritdoc cref="IZelosDatabaseUtil"/>
public sealed class ZelosDatabaseUtil : IZelosDatabaseUtil
{
    private readonly IFileUtil _fileUtil;
    private readonly IMemoryStreamUtil _memoryStreamUtil;
    private readonly ILogger<ZelosDatabaseUtil> _logger;
    private readonly SingletonDictionary<ZelosDatabase> _databases;

    public ZelosDatabaseUtil(IFileUtil fileUtil, IMemoryStreamUtil memoryStreamUtil, ILogger<ZelosDatabaseUtil> logger)
    {
        _fileUtil = fileUtil;
        _memoryStreamUtil = memoryStreamUtil;
        _logger = logger;

        _databases = new SingletonDictionary<ZelosDatabase>(CreateDatabase);
    }

    private ZelosDatabase CreateDatabase(string id)
    {
        if (id.IsNullOrEmpty())
            throw new ArgumentException("A file path is required");

        return new ZelosDatabase(id, _fileUtil, _memoryStreamUtil, _logger);
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