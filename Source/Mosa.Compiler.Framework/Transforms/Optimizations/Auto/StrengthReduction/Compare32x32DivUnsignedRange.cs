// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

using Mosa.Compiler.Framework;

namespace Mosa.Compiler.Framework.Transforms.Optimizations.Auto.StrengthReduction;

/// <summary>
/// Compare32x32DivUnsignedRange
/// </summary>
[Transform("IR.Optimizations.Auto.StrengthReduction")]
public sealed class Compare32x32DivUnsignedRange : BaseTransform
{
	public Compare32x32DivUnsignedRange() : base(IRInstruction.Compare32x32, TransformType.Auto | TransformType.Optimization)
	{
	}

	public override bool Match(Context context, TransformContext transform)
	{
		if (context.ConditionCode != ConditionCode.Equal)
			return false;

		if (!context.Operand1.IsVirtualRegister)
			return false;

		if (context.Operand1.Definitions.Count != 1)
			return false;

		if (context.Operand1.Definitions[0].Instruction != IRInstruction.DivUnsigned32)
			return false;

		if (!IsResolvedConstant(context.Operand2))
			return false;

		if (!IsResolvedConstant(context.Operand1.Definitions[0].Operand2))
			return false;

		if (IsZero(context.Operand1.Definitions[0].Operand2))
			return false;

		return true;
	}

	public override void Transform(Context context, TransformContext transform)
	{
		var result = context.Result;

		var t1 = context.Operand1.Definitions[0].Operand1;
		var t2 = context.Operand1.Definitions[0].Operand2;
		var t3 = context.Operand2;

		var v1 = transform.AllocateVirtualRegister(transform.I4);

		var e1 = transform.CreateConstant(MulUnsigned32(To32(t2), To32(t3)));

		context.SetInstruction(IRInstruction.Sub32, v1, t1, e1);
		context.AppendInstruction(IRInstruction.Compare32x32, ConditionCode.UnsignedLess, result, v1, t2);
	}
}

/// <summary>
/// Compare32x32DivUnsignedRange_v1
/// </summary>
[Transform("IR.Optimizations.Auto.StrengthReduction")]
public sealed class Compare32x32DivUnsignedRange_v1 : BaseTransform
{
	public Compare32x32DivUnsignedRange_v1() : base(IRInstruction.Compare32x32, TransformType.Auto | TransformType.Optimization)
	{
	}

	public override bool Match(Context context, TransformContext transform)
	{
		if (context.ConditionCode != ConditionCode.Equal)
			return false;

		if (!context.Operand2.IsVirtualRegister)
			return false;

		if (context.Operand2.Definitions.Count != 1)
			return false;

		if (context.Operand2.Definitions[0].Instruction != IRInstruction.DivUnsigned32)
			return false;

		if (!IsResolvedConstant(context.Operand1))
			return false;

		if (!IsResolvedConstant(context.Operand2.Definitions[0].Operand2))
			return false;

		if (IsZero(context.Operand2.Definitions[0].Operand2))
			return false;

		return true;
	}

	public override void Transform(Context context, TransformContext transform)
	{
		var result = context.Result;

		var t1 = context.Operand1;
		var t2 = context.Operand2.Definitions[0].Operand1;
		var t3 = context.Operand2.Definitions[0].Operand2;

		var v1 = transform.AllocateVirtualRegister(transform.I4);

		var e1 = transform.CreateConstant(MulUnsigned32(To32(t3), To32(t1)));

		context.SetInstruction(IRInstruction.Sub32, v1, t2, e1);
		context.AppendInstruction(IRInstruction.Compare32x32, ConditionCode.UnsignedLess, result, v1, t3);
	}
}
