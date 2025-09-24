using UnityEngine;
using UnityEngine.UIElements;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public float speed = 27f;
    public float disLimit = 3f;

    void Start()
    {
        Invoke("Follow()", 2f);
    }

    private void Awake()
    {
        this.player = PlayerCtrl.instance.transform;
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
