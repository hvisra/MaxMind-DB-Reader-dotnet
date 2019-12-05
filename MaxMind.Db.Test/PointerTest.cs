﻿#region

using FluentAssertions;
using MaxMind.Db.Test.Helper;
using System.Collections.Generic;
using System.IO;
using Xunit;

#endregion

namespace MaxMind.Db.Test
{
    public class PointerTest
    {
        [Fact]
        public void TestWithPointers()
        {
            var path = Path.Combine(TestUtils.TestDirectory, "TestData", "MaxMind-DB", "test-data", "maps-with-pointers.raw");

            using (var database = new ArrayBuffer(path))
            {
                var decoder = new Decoder(database, 0);

                var node = decoder.Decode<Dictionary<string, object>>(0, out _);
                node["long_key"].Should().Be("long_value1");

                node = decoder.Decode<Dictionary<string, object>>(22, out _);
                node["long_key"].Should().Be("long_value2");

                node = decoder.Decode<Dictionary<string, object>>(37, out _);
                node["long_key2"].Should().Be("long_value1");

                node = decoder.Decode<Dictionary<string, object>>(50, out _);
                node["long_key2"].Should().Be("long_value2");

                node = decoder.Decode<Dictionary<string, object>>(55, out _);
                node["long_key"].Should().Be("long_value1");

                node = decoder.Decode<Dictionary<string, object>>(57, out _);
                node["long_key2"].Should().Be("long_value2");
            }
        }
    }
}
