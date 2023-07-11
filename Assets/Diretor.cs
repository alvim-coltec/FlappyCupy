using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Diretor : MonoBehaviour { 
    [SerializeField] 
    private GameObject imagemGameOver;
    
    private Aviao aviao;
    
    public int pontos;
    public Text texto_pontos;
    
    public void FinalizarJogo(){
        Time.timeScale = 0;
        //habilitar a imagem Game Over
        this.imagemGameOver.SetActive(true);
    }

    private void Start(){
        this.aviao = GameObject.FindObjectOfType<Aviao>();
    }

    private void DestruirObstaculos(){
        Obstaculo[] obstaculos = GameObject.FindObjectsOfType<Obstaculo>();
        foreach(Obstaculo obstaculo in obstaculos){
            obstaculo.Destruir();
        }
    } 

    public void ReiniciarJogo() {
        this.imagemGameOver.SetActive(false);
        Time.timeScale = 1;
        this.pontos = 0;
        this.texto_pontos.text = pontos.ToString();
        this.aviao.Reiniciar();
        this.DestruirObstaculos();
    }

    public void SairDoJogo()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

}