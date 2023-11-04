﻿// Copyright (c) MOSA Project. Licensed under the New BSD License.

using Mosa.Compiler.Framework;

namespace Mosa.Compiler.x86.Intrinsic;

/// <summary>
/// IntrinsicMethods
/// </summary>
internal static partial class IntrinsicMethods
{
	[IntrinsicMethod("Mosa.Compiler.x86.Intrinsic::Tzcnt32")]
	private static void Tzcnt32(Context context, Transform transform)
	{
		context.SetInstruction(X86.Tzcnt32, context.Result, context.Operand1);
	}
}