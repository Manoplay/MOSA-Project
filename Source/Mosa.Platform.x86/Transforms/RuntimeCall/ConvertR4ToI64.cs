// Copyright (c) MOSA Project. Licensed under the New BSD License.

using Mosa.Compiler.Framework;
using Mosa.Compiler.Framework.Transforms;

namespace Mosa.Platform.x86.Transforms.RuntimeCall
{
	/// <summary>
	/// ConvertR4ToI64
	/// </summary>
	public sealed class ConvertR4ToI64 : BaseTransform
	{
		public ConvertR4ToI64() : base(IRInstruction.ConvertR4ToI64, TransformType.Manual | TransformType.Transform)
		{
		}

		public override bool Match(Context context, TransformContext transform)
		{
			return true;
		}

		public override void Transform(Context context, TransformContext transform)
		{
			transform.ReplaceWithCall(context, "Mosa.Runtime.Math", "Conversion", "R4ToI8");
		}
	}
}