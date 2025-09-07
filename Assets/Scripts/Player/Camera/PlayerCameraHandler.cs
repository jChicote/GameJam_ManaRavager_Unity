using Unity.Cinemachine;
using UnityEngine;

public class PlayerCameraHandler : MonoBehaviour
{

    public CinemachineCamera PlayerCamera;
    public Transform CameraForwardTrackingPoint;

    private CinemachineRotationComposer _rotationComposer;

    private void Start()
    {
        _rotationComposer = PlayerCamera.GetComponent<CinemachineRotationComposer>();
    }

    private void Update()
    {
        SetTrackingOffset();
    }

    private void SetTrackingOffset()
    {
        _rotationComposer.TargetOffset = CameraForwardTrackingPoint.localPosition;
    }

}