using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]

public class Cube : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private float _range;
    [SerializeField] private int _baseChanseSeparation = 200;

    public int BaseChanceSeparation => _baseChanseSeparation;

    public Action Clicked;

    private int _halfValue = 2;
    private MeshRenderer _meshRenderer;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();

        _meshRenderer.material.color = UnityEngine.Random.ColorHSV();
        _baseChanseSeparation /= _halfValue;
    }

    private void OnMouseUpAsButton()
    {
        Clicked?.Invoke();
        Explosion();
        SelfDestroy();
    }

    private void SelfDestroy()
    {
        Destroy(gameObject);
    }

    private List<Rigidbody> GetExplotableObjects()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _range);
        List<Rigidbody> cubes = new List<Rigidbody>();

        foreach (Collider hit in hits)
        {
            if (hit.attachedRigidbody != null)
                cubes.Add(hit.attachedRigidbody);
        }

        _range /= _halfValue;

        return cubes;
    }

    private void Explosion()
    {
        foreach (Rigidbody item in GetExplotableObjects())
            item.AddExplosionForce(_force, transform.position, _range);

        _force /= _halfValue;
    }
}