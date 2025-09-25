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
        // Chỉ xử lý collision với Player hoặc object có tag "Player"
        if (!collision.CompareTag("Player") && collision.GetComponent<PlayerCtrl>() == null) return;

        DamageReceiver damageReceiver = collision.GetComponent<DamageReceiver>();
        if (damageReceiver == null) return;

        SelfDestroy selfDestroy = collision.GetComponent<SelfDestroy>();
        if (selfDestroy != null)
            selfDestroy.Destroy();

        if (damageReceiver != null)
        {
            damageReceiver.Receive(1);
            // Chỉ destroy enemy khi va chạm với Player
            if (collision.GetComponent<PlayerCtrl>() != null)
                this.enemyCtrl.despawner.Despawn();
        }
    }


}
