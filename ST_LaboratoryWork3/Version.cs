using Microsoft.VisualBasic.CompilerServices;
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
			if (System.Text.RegularExpressions.Regex.IsMatch(version, @"\d+\.\d+\.\d+-?[\w+\.\w+]*"))
			{
				return true;
			}
			return false;
		}

		public static bool operator > (Version version1, Version version2)
		{
			return IsMore(version1, version2);
		}
		public static bool operator < (Version version1, Version version2)
		{
			return !IsMore(version1, version2);
		}

		private static bool IsMore (Version v1, Version v2)
		{
			if (v1.Major > v2.Major)
			{
				return true;
			}
			else if (v1.Major == v2.Major)
			{
				if (v1.Minor > v2.Minor)
				{
					return true;
				}
				else if (v1.Minor == v2.Minor)
				{
					if (v1.Patch > v2.Patch)
					{
						return true;
					}
					else if (v1.Patch == v2.Patch)
					{
						if (v1.PreRelease == null && v2.PreRelease != null)
						{
							return true;
						}
						if (v1.PreRelease != null & v2.PreRelease != null && string.Compare(v1.PreRelease, v2.PreRelease) > 0)
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		public static bool operator >= (Version version1, Version version2)
		{
			return IsMoreOrEqual(version1, version2);
		}

		private static bool IsMoreOrEqual (Version v1, Version v2)
		{
			if (v1.Major > v2.Major)
			{
				return true;
			}
			else if (v1.Major == v2.Major)
			{
				if (v1.Minor > v2.Minor)
				{
					return true;
				}
				else if (v1.Minor == v2.Minor)
				{
					if (v1.Patch > v2.Patch)
					{
						return true;
					}
					else if (v1.Patch == v2.Patch)
					{
						if (v1.PreRelease == null)
						{
							return true;
						}
						if (v1.PreRelease != null & v2.PreRelease != null && string.Compare(v1.PreRelease, v2.PreRelease) == 0)
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		public static bool operator <= (Version version1, Version version2)
		{
			return IsLessOrEqual(version1, version2);
		}

		private static bool IsLessOrEqual (Version v1, Version v2)
		{
			if (v1.Major > v2.Major)
			{
				return false;
			}
			else if (v1.Major == v2.Major)
			{
				if (v1.Minor > v2.Minor)
				{
					return false;
				}
				else if (v1.Minor == v2.Minor)
				{
					if (v1.Patch > v2.Patch)
					{
						return false;
					}
					else if (v1.Patch == v2.Patch)
					{
						if (v1.PreRelease == null & v2.PreRelease != null)
						{
							return false;
						}
						if (v1.PreRelease != null & v2.PreRelease != null && string.Compare(v1.PreRelease, v2.PreRelease) < 0)
						{
							return false;
						}
					}
				}
			}
			return true;
		}

		public static bool operator == (Version version1, Version version2)
		{
			return IsEqual(version1, version2);
		}

		public static bool operator != (Version version1, Version version2)
		{
			return !IsEqual(version1, version2);
		}

		private static bool IsEqual(Version v1, Version v2)
		{
			if (v1.ToString() == v2.ToString())
			{
				return true;
			}
			return false;
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