using System;
using System.Runtime.InteropServices;
using CoreAnimation;
using Foundation;
using ObjCRuntime;

namespace CAMeshTransformLib
{
	public class CAMutableMeshTransform
	{
		[DllImport(ObjCRuntime.Constants.ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
		private static extern IntPtr get_mesh_transform_msgSend(IntPtr target, IntPtr selector);

		[DllImport(ObjCRuntime.Constants.ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
		private static extern void add_vertex_msgSend(IntPtr target, IntPtr selector, CAMeshVertex meshVertex);

		[DllImport(ObjCRuntime.Constants.ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
		private static extern void add_face_msgSend(IntPtr target, IntPtr selector, CAMeshFace meshFace);

		[DllImport(ObjCRuntime.Constants.ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
		private static extern void remove_face_at_index_msgSend(IntPtr target, IntPtr selector, ulong index);

		[DllImport(ObjCRuntime.Constants.ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
		private static extern void remove_vertex_at_index_msgSend(IntPtr target, IntPtr selector, ulong index);

		[DllImport(ObjCRuntime.Constants.ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
		private static extern void replace_vertex_at_index_msgSend(IntPtr target, IntPtr selector, ulong index, CAMeshVertex vertex);

		[DllImport(ObjCRuntime.Constants.ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
		private static extern void replace_face_at_index_msgSend(IntPtr target, IntPtr selector, ulong index, CAMeshFace face);

		[DllImport(ObjCRuntime.Constants.ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
		private static extern void set_subdivision_msgSend(IntPtr target, IntPtr selector, int steps);

		[DllImport(ObjCRuntime.Constants.ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
		private static extern int get_subdivision_msgSend(IntPtr target, IntPtr selector);

		[DllImport(ObjCRuntime.Constants.ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
		private static extern int set_mesh_transform(IntPtr target, IntPtr selector, IntPtr meshTransform);

		private static readonly Selector GetMutableMeshTransformSelector = new Selector("meshTransform");
		private static readonly Selector AddVertexSelector = new Selector("addVertex:");
		private static readonly Selector AddFaceSelector = new Selector("addFace:");
		private static readonly Selector SetSubdivisionStepsSelector = new Selector("setSubdivisionSteps:");
		private static readonly Selector GetSubdivisionStepsSelector = new Selector("subdivisionSteps:");

		private static readonly Selector LayerSetMeshTransformSelector = new Selector("setMeshTransform:");

		private static readonly Selector RemoveFaceAtIndexSelector = new Selector("removeFaceAtIndex:");
		private static readonly Selector RemoveVertexAtIndexSelector = new Selector("removeVertexAtIndex:");

		private static readonly Selector ReplaceFaceAtIndexSelector = new Selector("replaceFaceAtIndex:withFace:");
		private static readonly Selector ReplaceVertexAtIndexSelector = new Selector("replaceVertexAtIndex:withVertex:");

		private NSObject meshNativeObject;

		private CAMutableMeshTransform()
		{ }

		public int SubdivisionSteps
		{
			get
			{
				return get_subdivision_msgSend(meshNativeObject.Handle, GetSubdivisionStepsSelector.Handle);
			}
			set
			{
				set_subdivision_msgSend(meshNativeObject.Handle, SetSubdivisionStepsSelector.Handle, value);
			}
		}

		public void AddVertex(CAMeshVertex meshVertex)
		{
			add_vertex_msgSend(meshNativeObject.Handle, AddVertexSelector.Handle, meshVertex);
		}

		public void AddFace(CAMeshFace meshFace)
		{
			add_face_msgSend(meshNativeObject.Handle, AddFaceSelector.Handle, meshFace);
		}

		public void SetSelfToLayer(CALayer layer)
		{
			var layerHandle = layer.Handle;
			set_mesh_transform(layerHandle, LayerSetMeshTransformSelector.Handle, meshNativeObject.Handle);
		}

		public void RemoveFace(uint index)
		{
			remove_face_at_index_msgSend(meshNativeObject.Handle, RemoveFaceAtIndexSelector.Handle, index);
		}

		public void ReplaceFace(uint index, CAMeshFace face)
		{
			replace_face_at_index_msgSend(meshNativeObject.Handle, ReplaceFaceAtIndexSelector.Handle, index, face);
		}

		public void RemoveVertex(uint index)
		{
			remove_vertex_at_index_msgSend(meshNativeObject.Handle, RemoveVertexAtIndexSelector.Handle, index);
		}

		public void ReplaceVertex(uint index, CAMeshVertex vertex)
		{
			replace_vertex_at_index_msgSend(meshNativeObject.Handle, ReplaceVertexAtIndexSelector.Handle, index, vertex);
		}

		public static CAMutableMeshTransform MeshTransform
		{
			get
			{
				var meshClassHandle = new ObjCRuntime.Class(nameof(CAMutableMeshTransform)).Handle;
				var meshHandle =
					get_mesh_transform_msgSend(meshClassHandle, GetMutableMeshTransformSelector.Handle);

				var wrapper = new CAMutableMeshTransform();
				wrapper.meshNativeObject = Runtime.GetNSObject(meshHandle);

				return wrapper;
			}
		}
	}
}