using System;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cube;
    [SerializeField] private float _force;

    public event Action<List<Rigidbody>> Splited;

    private void OnEnable()
    {
        _cube.Splited += CreateCubes;
    }

    private void OnDisable()
    {
        _cube.Splited -= CreateCubes;
    }

    private void CreateCubes()
    {
        GameObject newCube;
        Rigidbody rigidBody;

        List<Rigidbody> cubes = new List<Rigidbody>();

        for (int i = 0; i < GetRandomQuantityCubes(); i++)
        {
            newCube = Instantiate(gameObject, transform.position, Quaternion.identity);
            rigidBody = newCube.GetComponent<Rigidbody>();
            cubes.Add(rigidBody);
        }

        Splited?.Invoke(cubes);
    }

    private int GetRandomQuantityCubes()
    {
        int min = 2;
        int max = 6;

        return UnityEngine.Random.Range(min, max);
    }
}