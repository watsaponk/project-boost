using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 10f;

        private void Update()
        {
            float speed = moveSpeed * Time.deltaTime;
            float xMove = speed * Input.GetAxis("Horizontal");
            float yMove = speed * Input.GetAxis("Vertical");

            transform.Translate(xMove, yMove, 0);
        }
    }
}