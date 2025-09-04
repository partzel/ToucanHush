using System;
using UnityEngine;

public class Banana : MonoBehaviour
{
    public event Action ToucanHit;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Terrain"))
            Destroy(gameObject);

        if (collision.gameObject.CompareTag("Wall"))
            Destroy(gameObject);

        if (collision.gameObject.CompareTag("Toucan"))
            ToucanHit.Invoke();
    }
}
