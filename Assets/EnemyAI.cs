using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class EnemyAI : MonoBehaviour {
    public HUDScript HUDScript;

    public Text Score;
    public int score = 0;
    public Transform Player;
    public float ChaseSpeed = 5f;
    public float Range = 5f;
    public float CurrentSpeed;
    public double health;
    public float timer;
    public float cooldown = 3f;

    public AudioSource source;
    public AudioClip groansound;




    // Use this for initialization
    void Start () {
        health = 100;
        source = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		if(Vector3.Distance(transform.position, Player.position) <= Range)
        {
            //Rotate
            Vector3 vectorToTarget = Player.position - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, Time.deltaTime * CurrentSpeed);

            transform.LookAt(Player);
            //Follow
            CurrentSpeed = ChaseSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, Player.position - transform.forward * 2, CurrentSpeed);

            timer += Time.deltaTime;
            if (transform.position == Player.position - transform.forward * 2 && timer >= cooldown)
            {
                HUDScript.TakeDamage(10);
                HUDScript.updateHealth();
                timer = 0;
                
            }
        }
	}

    IEnumerable Wait(float duration)
    {
        yield return new WaitForSeconds(duration);
    }

    void OnTriggerEnter(Collider collided)
    {

        if (collided.gameObject.tag == "bullet" && health <= 0)
        {
            Destroy(gameObject);
            HUDScript.updateScore(50);
            



        }
        else if (collided.gameObject.tag == "bullet")
            source.PlayOneShot(groansound);
            health -= 34;
            HUDScript.updateScore(10);
     
    }
}
