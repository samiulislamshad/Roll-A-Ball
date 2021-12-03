using TMPro;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public GameObject coinPrefab;
    public GameObject bombPrefab;
    
   
    public TMP_Text scoreText;
    public TMP_Text gameOverScoreCountText;
    
    public GameObject gameOverText;
    public GameObject levelCompleteText;

    public GameObject scorePanel;
    public GameObject gameOverPanel;
    public GameObject optionPanel;
    
    public bool playerDead;
    public int score;
    public int level;


    [SerializeField] private int coinCount;
    [SerializeField] private int coinLimit;
    
    [SerializeField] private float countDown;

    [SerializeField] private GameObject player;
    
    void Start()
    {
        level = 1;
        coinLimit = 10;
        coinCount = 0;
        countDown = 5f;
        score = 0;
        playerDead = false;
        gameOverPanel.SetActive(false);
        optionPanel.SetActive(false);
        scorePanel.SetActive(true);
        gameOverText.SetActive(false);
        levelCompleteText.SetActive(false);
        InvokeRepeating(nameof(TemporaryUpdateMethod),2f,0.02f);
    }

    private void TemporaryUpdateMethod()
    {
        SpawnObject();
        scoreText.text = score.ToString();
        gameOverScoreCountText.text = score.ToString();

        if (score >= coinLimit)
        {
            player.GetComponent<PlayerController>().canMove = false;
            player.GetComponent<Rigidbody>().velocity= Vector3.zero;
            scorePanel.SetActive(false);
            gameOverPanel.SetActive(true);
            gameOverText.SetActive(false);
            levelCompleteText.SetActive(true);
        }

        if (playerDead)
        {
            scorePanel.SetActive(false);
            gameOverPanel.SetActive(true);
            levelCompleteText.SetActive(false);
            gameOverText.SetActive(true);
        }
    }

    private void SpawnObject()
    {
        if (countDown > 0)
        {
            countDown -= Time.deltaTime;
        }
        else
        {
            if (coinCount < coinLimit)
            {
                bool randBool = Random.value > 0.5;
                Instantiate(randBool ? coinPrefab : bombPrefab, RandomPos(), quaternion.identity);
                if (randBool)
                    coinCount++;
            }
            else
            {
                Instantiate(bombPrefab, RandomPos(), quaternion.identity);
            }
            countDown = Random.Range(2, 5);
        }
    }

    private Vector3 RandomPos()
    {
        return new Vector3(Random.Range(-23, 23), 1.5f, Random.Range(-23, 23));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin") || other.gameObject.CompareTag("Bomb"))
        {
            transform.position = RandomPos();
        }
    }
}
