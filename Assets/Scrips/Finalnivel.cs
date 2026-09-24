using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalNivel : MonoBehaviour
{
    public GameObject UIFinal;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UIFinal.SetActive(true);
        }
    }

    public void IrAlNivel2()
    {
        SceneManager.LoadScene("Nivel2");
    }
}