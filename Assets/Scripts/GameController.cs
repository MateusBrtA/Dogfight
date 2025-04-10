using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController controller;
    public UIController uicontroller;
    [SerializeField]
    private GameObject Inimigo;
    [SerializeField]
    private Text PontosText;
    static public int score;
    public SpawnInimigos spawnInimigo;
    public Aviao player;
    
    void Awake()
    {
        controller=this;
        GameController.score = 0;
    }

    void Update()
    {
       // AddScore();
    }

    // public void AddScore(int Pontos)
    // {
    //     GameController.score += Pontos;
    //     
    //     if (score >= 220)
    //     {
    //         score = 0;
    //         uicontroller.Ganhar();
    //     }
    // }

}
