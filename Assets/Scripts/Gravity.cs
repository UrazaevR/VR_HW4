using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gravity : MonoBehaviour
{
    public GameObject Plane = null;
    float z = 0.0F;
    int i = 0;
    public Vector3 g = new Vector3(0, (float)-0.01, 0);
    public Vector3 Speed = new Vector3(0, 0, 0);
    public Vector3 Jump_Boost = new Vector3(0, (float)0.3, 0);
    public Vector3 size;
    private MeshRenderer renderer1;
    // Start is called before the first frame update
    void Start()
    {
        renderer1 = GetComponent<MeshRenderer>();
        size = renderer1.bounds.size;
    }

    void Gravity_update()
    {
        Speed += g;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (this.gameObject.transform.position.y - size.y / 2 <= Plane.transform.position.y)
        {
            Speed = Jump_Boost;
            i++;
            Jump_Boost.y *= (float)1;
        }
        this.gameObject.transform.Translate(Speed);
        z = this.gameObject.transform.position.z;
        //Debug.Log(z);
        Gravity_update();
    }
}
