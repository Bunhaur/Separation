using System;
using UnityEngine;

public class ChanceSeparation : MonoBehaviour
{
    [SerializeField] private Cube _cube;

    public Action<Cube> GotedChance;

    private int _maxChance = 100;

    private void OnEnable()
    {
        _cube.Clicked += CalculationChance;        
    }

    private void OnDisable()
    {
        _cube.Clicked -= CalculationChance;
    }
    private void CalculationChance()
    {
        int chance = UnityEngine.Random.Range(1, _maxChance);

        if (chance < _cube.BaseChanceSeparation)
            GotedChance?.Invoke(_cube);
    }
}