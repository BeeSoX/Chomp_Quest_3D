using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // Cette méthode sera appelée lors du clic sur le bouton
    public void LoadSampleScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
