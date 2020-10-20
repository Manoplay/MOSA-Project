// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

using Mosa.Compiler.Framework.IR;

namespace Mosa.Compiler.Framework.Transform.Auto.IR.Algebraic
{
	/// <summary>
	/// Unsigned32AAMinusBB
	/// </summary>
	public sealed class Unsigned32AAMinusBB : BaseTransformation
	{
		public Unsigned32AAMinusBB() : base(IRInstruction.Sub32)
		{
		}

		public override bool Match(Context context, TransformContext transformContext)
		{
			if (!context.Operand1.IsVirtualRegister)
				return false;

			if (!context.Operand2.IsVirtualRegister)
				return false;

			if (context.Operand1.Definitions.Count != 1)
				return false;

			if (context.Operand1.Definitions[0].Instruction != IRInstruction.MulUnsigned32)
				return false;

			if (context.Operand2.Definitions.Count != 1)
				return false;

			if (context.Operand2.Definitions[0].Instruction != IRInstruction.MulUnsigned32)
				return false;

			if (!AreSame(context.Operand1.Definitions[0].Operand1, context.Operand1.Definitions[0].Operand2))
				return false;

			if (!AreSame(context.Operand2.Definitions[0].Operand1, context.Operand2.Definitions[0].Operand2))
				return false;

			return true;
		}

		public override void Transform(Context context, TransformContext transformContext)
		{
			var result = context.Result;

			var t1 = context.Operand1.Definitions[0].Operand1;
			var t2 = context.Operand2.Definitions[0].Operand1;

			var v1 = transformContext.AllocateVirtualRegister(transformContext.I4);
			var v2 = transformContext.AllocateVirtualRegister(transformContext.I4);

			context.SetInstruction(IRInstruction.Add32, v1, t1, t2);
			context.AppendInstruction(IRInstruction.Sub32, v2, t1, t2);
			context.AppendInstruction(IRInstruction.MulUnsigned32, result, v2, v1);
		}
	}
}