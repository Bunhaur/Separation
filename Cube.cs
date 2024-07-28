using System;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]

public class Cube : MonoBehaviour
{
    [SerializeField] private int _baseChanseSeparation = 100;

    private MeshRenderer _meshRenderer;

    public event Action Splited;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();

        _meshRenderer.material.color = UnityEngine.Random.ColorHSV();
    }

    private void OnMouseUpAsButton()
    {
        if (IsSplit() == true)
        {
            HalfBaseStats();
            Splited?.Invoke();
        }

        SelfDestroy();
    }

    private void SelfDestroy()
    {
        Destroy(gameObject);
    }

    private bool IsSplit()
    {
        int maxChance = 100;
        int chance = UnityEngine.Random.Range(1, maxChance);

        if (chance < _baseChanseSeparation)
            return true;
        else
            return false;
    }

    private void HalfBaseStats()
    {
        int halfValue = 2;

        _baseChanseSeparation /= halfValue;
        transform.localScale /= halfValue;
    }
}