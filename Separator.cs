using UnityEngine;

public class Separator : MonoBehaviour
{
    [SerializeField] private ChanceSeparation _chance;

    private int _minCount = 2;
    private int _maxCount = 6;
    private int _halfValue = 2;

    private void OnEnable()
    {
        _chance.GotedChance += Separation;
    }

    private void OnDisable()
    {
        _chance.GotedChance -= Separation;
    }

    private void Separation(Cube cube)
    {
        Vector3 newSize = cube.transform.localScale / _halfValue;
        int randomCubes = UnityEngine.Random.Range(_minCount, _maxCount);

        for (int i = 0; i < randomCubes; i++)
        {
            GameObject newCube = Instantiate(cube.gameObject, cube.transform.position, Quaternion.identity);
            newCube.transform.localScale = newSize;
        }
    }
}