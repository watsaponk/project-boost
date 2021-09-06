using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    public class PlayerCollision : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            switch (other.gameObject.tag)
            {
                case "Finish":
                {
                    Debug.Log("Finish");
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
                    Debug.Log("Destroy");
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                    break;
                }
            }
        }
    }
}