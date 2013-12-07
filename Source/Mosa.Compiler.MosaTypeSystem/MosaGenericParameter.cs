﻿using System.Collections.Generic;

namespace Mosa.Compiler.MosaTypeSystem
{
	public class MosaGenericParameter
	{
		public string Name { get; internal set; }

		public int Index { get; internal set; }

		public bool IsCovariant { get; internal set; }

		public bool IsContravariant { get; internal set; }

		public bool IsNonVariant { get; internal set; }

		public List<MosaType> Constraints { get; internal set; }

		public MosaGenericParameter()
		{
			Constraints = new List<MosaType>();
		}

		public override string ToString()
		{
			return Name;
		}
	}
}