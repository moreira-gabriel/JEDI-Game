using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{
    public void BackToMenuScene()
    {
        SceneManager.LoadScene("Credits");
    }

}
