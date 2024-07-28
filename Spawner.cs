using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cube;

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
        for (int i = 0; i < GetRandomQuantityCubes(); i++)
        {
            GameObject newCube = Instantiate(gameObject, transform.position, Quaternion.identity);
            print(_cube.BaseChanseSeparation());
        }
    }

    private int GetRandomQuantityCubes()
    {
        int min = 2;
        int max = 6;

        return Random.Range(min, max);
    }
}