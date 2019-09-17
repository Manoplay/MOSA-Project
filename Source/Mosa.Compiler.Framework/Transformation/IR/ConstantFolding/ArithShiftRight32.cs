﻿// Copyright (c) MOSA Project. Licensed under the New BSD License.

using Mosa.Compiler.Framework.IR;

namespace Mosa.Compiler.Framework.Transformation.IR.ConstantFolding
{
	public sealed class ArithShiftRight32 : BaseTransformation
	{
		public ArithShiftRight32() : base(IRInstruction.ArithShiftRight32, OperandFilter.ResolvedConstant, OperandFilter.ResolvedConstant)
		{
		}

		public override void Transform(Context context, TransformContext transformContext)
		{
			transformContext.SetResultToConstant(context, ((ulong)(((long)context.Operand1.ConstantUnsigned64) >> (int)context.Operand2.ConstantUnsigned64)) & 0xFFFFFFFF);
		}
	}
}