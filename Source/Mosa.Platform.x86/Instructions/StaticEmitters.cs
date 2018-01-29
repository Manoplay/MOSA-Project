﻿// Copyright (c) MOSA Project. Licensed under the New BSD License.

using Mosa.Compiler.Common;
using Mosa.Compiler.Framework;
using System.Diagnostics;

namespace Mosa.Platform.x86.Instructions
{
	public static partial class StaticEmitters
	{
		internal static void EmitAdc32(InstructionNode node, BaseCodeEmitter emitter)
		{
			Debug.Assert(node.Result == node.Operand1);
			Debug.Assert(node.Result.IsCPURegister);
			Debug.Assert(node.Operand2.IsCPURegister);

			(emitter as X86CodeEmitter).Emit(Adc32.LegacyOpcode, node.Result, node.Operand2);
		}

		internal static void EmitAdcConst32(InstructionNode node, BaseCodeEmitter emitter)
		{
			Debug.Assert(node.Result == node.Operand1);
			Debug.Assert(node.Result.IsCPURegister);
			Debug.Assert(node.Operand2.IsConstant);

			(emitter as X86CodeEmitter).Emit(AdcConst32.LegacyOpcode, node.Result, node.Operand2);
		}

		internal static void EmitAdd32(InstructionNode node, BaseCodeEmitter emitter)
		{
			Debug.Assert(node.Result == node.Operand1);
			Debug.Assert(node.Result.IsCPURegister);
			Debug.Assert(node.Operand2.IsCPURegister);

			(emitter as X86CodeEmitter).Emit(Add32.LegacyOpcode, node.Result, node.Operand2);
		}

		internal static void EmitAddConst32(InstructionNode node, BaseCodeEmitter emitter)
		{
			Debug.Assert(node.Result == node.Operand1);
			Debug.Assert(node.Result.IsCPURegister);
			Debug.Assert(node.Operand2.IsConstant);

			(emitter as X86CodeEmitter).Emit(AddConst32.LegacyOpcode, node.Result, node.Operand2);
		}

		internal static void EmitAddSS(InstructionNode node, BaseCodeEmitter emitter)
		{
			Debug.Assert(node.Result == node.Operand1);

			(emitter as X86CodeEmitter).Emit(AddSS.LegacyOpcode, node.Result, node.Operand2);
		}

		internal static void EmitAddSD(InstructionNode node, BaseCodeEmitter emitter)
		{
			Debug.Assert(node.Result == node.Operand1);

			(emitter as X86CodeEmitter).Emit(AddSD.LegacyOpcode, node.Result, node.Operand2);
		}

		internal static void EmitAnd32(InstructionNode node, BaseCodeEmitter emitter)
		{
			Debug.Assert(node.Result == node.Operand1);
			Debug.Assert(node.Result.IsCPURegister);
			Debug.Assert(node.Operand2.IsCPURegister);

			(emitter as X86CodeEmitter).Emit(And32.LegacyOpcode, node.Result, node.Operand2);
		}

		internal static void EmitAndConst32(InstructionNode node, BaseCodeEmitter emitter)
		{
			Debug.Assert(node.Result == node.Operand1);
			Debug.Assert(node.Result.IsCPURegister);
			Debug.Assert(node.Operand2.IsConstant);

			(emitter as X86CodeEmitter).Emit(AndConst32.LegacyOpcode, node.Result, node.Operand2);
		}

		internal static void EmitBtr32(InstructionNode node, BaseCodeEmitter emitter)
		{
			Debug.Assert(node.Result == node.Operand1);
			Debug.Assert(node.Result.IsCPURegister);
			Debug.Assert(node.Operand2.IsCPURegister);

			(emitter as X86CodeEmitter).Emit(Btr32.LegacyOpcode, node.Result, node.Operand2);
		}

