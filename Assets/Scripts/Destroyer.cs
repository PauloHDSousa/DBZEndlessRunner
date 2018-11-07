using UnityEngine;

public class Destroyer : MonoBehaviour {

    public float lifetime;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }
}
