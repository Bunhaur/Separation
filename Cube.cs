using System;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(Rigidbody))]

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
        if (IsSplit())
        {
            HalfBaseStats();
            Splited?.Invoke();
        }

        Destroy(gameObject);
    }

    private bool IsSplit()
    {
        int maxChance = 100;
        int chance = UnityEngine.Random.Range(1, maxChance);

        return chance < _baseChanseSeparation;
    }

    private void HalfBaseStats()
    {
        int halfValue = 2;

        _baseChanseSeparation /= halfValue;
        transform.localScale /= halfValue;
    }
}