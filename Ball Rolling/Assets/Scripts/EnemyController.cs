using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float movementSpeed = 3;
    public GameObject startText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (!startText.activeSelf)
        {
            transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            float[] turns = { 90, -90, 180 };
            int turnIndex = Random.Range(0, 2);
            transform.Rotate(transform.rotation.x, turns[turnIndex], transform.rotation.z);
        }
    }
}
