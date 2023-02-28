using TMPro;
using UnityEngine;

namespace Test {

    public class FPSDisplay : MonoBehaviour
    {
        public TextMeshProUGUI fpsText;
        private float deltaTime;

        void Update()
        {
            deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
            float fps = 1.0f / deltaTime;
            fpsText.text = "FPS: " + Mathf.Round(fps);
        }
    }

}