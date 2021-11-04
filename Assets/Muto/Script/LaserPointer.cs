using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPointer : MonoBehaviour
{
    [SerializeField] Transform _pivot = default;
    [SerializeField] float _rayDistance = 5f;
    [SerializeField] LayerMask _objectLayer = default;
    [SerializeField] LayerMask _playerLayer = default;
    [SerializeField] LineRenderer _lineRenderer = default;
    
    private void Update()
    {
        if(_pivot && _lineRenderer)
        {
            var ray = Physics2D.Raycast(_pivot.transform.position, _pivot.transform.up, _rayDistance, _objectLayer);
            var ray1 = Physics2D.Raycast(_pivot.transform.position, _pivot.transform.up, _rayDistance, _playerLayer);
            Debug.DrawRay(_pivot.transform.position, _pivot.transform.up * _rayDistance, Color.red);
            
            if(ray)
            {
                _lineRenderer.SetPosition(1, new Vector3(ray.point.x, ray.point.y, 0.1f));

                if(ray1)
                {
                    var dis = Vector2.Distance(_pivot.transform.position, ray.collider.transform.position);
                    var dis1 = Vector2.Distance(_pivot.transform.position, ray1.collider.transform.position);

                    if(dis > dis1)
                    {
                        var player = ray1.collider.gameObject.GetComponent<PlayerLifeManager>();
                        player.Damage();
                        Debug.Log("hit");
                    }
                }
            }
            else if(ray1)
            {
                var player = ray1.collider.gameObject.GetComponent<PlayerLifeManager>();
                player.Damage();
                Debug.Log("hit");
            }
            else
            {
                _lineRenderer.SetPosition(1, _pivot.transform.up * _rayDistance);
            }
        }
    }
}
