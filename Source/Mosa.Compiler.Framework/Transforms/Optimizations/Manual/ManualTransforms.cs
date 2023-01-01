// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

using System.Collections.Generic;

namespace Mosa.Compiler.Framework.Transforms.Optimizations.Manual
{
	/// <summary>
	/// Transformations
	/// </summary>
	public static class ManualTransforms
	{
		public static readonly List<BaseTransform> List = new List<BaseTransform>
		{
			new ConstantMove.Compare32x32(),
			new ConstantMove.Compare32x64(),
			new ConstantMove.Compare64x32(),
			new ConstantMove.Compare64x64(),

			new ConstantFolding.AddCarryOut32(),
			new ConstantFolding.AddCarryOut64(),

			new ConstantMove.Branch32(),
			new ConstantMove.Branch64(),

			new ConstantFolding.Compare32x32(),
			new ConstantFolding.Compare32x64(),
			new ConstantFolding.Compare64x32(),
			new ConstantFolding.Compare64x64(),

			new ConstantFolding.Branch32(),
			new ConstantFolding.Branch64(),

			new ConstantFolding.Switch(),

			new Special.Deadcode(),
			new Special.GetLow32From64(),

			new Simplification.AddCarryOut32CarryNotUsed(),
			new Simplification.AddCarryOut64CarryNotUsed(),
			new Simplification.SubCarryOut32CarryNotUsed(),
			new Simplification.SubCarryOut64CarryNotUsed(),

			new Special.Move32Propagate(),
			new Special.Move32PropagateConstant(),
			new Special.Move64Propagate(),
			new Special.Move64PropagateConstant(),
			new Special.MoveR4Propagate(),
			new Special.MoveR8Propagate(),

			new Special.Phi32Propagate(),
			new Special.Phi64Propagate(),
			new Special.PhiObjectPropagate(),
			new Special.PhiR4Propagate(),
			new Special.PhiR8Propagate(),

			new Special.Phi32Dead(),
			new Special.Phi64Dead(),
			new Special.PhiR4Dead(),
			new Special.PhiR8Dead(),

			new Special.Phi32Update(),
			new Special.Phi64Update(),
			new Special.PhiR4Update(),
			new Special.PhiR8Update(),

			new Simplification.Branch32OnlyOneExit(),
			new Simplification.Branch64OnlyOneExit(),
			new Simplification.BranchObjectOnlyOneExit(),

			new Rewrite.Branch32(),
			new Rewrite.Branch64(),

			new Rewrite.Branch32Object(),
			new Rewrite.Branch64Object(),

			new Special.MoveCompoundPropagate(),

			new Rewrite.Branch32From64(),
			new Rewrite.Branch64From32(),

			new Special.MoveObjectPropagate(),
			new Special.MoveObjectPropagateConstant(),

			new Rewrite.Compare32x32Combine32x32(),
			new Rewrite.Compare32x32Combine64x32(),
			new Rewrite.Compare32x32Combine32x64(),
			new Rewrite.Compare64x64Combine32x32(),
			new Rewrite.Compare64x64Combine64x32(),
			new Rewrite.Compare64x64Combine64x64(),

			new Rewrite.Branch32Combine32x32(),
			new Rewrite.Branch32Combine32x64(),
			new Rewrite.Branch32Combine64x32(),
			new Rewrite.Branch32Combine64x64(),
			new Rewrite.Branch64Combine32x32(),
			new Rewrite.Branch64Combine32x64(),
			new Rewrite.Branch64Combine64x32(),
			new Rewrite.Branch64Combine64x64(),

			new Rewrite.Compare64x32ZeroExtend(),
			new Rewrite.Compare64x32SignExtended(),
			new Rewrite.Compare64x32SignZeroExtend(),
			new Rewrite.Compare64x32ZeroSignExtend(),

			new Simplification.Compare64x32SameHigh(),
			new Simplification.Compare64x32SameLow(),

			// LowerTo32
			new LowerTo32.Add64(),
			new LowerTo32.And64(),
			new LowerTo32.Branch64Extends(),
			new LowerTo32.Compare64x32EqualOrNotEqual(),
			new LowerTo32.Compare64x64EqualOrNotEqual(),

			//LowerTo32.Compare64x32UnsignedGreater(),
			new LowerTo32.Load64(),
			new LowerTo32.LoadParam64(),
			new LowerTo32.LoadParamSignExtend16x64(),
			new LowerTo32.LoadParamSignExtend32x64(),
			new LowerTo32.LoadParamSignExtend8x64(),
			new LowerTo32.LoadParamZeroExtend16x64(),
			new LowerTo32.LoadParamZeroExtend32x64(),
			new LowerTo32.LoadParamZeroExtend8x64(),
			new LowerTo32.Not64(),
			new LowerTo32.Or64(),
			new LowerTo32.SignExtend16x64(),
			new LowerTo32.SignExtend32x64(),
			new LowerTo32.SignExtend8x64(),
			new LowerTo32.Store64(),
			new LowerTo32.StoreParam64(),
			new LowerTo32.Sub64(),
			new LowerTo32.Truncate64x32(),
			new LowerTo32.Xor64(),
			new LowerTo32.ZeroExtend16x64(),
			new LowerTo32.ZeroExtend32x64(),

			new LowerTo32.Move64(),

			// LowerTo32 -- but try other transformations first!
			new LowerTo32.Compare64x32Rest(),
			new LowerTo32.Compare64x32RestInSSA(),
			new LowerTo32.Compare64x64Rest(),
			new LowerTo32.Compare64x64RestInSSA(),
			new LowerTo32.Branch64(),

			new Memory.StoreLoadParam32(),
			new Memory.StoreLoadParam64(),
			new Memory.StoreLoadParamR4(),
			new Memory.StoreLoadParamR8(),
			new Memory.StoreLoadParamObject(),

			new Memory.LoadStoreParam32(),
			new Memory.LoadStoreParam64(),
			new Memory.LoadStoreParamR4(),
			new Memory.LoadStoreParamR8(),
			new Memory.LoadStoreParamObject(),

			new Memory.DoubleStoreParam32(),
			new Memory.DoubleStoreParam64(),
			new Memory.DoubleStoreParamR4(),
			new Memory.DoubleStoreParamR8(),
			new Memory.DoubleStoreParamObject(),

			new Memory.LoadStore32(),
			new Memory.LoadStore64(),
			new Memory.LoadStoreR4(),
			new Memory.LoadStoreR8(),
			new Memory.LoadStoreObject(),

			new Memory.StoreLoad32(),
			new Memory.StoreLoad64(),
			new Memory.StoreLoadR4(),
			new Memory.StoreLoadR8(),
			new Memory.StoreLoadObject(),

			new Memory.DoubleStore32(),
			new Memory.DoubleStore64(),
			new Memory.DoubleStoreR4(),
			new Memory.DoubleStoreR8(),
			new Memory.DoubleStoreObject(),

			new Memory.LoadZeroExtend16x32Store16(),
			new Memory.LoadZeroExtend16x64Store16(),
			new Memory.LoadZeroExtend8x32Store8(),
			new Memory.LoadZeroExtend8x64Store8(),
			new Memory.LoadZeroExtend32x64Store32(),

			new Memory.LoadSignExtend32x64Store32(),
			new Memory.LoadSignExtend16x32Store16(),
			new Memory.LoadSignExtend16x64Store16(),
			new Memory.LoadSignExtend8x32Store8(),
			new Memory.LoadSignExtend8x64Store8(),

			new Memory.LoadParamSignExtend16x32Store16(),
			new Memory.LoadParamSignExtend16x64Store16(),
			new Memory.LoadParamSignExtend8x32Store8(),
			new Memory.LoadParamSignExtend8x64Store8(),
			new Memory.LoadParamSignExtend32x64Store32(),
			new Memory.LoadParamZeroExtend16x32Store16(),
			new Memory.LoadParamZeroExtend16x64Store16(),
			new Memory.LoadParamZeroExtend8x32Store8(),
			new Memory.LoadParamZeroExtend8x64Store8(),
			new Memory.LoadParamZeroExtend32x64Store32(),

			new Memory.DoubleLoad32(),
			new Memory.DoubleLoad64(),
			new Memory.DoubleLoadR4(),
			new Memory.DoubleLoadR8(),
			new Memory.DoubleLoadParamObject(),

			new Memory.DoubleLoadParam32(),
			new Memory.DoubleLoadParam64(),
			new Memory.DoubleLoadParamR4(),
			new Memory.DoubleLoadParamR8(),
			new Memory.DoubleLoadParamObject(),

			//new Special.Phi32Conditional(),

			new Rewrite.Branch32GreaterOrEqualThanZero(),
			new Rewrite.Branch32LessThanZero(),
			new Rewrite.Branch32GreaterThanZero(),
			new Rewrite.Branch32LessOrEqualThanZero(),

			new Rewrite.Branch64GreaterOrEqualThanZero(),
			new Rewrite.Branch64LessThanZero(),
			new Rewrite.Branch64GreaterThanZero(),
			new Rewrite.Branch64LessOrEqualThanZero(),

			new PHI.Phi32Add32(),
		};
	}
}