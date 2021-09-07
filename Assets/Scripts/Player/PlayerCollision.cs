using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    public class PlayerCollision : MonoBehaviour
    {
        [SerializeField] private AudioClip finishSFX;
        [SerializeField] private AudioClip detroyedSFX;
        [SerializeField] private ParticleSystem finishParticle;
        [SerializeField] private ParticleSystem destroyedParticle;

        private AudioSource _audioSource;

        private bool _isTransitioning;
        private bool _isEnableCollision = true;

        private void Start()
        {
            _isTransitioning = false;
            _audioSource = GetComponent<AudioSource>();
        }

        private void Update()
        {
            DebugModeKeyHandler();
        }

        private void DebugModeKeyHandler()
        {
#if UNITY_EDITOR
            if (Input.GetKeyDown(KeyCode.L))
            {
                LoadNextScene();
            }
            else if (Input.GetKeyDown(KeyCode.C))
            {
                _isEnableCollision = !_isEnableCollision;
            }
#endif
        }

        private void OnCollisionEnter(Collision other)
        {
            if (!_isEnableCollision) return;

            switch (other.gameObject.tag)
            {
                case "Finish":
                {
                    ExecuteAction(nameof(LoadNextScene), finishSFX, finishParticle);
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
                    ExecuteAction(nameof(RespawnLevel), detroyedSFX, destroyedParticle);
                    break;
                }
            }
        }

        private void ExecuteAction(string method, AudioClip sfx, ParticleSystem particle)
        {
            if (!_isTransitioning)
            {
                _audioSource.Stop();
                _audioSource.PlayOneShot(sfx);
                particle.Stop();
                particle.Play();
            }

            _isTransitioning = true;
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