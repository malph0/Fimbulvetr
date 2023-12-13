using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name == "Moon(Clone)")
        {
            GameBehavior.Instance.moonCount += 1;
        }
        else if (gameObject.name == "Venus(Clone)")
        {
            GameBehavior.Instance.venusCount += 1;
        }
    }
    private void OnDestroy()
    {
        if (gameObject.name == "Moon(Clone)")
        {
            GameBehavior.Instance.moonCount -= 1;
        }
        else if (gameObject.name == "Venus(Clone)")
        {
            GameBehavior.Instance.venusCount -= 1;
        }
    }
}
