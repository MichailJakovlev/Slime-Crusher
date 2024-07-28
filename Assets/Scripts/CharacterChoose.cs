using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterChoose : MonoBehaviour
{
    public GameObject _warrior;
    public GameObject _shooter;
    public GameObject _wizard;

    public void GetCharacter()
    {
        if(_warrior.activeInHierarchy == true)
        {
            PlayerPrefs.SetString("PlayableCharacter", "Warrior");
            PlayerPrefs.Save();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (_shooter.activeInHierarchy == true)
        {
            PlayerPrefs.SetString("PlayableCharacter", "Shooter");
            PlayerPrefs.Save();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (_wizard.activeInHierarchy == true)
        {
            PlayerPrefs.SetString("PlayableCharacter", "Wizard");
            PlayerPrefs.Save();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            PlayerPrefs.SetString("PlayableCharacter", "Hounter");
            PlayerPrefs.Save();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
