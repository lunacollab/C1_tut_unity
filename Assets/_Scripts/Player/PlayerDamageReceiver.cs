using UnityEngine;

public class PlayerDamageReceiver : DamageReceiver
{
    public override void Receive(int damage)
    {   
        base.Receive(damage);
        this.hp -= damage;
        if (this.IsDead())
        {
            UiManager.instance.bnGameOver.SetActive(true);
        }
    }
}
