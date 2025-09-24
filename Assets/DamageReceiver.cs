using UnityEngine;

public class DamageReceiver : MonoBehaviour
{   
    public PlayerCtrl playerCtrl;
    protected int hp = 3; 

    public virtual bool IsDead()
    {
        return this.hp <= 0;
    }
  
    public virtual void Receive(int damage)
    {
        if (this.IsDead()) 
        {
            this.playerCtrl.playerStatus.Dead();
        }
    }
    
 
}
