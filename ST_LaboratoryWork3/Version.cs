using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST_LaboratoryWork3
{
	class Version
	{
		private int Major { get; set; }
		private int Minor { get; set; }
		private int Patch { get; set; }
		private string PreRelease { get; set; }

		public Version (string version)
		{
			if (!IsCorrect(version))
			{
				throw new ArgumentException("Значение версии не может быть распознано корректно");
			}
			string[] parameters = version.Split('-');
			string[] versions = parameters[0].Split('.');
			Major = int.Parse(versions[0]);
			Minor = int.Parse(versions[1]);
			Patch = int.Parse(versions[2]);
			if (parameters.Length == 2)
			{
				PreRelease = parameters[1];
			}
		}

		private static bool IsCorrect (string version)
		{
			if (System.Text.RegularExpressions.Regex.IsMatch(version, @"\d+\.\d+\.\d+-[\w+\.\w+]*"))
			{
				return true;
			}
			return false;
		}

		public static bool operator > (Version version1, Version version2)
		{

			return true;
		}

		public static bool operator >= (Version version1, Version version2)
		{
			return true;
		}

		public static bool operator < (Version version1, Version version2)
		{
			return true;
		}

		public static bool operator <= (Version version1, Version version2)
		{
			return true;
		}

		public static bool operator == (Version version1, Version version2)
		{
			return true;
		}

		public static bool operator != (Version version1, Version version2)
		{
			return true;
		}

		public override string ToString ()
		{
			if (PreRelease != null)
			{
				return $"{Major}.{Minor}.{Patch}-{PreRelease}";
			}
			return $"{Major}.{Minor}.{Patch}";
		}
	}
}