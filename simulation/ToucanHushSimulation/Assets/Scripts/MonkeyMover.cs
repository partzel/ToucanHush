using UnityEngine;
using UnityEngine.InputSystem;

public class MonkeyMover : MonoBehaviour
{
    public Animation animationPlayer;
    public float movementSpeed = 10.0f;
    public float rotationSpeed = 3.0f;

    public void Start()
    {
        animationPlayer = GetComponent<Animation>();
    }

    public void MoveForward()
    {
        animationPlayer.Play("Walk");
        transform.position += Vector3.forward * movementSpeed * Time.deltaTime;
    }

    public void MoveBackward()
    {
        animationPlayer.Play("Walk");
        transform.position += Vector3.back * movementSpeed * Time.deltaTime;
    }

    public void TurnLeft()
    {
        animationPlayer.Play("Walk");
        transform.Rotate(Vector3.up, rotationSpeed * -1.0f * Time.deltaTime, 0);
    }

    public void TurnRight()
    {
        animationPlayer.Play("Walk");
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, 0);
    }


    public void Noop()
    {
        animationPlayer.Play("Idle");
    }
}
