using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorDeBlocos : MonoBehaviour
{

    public GameObject[] blocos;
    public int linhas;

    //float multiplicadorDaLargura = 0;

    // Use this for initialization
    void Start ()
    {
		CriarGrupoDeBlocos();
	}

    void CriarGrupoDeBlocos()
    {
        Bounds limitesDoBloco = blocos[0].GetComponent<SpriteRenderer>().bounds;
        float larguraDoBloco = limitesDoBloco.size.x;
        float alturaDoBloco = limitesDoBloco.size.y;
        float larguraDaTela, alturaDaTela, multiplicadorDaLargura;
        int colunas;

        ColetarInformacoesDoBloco(larguraDoBloco, out larguraDaTela, out alturaDaTela, out colunas, out multiplicadorDaLargura);

        for (int contadorLinhas = 0; contadorLinhas < linhas; contadorLinhas++)
        {
            for (int contadorColunas = 0; contadorColunas < colunas; contadorColunas++)
            {
                GameObject blocoAleatorio = blocos[Random.Range(0, blocos.Length)];
                GameObject blocoInstanciado = (GameObject)Instantiate(blocoAleatorio);

                blocoInstanciado.transform.position = new Vector3(-(larguraDaTela * 0.5f) + (contadorColunas * larguraDoBloco * multiplicadorDaLargura), (alturaDaTela * 0.5f) - (contadorLinhas * alturaDoBloco), 0);
                float novaLarguraDoBloco = blocoInstanciado.transform.localScale.x * multiplicadorDaLargura;
                blocoInstanciado.transform.localScale = new Vector3(novaLarguraDoBloco, blocoInstanciado.transform.localScale.y, 1);
            }
        }
    }

    //Lembrar de colocar o out na frente, menos na larguraDoBloco
    void ColetarInformacoesDoBloco(float larguraDoBloco, out float larguraDaTela, out float alturaDaTela, out int colunas, out float multiplicadorDaLargura)
    {
        Camera c = GameObject.Find("Main Camera").GetComponent<Camera>();
        larguraDaTela = (c.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)) - c.ScreenToWorldPoint(new Vector3(0, 0, 0))).x;
        alturaDaTela = (c.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)) - c.ScreenToWorldPoint(new Vector3(0, 0, 0))).y;
        colunas = (int)(larguraDaTela / larguraDoBloco);


        //multiplicadorDaLargura * colunas * larguraDoBloco = larguraDaTela;
        //multiplicadorDaLargura = larguraDaTela/(colunas * larguraDoBloco);

        multiplicadorDaLargura = larguraDaTela / (colunas * larguraDoBloco);
    }
}
