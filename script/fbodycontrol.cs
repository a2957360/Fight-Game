using UnityEngine;
using System.Collections;

public class fbodycontrol : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "weapon")
        {
            saber.gethurtinter();
        }

    }

    // Update is called once per frame
    void Update () {
	
	}
}
