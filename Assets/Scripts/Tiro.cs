using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Tiro : MonoBehaviour
{
    [SerializeField] public float speed = 20;
    private Rigidbody rigidbody;
    [SerializeField] private float destroitiro = 3f;
    [SerializeField] private GameObject explosao;
    public AudioSource explosaoSom;

    
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = transform.up * speed;
        Destroy(gameObject, destroitiro);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "TiroInimigo")
        {
            Destroy(gameObject);
        }
        if (other.tag == "Inimigo")
        {
           // GameController.controller.AddScore(1);
            Destroy(gameObject);
            Instantiate(explosao, transform.position, transform.rotation);
        }
    }

    void Update()
    {
        
    }
}
