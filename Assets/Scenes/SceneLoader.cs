using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string Scene = "";
    void Start()
    {
        switch (Scene)
        {
            case "S1":
                SceneManager.LoadScene("S1", LoadSceneMode.Additive);
                break;
        }
    }
}