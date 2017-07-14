using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSortingLayerFix : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Renderer>().sortingLayerName = "Player";
        GetComponent<Renderer>().sortingOrder = -1;
    }
}
