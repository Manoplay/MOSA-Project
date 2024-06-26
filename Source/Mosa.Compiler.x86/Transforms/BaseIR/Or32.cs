// Copyright (c) MOSA Project. Licensed under the New BSD License.

using Mosa.Compiler.Framework;

namespace Mosa.Compiler.x86.Transforms.BaseIR;

/// <summary>
/// Or32
/// </summary>
public sealed class Or32 : BaseIRTransform
{
	public Or32() : base(IR.Or32, TransformType.Manual | TransformType.Transform)
	{
	}

	public override void Transform(Context context, Transform transform)
	{
		context.ReplaceInstruction(X86.Or32);
	}
}
