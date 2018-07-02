using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class wincontrol : MonoBehaviour {

    Text winnername;
	// Use this for initialization
	void Start () {
        winnername = GameObject.Find("Canvas/winnername").GetComponent<Text>();
    }
	
    void winner()
    {
        if (selectmanage.p1 == 2 )
        {
            winnername.text = "Player1";
        }else if(selectmanage.p2 == 2)
        {
            winnername.text = "Player2";
        }
    }

    void splash()
    {
        if (Input.GetButtonDown("p1Fire1") || Input.GetButtonDown("p2Fire1"))
        {
            SceneManager.LoadScene("splash");
        }
    }
	// Update is called once per frame
	void Update () {
        winner();
        splash();
    }
}
