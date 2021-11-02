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
    public Slider slider;
    public float jumpForce;

    private bool grounded;
    private Vector3 _reset;
    private float _startTime;
    private int _num;
    private float _time;
    private float _power;

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
        _power = 1f;
        grounded = true;

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
        slider.value += _power * Time.deltaTime;
        if (slider.value == slider.maxValue || slider.value == slider.minValue)
        {
            _power = -_power;
        }
        if (Input.GetMouseButtonDown(0))
        {
            _rb.AddRelativeForce(Vector3.forward * slider.value * speed, ForceMode.Impulse);
            _count++;
            SetCountText();
        }
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        //float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");

        //Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            winText.text = "Level Failed!";
            restartText.SetActive(true);
            gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("deathPlane"))
        {
            winText.text = "Level Failed!";
            restartText.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    void OnCollisionStay(Collision collisionInfo)
    {
        if (collisionInfo.collider.CompareTag("Ground"))
        {
            grounded = true;
        }
        if (collisionInfo.collider.CompareTag("Finish"))
        {
            winText.text = "You Win!";
        }
    }
    void OnCollisionExit(Collision collisionInfo)
    {
        if (collisionInfo.collider.CompareTag("Ground"))
        {
            grounded = false;
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + _count.ToString();
    }
}
