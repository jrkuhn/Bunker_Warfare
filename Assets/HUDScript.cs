using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour {

    public Image currHealth;
    public Text healthRate;
    public Text Score;
    public Text GameOver;


    private float hitpoints = 100;
    private float maxHitpoints = 100;
    private float score = 0;


	// Use this for initialization
	public void Start () {
        updateHealth();
        updateScore(0);
	}
	
	// Update is called once per frame
	public void Update () {
		
	}

    public void updateHealth()
    {
        float ratio = hitpoints / maxHitpoints;
        currHealth.rectTransform.localScale = new Vector3(ratio, 1, 1);
        healthRate.text = (ratio*100).ToString() + '%';
        if (hitpoints < 0)
        {
            GameOver.text = "Game Over";
            Time.timeScale = 0;
        }
    }

    public void TakeDamage(float dmg)
    {
        hitpoints -= dmg;
        if(hitpoints < 0)
        {
            hitpoints = 0;
            Debug.Log("Dead!");
            GameOver.text = "Game Over";
            Time.timeScale = 0;
        }
        
    }

    public void Heal(float health)
    {
        hitpoints += health;
        if(hitpoints > maxHitpoints)
        {
            hitpoints = maxHitpoints;
            
        }
    }

    public void updateScore(float amt)
    {
        score += amt;
        Score.text = "Score: " + (score).ToString();
    }

}
