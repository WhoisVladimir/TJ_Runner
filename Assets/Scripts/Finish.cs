using UnityEngine;
using UnityEngine.Events;

public class Finish : MonoBehaviour
{
    #region Events

    public static UnityAction OnFinishReach;
    #endregion

    #region Serialized fields

    [SerializeField] private GameObject player;
    #endregion

    #region Unity callbacks

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(player.transform.tag))
        {
            OnFinishReach?.Invoke();
        }
    }
    #endregion
}