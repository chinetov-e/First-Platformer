using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public void SelfDestroy()
    {
        Destroy(gameObject);
    }
}
