using System;
using UnityEngine;

public class MonkeyBananaThrow : MonoBehaviour
{
    Animation animationPlayer;
    [SerializeField] public Transform throwPoint;
    public float throwForce = 600f;
    public bool isThrowing;


    public GameObject banana;

    public void Start()
    {
        animationPlayer = GetComponent<Animation>();
        isThrowing = false;
    }

    public void ThrowBanana()
    {
        animationPlayer.Play("Throw");
        Debug.Log("Threw banana!");
        GameObject b = Instantiate(banana, throwPoint.position, throwPoint.rotation);
        Rigidbody rb = b.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(throwPoint.forward * throwForce, ForceMode.Impulse);
        }
    }
}
