using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointController : MonoBehaviour {

	// Use this for initialization
	public bool isTruen;
	void Start () {

        if (GetComponent<SkinnedMeshRenderer>())
        {
            SkinnedMeshRenderer smr = GetComponent<SkinnedMeshRenderer>();
            smr.sharedMesh.SetIndices(smr.sharedMesh.GetIndices(0), MeshTopology.Lines, 0);
        }
        else if(GetComponent<MeshFilter>())
        {
            MeshFilter meshFilter = GetComponent<MeshFilter>();
            meshFilter.mesh.SetIndices(meshFilter.mesh.GetIndices(0), MeshTopology.Lines, 0);
        }
	}
	
	// Update is called once per frame
	void Update () {


		if(!isTruen){
			transform.Rotate(new Vector3(0, 1, 0), 1);
		}else{
			transform.position = new Vector3(transform.position.x-0.001f,transform.position.y,transform.position.z);

		}
	}
}
