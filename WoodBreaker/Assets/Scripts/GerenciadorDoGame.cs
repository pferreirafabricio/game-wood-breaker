using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorDoGame : MonoBehaviour
{
    public static void FinalizarJogo()
    {
        Application.LoadLevel("CenaPrincipal");
        //SceneManager.LoadScene("CenaPrincipal");
    }

}
