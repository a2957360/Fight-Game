using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class fsaber : MonoBehaviour {

    public bool fire;
    private Animator anim;
    public Vector3 axis;
    private Vector3 movement;
    public float speed = 6f;

    public GameObject projectile;
    public GameObject projectileloc;
    private Vector3 projectilecontrol;
    public float projectilespeed;

    static fsaber first;
    static fsaber second;

    int health = 100;

    string player;

    // Use this for initialization
    void Start () {
        characterstart();
        anim = GetComponent<Animator>();
        if (player == "p1")
        {
            if (first != null)
            { Debug.Log("fsaber:: error, more than one saber instance enoucntered, using previous verison"); }
            else
            { first = this; }
        }
        else if(player == "p2")
        {
            if (second != null)
            { Debug.Log("fsaber:: error, more than one saber instance enoucntered, using previous verison"); }
            else
            { second = this; }
        }
    }

    void characterstart()
    {
        if (gamemanage.player1exist == false)
        {
            if (selectmanage.player1 == "hero2" || selectmanage.player2 == "hero2")
            {
                player = "p1";
            }
            gamemanage.player1exist = true;
        }
        else if (gamemanage.player2exist == false)
        {
            if (selectmanage.player1 == "hero2" || selectmanage.player2 == "hero2")
            {
                player = "p2";
            }
            gamemanage.player2exist = true;
        }

    }

    public void fsaberconrol()
    {
        axis.x = Input.GetAxis(player + "Vertical");
        axis.z = Input.GetAxis(player + "Horizontal");

        if (health > 0)
        {
            if (anim != null)
            {
                //attackcontrol
                if (Input.GetButtonDown(player + "Fire3"))
                {
                    anim.SetTrigger("attack");
                    SEcontrol.attackseinter();
                    if (player == "p1")
                    {
                        gamemanage.p1attack = true;
                    }
                    else
                    {
                        gamemanage.p2attack = true;
                    }
                    Invoke("resetattack", 1.0f);
                }
                //projectile
                if (Input.GetButtonDown(player + "Fire4"))
                {
                    anim.SetTrigger("projectile");
                    Invoke("projectilemanager", 1.0f);
                    SEcontrol.attackseinter();
                    if (player == "p1")
                    {
                        gamemanage.p1attack = true;
                    }
                    else
                    {
                        gamemanage.p2attack = true;
                    }
                    Invoke("resetattack", 1.0f);
                }


                //crouch
                if (Input.GetButton(player + "Fire1"))
                {
                    anim.SetBool("crouch", true);
                    if (Input.GetButton(player + "Fire5"))
                    {
                        anim.SetBool("crouchblock", true);
                    }
                }
                else
                {
                    anim.SetBool("crouch", false);
                    anim.SetBool("block", false);
                }

                //block
                if (Input.GetButton(player + "Fire5"))
                {
                    anim.SetBool("block", true);
                }
                else
                {
                    anim.SetBool("block", false);
                }

                //taunt
                if (Input.GetButtonDown(player + "Fire6"))
                {
                    anim.SetTrigger("taunt");
                    SEcontrol.tauntseinter();
                }

                //jump
                if (Input.GetButtonDown(player + "Fire2"))
                {
                    anim.SetTrigger("jump");
                    SEcontrol.jumplandseinter();
                }

                //movecontrol
                anim.SetFloat("vaxis", axis.z);
                anim.SetFloat("haxis", axis.x);

                if (axis.x != 0 || axis.z != 0)
                {
                    anim.SetBool("moveornot", true);
                    movement.Set(axis.z, 0f, axis.x);
                    movement = movement.normalized * speed * Time.deltaTime;
                    transform.Translate(movement);
                    SEcontrol.stepseinter();
                }
                else if (axis.x == 0 && axis.z == 0)
                {
                    anim.SetBool("moveornot", false);
                }
            }
        }

        if (health <= 0)
        {
            die();
        }
    }

    void resetattack()
    {
        gamemanage.p1attack = false;
        gamemanage.p2attack = false;
    }

    void gethurt()
    {
        if (health > 0)
        {
            anim.SetTrigger("impact");
            SEcontrol.ftakedamageseinter();
            if (gamemanage.p2attack)
            {
                gamemanage.p1damage();
            }
            else if (gamemanage.p1attack)
            {
                gamemanage.p2damage();
            }

            health -= 10;
            gamemanage.p1attack = false;
            gamemanage.p2attack = false;
        }
        else
        {
            die();
        }

    }
    static public void gethurtinter()
    {
        if (gamemanage.p2attack)
        {
            first.gethurt();
        }
        else if (gamemanage.p1attack)
        {
            second.gethurt();
        }
    }

    void die()
    {
        anim.SetTrigger("dead");
        SEcontrol.fdieseinter();
        if (player == "p1")
        {
            selectmanage.p1++;
        }
        else
        {
            selectmanage.p2++;
        }
        if (selectmanage.p1 == 2 || selectmanage.p2 == 2)
        {
            SceneManager.LoadScene("win");
        }
        else
        {
            gamemanage.player1exist = false;
            gamemanage.player2exist = false;
            SceneManager.LoadScene("ingame");
        }
    }

    public void projectilemanager()
    {
        //bulletspeed += Time.deltaTime * 0.1f;
        GameObject projInstance =
            (GameObject)Instantiate(projectile, projectileloc.transform.position, projectileloc.transform.rotation);

        if (projInstance != null)
        {
            Rigidbody bullectrg = projInstance.GetComponent<Rigidbody>();
            if (bullectrg != null)
            {
                projectilecontrol = projInstance.transform.forward;
                projectilecontrol.Scale(new Vector3(projectilespeed, projectilespeed, projectilespeed));
                bullectrg.AddForce(projectilecontrol);
                //projInstance.transform.position = (bulletforward.transform.position - bullletloc.transform.position) * bulletspeed + bullletloc.transform.position;

            }
        }

    }

    // Update is called once per frame
    void Update () {
        fsaberconrol();
    }
}
