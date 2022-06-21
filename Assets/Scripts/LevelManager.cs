using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    #region Events

    public static event UnityAction OnStopGameplay;
    #endregion

    #region Properties

    public static LevelManager Instance { get; private set; }
    #endregion

    #region Unity callbacks

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else DestroyImmediate(gameObject);
    }

    private void OnEnable()
    {
        Finish.OnFinishReach += StopGameplay;
    }

    private void OnDisable()
    {
        Finish.OnFinishReach -= StopGameplay;
    }
    #endregion

    #region Private methods

    private void StopGameplay()
    {
        OnStopGameplay?.Invoke();
    }
    #endregion

    #region Public methods

    public void RestartLevel()
    {
        var scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
    #endregion
}
