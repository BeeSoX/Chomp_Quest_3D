using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelingManager : MonoBehaviour
{
    public void Openlevel (int levelID) {
        SceneManager.LoadScene(levelID);
    }
}