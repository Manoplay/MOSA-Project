// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

using Mosa.Compiler.Framework;

namespace Mosa.Compiler.Framework.Transforms.Optimizations.Auto.ConstantFolding
{
	/// <summary>
	/// SubCarryIn64Outside1
	/// </summary>
	public sealed class SubCarryIn64Outside1 : BaseTransform
	{
		public SubCarryIn64Outside1() : base(IRInstruction.SubCarryIn64, TransformType.Auto | TransformType.Optimization)
		{
		}

		public override bool Match(Context context, TransformContext transform)
		{
			if (!IsResolvedConstant(context.Operand1))
				return false;

			if (!IsResolvedConstant(context.Operand3))
				return false;

			return true;
		}

		public override void Transform(Context context, TransformContext transform)
		{
			var result = context.Result;

			var t1 = context.Operand1;
			var t2 = context.Operand3;

			var e1 = transform.CreateConstant(Sub64(To64(t1), BoolTo64(To64(t2))));

			context.SetInstruction(IRInstruction.Sub64, result, e1);
		}
	}
}