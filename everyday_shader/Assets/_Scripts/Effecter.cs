using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effecter : MonoBehaviour
{
    [SerializeField, Range(0, 1)]
    private float displacement;
    [SerializeField]
    private Material effectMat;
    private Material defaultMat;
    private Renderer ren;
    private Mesh mesh;
    private bool isEffecting;

    private void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        ren = GetComponent<Renderer>();
        defaultMat = ren.material;
    }

    private void Update()
    {
        if (displacement > 0)
        {
            if (!isEffecting)
            {
                isEffecting = true;
                ChangeTopology(true);
            }
        }
        else
        {
            if (isEffecting)
            {
                isEffecting = false;
                ChangeTopology(false);
            }
        }

        if (isEffecting)
        {
            ren.material.SetFloat("_Displacement", displacement);
        }
    }

    private void ChangeTopology(bool isEffect)
    {
        if (isEffect)
        {
            ren.material = effectMat;
            mesh.SetIndices(mesh.GetIndices(0), MeshTopology.Points, 0);
        }
        else
        {
            ren.material = defaultMat;
            mesh.SetIndices(mesh.GetIndices(0), MeshTopology.Triangles, 0);
        }
    }
}