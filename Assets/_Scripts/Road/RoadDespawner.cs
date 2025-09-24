using UnityEngine;

public class RoadDespawner : MonoBehaviour
{
    protected float distance = 0;

    private void FixedUpdate()
    {
        this.UpdateRoad();
    }

    protected virtual void UpdateRoad()
    {
        this.distance = Vector2.Distance(PlayerCtrl.instance.transform.position, this.transform.position);
        if (this.distance > 70) this.Despawn();
    }

    protected virtual void Despawn()
    {
       Destroy(this.gameObject);
    }
}
