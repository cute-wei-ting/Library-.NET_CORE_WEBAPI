﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library_Core_Webapi.Test
{
	class Temp : IConfiguration
	{
		public string this[string key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public IEnumerable<IConfigurationSection> GetChildren()
		{
			throw new NotImplementedException();
		}

		public IChangeToken GetReloadToken()
		{
			throw new NotImplementedException();
		}

		public IConfigurationSection GetSection(string key)
		{
			throw new NotImplementedException();
		}
	}
}
