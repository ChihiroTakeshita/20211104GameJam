using UnityEngine;

public class BlockController : MonoBehaviour
{
    public bool isLast = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag != "Player" && isLast)
        {
            this.transform.position += new Vector3(0, 1, 0);
        }
    }
}
