using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_Enemy : MonoBehaviour
{
    private Ship_Manager manager;
    public GameObject bullet;

    private bool playDeathAnim = false;
    public float radius = 7.5f;
    public float speed = 1.5f;
    public bool offsetIsCenter = true;
    public Vector3 offset;

    private void Awake()
    {
        GameObject m = GameObject.FindGameObjectWithTag("MiniManager");
        manager = m.GetComponent<Ship_Manager>();
    }

    private void Start()
    {
        if (offsetIsCenter)
            offset = transform.position;
    }

    private void Update()
    {
        if (manager.gameManager.completedGoal == false)
        {
            transform.position = new Vector3(
                (radius * Mathf.Cos(Time.time * speed)) + offset.x,
                (radius / 8 * Mathf.Sin(Time.time * speed * 3)) + offset.y,
                offset.z);
        }

        if (playDeathAnim == true)
        {
            gameObject.GetComponent<Animation>().Play();
            gameObject.GetComponentInChildren<ParticleSystem>().Play();
            playDeathAnim = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (manager.gameManager.completedGoal == false)
        {
            manager.gameManager.completedGoal = true;
            playDeathAnim = true;
            manager.on = false;
            manager.explosion.Play();
        }
    }
}