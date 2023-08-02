using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitMaterial : MonoBehaviour
{
    List<Material> _materials;
    Material _hitMaterial;
    bool _isFlashing = false;
    private void Awake()
    {
        _hitMaterial = Resources.Load<Material>("Feedbacks/Materials/HitMaterial") as Material;
    }
    public void PlayFeedback() 
    {
        if (!_isFlashing)
        {
            _isFlashing = true;
            Material[] defaultMAt1 = GetComponent<Renderer>().materials;
            Material[] mats = GetComponent<Renderer>().materials;

            
            if (mats.Length>1)
            {
                for (int i = 0; i < mats.Length; i++)
                {
                    mats[i] = _hitMaterial;
                    if (i== mats.Length-1)
                    {
                   
                        for (int k = 0; k < mats.Length; k++)
                        {
                            GetComponent<Renderer>().materials = mats;
                        }
                        LeanTween.delayedCall(gameObject, 0.15f, () => {
                            GetComponent<Renderer>().materials = defaultMAt1;
                            _isFlashing = false;
                        });
                    }
                }

            }
            if (mats.Length==1)
            {
                Material defaultMAt = mats[0];
                mats[0] = _hitMaterial;
                GetComponent<MeshRenderer>().materials = mats;
                LeanTween.delayedCall(gameObject, 0.15f, () => {
                    mats[0] = defaultMAt;
                    GetComponent<MeshRenderer>().materials = mats;
                    _isFlashing = false;
                });
            }
        }




    }
}
