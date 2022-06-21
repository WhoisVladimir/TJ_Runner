using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    #region Events

    public static event UnityAction OnCoinPickUp;
    #endregion

    #region Serialized fields

    [SerializeField] private ParticleSystem effect;
    [SerializeField] private MeshRenderer mesh;
    [SerializeField] private GameObject player;
    [SerializeField] private Animator animator;
    #endregion

    #region Unity callbacks

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(player.tag))
        {
            OnCoinPickUp?.Invoke();
            animator.enabled = false;
            mesh.enabled = false;
            effect.Play();
            Destroy(gameObject, effect.main.duration);
        }
    }
    #endregion
}
