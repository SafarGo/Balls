using UnityEngine;
using TMPro;

public class MatchController : MonoBehaviour
{
    [Header("Целевой счёт (вводится игроком)")]
    public int goalsA_target = 3;
    public int goalsB_target = 2;

    [Header("Текущее количество голов")]
    public int goalsA = 0;
    public int goalsB = 0;

    [Header("Время матча (секунды)")]
    public float matchTime = 90f;
    private float timer;

    [Header("Transform мячей")]
    public Transform ball1;
    public Transform ball2;

    [Header("Тексты")]
    public TMP_Text scoreA;
    public TMP_Text scoreB;
    public TMP_Text time;

    public Transform resetposition1;
    public Transform resetposition2;
    public GameObject b1;
    public GameObject b2;
    bool isST  = true;
    public TMP_InputField inputFieldA;
    public TMP_InputField inputFieldB;
    public BallController ballControllerA;
    public BallController ballControllerB;

    
    void Start()
    {
        timer = -40;
    }

    void Update()
    {
       
        if (timer >=0 && isST)
        {
            ResetBalls();
            Destroy(b1);
            Destroy(b2);
            goalsA = 0;
            goalsB = 0;
            isST = false;
            Debug.Log("Game");
            ballControllerA.club = inputFieldA.text;
            ballControllerB.club = inputFieldB.text;
        }
            timer += Time.deltaTime * 1.48f;
            time.text = timer.ToString("F0") + "'";
            scoreA.text = goalsA.ToString();
            scoreB.text = goalsB.ToString();
            if (timer >= matchTime)
            {
                EndGame();
            Time.timeScale = 0;
            }
        
        Debug.Log($"{goalsA}:{goalsB}");
        
    }

    // Вызывается, когда мяч попал в ворота
    public void OnGoalScored(string club)
    {
        Debug.Log("Goal");
        if (club == "A")
        {
            goalsA++;
        }
        else if (club == "B")
        {
            goalsB++;
        }
        ResetBalls(); // Вернуть мячи в центр, если нужно
    }

    // Сброс мячей в центр (реализуй по-своему)
    public void ResetBalls()
    {
        ball1.transform.position = resetposition1.position;
        ball2.transform.position = resetposition2.position;
    }

    void EndGame()
    {
        Debug.Log("Матч окончен! Итоговый счет: " + goalsA + ":" + goalsB);
    }

 
}