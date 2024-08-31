using UnityEngine;

public class Fireball : MonoBehaviour
{
    public Wizard _wizard;
    public float life = 3;

    void Start()
    {
        _wizard = GameObject.FindWithTag("Player").GetComponent<Wizard>();
    }

    void Awake()
    {
        Destroy(gameObject, life);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Slime")
        {
            other.gameObject.GetComponent<SmallSlime>().GetHit(_wizard._damageValue);
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Map")
        {
            Destroy(gameObject);
        }
    }
}
