using System.Runtime.InteropServices;
using CoreGraphics;

namespace CAMeshTransformLib
{
	[StructLayout(LayoutKind.Sequential)]
	public struct CAMeshVertex
	{
		public CGPoint From;
		public CAPoint3D To;
	}
}