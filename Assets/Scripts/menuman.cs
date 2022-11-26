using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuman : MonoBehaviour
{
    //boton accion
    public void playButton() {
        SceneManager.LoadScene(1);
    }
}
