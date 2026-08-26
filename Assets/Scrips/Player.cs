using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float speed = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Holis");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Adios");

        // Vector3.forward es el automático de decir "movete para delante". Lo multiplicamos por la velocidad y por Time.deltaTime
        // Time.deltaTime: Hace que siempre se mueva a la misma velocidad en todas la compus por más que tengas más o menos FPS
        // Ctrl+K+D me ordena el código de forma linda y ordenada
        // Vector3.forward usa de referencia los vectores del mapa. Mientras que "transform.forward" hace que se muevas en lo que sería SU adelante

        if (Keyboard.current.wKey.IsPressed())
        {
            transform.position += Vector3.forward * speed * Time.deltaTime;
        }

        if (Keyboard.current.sKey.IsPressed())
        {
            transform.position += Vector3.back * speed * Time.deltaTime;
        }

        if (Keyboard.current.dKey.IsPressed())
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        if (Keyboard.current.aKey.IsPressed())
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
    }
}
