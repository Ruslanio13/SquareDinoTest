using UnityEngine;

public class Finish : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }
}
