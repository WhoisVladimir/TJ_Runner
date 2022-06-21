using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region Serialized fields

    [SerializeField] private Transform target;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float rotationSpeed = 1f;
    #endregion

    #region Fields

    private bool isGameplayActive;
    private Vector3 viewPoint;
    #endregion

    #region Unity callbacks

    private void OnEnable()
    {
        LevelManager.OnStopGameplay += DisableCamController;
    }

    private void OnDisable()
    {
        LevelManager.OnStopGameplay -= DisableCamController;
    }
    private void Start()
    {
        isGameplayActive = true;
        viewPoint = target.InverseTransformPoint(transform.position);
    }

    private void LateUpdate()
    {
        if (!isGameplayActive) return;
        MoveCamera();
        RotateCamera();
    }
    #endregion

    #region Private methods

    private void MoveCamera()
    {
        var currentViewPosition = target.TransformPoint(viewPoint);
        transform.position = Vector3.Lerp(transform.position, currentViewPosition, Time.fixedDeltaTime * speed);
    }

    private void RotateCamera()
    {
        var currentRotation = Quaternion.LookRotation((target.position - transform.position).normalized);
        transform.rotation = Quaternion.Lerp(transform.rotation, currentRotation, Time.fixedDeltaTime * rotationSpeed);
    }

    private void DisableCamController()
    {
        isGameplayActive = false;
    }
    #endregion
}
