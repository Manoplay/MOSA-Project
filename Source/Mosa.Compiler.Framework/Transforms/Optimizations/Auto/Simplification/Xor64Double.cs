// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

using Mosa.Compiler.Framework;

namespace Mosa.Compiler.Framework.Transforms.Optimizations.Auto.Simplification;

/// <summary>
/// Xor64Double
/// </summary>
[Transform("IR.Optimizations.Auto.Simplification")]
public sealed class Xor64Double : BaseTransform
{
	public Xor64Double() : base(IRInstruction.Xor64, TransformType.Auto | TransformType.Optimization)
	{
	}

	public override bool Match(Context context, TransformContext transform)
	{
		if (!context.Operand1.IsVirtualRegister)
			return false;

		if (context.Operand1.Definitions.Count != 1)
			return false;

		if (context.Operand1.Definitions[0].Instruction != IRInstruction.Or64)
			return false;

		if (!AreSame(context.Operand1.Definitions[0].Operand1, context.Operand2))
			return false;

		return true;
	}

	public override void Transform(Context context, TransformContext transform)
	{
		var result = context.Result;

		var t1 = context.Operand1.Definitions[0].Operand2;

		context.SetInstruction(IRInstruction.Move64, result, t1);
	}
}

/// <summary>
/// Xor64Double_v1
/// </summary>
[Transform("IR.Optimizations.Auto.Simplification")]
public sealed class Xor64Double_v1 : BaseTransform
{
	public Xor64Double_v1() : base(IRInstruction.Xor64, TransformType.Auto | TransformType.Optimization)
	{
	}

	public override bool Match(Context context, TransformContext transform)
	{
		if (!context.Operand2.IsVirtualRegister)
			return false;

		if (context.Operand2.Definitions.Count != 1)
			return false;

		if (context.Operand2.Definitions[0].Instruction != IRInstruction.Or64)
			return false;

		if (!AreSame(context.Operand1, context.Operand2.Definitions[0].Operand1))
			return false;

		return true;
	}

	public override void Transform(Context context, TransformContext transform)
	{
		var result = context.Result;

		var t1 = context.Operand2.Definitions[0].Operand2;

		context.SetInstruction(IRInstruction.Move64, result, t1);
	}
}

/// <summary>
/// Xor64Double_v2
/// </summary>
[Transform("IR.Optimizations.Auto.Simplification")]
public sealed class Xor64Double_v2 : BaseTransform
{
	public Xor64Double_v2() : base(IRInstruction.Xor64, TransformType.Auto | TransformType.Optimization)
	{
	}

	public override bool Match(Context context, TransformContext transform)
	{
		if (!context.Operand1.IsVirtualRegister)
			return false;

		if (context.Operand1.Definitions.Count != 1)
			return false;

		if (context.Operand1.Definitions[0].Instruction != IRInstruction.Or64)
			return false;

		if (!AreSame(context.Operand1.Definitions[0].Operand2, context.Operand2))
			return false;

		return true;
	}

	public override void Transform(Context context, TransformContext transform)
	{
		var result = context.Result;

		var t1 = context.Operand1.Definitions[0].Operand1;

		context.SetInstruction(IRInstruction.Move64, result, t1);
	}
}

/// <summary>
/// Xor64Double_v3
/// </summary>
[Transform("IR.Optimizations.Auto.Simplification")]
public sealed class Xor64Double_v3 : BaseTransform
{
	public Xor64Double_v3() : base(IRInstruction.Xor64, TransformType.Auto | TransformType.Optimization)
	{
	}

	public override bool Match(Context context, TransformContext transform)
	{
		if (!context.Operand2.IsVirtualRegister)
			return false;

		if (context.Operand2.Definitions.Count != 1)
			return false;

		if (context.Operand2.Definitions[0].Instruction != IRInstruction.Or64)
			return false;

		if (!AreSame(context.Operand1, context.Operand2.Definitions[0].Operand2))
			return false;

		return true;
	}

	public override void Transform(Context context, TransformContext transform)
	{
		var result = context.Result;

		var t1 = context.Operand2.Definitions[0].Operand1;

		context.SetInstruction(IRInstruction.Move64, result, t1);
	}
}
