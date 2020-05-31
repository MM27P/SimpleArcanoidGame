using System.Linq;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private int currentScore;
    [SerializeField]
    private static GameController instance;
    [SerializeField]
    private int lifesCount;
    [SerializeField]
    private UIController uIController;
    [SerializeField]
    private BallScript ball;
    [SerializeField]
    private PlayerPlatformControlScript playerPlatform;
    [SerializeField]
    private PointsController PointsController;
    [SerializeField]
    private FileManager fileManager;

    private Vector3 pauseForceBall;
    [SerializeField]
    private bool loadFile = false;
    public int CurrentScore { get { return currentScore; } }
    public int CurrentLifes { get { return lifesCount; } }
    public static GameController Instance
    {
        get
        {
            return instance;
        }
    }

    private GameController() { }

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
        if (loadFile)
        {
            LoadSaveFileObject();
        }
    }

    public void AddScore(int score)
    {
        currentScore += score;
        uIController.UpdateScoreText(currentScore);
    }

    public void LoseLife()
    {
        lifesCount -= 1;
        uIController.UpdateLifeImageList(lifesCount);
        if (lifesCount <= 0)
        {
            LoseGame();
        }
    }

    public void LoseGame()
    {
        uIController.ShowLoseText();
    }

    public void WinGame()
    {
        uIController.ShowWinText();
    }

    public void PauseGame()
    {
        var ballRig = ball.GetComponent<Rigidbody>();
        pauseForceBall = ballRig.velocity;
        ballRig.velocity = Vector3.zero;
        ball.gameObject.SetActive(false);
        playerPlatform.gameObject.SetActive(false);
    }

    public void ContinueGame()
    {
        ball.gameObject.SetActive(true);
        var ballRig = ball.GetComponent<Rigidbody>();
        ballRig.velocity = pauseForceBall;
        playerPlatform.gameObject.SetActive(true);
    }

    public void SaveFileObject()
    {
        SaveFileObject saveFileObject = new SaveFileObject();
        saveFileObject.gameController_LifeCounts = lifesCount;
        saveFileObject.gameController_Score = currentScore;
        saveFileObject.ball_Position = ball.GetCurrentPosition();
        saveFileObject.ball_Velocity = ball.GetCurrentForce();
        saveFileObject.platform_Position = playerPlatform.GetCurrentPosition();
        saveFileObject.pointsIdsInstance = PointsController.GetPointsInstancesList();
        fileManager.Save(saveFileObject);
        Debug.Log("File save");
    }

    public void LoadSaveFileObject()
    {
        SaveFileObject saveFileObject = fileManager.Load();
        lifesCount = saveFileObject.gameController_LifeCounts;
        currentScore = saveFileObject.gameController_Score;
        ball.SetCurrentPosition(saveFileObject.ball_Position);
        ball.SetCurrentForce(saveFileObject.ball_Velocity);
        playerPlatform.SetCurrentPosition(saveFileObject.platform_Position);
        PointsController.LoadPointsInstancesList(saveFileObject.pointsIdsInstance);
        uIController.UpdateLifeImageList(lifesCount);
        uIController.UpdateScoreText(currentScore);
    }
}
