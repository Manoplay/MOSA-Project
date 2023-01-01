// Copyright (c) MOSA Project. Licensed under the New BSD License.

using Mosa.Compiler.Framework;
using Mosa.Compiler.Framework.Transforms;

namespace Mosa.Platform.x86.Transforms.IR
{
	/// <summary>
	/// SignExtend32x64
	/// </summary>
	public sealed class SignExtend32x64 : BaseTransform
	{
		public SignExtend32x64() : base(IRInstruction.SignExtend32x64, TransformType.Manual | TransformType.Transform)
		{
		}

		public override bool Match(Context context, TransformContext transform)
		{
			return true;
		}

		public override void Transform(Context context, TransformContext transform)
		{
			transform.SplitLongOperand(context.Result, out var resultLow, out var resultHigh);

			var v1 = transform.AllocateVirtualRegister32();

			context.SetInstruction(X86.Mov32, v1, context.Operand1);
			context.AppendInstruction2(X86.Cdq32, resultHigh, resultLow, v1);
		}
	}
}