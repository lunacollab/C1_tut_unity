using UnityEngine;
using UnityEngine.UIElements;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    protected float speed = 7f;
    protected float disLimit = 0.5f;

    void Start()
    {
        Invoke("Follow()", 2f);
    }
    // Update is called once per frame
    void Update()
    {
        this.Follow();
    }
    
    void Follow()
    {
        Vector3 distance = this.player.transform.position - transform.position;

        if (distance.magnitude >= this.disLimit)
        {
            Vector3 targetPoint = this.player.transform.position - distance.normalized * this.disLimit;

            gameObject.transform.position =
                Vector3.MoveTowards(gameObject.transform.position, targetPoint, this.speed * Time.deltaTime);
        }
    }
}