		internal static void EmitBtrConst32(InstructionNode node, BaseCodeEmitter emitter)
		{
			Debug.Assert(node.Result == node.Operand1);
			Debug.Assert(node.Result.IsCPURegister);
			Debug.Assert(node.Operand2.IsConstant);

			(emitter as X86CodeEmitter).Emit(BtrConst32.LegacyOpcode, node.Result, node.Operand2);
		}

		internal static void EmitBts32(InstructionNode node, BaseCodeEmitter emitter)
		{
			Debug.Assert(node.Result == node.Operand1);
			Debug.Assert(node.Result.IsCPURegister);
			Debug.Assert(node.Operand2.IsCPURegister);

			(emitter as X86CodeEmitter).Emit(Bts32.LegacyOpcode, node.Result, node.Operand2);
		}

		internal static void EmitBtsConst32(InstructionNode node, BaseCodeEmitter emitter)
		{
			Debug.Assert(node.Result == node.Operand1);
			Debug.Assert(node.Result.IsCPURegister);
			Debug.Assert(node.Operand2.IsConstant);

			(emitter as X86CodeEmitter).Emit(BtsConst32.LegacyOpcode, node.Result, node.Operand2);
		}

		internal static void EmitSubSS(InstructionNode node, BaseCodeEmitter emitter)
		{
			Debug.Assert(node.Result == node.Operand1);

			(emitter as X86CodeEmitter).Emit(SubSS.LegacyOpcode, node.Result, node.Operand2);
		}

		internal static void EmitSubSD(InstructionNode node, BaseCodeEmitter emitter)
		{
			Debug.Assert(node.Result == node.Operand1);

			(emitter as X86CodeEmitter).Emit(SubSD.LegacyOpcode, node.Result, node.Operand2);
		}

		internal static void EmitCmpXchgLoad32(InstructionNode node, BaseCodeEmitter emitter)
		{
			Debug.Assert(node.Result.IsCPURegister);
			Debug.Assert(node.Operand1.IsCPURegister);
			Debug.Assert(node.Operand2.IsCPURegister);
			Debug.Assert(node.GetOperand(3).IsCPURegister);
			Debug.Assert(node.Result.Register == GeneralPurposeRegister.EAX);
			Debug.Assert(node.Operand1.Register == GeneralPurposeRegister.EAX);
			Debug.Assert(node.ResultCount == 1);

			// Compare EAX with r/m32. If equal, ZF is set and r32 is loaded into r/m32.
			// Else, clear ZF and load r/m32 into EAX.

			// memory, register 0000 1111 : 1011 000w : mod reg r/m
			var opcode = new OpcodeEncoder()
				.AppendConditionalPrefix(node.Size == InstructionSize.Size16, 0x66)  // 8:prefix: 16bit
				.AppendNibble(Bits.b0000)                                       // 4:opcode
				.AppendNibble(Bits.b1111)                                       // 4:opcode
				.AppendNibble(Bits.b1011)                                       // 4:opcode
				.Append3Bits(Bits.b000)                                         // 3:opcode
				.AppendWidthBit(node.Size != InstructionSize.Size8)             // 1:width
				.ModRegRMSIBDisplacement(true, node.GetOperand(3), node.Operand2, node.Operand3) // Mod-Reg-RM-?SIB-?Displacement
				.AppendConditionalIntegerValue(node.Operand2.IsLinkerResolved, 0);               // 32:memory

			if (node.Operand2.IsLinkerResolved)
				emitter.Emit(opcode, node.Operand2, (opcode.Size - 32) / 8);
			else
				emitter.Emit(opcode);
		}

		internal static void EmitCvtsd2ss(InstructionNode node, BaseCodeEmitter emitter)
		{
			Debug.Assert(node.Result.IsCPURegister);
			Debug.Assert(node.Operand1.IsCPURegister);
			Debug.Assert(node.Operand2 == null);

			(emitter as X86CodeEmitter).Emit(Cvtsd2ss.LegacyOpcode, node.Result, node.Operand1, null);
		}

