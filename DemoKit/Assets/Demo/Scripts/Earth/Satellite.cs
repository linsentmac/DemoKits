using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satellite : MonoBehaviour {

  public  static bool Play = false;
    public Vector3 Forward = Vector3.up;
    public float speed = 1f;
    private void FixedUpdate()
    {
        if (!Play)
        {
            return;
        }
        transform.Rotate(Forward * speed*Time.fixedDeltaTime);
    }
}
