using UnityEngine;
using UnityEngine.UIElements;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public float speed = 27f;
    public float disLimit = 6f;
    public float randomPos = 0;

    private void Awake()
    {
        this.player = PlayerCtrl.instance.transform;
        this.randomPos = Random.Range(-6,6);
    }
    // Update is called once per frame
    void Update()
    {
        this.Follow();
    }
    
    void Follow()
    {   
        Vector3 pos = this.player.position;
        Vector3 distance = pos - transform.position;
        pos.x = randomPos;

        if (distance.magnitude >= this.disLimit)
        {
            Vector3 targetPoint = pos - distance.normalized * this.disLimit;

            transform.position = Vector3.MoveTowards(gameObject.transform.position, targetPoint, this.speed * Time.deltaTime);
        }
    }
}
