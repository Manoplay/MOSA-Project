// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

namespace Mosa.Compiler.Framework.Instructions;

/// <summary>
/// SetReturnR8
/// </summary>
public sealed class SetReturnR8 : BaseIRInstruction
{
	public SetReturnR8()
		: base(1, 0)
	{
	}

	public override bool IsFlowNext => false;

	public override bool IsReturn => true;
}
