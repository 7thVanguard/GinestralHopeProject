using UnityEngine;
using System.Collections;

public class EnemyComponent : MonoBehaviour
{
    [HideInInspector] public Color originalColor;
    [HideInInspector] public float life;

    private int animCounter;


    void Update ()
    {
        // Counter update
        if (animCounter > 0)
        {
            animCounter--;
            if (animCounter == 0)
                gameObject.renderer.material.color = originalColor;
        }
    }


    public void Damage(float damage)
    {
        // Damage recieved
        life -= damage;
        DamageAnim();

        if (life <= 0)
            Destroy(gameObject);
    }


    private void DamageAnim()
    {
        // Changes the color when damaged
        animCounter = SNSlime.damageAnimTime;

        gameObject.renderer.material.color = Color.red;
    }
}
