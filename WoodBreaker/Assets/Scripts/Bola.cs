using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour {

    public Vector3 Direcao;
    public float Velocidade = 7;

	// Use this for initialization
	void Start ()
    {
        Direcao.Normalize(); //equivalente à: Direcao = Direcao.normalized;
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position += (Direcao * Velocidade) * Time.deltaTime;
	}

    void OnCollisionEnter2D(Collision2D colisor)
    {
        bool colisaoInvalida = false;
        Vector2 normal = colisor.contacts[0].normal;

        Plataforma plataforma = colisor.transform.GetComponent<Plataforma>();
        GeradorDeArestas geradorDeArestas = colisor.transform.GetComponent<GeradorDeArestas>();

        if (plataforma != null)
        {
            if (normal != Vector2.up)
            {
                colisaoInvalida = true;
            }
        }

        else if (geradorDeArestas != null)
        {
            if (normal == Vector2.up)
            {
                colisaoInvalida = true;
            }
        }

        else //Caso cairmos no else, estamos colidindo com um bloco, pois é o que sobra
        {
            colisaoInvalida = false;
            Destroy(colisor.gameObject);
        }

        if (!colisaoInvalida)
        {
            Direcao = Vector2.Reflect(Direcao, normal);
            Direcao.Normalize();
        }
        else
        {
            GerenciadorDoGame.FinalizarJogo();
        }
    }
}
