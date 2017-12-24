using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;



public class RopeGenerator : MonoBehaviour {

    public GameObject baseBlock;
    public GameObject linkBlock;
    public GameObject point;
    public int frequency;
    public float cubeHeight;


	// Use this for initialization
	void Start () {
		
	}
	
	
	public void generateRope(GameObject anchor, Vector3 target)
    {
        Vector3 starPos = (anchor.transform.position +target)/ 2;
        GameObject rope = Instantiate(linkBlock, starPos, Quaternion.Euler(Vector3.zero));
        float distance = Vector3.Distance(anchor.transform.position, target);
        List<GameObject> links = new List<GameObject>();
        int index = 0;
        for(float i = cubeHeight; i<distance; i += cubeHeight)
        {
            Vector3 position = anchor.transform.position;
            position.y -= i;
            GameObject block = Instantiate(linkBlock, position, Quaternion.Euler(Vector3.zero));
            if (index == 0)
            {
                block.GetComponent<HingeJoint>().connectedBody = anchor.GetComponent<Rigidbody>();
            }
            else
            {
                block.GetComponent<HingeJoint>().connectedBody = links[index-1].GetComponent<Rigidbody>();
            }
            links.Add(block);
            index++;
        }
        links[links.Count - 1].transform.position = target;

        GameObject player = FindObjectOfType<PlayerController>().gameObject;
        player.AddComponent<FixedJoint>();
        player.GetComponent<FixedJoint>().connectedBody = links[links.Count - 1].GetComponent<Rigidbody>();
        //grabPoint.transform.position = new Vector3(0, 0, -0.5f);
    }
}
