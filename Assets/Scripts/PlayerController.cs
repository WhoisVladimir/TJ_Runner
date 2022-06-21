using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Serialized fields

    [SerializeField] private Animator animator;
    [SerializeField] private CharacterController charController;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float sideMotionSpeed = 1f;
    #endregion

    #region Fields

    private bool isGameplayActive;

    private bool canRun = false;
    private string runTransitionName = "CanRun";

    private string xMouseName = "Mouse X";

    #endregion

    #region Unity callbacks

    private void Start()
    {
        isGameplayActive = true;
    }

    private void OnEnable()
    {
        LevelManager.OnStopGameplay += DisableController;
    }

    private void OnDisable()
    {
        LevelManager.OnStopGameplay -= DisableController;
    }

    private void Update()
    {
        CheckInputAction();
    }

    #endregion

    #region Private methods

    private void CheckInputAction()
    {
        if (isGameplayActive && Input.GetMouseButton(0))
        {
            if (!canRun)
            {
                SwitchRunAnimationState(true);
            }

            MovePlayer();
        }

        if (isGameplayActive && Input.GetMouseButtonUp(0))
        {
            SwitchRunAnimationState(false);
        }
    }

    private void MovePlayer()
    {
        float sideMotion = 0f;
        if(isGameplayActive) sideMotion = Input.GetAxisRaw(xMouseName);
        var motion = new Vector3(sideMotion * sideMotionSpeed, 0, speed) * Time.deltaTime;

        charController.Move(motion);
    }

    private void DisableController()
    {
        isGameplayActive = false;
        if (canRun)
        {
            var switchData = (false, 1.5f);
            StartCoroutine("HoldSwitchRunAnimation", switchData);
        }
    }

    private void SwitchRunAnimationState(bool isActive)
    {
        canRun = isActive;
        animator.SetBool(runTransitionName, canRun);
    }

    private IEnumerator HoldSwitchRunAnimation((bool isActive, float sec) data)
    {
        var timer = 0f;
        while (timer < data.sec)
        {
            MovePlayer();
            timer += Time.deltaTime;

            yield return null;
        }
        SwitchRunAnimationState(data.isActive);
    }

    #endregion
}
