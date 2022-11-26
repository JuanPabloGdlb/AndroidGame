using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SphereScript : MonoBehaviour
{
    public Rigidbody rb;
    public float fordwardSpeed;
    public float sideForce;

    int halfScreen;

    // Start is called before the first frame update
    void Start()
    {
        //Controles android
        halfScreen = Screen.width / 2;
    }

    // Update is called once per frame
    void Update()
    {//moverse A izquierda, B derecha
        rb.AddForce(new Vector3(0, 0, fordwardSpeed) * Time.deltaTime);
        if (Input.GetKey(KeyCode.A)) {
            rb.AddForce(new Vector3(-sideForce, 0, 0) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(new Vector3(sideForce, 0, 0) * Time.deltaTime);
        }

        if(Input.touchCount > 0)
        {
            if (Input.GetTouch(0).position.x <= halfScreen)
            {
                rb.AddForce(new Vector3(sideForce, 0, 0) * Time.deltaTime);
            }
            if (Input.GetTouch(0).position.x > halfScreen)
            {
                rb.AddForce(new Vector3(-sideForce, 0, 0) * Time.deltaTime);
            }
        }
        //Si te caes, respawneas
        if (transform.position.y < -5) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    //Si chocas, respawneas
    private void OnCollisionEnter(Collision colision) {
        if (colision.gameObject.CompareTag("o")) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
