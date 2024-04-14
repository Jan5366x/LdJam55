using UnityEngine;

public class EntityWithAttack : MonoBehaviour
{
    public int attackPower;
    public GameObject attackAnimationTemplate;

    public void AttackCastle()
    {
        GameObject.Find("GameStateManager").GetComponent<GameStateManager>().AddDamage(attackPower);
        PlayAttackAnimation();
    }

    private void PlayAttackAnimation()
    {
        if (attackAnimationTemplate != null)
        {
            var attackAnimation = Instantiate(attackAnimationTemplate);
            attackAnimation.transform.position = transform.position;
        }
    }
}