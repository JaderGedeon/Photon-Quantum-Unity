using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VestirRoupa : MonoBehaviour
{

    public Transform meuRig;
    public GameObject Roupa;


    [ContextMenu("Vestir")]
    public void Vestir()
    {
        if (meuRig != null && Roupa != null)
        {
            AlinharObjeto(Roupa, meuRig);
        }
    }


    void AlinharObjeto(GameObject _model, Transform _rig)
    {
       // GameObject _novoModelo = Instantiate(_model, transform);
        //obj = _novoModelo;

        SkinnedMeshRenderer[] _rend = _model.GetComponentsInChildren<SkinnedMeshRenderer>();
        for (int index = 0; index < _rend.Length; index++)
        {
            Transform[] bones = _rend[index].bones;

            Transform _novoRig = _rig.GetChild(0);

            _rend[index].rootBone = _novoRig;

            Transform[] children = _novoRig.GetComponentsInChildren<Transform>();

            for (int i = 0; i < bones.Length; i++)
                for (int a = 0; a < children.Length; a++)
                    if (bones[i].name == children[a].name)
                    {
                        bones[i] = children[a];
                        break;
                    }

            _rend[index].bones = bones;
        }

        Debug.Log("Rig Alinhado(" + _model.name + ")");

    }

}
