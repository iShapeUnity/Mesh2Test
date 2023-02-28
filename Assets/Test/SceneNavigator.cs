using UnityEngine;
using UnityEngine.SceneManagement;

namespace Test {

    public class SceneNavigator : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            // QualitySettings.vSyncCount = 0; // disable VSync
            Application.targetFrameRate = 60; 
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    
        public void OnButtonClick()
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            if (currentSceneName == "Test0") {
                SceneManager.LoadScene("Test1");    
            } else if (currentSceneName == "Test1") {
                SceneManager.LoadScene("Test2"); 
            } else if (currentSceneName == "Test2") {
                SceneManager.LoadScene("Test3");
            } else {
                SceneManager.LoadScene("Test0");
            }
        }
    }

}
