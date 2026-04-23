using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AwesomeAssertions;
using Soenneker.Tests.HostedUnit;
using Soenneker.Zelos.Abstract;
using Soenneker.Zelos.Database.Util.Abstract;

namespace Soenneker.Zelos.Database.Util.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class ZelosDatabaseUtilTests : HostedUnitTest
{
    private readonly IZelosDatabaseUtil _util;

    public ZelosDatabaseUtilTests(Host host) : base(host)
    {
        _util = Resolve<IZelosDatabaseUtil>();
    }

    [Test]
    public async ValueTask GetDatabase_should_get_database()
    {
        IZelosDatabase database = await _util.Get("test.json", System.Threading.CancellationToken.None);
        database.Should().NotBeNull();
    }

    [Test]
    public async ValueTask GetContainer_should_get_container()
    {
        IZelosDatabase database = await _util.Get("test.json", System.Threading.CancellationToken.None);

        IZelosContainer container = await database.GetContainer("test", System.Threading.CancellationToken.None);
        container.Should().NotBeNull();
    }

    [Test]
    public async ValueTask AddItem_should_add_item()
    {
        IZelosDatabase database = await _util.Get("test.json", System.Threading.CancellationToken.None);

        IZelosContainer container = await database.GetContainer("test", System.Threading.CancellationToken.None);

        var id = Guid.NewGuid().ToString();

        await container.AddItem(id, "test", System.Threading.CancellationToken.None);

        string? retrieved = container.GetItem(id);
        retrieved.Should().NotBeNull();
    }

    [Test]
    public async ValueTask GetAllItems_should_not_be_null()
    {
        IZelosDatabase database = await _util.Get("test.json", System.Threading.CancellationToken.None);

        IZelosContainer container = await database.GetContainer("test", System.Threading.CancellationToken.None);

        var id = Guid.NewGuid().ToString();

        await container.AddItem(id, "test", System.Threading.CancellationToken.None);

        List<string> all = container.GetAllItems();

        all.Should().NotBeNullOrEmpty();
    }
}
