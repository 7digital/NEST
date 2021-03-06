﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using Nest;
using Newtonsoft.Json.Converters;
using Nest.Resolvers.Converters;
using Nest.Tests.MockData.Domain;

namespace Nest.Tests.Unit
{
	[TestFixture]
	public class UpdateTests
	{
		[Test]
		public void TestUpdate()
		{
      var s = new UpdateDescriptor<ElasticSearchProject>()
        .Script("ctx._source.counter += count")
        .Params(p => p
            .Add("count", 4)
        );
			var json = TestElasticClient.Serialize(s);
			var expected = @"  {
	      script: ""ctx._source.counter += count"",
	      params: {
	        count: 4
	      }
	    }";
			Assert.True(json.JsonEquals(expected), json);
		}
	}
}
