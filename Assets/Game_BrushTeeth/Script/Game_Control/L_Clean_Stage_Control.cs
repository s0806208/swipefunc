using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_Clean_Stage_Control : MonoBehaviour
{
    [SerializeField] public int Targets;//  number of the childobjects //
    [SerializeField] private int Cleaness;// when reach to zero = VICTORY! //
    [SerializeField] private GameObject Tooth_GameObject;
    [SerializeField] private GameObject Enemy;
    [SerializeField] private GameObject Victory_Anim;
    [SerializeField] private GameObject GameControl;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        CountChildObjects();
        animator.SetTrigger("GameStart");
    }

    private void CountChildObjects()
    {
        Targets = CountChildren(Tooth_GameObject) +
                  CountChildren(Enemy);
        Cleaness = Targets;
    }

    private int CountChildren(GameObject gameObject)
    {
        if (gameObject == null)
        {
            return 0; 
        }

        return gameObject.transform.childCount;
    }
    private bool Victory = false;
    // Update is called once per frame
    void Update()
    {
        Cleaness = Targets;
        if (Cleaness == 0 & Victory == false)
        {
            Victory = true;
            Debug.Log("Hehehehehe");
            Victory_Anim.SetActive(true);
            Cursor.visible = false;
            animator.SetTrigger("GameOver");
        }
    }
}
