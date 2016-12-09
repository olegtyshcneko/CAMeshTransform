# CAMeshTransform Xamarin Library

It is bindings to iOS private API that allows to manipulate mesh of any UIView.
Create CAMutableTransform like this:
```
var transform = CAMutableTransform.MeshTransform;
```
Add vertices:
```
var vertex = new CAMeshVertex { From = new CGPoint(0,0), To = new CAPoint3D { X = 1, Y = 1, Z = 0  } };
transform.AddVertex(vertex); 
```
Add faces:
```
var face = new CAMeshFace(); //note that arrays are size 4, you should bound check yourself carefully
face.SetIndicesElement(0, 1);
face.SetIndicesElement(1, 2);
face.SetIndicesElement(2, 3);
face.SetIndicesElement(3, 4);
```
Add transform to layer that is modified:
```
transform.SetSelfToLayer(view.Layer);
```
And you are done.

This repository contains simple example: 

![alt sample](https://github.com/olegtyshcneko/CAMeshTransform/blob/master/sample_screen.png)
Thanks to Bartosz Ciechanowski for providing tutorial about this: [tutorial](http://ciechanowski.me/blog/2014/05/14/mesh-transforms/)
Read it to gain more understanding how to use this.

You should use this with caution as Apple doesn't allow to use private API and it will decline publishing into AppStore.
