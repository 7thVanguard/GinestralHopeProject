using UnityEngine;
using System.Collections;

public class EnemyComponent : MonoBehaviour
{
    public Color originalColor;
    public float life;

    private int animCounter;


    void Start()
    {
        animCounter = 0;
    }


    void Update ()
    {
        if (animCounter > 0)
        {
            animCounter--;
            if (animCounter == 0)
                gameObject.renderer.material.color = originalColor;
        }
    }


    public void Damage(float damage)
    {
        life -= damage;
        DamageAnim();

        if (life <= 0)
            Destroy(gameObject);
    }


    private void DamageAnim()
    {
        animCounter = SNSlime.damageAnimTime;

        gameObject.renderer.material.color = Color.red;
    }
}
