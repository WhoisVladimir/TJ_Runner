using UnityEngine;
using UnityEngine.UI;

public class PngButton : MonoBehaviour
{
    #region Serialized fields

    [SerializeField] private Image buttonImg;
    #endregion

    #region Unity callbacks

    private void Awake()
    {
        buttonImg.alphaHitTestMinimumThreshold = 0.01f;
    }
    #endregion
}
