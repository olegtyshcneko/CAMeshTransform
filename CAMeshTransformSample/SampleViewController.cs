using System;
using CAMeshTransformLib;
using CoreGraphics;
using UIKit;

namespace CAMeshTransformSample
{
	public class SampleViewController : UIViewController
	{
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			View.BackgroundColor = UIColor.White;

			var screenWidth = UIScreen.MainScreen.Bounds.Width;

			var originalLabel = new UILabel(new CGRect(0, 20, screenWidth, 100));
			originalLabel.BackgroundColor = UIColor.Green;
			originalLabel.Text = "Hello xamarin";

			var transformedLabel = new UILabel(new CGRect(0, 120, screenWidth, 100));
			transformedLabel.BackgroundColor = UIColor.Green;
			transformedLabel.Text = "Hello xamarin";

			View.AddSubview(transformedLabel);
			View.AddSubview(originalLabel);

			var transform = CreateSampleMeshTransform();
			transform.SetSelfToLayer(transformedLabel.Layer);
			transformedLabel.Layer.RasterizationScale = UIScreen.MainScreen.Scale;
		}

		private CAMutableMeshTransform CreateSampleMeshTransform()
		{
			float waves = 3.0f;
			float amplitude = 0.15f;
			float distanceShrink = 0.3f;

			int columns = 40;

			var transform = CAMutableMeshTransform.MeshTransform;

			for (int i = 0; i <= columns; i++)
			{
				float t = (float)i / columns;
				float sine = (float)Math.Sin(t * Math.PI * waves);

				var topVertex = new CAMeshVertex
				{
					From = new CGPoint(t, 0),
					To = new CAPoint3D
					{
						X = t,
						Y = amplitude * sine * sine + distanceShrink * t,
						Z = 0.0f
					}
				};

				var bottomVertex = new CAMeshVertex
				{
					From = new CGPoint(t, 1.0),
					To = new CAPoint3D
					{
						X = t,
						Y = 1 - amplitude + amplitude * sine * sine - distanceShrink * t,
						Z = 0.0f
					}
				};

				transform.AddVertex(topVertex);
				transform.AddVertex(bottomVertex);
			}

			for (uint i = 0; i < columns; i++)
			{
				uint topLeft = 2 * i + 0;
				uint topRight = 2 * i + 2;
				uint bottomRight = 2 * i + 3;
				uint bottomLeft = 2 * i + 1;

				var meshFace = new CAMeshFace();
				meshFace.SetIndicesElement(0, topLeft);
				meshFace.SetIndicesElement(1, topRight);
				meshFace.SetIndicesElement(2, bottomRight);
				meshFace.SetIndicesElement(3, bottomLeft);

				transform.AddFace(meshFace);
			}

			transform.SubdivisionSteps = 0;

			return transform;
		}
	}
}