using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public DamageReceiver damageReceiver;
    public PlayerStatus playerStatus;

    private void Awake()
    {
        this.damageReceiver = GetComponent<DamageReceiver>();
        this.playerStatus = GetComponent<PlayerStatus>();
    }
}
