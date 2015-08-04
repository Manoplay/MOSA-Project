// Copyright (c) MOSA Project. Licensed under the New BSD License.

namespace Mosa.Compiler.Framework.IR
{
	/// <summary>
	/// Used in the single static assignment form of the instruction stream to
	/// automatically select the appropriate value of a variable depending on the
	/// incoming edge.
	/// </summary>
	public sealed class Phi : BaseIRInstruction
	{
		#region Construction

		/// <summary>
		/// Initializes a new instance of the <see cref="Phi" /> class.
		/// </summary>
		public Phi()
			: base(0, 0)
		{
		}

		#endregion Construction

		#region Methods

		/// <summary>
		/// Allows visitor based dispatch for this instruction object.
		/// </summary>
		/// <param name="visitor">The visitor object.</param>
		/// <param name="context">The context.</param>
		public override void Visit(IIRVisitor visitor, Context context)
		{
			visitor.Phi(context);
		}

		#endregion Methods
	}
}
