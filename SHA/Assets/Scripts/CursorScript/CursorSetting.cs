using UnityEngine;

// Xボタンでカーソルを表示・非表示
public class CursorSetting : MonoBehaviour {

    public Texture2D cursor;       // カーソルを取得
    public bool cursorOFF = false; // MP(Script)から命令

    bool CursorAppear;             // マウスが表示・非表示

    void Start()
	{
        Cursor.SetCursor(cursor,
                         new Vector2(cursor.width / 2, cursor.height / 2),
                         CursorMode.ForceSoftware);

        CursorAppear = false;
    }

    void Update()
    {
        // Xボタンでカーソル表示・非表示を切り替え
        if(Input.GetKeyDown(KeyCode.X))
        {
            CursorAppear = !CursorAppear;
        }
        if (cursorOFF)
        {
            CursorAppear = !CursorAppear;
            cursorOFF = false;
        }
        if (CursorAppear)
        {
            Cursor.visible = true;
            // カーソルのロック解除
            Cursor.lockState = CursorLockMode.None;
        }
        if (!CursorAppear)
        {
            Cursor.visible = false;
            // カーソルを中心にロック
            Cursor.lockState = CursorLockMode.Locked;
        }
        
        if (Input.GetMouseButtonUp(0) &&
            CursorAppear)
        {
            CursorAppear = !CursorAppear;
        }
    }
}
