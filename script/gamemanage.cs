using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gamemanage : MonoBehaviour {

    //UI objects
    Text clock;
    RawImage player1;
    RawImage player2;
    RawImage p1win;
    RawImage p2win;
    public Slider healthbar1;
    public Slider healthbar2;

    static gamemanage This;
    //save which hero each player select
    string player1hero;
    string player2hero;

    //two heros' photoes
    public Texture h1;
    public Texture h2;

    //set the hero objects
    public GameObject hero1;
    public GameObject hero2;

    //check if player already have hero
    static public bool player1exist = false;
    static public bool player2exist = false;

    //two location that hero appear
    public GameObject player1loc;
    public GameObject player2loc;

    //indentify attack state
    static public bool p1attack = false;
    static public bool p2attack = false;

    //clock 
    int time = 90;
    float i = 0;

    // Use this for initialization
    void Start ()
    {
        
        //UI object
        clock = GameObject.Find("Canvas/Clock").GetComponent<Text>();
        player1 = GameObject.Find("Canvas/player1").GetComponent<RawImage>();
        player2 = GameObject.Find("Canvas/player2").GetComponent<RawImage>();
        p1win = GameObject.Find("Canvas/p1win").GetComponent<RawImage>();
        p2win = GameObject.Find("Canvas/p2win").GetComponent<RawImage>();

        playerphoto();

        if (This != null)
        { Debug.Log("gamemanage:: error, more than one gamemanage instance enoucntered, using previous verison"); }
        else
        { This = this; }

        wintime();
        initialise();
    }

    //player photo
    void playerphoto()
    {
        //get selected hero info
        player1hero = selectmanage.player1;
        player2hero = selectmanage.player2;

        if (player1hero == "hero1")
        {
            player1.texture = h1;
        }else
        {
            player1.texture = h2;
        }

        if (player2hero == "hero1")
        {
            player2.texture = h1;
        }
        else
        {
            player2.texture = h2;
        }

    }

    //winsign
    void wintime()
    {
        if (selectmanage.p1 == 1)
        {
            p1win.enabled = true;
        }

        if (selectmanage.p2 == 1)
        {
            p2win.enabled = true;
        }
    }

    //clock manage
    void clockauto()
    {
        clock.text = time.ToString();
        if (time > 0) {
            if (i > 1)
            {
                time--;
                i = 0;
            }
            i += Time.deltaTime;
        }
        else
        {
            timeup();
            SceneManager.LoadScene("ingame");
        }
    }

    void timeup()
    {
        if (healthbar1.value > healthbar2.value)
        {
            selectmanage.p1++;
        }else if(healthbar1.value < healthbar2.value){
            selectmanage.p2++;
        }else if (healthbar1.value == healthbar2.value)
        {
            selectmanage.p1++;
            selectmanage.p2++;
        }
        player1exist = false;
        player2exist = false;
    }

    //healthbar1
    void player1health()
    {
        healthbar1.value -= 10;
    }
    public static void p1damage()
    {
        if (This != null)
        {
            This.player1health();
        }
    }

    //healthbar2
    void player2health()
    {
        healthbar2.value -= 10;
    }

    public static void p2damage()
    {
        if (This != null)
        {
            This.player2health();
        }
    }

    void initialise()
    {
        if (player1hero == "hero1")
        {
            Instantiate(hero1, player1loc.transform.position, player1loc.transform.rotation);
        }else if (player1hero == "hero2")
        {
            Instantiate(hero2, player1loc.transform.position, player1loc.transform.rotation);
        }

        if (player2hero == "hero1")
        {
            Instantiate(hero1, player2loc.transform.position, player2loc.transform.rotation);
        }
        else if (player2hero == "hero2")
        {
            Instantiate(hero2, player2loc.transform.position, player2loc.transform.rotation);
        }
    }
    // Update is called once per frame
    void Update () {
        clockauto();
    }
}
