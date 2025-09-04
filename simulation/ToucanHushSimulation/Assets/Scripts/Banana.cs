using UnityEngine;

public class Banana : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Terrain"))
            Destroy(gameObject);

        if (collision.gameObject.CompareTag("Wall"))
            Destroy(gameObject);
    }
}
