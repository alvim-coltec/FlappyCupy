using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pontos : MonoBehaviour
{
	public Diretor diretor;
	public AudioSource pontuacaoM4A;
	
	void Awake()
	{
		diretor = FindObjectOfType<Diretor>();
		pontuacaoM4A = GetComponent<AudioSource>();
	}

	void OnTriggerEnter2D(Collider2D colisor)
	{
		diretor.pontos++;
		diretor.texto_pontos.text = diretor.pontos.ToString();
		pontuacaoM4A.Play();
	}    
}
