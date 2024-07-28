using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;

    private float _force = 500;
    private float _radius = 500;

    private void OnEnable()
    {
        _spawner.Splited += ScatterCteatedCubes;
    }

    private void OnDisable()
    {
        _spawner.Splited -= ScatterCteatedCubes;
    }

    private void ScatterCteatedCubes(List<Rigidbody>cubes)
    {
        foreach (Rigidbody rb in cubes)
            rb.AddExplosionForce(_force, transform.position, _radius);
    }
}