using UnityEngine;

// 影を選択した瞬間パチッと光るやつのコード
public class WhiteSelect : MonoBehaviour {

    Renderer rend;
    Color color;
    float alpha;

    void Start () {
        rend = GetComponent<Renderer>();
        alpha = 1;
    }
	
    void Update ()
    {
        //フェードアウト
        alpha = alpha - Time.deltaTime * 3f;
        rend.material.color = new Color(1f, 1f, 1f, alpha);

        if (0 > alpha)
        {
            Destroy(this.gameObject);
        }
    }
}
