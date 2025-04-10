using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

[Serializable]
public class BordaMapa
{
    public float xMin, xMax, yMin, yMax;
    
}


public class Aviao : MonoBehaviour
{
    //inclinacao
    [SerializeField] private float slope = 4;
    //velocidade
    [SerializeField] public float speed = 10;
    //bordas
    [SerializeField] public BordaMapa bordas;

    public Rigidbody rigidbody;

    [SerializeField] private int vidas = 3;

    public GameObject[] myGuns;
    public GameObject[] myShots;

    [SerializeField] private GameObject explosao;

    float reverterbala = 0;

    [SerializeField] Transform myActiveGun;
    [SerializeField] Transform Tiro;
    [SerializeField] Transform Tiro2;
    [SerializeField] Transform Tiro3;
    [SerializeField] Transform Tiro4;
    [SerializeField] float FireRate = 0.25f;
    [SerializeField] private int leveltiro = 0;

    [SerializeField] private Text vidaText;

    private float nextFire;

    public SpawnInimigos spawnInimigos;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        myActiveGun=myGuns[0].transform;
        
    }

    private void Update()
    {
        //print(Vida);  
        leveltiro = spawnInimigos.level;
    }
    void FixedUpdate()
    {
        this.move();
        this.Atirar();
    }

    private void Atirar()
    {
        if ((Input.GetButton("Fire1") || Input.GetKey(KeyCode.Space)) && Time.time > nextFire)
        {
            switch (leveltiro)
            {
                case 1 or 2 or 3:
                    nextFire = Time.time + FireRate;
                    for (int i = 0; i < myActiveGun.transform.childCount; i++)
                    {
                        Instantiate(Tiro, myActiveGun.GetChild(i).transform.position, myActiveGun.GetChild(i).transform.rotation);
                    }
                    break;

                case 4 or 5 or 6:
                    nextFire = Time.time + FireRate;
                    for (int i = 0; i < myActiveGun.transform.childCount; i++)
                    {
                        Instantiate(Tiro2, myActiveGun.GetChild(i).transform.position, myActiveGun.GetChild(i).transform.rotation);
                    }
                    break;
                case 7 or 8 or 9:
                    nextFire = Time.time + FireRate;
                    for (int i = 0; i < myActiveGun.transform.childCount; i++)
                    {
                        Instantiate(Tiro3, myActiveGun.GetChild(i).transform.position, myActiveGun.GetChild(i).transform.rotation);
                    }
                    break;
                case 10:
                    nextFire = Time.time + FireRate;
                    for (int i = 0; i < myActiveGun.transform.childCount; i++)
                    {
                        Instantiate(Tiro4, myActiveGun.GetChild(i).transform.position, myActiveGun.GetChild(i).transform.rotation);
                    }
                    break;
            }
        }
    }

    private void move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //movimento horizontal e vertical
        Vector3 moviment = new Vector3(moveHorizontal, moveVertical, 0.0f);

        //velocidade de movimento
        rigidbody.velocity = moviment * speed;

        rigidbody.position = new Vector3(
            Mathf.Clamp(rigidbody.position.x, bordas.xMin, bordas.xMax),
            Mathf.Clamp(rigidbody.position.y, bordas.yMin, bordas.yMax),
            0.0f);
        //rotacionar a nave
        rigidbody.rotation = Quaternion.Euler(0.0f, 0.0f, rigidbody.velocity.x * -slope);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "TiroInimigo")
        {
            PerderVida(1);
            Instantiate(explosao, transform.position, transform.rotation);
            Destroy(other.gameObject);
        }
        if (other.tag == "VidaPU")
        {
            AumentarVida();
            Destroy(other.gameObject);
        }
        if (other.tag == "tiroduplo")
        {
            myActiveGun = myGuns[1].transform;
            Invoke("ArmaAtiva", 4f);
            Destroy(other.gameObject);
        }
        if (other.tag == "Atkspeed")
        {
            FireRate = FireRate * 0.5f;
            Invoke("VelocidaDeAtk", 4f);
            Destroy(other.gameObject);
        }
        if (other.tag == "TiroTriplo")
        {
            myActiveGun = myGuns[2].transform;
            Invoke("ArmaAtiva", 4f);
            Destroy(other.gameObject);
        }
        if (other.tag == "VelocidadeMov")
        {
            speed = 15;
            Invoke("VelocidadeMovimento", 4f);
            Destroy(other.gameObject);
        }
        if (other.tag == "TiroSeguir")
        {
            speed = 5;
            Instantiate(explosao, transform.position, transform.rotation);
            Invoke("VelocidadeMovimento", 2f);
            Destroy(other.gameObject);
        }
    }

    public void VelocidaDeAtk()
    {
        FireRate = 0.25f;
    }

    public void ArmaAtiva()
    {
        myActiveGun = myGuns[0].transform;
    }

    public void VelocidadeMovimento()
    {
        speed = 10;
    }

    public void AumentarVida()
    {

    }

    public void PerderVida(int dano)
    {
        vidas -= dano;
        Debug.Log(vidas);
        vidaText.text = vidas.ToString();
        if (vidas <= 0)
        {
            Derrota();
        }
    }
   
    public void Derrota()
    {
        SceneManager.LoadScene(3);
    }




}
