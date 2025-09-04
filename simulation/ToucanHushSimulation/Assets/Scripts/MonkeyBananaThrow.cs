using System;
using UnityEngine;

public class MonkeyBananaThrow : MonoBehaviour
{
    public float throwForce = 20f;
    [SerializeField] public Transform throwPoint;
    [HideInInspector] public bool isThrowing;
    [HideInInspector] public int ToucansHit = 0;

    public event Action ToucanScored;


    Animation animationPlayer;


    public GameObject banana;

    public void Start()
    {
        animationPlayer = GetComponent<Animation>();
        isThrowing = false;
    }

    public void ThrowBanana()
    {
        isThrowing = true;
        animationPlayer.Play("Throw");
    }

    public void SpawnBanana()
    {
        GameObject b = Instantiate(banana, throwPoint.position, throwPoint.rotation);
        Rigidbody rb = b.GetComponent<Rigidbody>();
        Banana bb = b.GetComponent<Banana>();
        bb.ToucanHit += ScoreToucan;

        if (rb != null)
        {
            rb.AddForce((throwPoint.forward + 0.5f * throwPoint.up) * throwForce, ForceMode.Impulse);
        }
    }

    public void UnlockMovement()
    {
        isThrowing = false;
    }

    void ScoreToucan()
    {
        ToucansHit += 1;
        ToucanScored.Invoke();
    }
}