		internal static void EmitCvtsi2sd(InstructionNode node, BaseCodeEmitter emitter)
		{
			Debug.Assert(node.Result.IsCPURegister);
			Debug.Assert(node.Operand1.IsCPURegister);
			Debug.Assert(node.Operand2 == null);

			(emitter as X86CodeEmitter).Emit(Cvtsi2sd.LegacyOpcode, node.Result, node.Operand1, null);
		}

		internal static void EmitCvtsi2ss(InstructionNode node, BaseCodeEmitter emitter)
		{
			Debug.Assert(node.Result.IsCPURegister);
			Debug.Assert(node.Operand1.IsCPURegister);
			Debug.Assert(node.Operand2 == null);

			(emitter as X86CodeEmitter).Emit(Cvtsi2ss.LegacyOpcode, node.Result, node.Operand1, null);
		}

		internal static void EmitCvtss2sd(InstructionNode node, BaseCodeEmitter emitter)
		{
			Debug.Assert(node.Result.IsCPURegister);
			Debug.Assert(node.Operand1.IsCPURegister);
			Debug.Assert(node.Operand2 == null);

			(emitter as X86CodeEmitter).Emit(Cvtss2sd.LegacyOpcode, node.Result, node.Operand1, null);
		}

		internal static void EmitCvttsd2si(InstructionNode node, BaseCodeEmitter emitter)
		{
			Debug.Assert(node.Result.IsCPURegister);
			Debug.Assert(node.Operand1.IsCPURegister);
			Debug.Assert(node.Operand2 == null);

			(emitter as X86CodeEmitter).Emit(Cvttsd2si.LegacyOpcode, node.Result, node.Operand1, null);
		}

		internal static void EmitCvttss2si(InstructionNode node, BaseCodeEmitter emitter)
		{
			Debug.Assert(node.Result.IsCPURegister);
			Debug.Assert(node.Operand1.IsCPURegister);
			Debug.Assert(node.Operand2 == null);

			(emitter as X86CodeEmitter).Emit(Cvttss2si.LegacyOpcode, node.Result, node.Operand1, null);
		}

		internal static void EmitComisd(InstructionNode node, BaseCodeEmitter emitter)
		{
			Debug.Assert(node.Operand1.IsCPURegister);
			Debug.Assert(node.Operand2.IsCPURegister);
			Debug.Assert(node.Result == null);

			(emitter as X86CodeEmitter).Emit(Comisd.LegacyOpcode, node.Operand1, node.Operand2);
		}

		internal static void EmitComiss(InstructionNode node, BaseCodeEmitter emitter)
		{
			Debug.Assert(node.Operand1.IsCPURegister);
			Debug.Assert(node.Operand2.IsCPURegister);
			Debug.Assert(node.Result == null);

			(emitter as X86CodeEmitter).Emit(Comiss.LegacyOpcode, node.Operand1, node.Operand2);
		}

		internal static void EmitUcomisd(InstructionNode node, BaseCodeEmitter emitter)
		{
			Debug.Assert(node.Operand1.IsCPURegister);
			Debug.Assert(node.Operand2.IsCPURegister);
			Debug.Assert(node.Result == null);

			(emitter as X86CodeEmitter).Emit(Ucomisd.LegacyOpcode, node.Operand1, node.Operand2);
		}

		internal static void EmitUcomiss(InstructionNode node, BaseCodeEmitter emitter)
		{
			Debug.Assert(node.Operand1.IsCPURegister);
			Debug.Assert(node.Operand2.IsCPURegister);
			Debug.Assert(node.Result == null);

			(emitter as X86CodeEmitter).Emit(Ucomiss.LegacyOpcode, node.Operand1, node.Operand2);
		}

