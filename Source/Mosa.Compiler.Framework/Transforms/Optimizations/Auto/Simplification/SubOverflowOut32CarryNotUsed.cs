// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

namespace Mosa.Compiler.Framework.Transforms.Optimizations.Auto.Simplification;

public sealed class SubOverflowOut32CarryNotUsed : BaseTransform
{
	public SubOverflowOut32CarryNotUsed() : base(IR.SubOverflowOut32, TransformType.Auto | TransformType.Optimization)
	{
	}

	public override bool Match(Context context, Transform transform)
	{
		if (IsResult2Used(context))
			return false;

		return true;
	}

	public override void Transform(Context context, Transform transform)
	{
		var result = context.Result;

		var t1 = context.Operand1;
		var t2 = context.Operand2;

		context.SetInstruction(IR.Sub32, result, t1, t2);
	}
}