using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class splash : MonoBehaviour {

    Text player1;
    Text player2;

    // Use this for initialization
    void Start () {
        player1 = GameObject.Find("Canvas/player1ready").GetComponent<Text>();
        player2 = GameObject.Find("Canvas/player2ready").GetComponent<Text>();
    }
	
    void idready()
    {
        if (Input.GetButtonDown("p1Fire1"))
        {
            player1.text = "Ready";
        }

        if (Input.GetButtonDown("p2Fire1"))
        {
            player2.text = "Ready";
        }

        if (player1.text == "Ready" && player2.text == "Ready")
        {
            SceneManager.LoadScene("selecthero");
        }
    }
	// Update is called once per frame
	void Update () {
        idready();
    }
}
