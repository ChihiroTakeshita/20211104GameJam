using UnityEngine;

public class BlockController : MonoBehaviour
{
    public bool isLast = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(isLast)
        {
            this.transform.position += new Vector3(0, 1, 0);
        }
    }
}
