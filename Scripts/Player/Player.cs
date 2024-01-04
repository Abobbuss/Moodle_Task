using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private string _verticalInput = "Vertical";

    private void Update()
    {
        float verticalMove = Input.GetAxis(_verticalInput);

        Move(verticalMove);
    }

    private void Move(float verticalInput)
    {
        Vector3 movement = new Vector3(0f, 0f, verticalInput);

        transform.Translate(movement * _moveSpeed * Time.deltaTime);
    }
}
