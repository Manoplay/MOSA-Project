// Copyright (c) MOSA Project. Licensed under the New BSD License.

using Mosa.Compiler.Framework;

namespace Mosa.Compiler.x64.Transforms.IR;

/// <summary>
/// RemSigned32
/// </summary>
[Transform("x64.IR")]
public sealed class RemSigned32 : BaseIRTransform
{
	public RemSigned32() : base(IRInstruction.RemSigned32, TransformType.Manual | TransformType.Transform)
	{
	}

	public override void Transform(Context context, Transform transform)
	{
		var result = context.Result;
		var operand1 = context.Operand1;
		var operand2 = context.Operand2;

		var v1 = transform.VirtualRegisters.Allocate32();
		var v2 = transform.VirtualRegisters.Allocate32();

		context.SetInstruction(X64.Cdq32, v1, operand1);
		context.AppendInstruction2(X64.IDiv32, result, v2, v1, operand1, operand2);
	}
}