using UnityEngine;

public class LookInfo : MonoBehaviour
{
    public float distance = 5f;

    GameObject last;

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, distance))
        {
            var info = hit.collider.GetComponentInParent<ShowInfo>();
            if (info != null)
            {
                if (last != info.gameObject)
                {
                    if (last != null) last.GetComponent<ShowInfo>().Hide();
                    info.Show();
                    last = info.gameObject;
                }
                return;
            }
        }

        if (last != null)
        {
            last.GetComponent<ShowInfo>().Hide();
            last = null;
        }
    }
}