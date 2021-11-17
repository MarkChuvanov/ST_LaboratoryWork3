using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST_LaboratoryWork3
{
	[TestFixture]
	public class VersionTest
	{
		[Test]
		public void MoreTest ()
		{
			Assert.Throws<ArgumentException>(() => 
			{ 
				bool metka = new Version("1.0,0-beta.alpha") > new Version("1.0.0-beta.1");
			});
			Assert.IsTrue(new Version("1.0.0-beta.alpha") > new Version("1.0.0-beta.1"));
			Assert.IsTrue(new Version("1.0.0") > new Version("1.0.0-alpha"));
			Assert.IsTrue(new Version("1.0.1") > new Version("1.0.0"));
			Assert.IsTrue(new Version("1.1.0") > new Version("1.0.0"));
			Assert.IsTrue(new Version("2.0.0") > new Version("1.0.0"));
		}

		[Test]
		public void MoreOrEqualTest ()
		{
			Assert.IsTrue(new Version("1.1.0") >= new Version("1.0.0"));
			Assert.IsTrue(new Version("1.0.0") >= new Version("1.0.0"));
			Assert.IsTrue(new Version("1.0.0") >= new Version("1.0.0-alpha"));
		}

		[Test]
		public void LessOrEqualTest ()
		{
			Assert.IsTrue(new Version("1.0.0") <= new Version("1.1.0"));
			Assert.IsTrue(new Version("1.1.0") <= new Version("1.1.0"));
			Assert.IsTrue(new Version("1.1.0-alpha") <= new Version("1.1.0"));
			Assert.IsTrue(new Version("1.1.0-alpha") <= new Version("1.1.0-alpha"));
		}

		[Test]
		public void EqualTest ()
		{
			Assert.IsTrue(new Version("1.0.0") == new Version("1.0.0"));
			Assert.IsTrue(new Version("1.0.0") == new Version("1.0.0"));
			Assert.IsTrue(new Version("1.1.1-alpha") == new Version("1.1.1-alpha"));
		}
	}
}