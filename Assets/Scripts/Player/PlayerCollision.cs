using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    public class PlayerCollision : MonoBehaviour
    {
        [SerializeField] private AudioClip finishSFX;
        [SerializeField] private AudioClip detroyedSFX;

        private AudioSource _audioSource;

        private bool isTransitioning;

        private void Start()
        {
            isTransitioning = false;
            _audioSource = GetComponent<AudioSource>();
        }

        private void OnCollisionEnter(Collision other)
        {
            switch (other.gameObject.tag)
            {
                case "Finish":
                {
                    ExecuteAction(nameof(LoadNextScene), finishSFX);
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
                    ExecuteAction(nameof(RespawnLevel), detroyedSFX);
                    break;
                }
            }
        }

        private void ExecuteAction(string method, AudioClip sfx)
        {
            if (!isTransitioning)
            {
                _audioSource.Stop();
                _audioSource.PlayOneShot(sfx);
            }

            isTransitioning = true;
            GetComponent<PlayerMovement>().enabled = false;
            Invoke(method, 1f);
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