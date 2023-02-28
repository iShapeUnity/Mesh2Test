using iShape.Mesh2d;
using TMPro;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Test {

    public class Test3 : MonoBehaviour
    {
        private JobHandle jobHandle;
        private NativePrimitiveMesh resultMesh;
        private Mesh mesh;
        public TextMeshProUGUI skipText;
        private int count;
        private int notSkipCount;
        
        private void Start() {
            count = 0;
            notSkipCount = 0;
            mesh = this.GetComponent<MeshFilter>().mesh;
            mesh.MarkDynamic();
            resultMesh = new NativePrimitiveMesh(256, Allocator.Persistent);
            StartJob();
        }

        private void Update() {
            count += 1;
            if (jobHandle.IsCompleted) {
                notSkipCount += 1;
                jobHandle.Complete();
                resultMesh.Fill(mesh);
                StartJob();
            }

            int percent = (int)(100 * (float)notSkipCount / count);
            skipText.text = percent.ToString();
            if (count == 1000) {
                count = 100;
                notSkipCount = notSkipCount / 10;
            }
        }

        private void StartJob() {
            resultMesh.Clear();
            var generateMeshJob = new GenerateMeshJobTest3 {
                time = Time.time,
                result = resultMesh
            }; 
            jobHandle = generateMeshJob.Schedule();
        }

        private void OnDestroy() {
            jobHandle.Complete();
            resultMesh.Dispose();
        }
    }
    
    [BurstCompile]
    public struct GenerateMeshJobTest3 : IJob {
        [ReadOnly]
        public float time;

        public NativePrimitiveMesh result;

        public void Execute() {
            float r = 0.125f * (2 + math.sin(time));
            float R = r + 0.2f;

            const float w = 4;
            const float h = 2;
            var starStyle = new StrokeStyle(0.05f);
            for (float x = -w; x < w; x += 1f) {
                for (float y = -h; y < h; y += 1f) {
                    var starMesh = MeshGenerator.StrokeForSoftStar(new float2(x, y), r,R, 64, starStyle, 0, Allocator.Temp);
                    result.AddAndDispose(starMesh);            
                }   
            }
        }
    }

}