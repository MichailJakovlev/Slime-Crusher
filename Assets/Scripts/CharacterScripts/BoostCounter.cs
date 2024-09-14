using System.Linq;
using UnityEngine;

public class BoostCounter : MonoBehaviour
{
    void LateUpdate()
    {
        DestroyGameObject("Speed");
        DestroyGameObject("Damage");
        DestroyGameObject("Heal");
    }

    void DestroyGameObject(string _tagName)
    {
        if (GameObject.FindGameObjectsWithTag($"{_tagName}").Length > 5)
        {
            Destroy(GameObject.FindGameObjectsWithTag($"{_tagName}").First());
        }
    }
}