		internal static void EmitSub32(InstructionNode node, BaseCodeEmitter emitter)
		{
			Debug.Assert(node.Result == node.Operand1);
			Debug.Assert(node.Result.IsCPURegister);
			Debug.Assert(node.Operand2.IsCPURegister);

			(emitter as X86CodeEmitter).Emit(Sub32.LegacyOpcode, node.Result, node.Operand2);
		}

		internal static void EmitSubConst32(InstructionNode node, BaseCodeEmitter emitter)
		{
			Debug.Assert(node.Result == node.Operand1);
			Debug.Assert(node.Result.IsCPURegister);
			Debug.Assert(node.Operand2.IsConstant);

			(emitter as X86CodeEmitter).Emit(SubConst32.LegacyOpcode, node.Result, node.Operand2);
		}

		internal static void EmitTest32(InstructionNode node, BaseCodeEmitter emitter)
		{
			Debug.Assert(node.Operand1.IsCPURegister);
			Debug.Assert(node.Operand2.IsCPURegister);

			(emitter as X86CodeEmitter).Emit(Test32.LegacyOpcode, node.Result, node.Operand2);
		}

		internal static void EmitTestConst32(InstructionNode node, BaseCodeEmitter emitter)
		{
			Debug.Assert(node.Operand1.IsCPURegister);
			Debug.Assert(node.Operand2.IsConstant);

			(emitter as X86CodeEmitter).Emit(TestConst32.LegacyOpcode, node.Result, node.Operand2);
		}

		internal static void EmitMovd(InstructionNode node, BaseCodeEmitter emitter)
		{
			Debug.Assert(node.Result.IsCPURegister);
			Debug.Assert(node.Operand1.IsCPURegister);

			// reg from mmxreg
			// 0000 1111:0111 1110: 11 mmxreg reg
			var opcode = new OpcodeEncoder()
				.AppendNibble(Bits.b0110)                                       // 4:opcode
				.AppendNibble(Bits.b0110)                                       // 4:opcode
				.AppendNibble(Bits.b0000)                                       // 4:opcode
				.AppendNibble(Bits.b1111)                                       // 4:opcode
				.Append3Bits(Bits.b011)                                         // 3:opcode
				.AppendBit(node.Result.Register.Width != 128)                   // 1:direction
				.AppendNibble(Bits.b1110)                                       // 4:opcode
				.Append2Bits(Bits.b11)                                          // 2:opcode
				.AppendRM(node.Operand1)                                        // 3:r/m (source)
				.AppendRegister(node.Result.Register);                          // 3:register (destination)

			emitter.Emit(opcode);
		}

		internal static void EmitMovsdLoad(InstructionNode node, BaseCodeEmitter emitter)
		{
			Debug.Assert(node.Result.IsCPURegister);

			// mem to xmmreg1 1111 0010:0000 1111:0001 0000: mod xmmreg r/m
			var opcode = new OpcodeEncoder()
				.AppendNibble(Bits.b1111)                                       // 4:opcode
				.AppendNibble(Bits.b0010)                                       // 4:opcode
				.AppendNibble(Bits.b0000)                                       // 4:opcode
				.AppendNibble(Bits.b1111)                                       // 4:opcode
				.AppendNibble(Bits.b0001)                                       // 4:opcode
				.AppendNibble(Bits.b0000)                                       // 4:opcode
				.ModRegRMSIBDisplacement(false, node.Result, node.Operand1, node.Operand2) // Mod-Reg-RM-?SIB-?Displacement
				.AppendConditionalPatchPlaceholder(node.Operand1.IsLinkerResolved, out int patchOffset); // 32:memory

			if (node.Operand1.IsLinkerResolved)
				emitter.Emit(opcode, node.Operand1, patchOffset);
			else
				emitter.Emit(opcode);
		}

