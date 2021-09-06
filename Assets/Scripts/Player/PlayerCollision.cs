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
                    GetComponent<PlayerMovement>().enabled = false;
                    Invoke(nameof(LoadNextScene), 1f);
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
                    GetComponent<PlayerMovement>().enabled = false;
                    Invoke(nameof(RespawnLevel), 1f);
                    break;
                }
            }
        }

        private void RespawnLevel()
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
        }

        private void LoadNextScene()
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int nextSceneIndex = currentSceneIndex + 1;
            if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
            {
                nextSceneIndex = 0;
            }

            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}