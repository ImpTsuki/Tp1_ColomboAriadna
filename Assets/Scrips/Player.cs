using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Rigidbody rigidbodyy;
    public float speed = 10f;
    bool Canjump = false;
    public float jump = 100f;
    public Camera Camarapersonaje;
    public float Vrotación = 100f;
    private Vector3 puntoRespawn = new Vector3(0, 10, 0);
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //se usa Camera.main ya que la cámara está asignada con este tipo y nombre
        Camarapersonaje = Camera.main;
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Piso")
        {
            Canjump = true;

          
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Piso")
        {
            Canjump = false;
        }
    }

    public void ActivarCheckpoint(Vector3 posicion)
{
    puntoRespawn = posicion;
}
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -45)
    {
            transform.position = puntoRespawn;
            rigidbodyy.linearVelocity = Vector3.zero;
            rigidbodyy.angularVelocity = Vector3.zero;
    }

        // Vector3.forward es el automático de decir "movete para delante". Lo multiplicamos por la velocidad y por Time.deltaTime
        // Time.deltaTime: Hace que siempre se mueva a la misma velocidad en todas la compus por más que tengas más o menos FPS
        // Ctrl+K+D me ordena el código de forma linda y ordenada
        // Vector3.forward usa de referencia los vectores del mapa. Mientras que "transform.forward" hace que se muevas en lo que sería SU adelante
        //if (Keyboard.current.wKey.IsPressed())
        //{
        // transform.position += Vector3.forward * speed * Time.deltaTime;
        // }

        //Con el rigidbody lo que le digo es "te doy una fuerza hacia adelante" no es lo mismo que moverse hacia adelante. Es decir, si toco W, se cae hacia adelante.
        // Dentro de Unity, en el Rigidbidy, le desactivo la rtoación en X, Y, Z para que ahora no se caiga.
        // El "rigidbodyy" que escribí es la variable pública que creé más arrba. En unity, en esta variable, le tengo que poner el Regidbody verdadero
        // "wasPressedThisFrame" lo uso para decirle apretá una vez no mantenerlo apretado

        if (Keyboard.current.wKey.IsPressed())
        {
            rigidbodyy.AddForce(transform.forward * speed * Time.fixedDeltaTime, ForceMode.Force);
        }

        if (Keyboard.current.sKey.IsPressed())
        {
            rigidbodyy.AddForce(-transform.forward   * speed * Time.fixedDeltaTime, ForceMode.Force);
        }

        if (Keyboard.current.dKey.IsPressed())
        {
            rigidbodyy.AddForce(transform.right * speed * Time.fixedDeltaTime, ForceMode.Force);
        }

        if (Keyboard.current.aKey.IsPressed())
        {
            rigidbodyy.AddForce(-transform.right * speed * Time.fixedDeltaTime, ForceMode.Force);

        }
        if (Mouse.current.delta.ReadValue().x > 0)
        {
            transform.Rotate(Vector3.up * Vrotación * Time.fixedDeltaTime);
        }

        if (Mouse.current.delta.ReadValue().x < 0)
        {
            transform.Rotate(Vector3.down * Vrotación * Time.fixedDeltaTime);
        }

        if (Keyboard.current.spaceKey.IsPressed()&& Canjump)
        {
            rigidbodyy.AddForce(Vector3.up * jump * Time.fixedDeltaTime, ForceMode.Force);
        }
    }
}
