using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aviao : MonoBehaviour {
    Rigidbody2D fisica;
    [SerializeField] private float forca;
    [SerializeField] Sprite XicrinhoDef;
    [SerializeField] Sprite XicrinhoUp;
    private Diretor diretor;
    private Vector3 posicaoInicial;

    private void Awake()
    {
        this.posicaoInicial = this.transform.position;
        this.fisica = this.GetComponent<Rigidbody2D>();
    }

    private void Start(){
        this.diretor = GameObject.FindObjectOfType<Diretor>();
    }

    private void Update () { 
        if(Input.GetButtonDown("Fire1") || Input.GetKeyDown("space")){
            this.Impulsionar();
            Invoke("DefSprite", 0.5f);
        }
    }

    private void DefSprite()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = XicrinhoDef;
    }

    private void UpSprite()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = XicrinhoUp;
    }

    public void Reiniciar(){
        this.transform.position = this.posicaoInicial;
        this.fisica.simulated = true;
    }


    private void Impulsionar()
    {
        this.fisica.AddForce(Vector2.up * forca, ForceMode2D.Impulse);
        UpSprite();
    }

    private void OnCollisionEnter2D(Collision2D colisao){
        this.fisica.simulated = false;
        this.diretor.FinalizarJogo();
    }
}