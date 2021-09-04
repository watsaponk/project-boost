using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float thrust = 1f;
        [SerializeField] private float rotationSpeed = 1;

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
            float rotate = rotationSpeed * Time.deltaTime * Input.GetAxis("Horizontal") * -1;
            transform.Rotate(0, 0, rotate);
        }
    }
}