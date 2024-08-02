using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public GameObject _warrior;
    public GameObject _shooter;
    public GameObject _wizard;
    public GameObject _hounter;

    public void Start()
    {
        switch (PlayerPrefs.GetString("PlayableCharacter"))
        {
            case "Warrior":
                _warrior.SetActive(true);
                break;
            case "Shooter":
                _shooter.SetActive(true);
                break;
            case "Wizard":
                _wizard.SetActive(true);
                break;
            case "Hounter":
                _hounter.SetActive(true);
                break;
        }
    }
}
