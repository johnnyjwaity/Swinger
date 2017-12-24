using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour {

    public List<GameObject> allLinks = new List<GameObject>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	
    public GameObject getEndBlock()
    {
        return allLinks[allLinks.Count - 1];
    }

    public void destroyRope()
    {
        foreach(GameObject link in allLinks)
        {
            Destroy(link);
        }
        Destroy(gameObject);
    }
}
