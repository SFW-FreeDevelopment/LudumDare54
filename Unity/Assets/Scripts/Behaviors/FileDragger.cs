using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace LD54.Behaviors
{
    public class FileDragger : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        private Image _image;
        private Vector3 _startPosition;
        
        private void Start()
        {
            _image = GetComponent<Image>();
            _startPosition = transform.position;
        }
        
        public void OnBeginDrag(PointerEventData eventData)
        {
            _startPosition = transform.position;
            _image.raycastTarget = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = eventData.position;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _image.raycastTarget = true;
        }
    }
}