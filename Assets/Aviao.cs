using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aviao : MonoBehaviour {
    Rigidbody2D fisica;
    [SerializeField] private float forca;
    [SerializeField] Sprite XicrinhoDef;
    [SerializeField] Sprite XicrinhoUp;

    private void Awake()
    {
        this.fisica = this.GetComponent<Rigidbody2D>();
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


    private void Impulsionar()
    {
        this.fisica.AddForce(Vector2.up * forca, ForceMode2D.Impulse);
        UpSprite();
    }
}