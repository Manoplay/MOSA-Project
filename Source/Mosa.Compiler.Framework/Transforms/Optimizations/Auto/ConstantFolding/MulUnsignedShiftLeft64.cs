// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

using Mosa.Compiler.Framework;

namespace Mosa.Compiler.Framework.Transforms.Optimizations.Auto.ConstantFolding;

/// <summary>
/// MulUnsignedShiftLeft64
/// </summary>
[Transform("IR.Optimizations.Auto.ConstantFolding")]
public sealed class MulUnsignedShiftLeft64 : BaseTransform
{
	public MulUnsignedShiftLeft64() : base(IRInstruction.MulUnsigned64, TransformType.Auto | TransformType.Optimization)
	{
	}

	public override bool Match(Context context, TransformContext transform)
	{
		if (!context.Operand1.IsVirtualRegister)
			return false;

		if (context.Operand1.Definitions.Count != 1)
			return false;

		if (context.Operand1.Definitions[0].Instruction != IRInstruction.ShiftLeft64)
			return false;

		if (IsResolvedConstant(context.Operand1.Definitions[0].Operand1))
			return false;

		if (IsResolvedConstant(context.Operand2))
			return false;

		if (!IsResolvedConstant(context.Operand1.Definitions[0].Operand2))
			return false;

		return true;
	}

	public override void Transform(Context context, TransformContext transform)
	{
		var result = context.Result;

		var t1 = context.Operand1.Definitions[0].Operand1;
		var t2 = context.Operand1.Definitions[0].Operand2;
		var t3 = context.Operand2;

		var v1 = transform.AllocateVirtualRegister(transform.I8);

		context.SetInstruction(IRInstruction.MulUnsigned64, v1, t1, t3);
		context.AppendInstruction(IRInstruction.ShiftLeft64, result, v1, t2);
	}
}

/// <summary>
/// MulUnsignedShiftLeft64_v1
/// </summary>
[Transform("IR.Optimizations.Auto.ConstantFolding")]
public sealed class MulUnsignedShiftLeft64_v1 : BaseTransform
{
	public MulUnsignedShiftLeft64_v1() : base(IRInstruction.MulUnsigned64, TransformType.Auto | TransformType.Optimization)
	{
	}

	public override bool Match(Context context, TransformContext transform)
	{
		if (!context.Operand2.IsVirtualRegister)
			return false;

		if (context.Operand2.Definitions.Count != 1)
			return false;

		if (context.Operand2.Definitions[0].Instruction != IRInstruction.ShiftLeft64)
			return false;

		if (IsResolvedConstant(context.Operand2.Definitions[0].Operand1))
			return false;

		if (IsResolvedConstant(context.Operand1))
			return false;

		if (!IsResolvedConstant(context.Operand2.Definitions[0].Operand2))
			return false;

		return true;
	}

	public override void Transform(Context context, TransformContext transform)
	{
		var result = context.Result;

		var t1 = context.Operand1;
		var t2 = context.Operand2.Definitions[0].Operand1;
		var t3 = context.Operand2.Definitions[0].Operand2;

		var v1 = transform.AllocateVirtualRegister(transform.I8);

		context.SetInstruction(IRInstruction.MulUnsigned64, v1, t2, t1);
		context.AppendInstruction(IRInstruction.ShiftLeft64, result, v1, t3);
	}
}
