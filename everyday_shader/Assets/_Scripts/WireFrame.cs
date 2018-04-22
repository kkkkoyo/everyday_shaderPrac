using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireFrame : MonoBehaviour {

	// Use this for initialization
    //参考: http://nn-hokuson.hatenablog.com/entry/2018/03/01/193935
	void Start () {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        meshFilter.mesh.SetIndices(meshFilter.mesh.GetIndices(0), MeshTopology.Lines, 0);
    }
}
