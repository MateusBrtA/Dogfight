using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMove : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        Mover();
    }

    private void Mover()
    {
        transform.Translate(new Vector3(0, -speed, 0) * Time.deltaTime);
    }
}
