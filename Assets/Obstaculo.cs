using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo: MonoBehaviour {
    [SerializeField] private float velocidade = 5f;
    [SerializeField] private float variacaoDaPosicaoY = 1;

    private void Awake(){
        this.transform.Translate(Vector3.up * Random.Range(-variacaoDaPosicaoY, variacaoDaPosicaoY));
    }

    private void Update() {
        this.transform.Translate(Vector3.left * this.velocidade * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D outro){
        if(outro.gameObject.tag == "Apagar")
            Destruir();
    }

    public void Destruir(){
        Destroy(this.gameObject);
    }
}