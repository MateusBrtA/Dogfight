using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnInimigos : MonoBehaviour
{
    [SerializeField] private GameObject[] Enemies;

    private float tempoSpawn = 0f;
    [SerializeField] private float tempoEspera = 2f;
    public GameObject Inimigo;
    [SerializeField] public int level = 1;
    [SerializeField] private int pontos = 0;
    [SerializeField] private int baselevel = 100;
    [SerializeField] private GameObject bossAnimation;
    private bool animationBoss = false;
    [SerializeField] private Text pontosText;

    private void Update()
    {
        
        if (level < 10)
        {
            GeradorInimigos();
        }
        else
        {
            GeraBoss();
        }
    }

    private void GeraBoss()
    {
        if (!animationBoss)
        {
            GameObject animBoss = Instantiate(bossAnimation, new Vector3(0, 7.45f, 0), transform.rotation);
            Destroy(animBoss, 7f);
            animationBoss = true;
        }
    }

    private void GeradorInimigos()
    {
        if(tempoSpawn > 0)
        {
            tempoSpawn -= Time.deltaTime;
        }
        
        if (tempoSpawn <= 0f)
        {
            int quantidade = level * 1;
            int qtd = 0;

            while (qtd < quantidade)
            {

                GameObject inimigoCriado;

                float chance = Random.Range(0f, level);
                if (chance > 4f)
                {
                    inimigoCriado = Enemies[2];
                }
                else if (chance > 2f)
                {
                    inimigoCriado = Enemies[1];
                }
                else
                {
                    inimigoCriado = Enemies[0];
                }

                Vector3 posicao = new Vector3(0f, Random.Range(2.80f, 4f), 0f);
                
                Instantiate(inimigoCriado, posicao, transform.rotation);
                
                qtd++;

                tempoSpawn = tempoEspera;

            }
        }
    }

    public void GanhaPontos(int valor)
    {
        print("+pontos");
        if (level <10)
        {
            pontos += valor;
            pontosText.text = pontos.ToString();
            if (pontos > baselevel * level)
            {
                level++;
            }
        }
    }

}
