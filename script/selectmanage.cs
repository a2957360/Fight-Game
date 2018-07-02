using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class selectmanage : MonoBehaviour {

    Text hero1player1;
    Text hero2player1;
    Text hero1player2;
    Text hero2player2;
    Text Player1ready;
    Text Player2ready;

    static public string player1;
    static public string player2;

    static public int p1;
    static public int p2;

    bool p1turn = false;
    bool p2turn = false;

    // Use this for initialization
    void Start () {
        hero1player1 = GameObject.Find("Canvas/hero1player1").GetComponent<Text>();
        hero1player2 = GameObject.Find("Canvas/hero1player2").GetComponent<Text>();
        hero2player1 = GameObject.Find("Canvas/hero2player1").GetComponent<Text>();
        hero2player2 = GameObject.Find("Canvas/hero2player2").GetComponent<Text>();
        Player1ready = GameObject.Find("Canvas/Player1ready").GetComponent<Text>();
        Player2ready = GameObject.Find("Canvas/Player2ready").GetComponent<Text>();
    }
	void selectcontrol()
    {

        if (Input.GetAxis("p1Horizontal") == 0)
        {
            p1turn = true;
        }

        if (Player1ready.enabled == false)
        {
            if (Input.GetAxis("p1Horizontal") != 0 && p1turn)
           {
                if (hero1player1.enabled == true) {
                hero2player1.enabled = true;
                hero1player1.enabled = false;
              }else
               {
                   hero2player1.enabled = false;
                  hero1player1.enabled = true;
               }
                p1turn = false;
           }
        }

        if (Input.GetAxis("p2Horizontal") == 0)
        {
            p2turn = true;
        }

        if (Player2ready.enabled == false)
        {
            if (Input.GetAxis("p2Horizontal") != 0 && p2turn)
            {
                if (hero2player1.enabled == true)
                {
                    hero2player2.enabled = true;
                    hero1player2.enabled = false;
                }
                else
                {
                    hero2player2.enabled = false;
                    hero1player2.enabled = true;
                }
                p2turn = false;
            }           
        }
    }


    void ready()
    {
        //player1 ready
        if (Input.GetButtonDown("p1Fire1"))
        {
            Player1ready.enabled = true;
        }

        if (Input.GetButtonDown("p1Fire2"))
        {
            Player1ready.enabled = false;
        }

        //player2 ready
        if (Input.GetButtonDown("p2Fire1"))
        {
            Player2ready.enabled = true;
        }

        if (Input.GetButtonDown("p2Fire2"))
        {
            Player2ready.enabled = false;
        }

        //both ready send select info to ingame
        if (Player1ready.enabled == true && Player2ready.enabled == true)
        {
            //player1
            if (hero1player1.enabled == true)
            {
                player1 = "hero1";
            }else if (hero2player1.enabled == true)
            {
                player1 = "hero2";
            }
            //player2
            if (hero1player2.enabled == true)
            {
                player2 = "hero1";
            }
            else if (hero2player2.enabled == true)
            {
                player2 = "hero2";
            }
            SceneManager.LoadScene("ingame");
        }

    }
	// Update is called once per frame
	void Update () {
        selectcontrol();
        ready();
    }
}
