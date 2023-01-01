﻿// Copyright (c) MOSA Project. Licensed under the New BSD License.

namespace Mosa.Compiler.Framework.Transforms.Optimizations.Manual.LowerTo32
{
	public sealed class Compare64x64EqualOrNotEqual : BaseTransform
	{
		public Compare64x64EqualOrNotEqual() : base(IRInstruction.Compare64x64, TransformType.Manual | TransformType.Optimization, true)
		{
		}

		public override bool Match(Context context, TransformContext transform)
		{
			if (context.ConditionCode != ConditionCode.Equal && context.ConditionCode != ConditionCode.NotEqual)
				return false;

			return transform.LowerTo32;
		}

		public override void Transform(Context context, TransformContext transform)
		{
			var result = context.Result;
			var operand1 = context.Operand1;
			var operand2 = context.Operand2;
			var condition = context.ConditionCode;

			var op0Low = transform.AllocateVirtualRegister32();
			var op0High = transform.AllocateVirtualRegister32();
			var op1Low = transform.AllocateVirtualRegister32();
			var op1High = transform.AllocateVirtualRegister32();

			var v1 = transform.AllocateVirtualRegister32();
			var v2 = transform.AllocateVirtualRegister32();
			var v3 = transform.AllocateVirtualRegister32();

			transform.SplitLongOperand(result, out Operand resultLow, out Operand resultHigh);

			context.SetInstruction(IRInstruction.GetLow32, op0Low, operand1);
			context.AppendInstruction(IRInstruction.GetHigh32, op0High, operand1);
			context.AppendInstruction(IRInstruction.GetLow32, op1Low, operand2);
			context.AppendInstruction(IRInstruction.GetHigh32, op1High, operand2);

			context.AppendInstruction(IRInstruction.Xor32, v1, op0Low, op1Low);
			context.AppendInstruction(IRInstruction.Xor32, v2, op0High, op1High);
			context.AppendInstruction(IRInstruction.Or32, v3, v1, v2);
			context.AppendInstruction(IRInstruction.Compare32x32, condition, resultLow, v3, transform.Constant32_0);
			context.AppendInstruction(IRInstruction.Move32, condition, resultHigh, transform.Constant64_0);
		}
	}
}