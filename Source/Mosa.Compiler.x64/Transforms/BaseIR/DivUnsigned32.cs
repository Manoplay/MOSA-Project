// Copyright (c) MOSA Project. Licensed under the New BSD License.

using Mosa.Compiler.Framework;

namespace Mosa.Compiler.x64.Transforms.BaseIR;

/// <summary>
/// DivUnsigned32
/// </summary>
public sealed class DivUnsigned32 : BaseIRTransform
{
	public DivUnsigned32() : base(IR.DivUnsigned32, TransformType.Manual | TransformType.Transform)
	{
	}

	public override void Transform(Context context, Transform transform)
	{
		var operand1 = context.Operand1;
		var operand2 = context.Operand2;
		var result = context.Result;

		var v1 = transform.VirtualRegisters.Allocate32();
		var v2 = transform.VirtualRegisters.Allocate32();

		context.SetInstruction(X64.Mov32, v1, Operand.Constant32_0);
		context.AppendInstruction2(X64.Div32, v1, v2, v1, operand1, operand2);
		context.AppendInstruction(X64.Mov32, result, v2);
	}
}
