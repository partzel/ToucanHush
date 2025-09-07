using UnityEngine;

public class TransformRandomizer : MonoBehaviour
{
    [SerializeField] Transform spawnOrigin;
    [SerializeField] Vector3 positionMinOffset;
    [SerializeField] Vector3 positionMaxOffset;
    public bool randomizeOnEpisodeStart;

    public void RandomizeTransform()
    {
        var positionOffset = new Vector3(
            Random.Range(positionMinOffset.x, positionMaxOffset.x),
            Random.Range(positionMinOffset.y, positionMaxOffset.y),
            Random.Range(positionMinOffset.z, positionMaxOffset.z)
        );

        transform.position = spawnOrigin.position + positionOffset;
        transform.Rotate(Vector3.up, Random.Range(-180, 180));
    }
}
