﻿// Copyright (c) MOSA Project. Licensed under the New BSD License.

namespace Mosa.Compiler.Framework.Transforms.Optimizations.Manual.Memory
{
	public sealed class LoadStoreR8 : BaseTransform
	{
		public LoadStoreR8() : base(IRInstruction.LoadR8, TransformType.Manual | TransformType.Optimization)
		{
		}

		public override bool Match(Context context, TransformContext transform)
		{
			if (!context.Operand1.IsVirtualRegister)
				return false;

			if (!context.Operand2.IsResolvedConstant)
				return false;

			var previous = GetPreviousNodeUntil(context, IRInstruction.StoreR8, transform.Window, out bool immediate, context.Operand1);

			if (previous == null)
				return false;

			if (!immediate && !IsSSAForm(previous.Operand3))
				return false;

			if (!previous.Operand2.IsResolvedConstant)
				return false;

			if (previous.Operand1 != context.Operand1)
				return false;

			if (previous.Operand2.ConstantUnsigned64 != context.Operand2.ConstantUnsigned64)
				return false;

			return true;
		}

		public override void Transform(Context context, TransformContext transform)
		{
			var previous = GetPreviousNodeUntil(context, IRInstruction.StoreR8, transform.Window, context.Operand1);

			context.SetInstruction(IRInstruction.Move32, context.Result, previous.Operand3);
		}
	}
}