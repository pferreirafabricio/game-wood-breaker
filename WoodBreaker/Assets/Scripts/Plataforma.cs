using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour {

    public float velocidadeDeMovimento;
    public float limiteEmX;

	// Use this for initialization
	void Start ()
    {
        limiteEmX = GameObject.Find("Main Camera").GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x - GameObject.Find("Plataforma").GetComponent<SpriteRenderer>().bounds.extents.x;
	}
	
	// Update is called once per frame
	void Update ()
    {
        float direcaoHorizontalDoMouse = Input.GetAxis("Mouse X"); //-1 = esquerda; 0 = parado; 1 = direita

        GetComponent<Transform>().position += ((Vector3.right * direcaoHorizontalDoMouse) * velocidadeDeMovimento) * Time.deltaTime;

        float xAtual = transform.position.x; //OBS: Isso só é válido para a propriedade Transform
        xAtual = Mathf.Clamp(xAtual, -limiteEmX, limiteEmX);
        transform.position = new Vector3(xAtual, transform.position.y, transform.position.z);

	}
}
