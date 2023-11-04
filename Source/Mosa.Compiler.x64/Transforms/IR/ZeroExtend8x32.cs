// Copyright (c) MOSA Project. Licensed under the New BSD License.

using Mosa.Compiler.Framework;

namespace Mosa.Compiler.x64.Transforms.IR;

/// <summary>
/// ZeroExtend8x32
/// </summary>
[Transform("x64.IR")]
public sealed class ZeroExtend8x32 : BaseIRTransform
{
	public ZeroExtend8x32() : base(IRInstruction.ZeroExtend8x32, TransformType.Manual | TransformType.Transform)
	{
	}

	public override void Transform(Context context, Transform transform)
	{
		context.ReplaceInstruction(X64.Movzx8To32);
	}
}