		internal static void EmitMovsdStore(InstructionNode node, BaseCodeEmitter emitter)
		{
			Debug.Assert(node.Operand3.IsCPURegister);
			Debug.Assert(node.ResultCount == 0);
			Debug.Assert(!node.Operand3.IsConstant);

			// xmmreg1 to mem 1111 0010:0000 1111:0001 0001: mod xmmreg r/m
			var opcode = new OpcodeEncoder()
				.AppendNibble(Bits.b1111)                                       // 4:opcode
				.AppendNibble(Bits.b0010)                                       // 4:opcode
				.AppendNibble(Bits.b0000)                                       // 4:opcode
				.AppendNibble(Bits.b1111)                                       // 4:opcode
				.AppendNibble(Bits.b0001)                                       // 4:opcode
				.AppendNibble(Bits.b0001)                                       // 4:opcode

				// This opcode has a directionality bit, and it is set to 0
				// This means we must swap around operand1 and operand3, and set offsetDestination to false
				.ModRegRMSIBDisplacement(false, node.Operand3, node.Operand1, node.Operand2) // Mod-Reg-RM-?SIB-?Displacement
				.AppendConditionalPatchPlaceholder(node.Operand1.IsLinkerResolved, out int patchOffset); // 32:memory

			if (node.Operand1.IsLinkerResolved)
				emitter.Emit(opcode, node.Operand1, patchOffset);
			else
				emitter.Emit(opcode);
		}

		internal static void EmitMovssLoad(InstructionNode node, BaseCodeEmitter emitter)
		{
			Debug.Assert(node.Result.IsCPURegister);

			// mem to xmmreg1 1111 0011:0000 1111:0001 0000: mod xmmreg r/m
			var opcode = new OpcodeEncoder()
				.AppendNibble(Bits.b1111)                                       // 4:opcode
				.AppendNibble(Bits.b0011)                                       // 4:opcode
				.AppendNibble(Bits.b0000)                                       // 4:opcode
				.AppendNibble(Bits.b1111)                                       // 4:opcode
				.AppendNibble(Bits.b0001)                                       // 4:opcode
				.AppendNibble(Bits.b0000)                                       // 4:opcode
				.ModRegRMSIBDisplacement(false, node.Result, node.Operand1, node.Operand2) // Mod-Reg-RM-?SIB-?Displacement
				.AppendConditionalPatchPlaceholder(node.Operand1.IsLinkerResolved, out int patchOffset); // 32:memory

			if (node.Operand1.IsLinkerResolved)
				emitter.Emit(opcode, node.Operand1, patchOffset);
			else
				emitter.Emit(opcode);
		}

		internal static void EmitMovssStore(InstructionNode node, BaseCodeEmitter emitter)
		{
			Debug.Assert(node.Operand3.IsCPURegister);
			Debug.Assert(node.ResultCount == 0);
			Debug.Assert(!node.Operand3.IsConstant);

			// xmmreg1 to mem 1111 0011:0000 1111:0001 0001: mod xmmreg r/m
			var opcode = new OpcodeEncoder()
				.AppendNibble(Bits.b1111)                                       // 4:opcode
				.AppendNibble(Bits.b0011)                                       // 4:opcode
				.AppendNibble(Bits.b0000)                                       // 4:opcode
				.AppendNibble(Bits.b1111)                                       // 4:opcode
				.AppendNibble(Bits.b0001)                                       // 4:opcode
				.AppendNibble(Bits.b0001)                                       // 4:opcode

				// This opcode has a directionality bit, and it is set to 0
				// This means we must swap around operand1 and operand3, and set offsetDestination to false
				.ModRegRMSIBDisplacement(false, node.Operand3, node.Operand1, node.Operand2) // Mod-Reg-RM-?SIB-?Displacement
				.AppendConditionalPatchPlaceholder(node.Operand1.IsLinkerResolved, out int patchOffset); // 32:memory

			if (node.Operand1.IsLinkerResolved)
				emitter.Emit(opcode, node.Operand1, patchOffset);
			else
				emitter.Emit(opcode);
		}
	}
}