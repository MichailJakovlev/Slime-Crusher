using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Shooter _shooter;
    public float life = 3;

    void Start()
    {
        _shooter = GameObject.FindWithTag("Player").GetComponent<Shooter>();
    }

    void Awake()
    {
        Destroy(gameObject, life);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Slime")
        {
            other.gameObject.GetComponent<SmallSlime>().GetHit(_shooter._damageValue);
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Map")
        {
            Destroy(gameObject);
        }
    }
}
