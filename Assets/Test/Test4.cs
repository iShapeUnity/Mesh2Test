using iShape.Mesh2d;
using Unity.Collections;
using Unity.Mathematics;
using UnityEditor.UI;
using UnityEngine;

namespace Test {

    public class Test4 : MonoBehaviour {
        
        private void Start() {
            
            // Create a new NativeColorMesh with a capacity of 256 vertices
            var mesh = new NativeColorMesh(256, Allocator.Temp);

            // Generate a magenta stroke mesh for a path
            var pathStyle = new StrokeStyle(0.5f);
            var mPath = new NativeList<float2>(4, Allocator.Temp);
            mPath.Add(new float2(-7.1875f, -2.0625f));
            mPath.Add(new float2(-7.0625f, 2.125f));
            mPath.Add(new float2(-5.125f, -2.0625f));
            mPath.Add(new float2(-3.1875f, 2.125f));
            mPath.Add(new float2(-3.0625f, -2.0625f));

            var mMesh = MeshGenerator.StrokeByPath(mPath, false, pathStyle, 0, Allocator.Temp);

            this.printSVGSegment(mMesh);
            
            mesh.AddAndDispose(mMesh, Color.gray);
            mPath.Dispose();
            
            var ePath = new NativeList<float2>(4, Allocator.Temp);
            ePath.Add(new float2(-1.4375f, -0.5f));
            ePath.Add(new float2(0.6875f, -0.5f));
            ePath.Add(new float2(0.625f, 0.125f));
            ePath.Add(new float2(-0.0625f, 0.8125f));
            ePath.Add(new float2(-0.5f, 0.875f));
            ePath.Add(new float2(-1.0f, 0.75f));
            ePath.Add(new float2(-1.375f, 0.5f));
            ePath.Add(new float2(-1.6875f, -0.125f));
            ePath.Add(new float2(-1.6875f, -1.0f));
            ePath.Add(new float2(-1.4375f, -1.5625f));
            ePath.Add(new float2(-1.0625f, -1.9375f));
            ePath.Add(new float2(-0.375f, -2.0625f));
            ePath.Add(new float2(0.25f, -1.9375f));
            ePath.Add(new float2(0.6875f, -1.5f));

            pathStyle.StartCap = false;
            var eMesh = MeshGenerator.StrokeByPath(ePath, false, pathStyle, 0, Allocator.Temp);
            
            this.printSVGSegment(eMesh);
            
            mesh.AddAndDispose(eMesh, Color.gray);
            ePath.Dispose();
            pathStyle.StartCap = true;
            
            var sPath = new NativeList<float2>(4, Allocator.Temp);
            sPath.Add(new float2(1.75f, -1.5f));
            sPath.Add(new float2(1.9375f, -1.8125f));
            sPath.Add(new float2(2.375f, -2.0625f));
            sPath.Add(new float2(3.0f, -2.0625f));
            sPath.Add(new float2(3.625f, -1.9375f));
            sPath.Add(new float2(3.875f, -1.5625f));
            sPath.Add(new float2(3.875f, -1.125f));
            sPath.Add(new float2(3.46875f, -0.71875f));
            sPath.Add(new float2(2.75f, -0.5625f));
            sPath.Add(new float2(2.0625f, -0.3125f));
            sPath.Add(new float2(1.8125f, 0.0f));
            sPath.Add(new float2(1.875f, 0.5625f));
            sPath.Add(new float2(2.40625f, 0.875f));
            sPath.Add(new float2(3.09375f, 0.875f));
            sPath.Add(new float2(3.625f, 0.59375f));
            sPath.Add(new float2(3.75f, 0.3125f));
            
            var sMesh = MeshGenerator.StrokeByPath(sPath, false, pathStyle, 0, Allocator.Temp);
            this.printSVGSegment(sMesh);
            
            mesh.AddAndDispose(sMesh, Color.gray);
            sPath.Dispose();

            var h0Path = new NativeList<float2>(4, Allocator.Temp);
            h0Path.Add(new float2(5.125f, -2.0625f));
            h0Path.Add(new float2(5.125f, 2.25f));
            
            var h0Mesh = MeshGenerator.StrokeByPath(h0Path, false, pathStyle, 0, Allocator.Temp);
            this.printSVGSegment(h0Mesh);
            mesh.AddAndDispose(h0Mesh, Color.gray);
            h0Path.Dispose();
            
            
            var h1Path = new NativeList<float2>(4, Allocator.Temp);
            h1Path.Add(new float2(5.375f, 0.4375f));
            h1Path.Add(new float2(6.5f, 0.4375f));
            h1Path.Add(new float2(6.96875f, 0.3125f));
            h1Path.Add(new float2(7.21875f, 0.0f));
            h1Path.Add(new float2(7.3125f, -0.375f));
            h1Path.Add(new float2(7.3125f, -2.0625f));
            
            pathStyle.StartCap = false;
            var h1Mesh = MeshGenerator.StrokeByPath(h1Path, false, pathStyle, 0, Allocator.Temp);
            this.printSVGSegment(h1Mesh);
            mesh.AddAndDispose(h1Mesh, Color.gray);
            h1Path.Dispose();
            
            // Set the generated mesh as the MeshFilter's mesh
            var meshFilter = this.GetComponent<MeshFilter>();
            
            meshFilter.mesh = mesh.Convert();
        }

        private void printSVGSegment(NativePrimitiveMesh mesh) {
            var s = new string("");
            var count = mesh.triangles.Length / 3;
            var j = 0;
            for (int i = 0; i < count; ++i) {
                var p0 = mesh.vertices[mesh.triangles[j++]];
                var p1 = mesh.vertices[mesh.triangles[j++]];
                var p2 = mesh.vertices[mesh.triangles[j++]];
                s += "<path d=\"M ";
                s += p0.x +"," + p0.y;
                s += " L ";
                s += p1.x +"," + p1.y;
                s += " L ";
                s += p2.x +"," + p2.y;
                s += " Z\" fill=\"none\" stroke=\"red\" style=\"stroke-width:0.1\" />";
            }
            
            Debug.Log(s);
        }
    }

}
