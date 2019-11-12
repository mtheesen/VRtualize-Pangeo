﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public static class Startup
{
    static Startup()
    {
        GameObject oldMesh = GameObject.Find("Mesh");
        if (oldMesh != null)
            Object.DestroyImmediate(oldMesh);

        Material mat = Resources.Load("Materials/Stylize_Grass", typeof(Material)) as Material;
        
        Vector3[] vertices = new Vector3[4];
        Vector2[] uv = new Vector2[4];
        int[] triangles = new int[6];

        vertices[0] = new Vector3(0,1);
        vertices[1] = new Vector3(1,1);
        vertices[2] = new Vector3(0,0);
        vertices[3] = new Vector3(1,0);

        uv[0] = new Vector2(0,1);
        uv[1] = new Vector2(1,1);
        uv[2] = new Vector2(0,0);
        uv[3] = new Vector2(1,0);

        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;
        triangles[3] = 2;
        triangles[4] = 1;
        triangles[5] = 3;

        Mesh mesh = new Mesh();

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;

        GameObject Obj = new GameObject("Mesh", typeof(MeshFilter), typeof(MeshRenderer));
        Obj.transform.localScale = new Vector3(1, 1, 1);
        Obj.transform.rotation = Quaternion.Euler(90, 0, 0);
        Obj.transform.position = new Vector3(0, 0.1F, 0);

        Obj.GetComponent<MeshFilter>().mesh = mesh;

        Obj.GetComponent<MeshRenderer>().material = mat;
    }

}
