// Copyright (c) MOSA Project. Licensed under the New BSD License.

using Mosa.Compiler.Framework;
using Mosa.Compiler.Framework.Transforms;

namespace Mosa.Platform.ARMv8A32.Transforms.IR
{
	/// <summary>
	/// IfThenElse64
	/// </summary>
	public sealed class IfThenElse64 : BaseTransform
	{
		public IfThenElse64() : base(IRInstruction.IfThenElse64, TransformType.Manual | TransformType.Transform)
		{
		}

		public override bool Match(Context context, TransformContext transform)
		{
			return true;
		}

		public override void Transform(Context context, TransformContext transform)
		{
			transform.SplitLongOperand(context.Result, out var resultLow, out var resultHigh);
			transform.SplitLongOperand(context.Operand1, out var op1L, out var op1H);
			transform.SplitLongOperand(context.Operand2, out var op2L, out var op2H);
			transform.SplitLongOperand(context.Operand3, out var op3L, out var op3H);

			var v1 = transform.AllocateVirtualRegister32();

			op1L = ARMv8A32TransformHelper.MoveConstantToRegister(transform, context, op1L);
			op1H = ARMv8A32TransformHelper.MoveConstantToRegisterOrImmediate(transform, context, op1H);
			op2L = ARMv8A32TransformHelper.MoveConstantToRegisterOrImmediate(transform, context, op2L);
			op2H = ARMv8A32TransformHelper.MoveConstantToRegisterOrImmediate(transform, context, op2H);
			op3L = ARMv8A32TransformHelper.MoveConstantToRegisterOrImmediate(transform, context, op3L);
			op3H = ARMv8A32TransformHelper.MoveConstantToRegisterOrImmediate(transform, context, op3H);

			context.SetInstruction(ARMv8A32.Orr, v1, op1L, op1H);
			context.AppendInstruction(ARMv8A32.Cmp, StatusRegister.Set, null, v1, transform.Constant32_0);
			context.AppendInstruction(ARMv8A32.Mov, ConditionCode.NotEqual, resultLow, resultLow, op2L);
			context.AppendInstruction(ARMv8A32.Mov, ConditionCode.NotEqual, resultHigh, resultHigh, op2H);
			context.AppendInstruction(ARMv8A32.Mov, ConditionCode.Equal, resultLow, resultLow, op3L);
			context.AppendInstruction(ARMv8A32.Mov, ConditionCode.Equal, resultHigh, resultHigh, op3H);
		}
	}
}