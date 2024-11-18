using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FruityMixPlayer : MonoBehaviour
{

    public int score = 0;
    public int penalty = 10; // Penalty for colliding with bad fruits
    public int life;    //the life of player
    public GameObject lifeUIOne;
    public GameObject lifeUITwo;
    public GameObject lifeUIThree;

    public float movementSpeed = 5f; // Speed of player movement
    public float clampX = 3f; // Maximum horizontal position of the player

    private Rigidbody2D rb;
    Animator player;

    public TextMeshProUGUI ScoreTxt;
    public TextMeshProUGUI ScoreTxtGOver;

    public GameObject penaltyTxt;

    public FruitFall fruitgame;


    



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("GoodFruit"))
        {
            // Increase score when colliding with good fruits
            score += 1;
            Destroy(other.gameObject); // Destroy the collided good fruit
            player.Play("collect");
            ScoreTxt.text = score.ToString();
            ScoreTxtGOver.text = score.ToString();

        }
        else if (other.CompareTag("BadFruit"))
        {
            // Decrease score or apply penalty when colliding with bad fruits
            score -= penalty;
            Destroy(other.gameObject); // Destroy the collided bad fruit

            player.Play("bomb");

            penaltyTxt.SetActive(true);
            Invoke("penaltyOff", 0.5f);
            life--;

        }
        else if (other.CompareTag("life"))
        {
            life++;
            Destroy(other.gameObject);
        }
    }

    void penaltyOff()
    {
        penaltyTxt.SetActive(false);
    }

    void gameEnd()
    {
        
        fruitgame.GameOver();
    }
      


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<Animator>();
        
    }

    void Update()
    {
        if (score <= 0)
        {
            score = 0;
        }






        // Check for touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Convert touch position to world space
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));

            // Move player horizontally towards touch position
            Vector2 targetPosition = new Vector2(Mathf.Clamp(touchPosition.x, -clampX, clampX), transform.position.y);
            rb.MovePosition(Vector2.Lerp(rb.position, targetPosition, movementSpeed * Time.deltaTime));
        }

        //ScoreTxt.text = score.ToString();
        //ScoreTxtGOver.text = score.ToString();

       
        if (life <= 0)
        {

            Invoke("gameEnd", 2);
            lifeUIOne.SetActive(false);
            lifeUITwo.SetActive(false);
            lifeUIThree.SetActive(false);

        }
        else if (life == 1)
        {
            lifeUIOne.SetActive(true);
            lifeUITwo.SetActive(false);
            lifeUIThree.SetActive(false);
        }
        else if (life == 2)
        {
            lifeUIOne.SetActive(true);
            lifeUITwo.SetActive(true);
            lifeUIThree.SetActive(false);
        }
        else if (life == 3)
        {
            lifeUIOne.SetActive(true);
            lifeUITwo.SetActive(true);
            lifeUIThree.SetActive(true);
        }
        else if (life >= 3)
        {
            life = 3;
        }




    }


}
