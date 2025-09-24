using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    protected PlayerCtrl playerCtrl;

    private void Awake()
    {
        this.playerCtrl = GetComponent<PlayerCtrl>();
    }

    public virtual void Dead()
    {
        Debug.Log("Dead");
    }

}
