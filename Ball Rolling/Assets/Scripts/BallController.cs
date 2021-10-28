using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    private Rigidbody _rb;
    public float speed;
    private int _count;
    public Text countText;
    public Text winText;
    public GameObject startText;
    public Text timerText;
    public GameObject restartText;

    private Vector3 _reset;
    private float _startTime;
    private int _num;
    private float _time;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _count = 0;
        SetCountText();
        winText.text = "";
        timerText.text = "";
        _reset = transform.position;
        restartText.SetActive(false);

        _num = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //num is so thet this only happens once and it only starts counting after this is done
         if(transform.position != _reset && _num == 0)
        {
            startText.SetActive(false);
            _startTime = Time.time;

            _num++;
        }
        if(_num > 0 && winText.text == "")
        {
            _time = Time.time - _startTime;

            string seconds = _time.ToString("f2");

            timerText.text = seconds + "s";
            
            if(_time >= 120)
            {
                winText.text = "Level Failed!";
            }
        }
        if(winText.text != "")
        {
            restartText.SetActive(true);
            if(Input.GetKeyDown(KeyCode.R))
            {
                string currentSceneName = SceneManager.GetActiveScene().name;
                SceneManager.LoadScene(currentSceneName);
            }
        }
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        _rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            _count++;
            SetCountText();
        }
        if (other.gameObject.CompareTag("TP"))
        {
            if (transform.position.x < 0)
            {
                transform.position = new Vector3(-transform.position.x - 0.25f, transform.position.y, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(-transform.position.x + 0.25f, transform.position.y, transform.position.z);
            }
        }
        if (other.gameObject.CompareTag("Goal"))
        {
            if(_count >= 101)
            {
                winText.text = "You Win!";
            }
            else
            {
                winText.text = "Level Failed!";
            }
        }
        if (other.gameObject.CompareTag("Enemy"))
        {

            winText.text = "Level Failed!";
            restartText.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + _count.ToString();
    }
}
