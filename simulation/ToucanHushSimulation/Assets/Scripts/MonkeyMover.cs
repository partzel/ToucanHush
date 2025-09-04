using UnityEngine;
using UnityEngine.InputSystem;

public class MonkeyMover : MonoBehaviour
{
    public Animation animationPlayer;
    public float movementSpeed = 5.0f;
    public float rotationSpeed = 180.0f;
    public bool isThrowing;
    [HideInInspector] public bool isMoveForward, isMoveBackward, isTurnLeft, isTurnRight, isThrowBanana;

    PlayerInput playerInput;

    public void Start()
    {
        animationPlayer = GetComponent<Animation>();
        playerInput = GetComponent<PlayerInput>();

        playerInput.actions["MoveForward"].performed += ctx => isMoveForward = true;
        playerInput.actions["MoveForward"].canceled += ctx => isMoveForward = true;

        playerInput.actions["MoveForward"].performed += ctx => isMoveForward = true;
        playerInput.actions["MoveForward"].canceled  += ctx => isMoveForward = false;

        playerInput.actions["MoveBackward"].performed += ctx => isMoveBackward = true;
        playerInput.actions["MoveBackward"].canceled  += ctx => isMoveBackward = false;

        playerInput.actions["TurnLeft"].performed += ctx => isTurnLeft = true;
        playerInput.actions["TurnLeft"].canceled  += ctx => isTurnLeft = false;

        playerInput.actions["TurnRight"].performed += ctx => isTurnRight = true;
        playerInput.actions["TurnRight"].canceled  += ctx => isTurnRight = false;

        playerInput.actions["ThrowBanana"].performed += ctx => isThrowBanana = true;
        playerInput.actions["ThrowBanana"].canceled += ctx => isThrowBanana = false;
    }

    public void MoveForward()
    {
        animationPlayer.Play("Walk");
        transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
    }

    public void MoveBackward()
    {
        animationPlayer.Play("Walk");
        transform.Translate(Vector3.back * movementSpeed * Time.deltaTime);
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
