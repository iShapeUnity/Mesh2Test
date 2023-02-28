using iShape.Mesh2d;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

namespace Test {

    public class Test1 : MonoBehaviour
    {
        void Update()
        {
            float t = Time.time;
            float r = 0.125f * (2 + math.sin(t));
            float R = r + 0.2f;

            var mesh = new NativeColorMesh(1024, Allocator.Temp);

            float w = 5;
            float h = 3;
            var starStyle = new StrokeStyle(0.05f);
            for (float x = -w; x < w; x += 1f) {
                for (float y = -h; y < h; y += 1f) {
                    var starMesh = MeshGenerator.StrokeForSoftStar(new float2(x, y), r,R, 64, starStyle, 0, Allocator.Temp);
                    mesh.AddAndDispose(starMesh, Color.yellow);            
                }   
            }
            var meshFilter = this.GetComponent<MeshFilter>();

            meshFilter.mesh = mesh.Convert();
        }
    }

}
