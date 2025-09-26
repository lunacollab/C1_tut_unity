using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{
    public Despawner despawner;
    public BombDamageReceiver damageReceiver;

    private void Awake()
    {
        this.despawner = GetComponent<Despawner>();
        this.damageReceiver = GetComponent<BombDamageReceiver>();
    }
}
