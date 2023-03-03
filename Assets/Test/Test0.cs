using iShape.Mesh2d;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

namespace Test {

    public class Test0 : MonoBehaviour {
        
        private void Start() {
            
            // Create a new NativeColorMesh with a capacity of 256 vertices
            var mesh = new NativeColorMesh(256, Allocator.Temp);
        
            // Generate a blue stroke mesh for an edge
            var edgeStyle = new StrokeStyle(0.4f);
            var edgeMesh = MeshGenerator.StrokeForEdge(new float2(3, 3), new float2(-3, 3), edgeStyle, 0, Allocator.Temp);
            mesh.AddAndDispose(edgeMesh, Color.blue);

            // Generate a magenta stroke mesh for a path
            var pathStyle = new StrokeStyle(0.5f);
            var path = new NativeList<Vector2>(4, Allocator.Temp);
            path.Add(new Vector2(-4, 3));
            path.Add(new Vector2(-4, -3));
            path.Add(new Vector2(4, -3));
            path.Add(new Vector2(4, 3));

            var floatArray = path.ConvertToFloat(Allocator.Temp);
            
            var pathMesh = MeshGenerator.StrokeByPath(floatArray, false, pathStyle, 0, Allocator.Temp);

            mesh.AddAndDispose(pathMesh, Color.magenta);
            
            floatArray.Dispose();
            
            // Generate a green stroke mesh for a rectangle
            var rectStyle = new StrokeStyle(0.2f);
            var rectMesh = MeshGenerator.StrokeForRect(float2.zero, new float2(4, 4), rectStyle, 0, Allocator.Temp);
            mesh.AddAndDispose(rectMesh, Color.green);

            // Generate a red stroke mesh for a circle
            var circleStyle = new StrokeStyle(0.1f);
            var circleMesh = MeshGenerator.StrokeForCircle(float2.zero, 1, 32, circleStyle, 0, Allocator.Temp);
            mesh.AddAndDispose(circleMesh, Color.red);

            // Generate a yellow stroke mesh for a soft star
            var starStyle = new StrokeStyle(0.05f);
            var starMesh = MeshGenerator.StrokeForSoftStar(float2.zero, 0.4f,0.7f, 64, starStyle, 0, Allocator.Temp);
            mesh.AddAndDispose(starMesh, Color.yellow);
            
            // Generate a white circle mesh
            var circleShape = MeshGenerator.Circle(new float2(6, 0), 1.0f,16, 0, Allocator.Temp);
            mesh.AddAndDispose(circleShape, Color.white);
            
            // Generate a white rectangle mesh
            var rectShape = MeshGenerator.Rect(new float2(-6, 0), new float2(2, 2),0, Allocator.Temp);
            mesh.AddAndDispose(rectShape, Color.white);
            
            // Set the generated mesh as the MeshFilter's mesh
            var meshFilter = this.GetComponent<MeshFilter>();
            
            meshFilter.mesh = mesh.Convert();
        }
    }

}
