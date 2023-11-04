﻿// Copyright (c) MOSA Project. Licensed under the New BSD License.

using Mosa.Compiler.Framework;

namespace Mosa.Compiler.x64.Intrinsic;

/// <summary>
/// IntrinsicMethods
/// </summary>
internal static partial class IntrinsicMethods
{
	[IntrinsicMethod("Mosa.Compiler.x64.Intrinsic::InterruptReturn")]
	private static void InterruptReturn(Context context, Transform transform)
	{
		var v0 = context.Operand1;

		var rsp = transform.PhysicalRegisters.Allocate64(CPURegister.RSP);

		context.SetInstruction(X64.Mov64, rsp, v0);
		context.AppendInstruction(X64.Popad);
		context.AppendInstruction(X64.Add64, rsp, rsp, Operand.Constant64_8);
		context.AppendInstruction(X64.Sti);
		context.AppendInstruction(X64.IRetd);

		// future - common code (refactor opportunity)
		context.GotoNext();

		// Remove all remaining instructions in block and clear next block list
		while (!context.IsBlockEndInstruction)
		{
			if (!context.IsEmpty)
			{
				context.Empty();
			}
			context.GotoNext();
		}

		var nextBlocks = context.Block.NextBlocks;

		foreach (var next in nextBlocks)
		{
			next.PreviousBlocks.Remove(context.Block);
		}

		nextBlocks.Clear();
	}
}