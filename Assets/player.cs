using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Movement : MonoBehaviour
{
    public float jumpforce;
    public float speed;
    public Vector2 inputVector;
    public Rigidbody rigidBody;
    public Vector3 velocity;
    public float velocityMagnitude;
    public bool canjump;
    public int collectedItems;
    public Collision contraloquechoque;
    public TMPro.TextMeshProUGUI ScoreText;

    // Start is called before the first frame update
    

    // Update is called once per frame
    
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        canjump = true;
    }
void Update()
    {
        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = Input.GetAxis("Vertical");
        transform.Translate(inputVector.x * speed, 0f, inputVector.y * speed);

        velocity = rigidBody.velocity;
        velocityMagnitude = velocity.magnitude;

        if (Input.GetKeyDown(KeyCode.Space) && canjump)
        {
            rigidBody.AddForce(0f, jumpforce, 0f, ForceMode.Impulse);
            canjump = false;

        }
    }
private void OnCollisionEnter(Collision contraloquechoque)
    {
        Debug.Log("choque contra: " + contraloquechoque.gameObject.name);
        if (contraloquechoque.gameObject.CompareTag("piso"))
        {
            canjump = true;
        }

        if (contraloquechoque.gameObject.CompareTag("muerte"))
        {
            SceneManager.LoadScene("motores escena oscar");
        }

        if (contraloquechoque.gameObject.CompareTag("carlos"))
        {
            Destroy(contraloquechoque.gameObject);
            collectedItems++;
            ScoreText.text = collectedItems.ToString();
         }

        if (collectedItems == 4)
        {
            SceneManager.LoadScene(1);
        }
    }
}
