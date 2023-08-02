using UnityEngine;
using UnityEngine.EventSystems;
using Obvious.Soap;
using UnityEngine.Events;
namespace YK.Controller
{
    public class Input : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField] ScriptableEventNoParam _onBeginDrag, _onDraging, _onDragUp;
        [SerializeField] Vector2Variable _firstPoint, _secondPoint;
        [SerializeField] UnityEvent _onLeftMove, _onRightMove,onRegularMove;
        public void OnBeginDrag(PointerEventData eventData)
        {
            _onBeginDrag?.Raise();
            _firstPoint.Value = eventData.position;
        }

        public void OnDrag(PointerEventData eventData)
        {
            _onDraging?.Raise();
            _secondPoint.Value = eventData.position;
            float distanceX = _secondPoint.Value.x - _firstPoint.Value.x;
            if (distanceX >= -100 && distanceX <= 100)
            {
                onRegularMove?.Invoke();
            }
            if (distanceX < -100)
            {
                _onLeftMove?.Invoke();
            }
           
            if (distanceX > 100)
            {
                _onRightMove?.Invoke();
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _onDragUp?.Raise();
            _secondPoint.Value = Vector2.zero;
            _firstPoint.Value = Vector2.zero;
        }
    }
}