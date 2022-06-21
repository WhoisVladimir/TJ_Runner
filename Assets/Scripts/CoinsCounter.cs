using UnityEngine;
using TMPro;

public class CoinsCounter : MonoBehaviour
{
    #region Serialized fields

    [SerializeField] TextMeshProUGUI coinsCounterTM;
    #endregion

    #region Fields

    private int coinsCount = 0;
    #endregion

    #region Unity callbacks

    private void Awake()
    {
        coinsCounterTM.text = coinsCount.ToString();
    }
    private void OnEnable()
    {
        Coin.OnCoinPickUp += AddCoin;
    }

    private void OnDisable()
    {
        Coin.OnCoinPickUp -= AddCoin;
    }

    #endregion

    #region Private methods

    private void AddCoin()
    {
        coinsCount++;
        coinsCounterTM.text = coinsCount.ToString();
    }
    #endregion
}
