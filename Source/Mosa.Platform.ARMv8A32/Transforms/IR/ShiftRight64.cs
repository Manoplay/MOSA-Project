// Copyright (c) MOSA Project. Licensed under the New BSD License.

using Mosa.Compiler.Framework;
using Mosa.Compiler.Framework.Transforms;

namespace Mosa.Platform.ARMv8A32.Transforms.IR
{
	/// <summary>
	/// ShiftRight64
	/// </summary>
	public sealed class ShiftRight64 : BaseTransform
	{
		public ShiftRight64() : base(IRInstruction.ShiftRight64, TransformType.Manual | TransformType.Transform)
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

			//shiftright64(long long, int):
			//		r0 (op1l), r1 (op1h), r2 (operand2)

			//rsb	v1, operand2, #32
			//subs	v2, operand2, #32
			//lsr	v3, op1l, operand2

			//orr	v4, v3, op1h, lsl v1
			//orrpl	resultLow, v4, op1h, asr v2

			//asr	resultHigh, op1h, operand2

			var v1 = transform.AllocateVirtualRegister32();
			var v2 = transform.AllocateVirtualRegister32();
			var v3 = transform.AllocateVirtualRegister32();
			var v4 = transform.AllocateVirtualRegister32();

			op1L = ARMv8A32TransformHelper.MoveConstantToRegister(transform, context, op1L);
			op1H = ARMv8A32TransformHelper.MoveConstantToRegister(transform, context, op1H);
			op2L = ARMv8A32TransformHelper.MoveConstantToRegister(transform, context, op2L);

			context.SetInstruction(ARMv8A32.Rsb, v1, op2L, transform.Constant32_32);
			context.AppendInstruction(ARMv8A32.Sub, StatusRegister.Set, v2, op2L, transform.Constant32_32);
			context.AppendInstruction(ARMv8A32.Lsr, v3, op1L, op2L);
			context.AppendInstruction(ARMv8A32.OrrRegShift, v4, v3, op1H, v1, transform.Constant32_0 /* LSL */);
			context.AppendInstruction(ARMv8A32.OrrRegShift, ConditionCode.Zero, resultLow, v4, op1H, v2, transform.Constant32_2 /* ASR */);
			context.AppendInstruction(ARMv8A32.Asr, resultHigh, op1H, op2L);
		}
	}
}