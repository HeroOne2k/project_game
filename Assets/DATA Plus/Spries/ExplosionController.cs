using System.Collections;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    public GameObject explosionPrefab;
    public float explosionScale = 1;
    public float explosionDuration;

    public void Explode()
    {
        var explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
        explosion.transform.localScale = Vector3.one * explosionScale;
        Destroy(explosion, explosionDuration);
    }
}
