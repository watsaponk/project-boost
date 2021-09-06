using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    public class PlayerCollision : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            switch (other.gameObject.tag)
            {
                case "Finish":
                {
                    int nextSceneIndex = currentSceneIndex + 1;
                    if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
                    {
                        nextSceneIndex = 0;
                    }
                    
                    SceneManager.LoadScene(nextSceneIndex);
                    break;
                }
                case "Friendly":
                {
                    Debug.Log("Friendly");
                    break;
                }
                case "Fuel":
                {
                    Debug.Log("Fuel");
                    break;
                }
                default:
                {
                    SceneManager.LoadScene(currentSceneIndex);
                    break;
                }
            }
        }
    }
}