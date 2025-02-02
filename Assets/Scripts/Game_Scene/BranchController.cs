using UnityEngine;

public class BranchController : MonoBehaviour
{
    public static float bottomY = -20f;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < bottomY) {
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
            apScript.BranchMissed();
        }
    }
}
