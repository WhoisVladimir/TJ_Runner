using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    #region Serialized fields

    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private short coinsCount = 1;

    #endregion

    #region Unity callbacks

    private void Start()
    {
        var instancePos = transform.position;

        GameObject instance = null;

        for (int i = 0; i < coinsCount; i++)
        {
            if(i > 0)
            {
                instancePos = instance.transform.TransformPoint(Vector3.forward * 1.5f);
            }

            instance = Instantiate(coinPrefab, instancePos, Quaternion.identity);
        }
    }
    #endregion
}
