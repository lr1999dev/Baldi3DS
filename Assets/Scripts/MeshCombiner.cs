using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshCombiner : MonoBehaviour 
{
    public string fileName;

#if UNITY_EDITOR
    // Use this for initialization
    void Start () 
	{
        var oldPosition = transform.position;
        transform.position = Vector3.zero;

        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
        CombineInstance[] combine = new CombineInstance[meshFilters.Length];

        for (int i = 0; i < meshFilters.Length; i++)
        {
            combine[i].mesh = meshFilters[i].sharedMesh;
            combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
            meshFilters[i].gameObject.SetActive(false);
        }

        Mesh mesh = new Mesh();
        mesh.CombineMeshes(combine);

        UnityEditor.AssetDatabase.CreateAsset(mesh, "Assets/" + fileName + ".asset");
        UnityEditor.AssetDatabase.SaveAssets();

        transform.position = oldPosition;
    }
#endif
}