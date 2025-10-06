using UnityEngine;

public class AnimationToRagdollHandler : MonoBehaviour
{

    public GameObject RigSource;

    private Rigidbody[] _ragdollRigidbodies;
    private Collider[] _ragdollColliders;
    private bool _isRagdoll;

    private void Start()
    {
        _ragdollRigidbodies = RigSource.GetComponentsInChildren<Rigidbody>();
        _ragdollColliders = RigSource.GetComponentsInChildren<Collider>();

        // Ensure in animation mode
        ToggleRagdoll(false);
    }

    public void ToggleRagdoll(bool isRagdoll)
    {
        _isRagdoll = isRagdoll;
        foreach (var _collider in _ragdollColliders)
            _collider.enabled = _isRagdoll;

        foreach (var _rigidbody in _ragdollRigidbodies)
            _rigidbody.isKinematic = !_isRagdoll;
    }

}