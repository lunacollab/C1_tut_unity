using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("Destroy", 12f);
    }

    public virtual void Destroy()
    {
        Destroy(gameObject);
    }

}
