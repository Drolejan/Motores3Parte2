using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{

    void OnCollisionEnter(Collision collision)
    {
        SceneManager.LoadScene("Nivel2");
    }

}
