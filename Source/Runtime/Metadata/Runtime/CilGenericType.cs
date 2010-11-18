using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using Mosa.Runtime.Loader;
using Mosa.Runtime.Metadata.Signatures;
using Mosa.Runtime.Vm;

namespace Mosa.Runtime.Metadata.Runtime
{

	public class CilGenericType : RuntimeType
	{
		private readonly GenericInstSigType signature;

		private RuntimeType genericType;

		private SigType[] genericArguments;

		public CilGenericType(IModuleTypeSystem moduleTypeSystem, RuntimeType type, GenericInstSigType genericTypeInstanceSignature) :
			base(moduleTypeSystem, type.Token)
		{
			this.signature = genericTypeInstanceSignature;

			this.Methods = this.GetMethods();
			this.Fields = this.GetFields();
		}

		public SigType[] GenericArguments
		{
			get
			{
				ProcessSignature();
				return genericArguments;
			}
		}

		protected override string GetName()
		{
			ProcessSignature();

			StringBuilder sb = new StringBuilder();
			sb.AppendFormat("{0}<", genericType.Name);

			foreach (SigType sigType in genericArguments)
			{
				if (sigType.ContainsGenericParameter)
				{
					sb.AppendFormat("<{0}>, ", sigType.ToString());
				}
				else
				{
					sb.AppendFormat("{0}, ", GetRuntimeTypeForSigType(sigType).FullName);
				}
			}

			sb.Length -= 2;
			sb.Append(">");

			return sb.ToString();
		}

		protected override string GetNamespace()
		{
			ProcessSignature();
			return genericType.Namespace;
		}

		protected override RuntimeType GetBaseType()
		{
			ProcessSignature();
			return genericType.BaseType;
		}

		private IList<RuntimeMethod> GetMethods()
		{
			ProcessSignature();

			List<RuntimeMethod> methods = new List<RuntimeMethod>();
			foreach (CilRuntimeMethod method in this.genericType.Methods)
			{
				MethodSignature signature = new MethodSignature(method.MetadataModule.Metadata, method.Signature.Token);

				RuntimeMethod genericInstanceMethod = new CilGenericMethod(moduleTypeSystem, method, signature);
				methods.Add(genericInstanceMethod);
			}

			return methods;
		}

		private IList<RuntimeField> GetFields()
		{
			ProcessSignature();

			List<RuntimeField> fields = new List<RuntimeField>();
			foreach (CilRuntimeField field in this.genericType.Fields)
			{
				CilGenericField genericInstanceField = new CilGenericField(moduleTypeSystem, this, field);
				fields.Add(genericInstanceField);
			}

			return fields;
		}

		private void ProcessSignature()
		{
			if (genericType == null)
			{
				genericType = moduleTypeSystem.GetType(signature.BaseType.Token);
				genericArguments = signature.GenericArguments;
			}
		}

		private RuntimeType GetRuntimeTypeForSigType(SigType sigType)
		{
			RuntimeType result = null;

			switch (sigType.Type)
			{
				case CilElementType.Class:
					Debug.Assert(sigType is TypeSigType, @"Failing to resolve VarSigType in GenericType.");
					result = moduleTypeSystem.GetType(((TypeSigType)sigType).Token);
					break;

				case CilElementType.ValueType:
					goto case CilElementType.Class;

				case CilElementType.Var:
					throw new NotImplementedException(@"Failing to resolve VarSigType in GenericType.");

				case CilElementType.MVar:
					throw new NotImplementedException(@"Failing to resolve VarMSigType in GenericType.");

				default:
					{
						BuiltInSigType builtIn = sigType as BuiltInSigType;
						if (builtIn != null)
						{
							result = moduleTypeSystem.TypeSystem.GetType(builtIn.TypeName + ", mscorlib");
						}
						else
						{
							throw new NotImplementedException(String.Format("SigType of CilElementType.{0} is not supported.", sigType.Type));
						}
						break;
					}
			}

			return result;
		}

		public override bool ContainsGenericParameters
		{
			get
			{
				return signature.ContainsGenericParameters;
			}
		}

		protected override IList<RuntimeType> LoadInterfaces()
		{
			return NoInterfaces;
		}
	}
}
