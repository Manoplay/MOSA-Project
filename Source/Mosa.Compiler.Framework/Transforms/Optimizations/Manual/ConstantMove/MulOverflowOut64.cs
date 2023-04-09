// Copyright (c) MOSA Project. Licensed under the New BSD License.

namespace Mosa.Compiler.Framework.Transforms.Optimizations.Manual.ConstantMove;

/// <summary>
/// MulOverflowOut64
/// </summary>
public sealed class MulOverflowOut64 : BaseTransform
{
	public MulOverflowOut64() : base(IRInstruction.MulOverflowOut64, TransformType.Manual | TransformType.Optimization)
	{
	}

	public override bool Match(Context context, TransformContext transform)
	{
		if (!IsResolvedConstant(context.Operand1))
			return false;

		if (IsResolvedConstant(context.Operand2))
			return false;

		return true;
	}

	public override void Transform(Context context, TransformContext transform)
	{
		SwapOperands1And2(context);
	}
}