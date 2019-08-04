using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(moveController))]
public class Player : MonoBehaviour {
    [System.Serializable]
    public class MouseInput
    {
        public Vector2 Damping;
        public Vector2 Senitivity;
    }
    [SerializeField]
    float speed;//移動速度
    [SerializeField]
    MouseInput MouseControl;//滑鼠輸入
    InputController playerInput;//輸入控制器
    Vector2 mouseInput;//滑鼠轉換為2元座標
    private moveController m_moveController;//移動控制器
    public moveController moveController//防呆
    {
        get
        {
            if (m_moveController == null)
                m_moveController = GetComponent<moveController>();
            return m_moveController;
        }
    }
    private Crosshair m_Crosshair;
    private Crosshair Crosshair
    {
        get
        {
            if (m_Crosshair == null)
                m_Crosshair = GetComponentInChildren<Crosshair>();
            return m_Crosshair;
        }
    }
    private void Awake()
    {
        playerInput = GameManager.Instance.InputController;
        GameManager.Instance.LocalPlayer = this;
        
    }
	void Update () {
        Vector2 direction = new Vector2(playerInput.Vertical * speed, playerInput.Horizontal * speed);
        moveController.Move(direction);//移動功能
        mouseInput.x = Mathf.Lerp(mouseInput.x,playerInput.MouseInput.x, 1f/MouseControl.Damping.x) ;
        mouseInput.y = Mathf.Lerp(mouseInput.y, playerInput.MouseInput.y, 1f / MouseControl.Damping.y);
        transform.Rotate(Vector3.up * mouseInput.x * MouseControl.Senitivity.x);


        Crosshair.LookHeight(mouseInput.y * MouseControl.Senitivity.y);

	}
}
