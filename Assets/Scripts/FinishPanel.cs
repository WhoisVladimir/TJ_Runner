using UnityEngine;

public class FinishPanel : MonoBehaviour
{
    #region Unity callbacks

    private void Awake()
    {
        LevelManager.OnStopGameplay += ViewPanel;
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        LevelManager.OnStopGameplay -= ViewPanel;
    }
    #endregion

    #region Private methods

    private void ViewPanel()
    {
        gameObject.SetActive(true);
    }
    #endregion
}
