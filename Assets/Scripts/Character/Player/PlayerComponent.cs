using UnityEngine;
using System.Collections;

public class PlayerComponent : MonoBehaviour 
{
    // Damage relative
    public Color originalColor;
    private int animCounter;


    void Start()
    {
        animCounter = 0;

        // Damage relative
        originalColor = gameObject.renderer.material.color;
        animCounter = 0;
    }


    void Update()
    {
        // Hit animation
        if (animCounter > 0)
        {
            animCounter--;
            if (animCounter == 0)
                gameObject.renderer.material.color = originalColor;
        }
    }


    public void Damage(float damage)
    {
        SPlayer.currentLife -= damage;
        DamageAnim();

        // Player dead
        if (SPlayer.currentLife <= 0)
            Object.Destroy(gameObject);
    }


    private void DamageAnim()
    {
        animCounter = SPlayer.damageAnimTime;

        gameObject.renderer.material.color = Color.red;
    }
}
