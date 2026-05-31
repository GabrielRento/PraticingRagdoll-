using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    public Transform player;
    public UIManager uiManager;
    public GameObject winUI;

    [Header("Settings")]
    [SerializeField] private float restartDelay = 4f;
    [SerializeField] private int targetDistance = 127;

    private int lastValue;
    private float idleTime;

    void Start()
    {
        winUI.SetActive(false);
    }

    void Update()
    {
        float posX = player.position.x;
        int value = Mathf.Abs(Mathf.FloorToInt(posX));

        uiManager.Distance(value);

        if (value >= targetDistance)
        {
            winUI.SetActive(true);
        }

        if (value == lastValue)
        {
            idleTime += Time.deltaTime;

            if (idleTime >= restartDelay)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        else
        {
            idleTime = 0f;
        }

        lastValue = value;
    }
}