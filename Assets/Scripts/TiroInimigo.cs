using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroInimigo : MonoBehaviour
{
    [SerializeField]
    float speed = 20;
    private Rigidbody rigidbody;
    [SerializeField]
    private float destroitiro = 3f;
    

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.linearVelocity = transform.up * speed;
        Destroy(gameObject, destroitiro);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Tiro")
        {
            Destroy(gameObject);
        }
        if (other.tag == "Aviao")
        {
            Destroy(gameObject);
        }
    }

        // Update is called once per frame
        void Update()
    {
        
    }
}
