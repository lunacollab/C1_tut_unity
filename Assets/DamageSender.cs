using UnityEngine;

public class DamageSender : MonoBehaviour
{
    protected EnemyCtrl enemyCtrl;
    
    private void Awake()
    {
      this.enemyCtrl = GetComponent<EnemyCtrl>();   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageReceiver damageReceiver = collision.GetComponent<DamageReceiver>();

        SelfDestroy selfDestroy = collision.GetComponent<SelfDestroy>();
        if (selfDestroy != null)
            selfDestroy.Destroy();

        if (damageReceiver != null)
            damageReceiver.Receive(1);
            this.enemyCtrl.despawner.Despawn();
    }


}
