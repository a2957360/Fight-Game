using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SEcontrol : MonoBehaviour {

    public List<AudioClip> attack;
    public List<AudioClip> impact;
    public List<AudioClip> takedamage;
    public List<AudioClip> ftakedamage;
    public AudioClip jumpland;
    public AudioClip step;
    public List<AudioClip> die;
    public List<AudioClip> fdie;
    public List<AudioClip> taunt;
    public List<AudioClip> ftaunt;

    public AudioSource asource;
    static SEcontrol This;

    // Use this for initialization
    void Start () {

        if (This != null)
        { Debug.Log("saber:: error, more than one saber instance enoucntered, using previous verison"); }
        else
        { This = this; }
    }

    public void attackse()
    {
        // play random clip
        int id = Random.Range(0, attack.Count);
        if (asource != null)
        {
            // set the clip on the source
            asource.clip = attack[id];
            asource.PlayOneShot(asource.clip);
        }
    }

    public static void attackseinter()
    {
        This.attackse();
    }

    public void impactse()
    {
        // play random clip
        int id = Random.Range(0, impact.Count);
        if (asource != null)
        {
            // set the clip on the source
            asource.clip = impact[id];
            asource.PlayOneShot(asource.clip);
        }
    }

    public static void impactseinter()
    {
        This.impactse();
    }

    public void takedamagese()
    {
        // play random clip
        int id = Random.Range(0, takedamage.Count);
        if (asource != null)
        {
            // set the clip on the source
            asource.clip = takedamage[id];
            asource.PlayOneShot(asource.clip);
        }
    }

    public static void takedamageseinter()
    {
        This.takedamagese();
    }

    public void ftakedamagese()
    {
        // play random clip
        int id = Random.Range(0, ftakedamage.Count);
        if (asource != null)
        {
            // set the clip on the source
            asource.clip = ftakedamage[id];
            asource.PlayOneShot(asource.clip);
        }
    }

    public static void ftakedamageseinter()
    {
        This.ftakedamagese();
    }

    public void jumplandse()
    {
        if (asource != null)
        {
            // set the clip on the source
            asource.clip = jumpland;
            asource.PlayOneShot(asource.clip);
        }
    }

    public static void jumplandseinter()
    {
        This.jumplandse();
    }

    public void stepse()
    {
        if (asource != null)
        {
            // set the clip on the source
            asource.clip = step;
            asource.PlayOneShot(asource.clip);
        }
    }

    public static void stepseinter()
    {
        This.stepse();
    }

    public void diese()
    {
        // play random clip
        int id = Random.Range(0, die.Count);
        if (asource != null)
        {
            // set the clip on the source
            asource.clip = die[id];
            asource.PlayOneShot(asource.clip);
        }
    }

    public static void dieseinter()
    {
        This.diese();
    }

    public void fdiese()
    {
        // play random clip
        int id = Random.Range(0, fdie.Count);
        if (asource != null)
        {
            // set the clip on the source
            asource.clip = fdie[id];
            asource.PlayOneShot(asource.clip);
        }
    }

    public static void fdieseinter()
    {
        This.fdiese();
    }

    public void tauntse()
    {
        // play random clip
        int id = Random.Range(0, taunt.Count);
        if (asource != null)
        {
            // set the clip on the source
            asource.clip = taunt[id];
            asource.PlayOneShot(asource.clip);
        }
    }

    public static void tauntseinter()
    {
        This.tauntse();
    }

    public void ftauntse()
    {
        // play random clip
        int id = Random.Range(0, ftaunt.Count);
        if (asource != null)
        {
            // set the clip on the source
            asource.clip = ftaunt[id];
            asource.PlayOneShot(asource.clip);
        }
    }

    public static void ftauntseinter()
    {
        This.tauntse();
    }

    // Update is called once per frame
    void Update () {
	
	}
}
