// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

namespace Mosa.Compiler.Framework.Instructions;

/// <summary>
/// LoadParamZeroExtend16x64
/// </summary>
public sealed class LoadParamZeroExtend16x64 : BaseIRInstruction
{
	public LoadParamZeroExtend16x64()
		: base(1, 1)
	{
	}

	public override bool IsMemoryRead => true;

	public override bool IsParameterLoad => true;
}
