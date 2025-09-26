using UnityEngine;

public class DamageReceiver : MonoBehaviour
{   
    public PlayerCtrl playerCtrl;

    [Header("DamageReceiver")]
    public int hp = 1; 

    public virtual bool IsDead()
    {
        return this.hp <= 0;
    }
  
    public virtual void Receive(int damage)
    {   
        this.hp  -= damage;
    }
    
}
