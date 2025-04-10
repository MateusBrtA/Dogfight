using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Inimigo : MonoBehaviour
{
    [SerializeField] private float CooldownTiro = 1f;

    public GameObject[] myGuns;

    [SerializeField]float FireRate = 0.25f;

    private float nextFire;

    [SerializeField] Transform myActiveGun;
    [SerializeField] private GameObject TiroInimigo;
    [SerializeField] protected GameObject powerup;
    
    public Rigidbody rb;

    [SerializeField] private int vida = 1;
    [SerializeField] protected int experiencia = 10;

    public GameObject[] powerups;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        myActiveGun = myGuns[0].transform;
    }

    void Update()
    {
        //CooldownTiro -= Time.deltaTime;
        // if (CooldownTiro <= 0)
        // {
        //     Instantiate(TiroInimigo, SpawnTiro.position, SpawnTiro.rotation);
        //     CooldownTiro = 2f;
        // }
        Atirar();
    }

    private void Atirar()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + FireRate;
            for (int i = 0; i < myActiveGun.transform.childCount; i++)
            {
                Instantiate(TiroInimigo, myActiveGun.GetChild(i).transform.position, myActiveGun.GetChild(i).transform.rotation);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
                 
        if (other.gameObject.CompareTag("Tiro"))
        {
            PerdeVidaInimigo(1);
        }
        if (other.gameObject.CompareTag("Tiro2"))
        {
            PerdeVidaInimigo(2);
        }
        if (other.gameObject.CompareTag("Tiro3"))
        {
            PerdeVidaInimigo(3);
        }
        if (other.gameObject.CompareTag("Tiro4"))
        {
            PerdeVidaInimigo(5);
        }
    }

    public void DropItem()
    {
        float chance = Random.Range(0f, 1f);

        if (chance > 0.8f)
        {
            Instantiate(powerups[Random.Range(0, 2)], transform.position, transform.rotation);
        }
    }

    public void PerdeVidaInimigo(int dano)
    {
        vida -= dano;
        Debug.Log("PerdeuPlaybas");
        if (vida <= 0)
        {
            DropItem();
            FindObjectOfType<SpawnInimigos>().GanhaPontos(experiencia);
            Destroy(gameObject);
        }
    }
}
