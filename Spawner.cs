using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cube;
    [SerializeField] private float _force;

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

        for (int i = 0; i < GetRandomQuantityCubes(); i++)
        {
            newCube = Instantiate(gameObject, transform.position, Quaternion.identity);
            Scatter(newCube);
        }
    }

    private int GetRandomQuantityCubes()
    {
        int min = 2;
        int max = 6;

        return Random.Range(min, max);
    }

    private void Scatter(GameObject cube)
    {
        Rigidbody rigidBody;
        Vector3 randomDirection;

        randomDirection = Random.insideUnitSphere;

        rigidBody = cube.GetComponent<Rigidbody>();
        rigidBody.AddForce(randomDirection * _force, ForceMode.Impulse);
    }
}