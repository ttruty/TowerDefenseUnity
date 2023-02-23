using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGenerator : MonoBehaviour
{
    [SerializeField] private int Worldx;
    [SerializeField] private int Worldz;

    private Mesh mesh;

    private int[] triangles;
    private Vector3[] verts;

    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        GenerateMesh();
        UpdateMesh();
    }

    void GenerateMesh() {
        triangles = new int[Worldx * Worldz * 6];
        verts = new Vector3[(Worldx + 1) * (Worldz + 1)];

        for (int i = 0, z = 0; z <= Worldz; z++) {
            for( int x = 0; x <= Worldx; x++) {
                verts[i] = new Vector3(x,0,z);
                i++;
            }
        }

        int triCounter = 0;
        int vertCounter = 0;

        for (int z = 0; z < Worldz; z++) {
            for( int x = 0; x < Worldx; x++) {
                triangles[triCounter + 0] =vertCounter + 0;
                triangles[triCounter + 1] = vertCounter + Worldz + 1;
                triangles[triCounter + 2] = vertCounter + 1;

                triangles[triCounter + 3] = vertCounter + 1;
                triangles[triCounter + 4] = vertCounter + Worldz + 1;
                triangles[triCounter + 5] = vertCounter + Worldz + 2;

                vertCounter++;
                triCounter += 6;
            }

            vertCounter++;

        }


    }

    void UpdateMesh() {
        mesh.Clear();
        mesh.vertices = verts;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
