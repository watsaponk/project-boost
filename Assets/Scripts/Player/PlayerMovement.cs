using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float thrust = 1f;
        [SerializeField] private float rotationThrust = 1;

        private Rigidbody _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
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
            }
        }

        private void ProcessRotation()
        {
            if (Input.GetKey(KeyCode.A))
            {
                ApplyRotation(1);
            }

            if (Input.GetKey(KeyCode.D))
            {
                ApplyRotation(-1);
            }
        }

        private void ApplyRotation(float directionMultiply)
        {
            _rigidbody.freezeRotation = true;
            transform.Rotate(0, 0, rotationThrust * Time.deltaTime * directionMultiply);
            _rigidbody.freezeRotation = false;
        }
    }
    
}