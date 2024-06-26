// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

using Mosa.Compiler.Framework;

namespace Mosa.Compiler.x86.Instructions;

/// <summary>
/// Not32
/// </summary>
public sealed class Not32 : X86Instruction
{
	internal Not32()
		: base(1, 1)
	{
	}

	public override void Emit(Node node, OpcodeEncoder opcodeEncoder)
	{
		System.Diagnostics.Debug.Assert(node.ResultCount == 1);
		System.Diagnostics.Debug.Assert(node.OperandCount == 1);
		System.Diagnostics.Debug.Assert(node.Result.IsPhysicalRegister);
		System.Diagnostics.Debug.Assert(node.Operand1.IsPhysicalRegister);
		System.Diagnostics.Debug.Assert(node.Result.Register == node.Operand1.Register);
		System.Diagnostics.Debug.Assert(opcodeEncoder.CheckOpcodeAlignment());

		opcodeEncoder.Append8Bits(0xF7);
		opcodeEncoder.Append2Bits(0b11);
		opcodeEncoder.Append3Bits(0b010);
		opcodeEncoder.Append3Bits(node.Result.Register.RegisterCode);

		System.Diagnostics.Debug.Assert(opcodeEncoder.CheckOpcodeAlignment());
	}
}
