using System;
using System.Runtime.InteropServices;

namespace CAMeshTransformLib
{
	[StructLayout(LayoutKind.Sequential)]
	public struct CAPoint3D
	{
		public nfloat X;
		public nfloat Y;
		public nfloat Z;
	}
}