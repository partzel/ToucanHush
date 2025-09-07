using UnityEngine;

public class ToucanMover : MonoBehaviour
{
    TransformRandomizer transformRandomizer;
    void Start()
    {
        transformRandomizer = GetComponent<TransformRandomizer>();
    }


    public void ResetTransform()
    {
        if (transformRandomizer.randomizeOnEpisodeStart)
        {
            transformRandomizer.RandomizeTransform();
        }
    }
}
