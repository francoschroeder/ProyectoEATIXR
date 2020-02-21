using System.Collections;
using UnityEngine;

public class PhotoSwitch : MonoBehaviour {
    private ArrayList children;
    private int actualPos = 0;

    // Use this for initialization
    void Start() {
        getChildren();
        activateChild(actualPos);
    }

    // Update is called once per frame
    void Update() {
        if (clickPerformed())
            changeChild();
    }

    private void getChildren() {
        children = new ArrayList();

        foreach (Transform tr in transform)
           children.Add(tr.gameObject);
    }

    private void activateChild(int pos) {
        ((GameObject)children[pos]).SetActive(true);
    }

    private void deactivateChild(int pos) {
        ((GameObject)children[pos]).SetActive(false);
    }

    private bool clickPerformed() {
        return Input.GetKeyDown(KeyCode.Mouse0);
    }

    public void changeChild() {
        for (int i = 0; i < children.Count; i++)
            deactivateChild(i);
        
        updateActualPos();
        activateChild(actualPos);
    }

    public void updateActualPos() {
        actualPos = (actualPos + 1) % children.Count;
    }
}
