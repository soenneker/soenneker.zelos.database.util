using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AwesomeAssertions;
using Soenneker.Tests.FixturedUnit;
using Soenneker.Zelos.Abstract;
using Soenneker.Zelos.Database.Util.Abstract;
using Xunit;

namespace Soenneker.Zelos.Database.Util.Tests;

[Collection("Collection")]
public class ZelosDatabaseUtilTests : FixturedUnitTest
{
    private readonly IZelosDatabaseUtil _util;

    public ZelosDatabaseUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _util = Resolve<IZelosDatabaseUtil>();
    }

    [Fact]
    public async ValueTask GetDatabase_should_get_database()
    {
        IZelosDatabase database = await _util.Get("test.json", CancellationToken);
        database.Should().NotBeNull();
    }

    [Fact]
    public async ValueTask GetContainer_should_get_container()
    {
        IZelosDatabase database = await _util.Get("test.json", CancellationToken);

        IZelosContainer container = await database.GetContainer("test", CancellationToken);
        container.Should().NotBeNull();
    }

    [Fact]
    public async ValueTask AddItem_should_add_item()
    {
        IZelosDatabase database = await _util.Get("test.json", CancellationToken);

        IZelosContainer container = await database.GetContainer("test", CancellationToken);

        var id = Guid.NewGuid().ToString();

        await container.AddItem(id, "test", CancellationToken);

        string? retrieved = container.GetItem(id);
        retrieved.Should().NotBeNull();
    }

    [Fact]
    public async ValueTask GetAllItems_should_not_be_null()
    {
        IZelosDatabase database = await _util.Get("test.json", CancellationToken);

        IZelosContainer container = await database.GetContainer("test", CancellationToken);

        var id = Guid.NewGuid().ToString();

        await container.AddItem(id, "test", CancellationToken);

        List<string> all = container.GetAllItems();

        all.Should().NotBeNullOrEmpty();
    }
}