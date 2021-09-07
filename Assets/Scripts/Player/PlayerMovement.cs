using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float thrust = 1f;
        [SerializeField] private float rotationThrust = 1;
        [SerializeField] private AudioClip boostSFX;
        [SerializeField] private ParticleSystem mainBoostParticle;
        [SerializeField] private ParticleSystem leftBoostParticle;
        [SerializeField] private ParticleSystem rightBoostParticles;

        private Rigidbody _rigidbody;
        private AudioSource _audioSource;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _audioSource = GetComponent<AudioSource>();
        }

        private void Update()
        {
            ProcessThrust();
            ProcessRotation();
        }

        private void ProcessThrust()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                _rigidbody.AddRelativeForce(Vector3.up * thrust * Time.deltaTime);
                if (!_audioSource.isPlaying)
                    _audioSource.PlayOneShot(boostSFX);

                if (!mainBoostParticle.isPlaying)
                    mainBoostParticle.Play();
            }
            else
            {
                if (_audioSource.isPlaying)
                    _audioSource.Stop();
                mainBoostParticle.Stop();
            }
        }

        private void ProcessRotation()
        {
            if (Input.GetKey(KeyCode.A))
            {
                ApplyRotation(1, rightBoostParticles);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                ApplyRotation(-1, leftBoostParticle);
            }
            else
            {
                rightBoostParticles.Stop();
                leftBoostParticle.Stop();
            }
        }

        private void ApplyRotation(float directionMultiply, ParticleSystem particle)
        {
            if(!particle.isPlaying)
                particle.Play();

            _rigidbody.freezeRotation = true;
            transform.Rotate(0, 0, rotationThrust * Time.deltaTime * directionMultiply);
            _rigidbody.freezeRotation = false;
        }
    }
}