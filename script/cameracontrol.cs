using UnityEngine;
using System.Collections;

public class cameracontrol : MonoBehaviour {

    GameObject[] heros;
    Vector3 hero1position;
    Vector3 hero2position;
    Vector3 midposition;

    Camera camera;

    public float zoomLevel = 2.0f;
    public float zoomSpeed = 10.0f;

    public float initFOV;

    public float t;
    // Use this for initialization
    void Start () {
        camera = GetComponent<Camera>();
    }


    public void dynamictrack()
    {
        heros = GameObject.FindGameObjectsWithTag("hero");
        hero1position = heros[0].transform.position;
        hero2position = heros[1].transform.position;
        midposition = new Vector3((hero1position.x + hero2position.x)/2, 0.0f ,(hero1position.z + hero2position.z) / 2 );
        camera.transform.LookAt(midposition);
        Vector3 x = camera.WorldToViewportPoint(hero1position);
        Vector3 y = camera.WorldToViewportPoint(hero2position);
        if (Camera.main.fieldOfView > 30) {
            if (0.2f < x.y && x.y < 0.8f || 0.2f < y.y && y.y < 0.8f && x.x > 0 && x.x < 1 && y.x > 0 && y.x < 1)
            {
                Camera.main.fieldOfView -= (Time.deltaTime * zoomSpeed);
            }
        }

        if (Camera.main.fieldOfView < 60)
        {
            if (x.y < 0.2f || x.y > 0.8f || y.y < 0.2f || y.y > 0.8f || x.x < 0 || x.x > 1 || y.x < 0 || y.x > 1)
            {
                Camera.main.fieldOfView += (Time.deltaTime * zoomSpeed);
            }
        }


    }

    // Update is called once per frame
    void Update () {
        dynamictrack();
        //Cameratrack();
        //Camera.main.fieldOfView = initFOV;
    }
}
