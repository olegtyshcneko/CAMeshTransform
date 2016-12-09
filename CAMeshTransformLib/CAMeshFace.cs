using System.Runtime.InteropServices;

namespace CAMeshTransformLib
{
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct CAMeshFace
	{
		public fixed uint Indices[4];
		public fixed float W[4];

		public void SetIndicesElement(uint i, uint val)
		{
			fixed (uint* indPtr = Indices)
			{
				*(indPtr + i) = val;
			}
		}

		public uint GetIndicesElement(uint i)
		{
			uint result = 0;

			fixed (uint* indPtr = Indices)
			{
				result = *(indPtr + i);
			}

			return result;
		}

		public void SetWElement(uint i, float val)
		{
			fixed (float* wPtr = W)
			{
				*(wPtr + i) = val;
			}
		}

		public float GetWElement(uint i)
		{
			float result = 0f;

			fixed (float* wPtr = W)
			{
				result = *(wPtr + i);
			}

			return result;
		}
	}
}
