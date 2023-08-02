using UnityEditor;
using Object = UnityEngine.Object;

namespace Obvious.Soap.Editor
{
    [CustomEditor(typeof(Object), true)]
    [CanEditMultipleObjects]
    internal class ObjectEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            var targetType = serializedObject.targetObject.GetType();
            var customEditorType = typeof(CustomEditor);
            var customEditors = targetType.GetCustomAttributes(customEditorType, true);
        
            if (customEditors.Length == 0)
            {
                DrawDefaultInspector();
            }
            else
            {
                // Custom editor exists, handle it accordingly
                base.OnInspectorGUI();
            }
        }
    }
}
