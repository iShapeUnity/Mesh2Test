using iShape.Mesh2d;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

namespace Test {

    public class Test0 : MonoBehaviour {
        // Start is called before the first frame update
        void Start() {
            var mesh = new NativeColorMesh(256, Allocator.Temp);
        
            
            var edgeStyle = new StrokeStyle(0.4f);
            var edgeMesh = MeshGenerator.StrokeForEdge(new float2(3, 3), new float2(-3, 3), edgeStyle, 0, Allocator.Temp);
            mesh.AddAndDispose(edgeMesh, Color.blue);
            
            
            var pathStyle = new StrokeStyle(0.5f);
            var path = new NativeArray<float2>(4, Allocator.Temp);
            path[0] = new float2(-4, 3);
            path[1] = new float2(-4,  -3);
            path[2] = new float2(4, -3);
            path[3] = new float2(4, 3);
            
            var pathMesh = MeshGenerator.StrokeByPath(path, false, pathStyle, 0, Allocator.Temp);
            mesh.AddAndDispose(pathMesh, Color.magenta);
            
            path.Dispose();
            
            var rectStyle = new StrokeStyle(0.2f);
            var rectMesh = MeshGenerator.StrokeForRect(float2.zero, new float2(4, 4), rectStyle, 0, Allocator.Temp);
            mesh.AddAndDispose(rectMesh, Color.green);

            
            var circleStyle = new StrokeStyle(0.1f);
            var circleMesh = MeshGenerator.StrokeForCircle(float2.zero, 1, 32, circleStyle, 0, Allocator.Temp);
            mesh.AddAndDispose(circleMesh, Color.red);
        
            
            var starStyle = new StrokeStyle(0.05f);
            var starMesh = MeshGenerator.StrokeForSoftStar(float2.zero, 0.4f,0.7f, 64, starStyle, 0, Allocator.Temp);
            mesh.AddAndDispose(starMesh, Color.yellow);
            
            
            var circleShape = MeshGenerator.Circle(new float2(6, 0), 1.0f,16, 0, Allocator.Temp);
            mesh.AddAndDispose(circleShape, Color.white);
            
            
            var rectShape = MeshGenerator.Rect(new float2(-6, 0), new float2(2, 2),0, Allocator.Temp);
            mesh.AddAndDispose(rectShape, Color.white);
            
            
            var meshFilter = this.GetComponent<MeshFilter>();
            
            meshFilter.mesh = mesh.Convert();
        }
    }

}
