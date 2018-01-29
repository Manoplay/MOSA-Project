﻿// Copyright (c) MOSA Project. Licensed under the New BSD License.
 

// This code was generated by an automated template.

using Mosa.Platform.x86.Instructions;

namespace Mosa.Platform.x86
{
	/// <summary>
	/// X86 Instructions
	/// </summary>
	public static class X86
	{
		public static readonly Adc32 Adc32 = new Adc32();
		public static readonly AdcConst32 AdcConst32 = new AdcConst32();
		public static readonly Add32 Add32 = new Add32();
		public static readonly AddConst32 AddConst32 = new AddConst32();
		public static readonly AddSD AddSD = new AddSD();
		public static readonly AddSS AddSS = new AddSS();
		public static readonly And32 And32 = new And32();
		public static readonly AndConst32 AndConst32 = new AndConst32();
		public static readonly Branch Branch = new Branch();
		public static readonly Break Break = new Break();
		public static readonly Btr32 Btr32 = new Btr32();
		public static readonly BtrConst32 BtrConst32 = new BtrConst32();
		public static readonly Bts32 Bts32 = new Bts32();
		public static readonly BtsConst32 BtsConst32 = new BtsConst32();
		public static readonly Call Call = new Call();
		public static readonly Cdq Cdq = new Cdq();
		public static readonly Cli Cli = new Cli();
		public static readonly Cmovcc Cmovcc = new Cmovcc();
		public static readonly Cmp Cmp = new Cmp();
		public static readonly CmpXchgLoad32 CmpXchgLoad32 = new CmpXchgLoad32();
		public static readonly Comisd Comisd = new Comisd();
		public static readonly Comiss Comiss = new Comiss();
		public static readonly CpuId CpuId = new CpuId();
		public static readonly Cvtsd2ss Cvtsd2ss = new Cvtsd2ss();
		public static readonly Cvtsi2sd Cvtsi2sd = new Cvtsi2sd();
		public static readonly Cvtsi2ss Cvtsi2ss = new Cvtsi2ss();
		public static readonly Cvtss2sd Cvtss2sd = new Cvtss2sd();
		public static readonly Cvttsd2si Cvttsd2si = new Cvttsd2si();
		public static readonly Cvttss2si Cvttss2si = new Cvttss2si();
		public static readonly Dec Dec = new Dec();
		public static readonly Div Div = new Div();
		public static readonly Divsd Divsd = new Divsd();
		public static readonly Divss Divss = new Divss();
		public static readonly FarJmp FarJmp = new FarJmp();
		public static readonly Hlt Hlt = new Hlt();
		public static readonly IDiv IDiv = new IDiv();
		public static readonly IMul IMul = new IMul();
		public static readonly In In = new In();
		public static readonly Inc Inc = new Inc();
		public static readonly Int Int = new Int();
		public static readonly Invlpg Invlpg = new Invlpg();
		public static readonly IRetd IRetd = new IRetd();
		public static readonly Jmp Jmp = new Jmp();
		public static readonly Lea Lea = new Lea();
		public static readonly Leave Leave = new Leave();
		public static readonly Lgdt Lgdt = new Lgdt();
		public static readonly Lidt Lidt = new Lidt();
		public static readonly Lock Lock = new Lock();
		public static readonly Mov Mov = new Mov();
		public static readonly Movaps Movaps = new Movaps();
		public static readonly MovapsLoad MovapsLoad = new MovapsLoad();
		public static readonly MovCRLoad MovCRLoad = new MovCRLoad();
		public static readonly MovCRStore MovCRStore = new MovCRStore();
		public static readonly Movd Movd = new Movd();
		public static readonly MovLoad MovLoad = new MovLoad();
		public static readonly Movsd Movsd = new Movsd();
		public static readonly MovsdLoad MovsdLoad = new MovsdLoad();
		public static readonly MovsdStore MovsdStore = new MovsdStore();
		public static readonly Movss Movss = new Movss();
		public static readonly MovssLoad MovssLoad = new MovssLoad();
		public static readonly MovssStore MovssStore = new MovssStore();
		public static readonly MovStore MovStore = new MovStore();
		public static readonly Movsx Movsx = new Movsx();
		public static readonly MovsxLoad MovsxLoad = new MovsxLoad();
		public static readonly Movups Movups = new Movups();
		public static readonly MovupsLoad MovupsLoad = new MovupsLoad();
		public static readonly MovupsStore MovupsStore = new MovupsStore();
		public static readonly Movzx Movzx = new Movzx();
		public static readonly MovzxLoad MovzxLoad = new MovzxLoad();
		public static readonly Mul Mul = new Mul();
		public static readonly Mulsd Mulsd = new Mulsd();
		public static readonly Mulss Mulss = new Mulss();
		public static readonly Neg Neg = new Neg();
		public static readonly Nop Nop = new Nop();
		public static readonly Not Not = new Not();
		public static readonly Or Or = new Or();
		public static readonly Out Out = new Out();
		public static readonly Pause Pause = new Pause();
		public static readonly Pextrd Pextrd = new Pextrd();
		public static readonly Pop Pop = new Pop();
		public static readonly Popad Popad = new Popad();
		public static readonly Push Push = new Push();
		public static readonly Pushad Pushad = new Pushad();
		public static readonly PXor PXor = new PXor();
		public static readonly Rcr Rcr = new Rcr();
		public static readonly Rep Rep = new Rep();
		public static readonly Ret Ret = new Ret();
		public static readonly Roundsd Roundsd = new Roundsd();
		public static readonly Roundss Roundss = new Roundss();
		public static readonly Sar Sar = new Sar();
		public static readonly Sbb Sbb = new Sbb();
		public static readonly Setcc Setcc = new Setcc();
		public static readonly Shl Shl = new Shl();
		public static readonly Shld Shld = new Shld();
		public static readonly Shr Shr = new Shr();
		public static readonly Shrd Shrd = new Shrd();
		public static readonly Sti Sti = new Sti();
		public static readonly Stos Stos = new Stos();
		public static readonly Sub Sub = new Sub();
		public static readonly SubSD SubSD = new SubSD();
		public static readonly SubSS SubSS = new SubSS();
		public static readonly Test Test = new Test();
		public static readonly Ucomisd Ucomisd = new Ucomisd();
		public static readonly Ucomiss Ucomiss = new Ucomiss();
		public static readonly Xchg Xchg = new Xchg();
		public static readonly Xor Xor = new Xor();
		public static readonly BranchOverflow BranchOverflow = new BranchOverflow();
		public static readonly BranchNoOverflow BranchNoOverflow = new BranchNoOverflow();
		public static readonly BranchCarry BranchCarry = new BranchCarry();
		public static readonly BranchUnsignedLessThan BranchUnsignedLessThan = new BranchUnsignedLessThan();
		public static readonly BranchUnsignedGreaterOrEqual BranchUnsignedGreaterOrEqual = new BranchUnsignedGreaterOrEqual();
		public static readonly BranchNoCarry BranchNoCarry = new BranchNoCarry();
		public static readonly BranchEqual BranchEqual = new BranchEqual();
		public static readonly BranchZero BranchZero = new BranchZero();
		public static readonly BranchNotEqual BranchNotEqual = new BranchNotEqual();
		public static readonly BranchNotZero BranchNotZero = new BranchNotZero();
		public static readonly BranchUnsignedLessOrEqual BranchUnsignedLessOrEqual = new BranchUnsignedLessOrEqual();
		public static readonly BranchUnsignedGreaterThan BranchUnsignedGreaterThan = new BranchUnsignedGreaterThan();
		public static readonly BranchSigned BranchSigned = new BranchSigned();
		public static readonly BranchNotSigned BranchNotSigned = new BranchNotSigned();
		public static readonly BranchParity BranchParity = new BranchParity();
		public static readonly BranchNoParity BranchNoParity = new BranchNoParity();
		public static readonly BranchLessThan BranchLessThan = new BranchLessThan();
		public static readonly BranchGreaterOrEqual BranchGreaterOrEqual = new BranchGreaterOrEqual();
		public static readonly BranchLessOrEqual BranchLessOrEqual = new BranchLessOrEqual();
		public static readonly BranchGreaterThan BranchGreaterThan = new BranchGreaterThan();
	}
}
