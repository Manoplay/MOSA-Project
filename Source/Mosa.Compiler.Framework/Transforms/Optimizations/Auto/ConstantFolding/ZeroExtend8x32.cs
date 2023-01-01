// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

using Mosa.Compiler.Framework;

namespace Mosa.Compiler.Framework.Transforms.Optimizations.Auto.ConstantFolding
{
	/// <summary>
	/// ZeroExtend8x32
	/// </summary>
	public sealed class ZeroExtend8x32 : BaseTransform
	{
		public ZeroExtend8x32() : base(IRInstruction.ZeroExtend8x32, TransformType.Auto | TransformType.Optimization)
		{
		}

		public override bool Match(Context context, TransformContext transform)
		{
			if (!IsResolvedConstant(context.Operand1))
				return false;

			return true;
		}

		public override void Transform(Context context, TransformContext transform)
		{
			var result = context.Result;

			var t1 = context.Operand1;

			var e1 = transform.CreateConstant(To32(ToByte(t1)));

			context.SetInstruction(IRInstruction.Move32, result, e1);
		}
	}
}