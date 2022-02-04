using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class realpaint : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public Camera cam;
    public Texture2D brush;
    public Vector2Int textureArea; 
    Texture2D texture;
    Vector2Int halfBrush;
    Color32[] brushC32;
    Color32[] texPixels;
    int xPos, yPos, tPos;
    // Start is called before the first frame update
    void Start()
    {
        //Fýrça ortasý
        halfBrush = new Vector2Int(brush.width / 2, brush.height / 2);

        texture = new Texture2D(textureArea.x, textureArea.y, TextureFormat.ARGB32, false);
        meshRenderer.material.mainTexture = texture;
        brushC32 = brush.GetPixels32();
        texPixels = texture.GetPixels32();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitData;

            if (Physics.Raycast(ray, out hitData) && hitData.collider.tag == "realpaint")
            {
                Paint(hitData.textureCoord);
            }
        }
    }
    
    void Paint(Vector2 coordinate)
    {
        coordinate.x *= texture.width;
        coordinate.y *= texture.height;

        for (int x = 0; x < brush.width; x++)
        {
            xPos = x - halfBrush.x + (int)coordinate.x;
            if (xPos < 0 || xPos >= texture.width)
            {
                continue;
            }
            for (int y = 0; y < brush.height; y++)
            {
                yPos = y - halfBrush.y + (int)coordinate.y;
                if (yPos < 0 || yPos >= texture.width)
                {
                    continue;
                }
                if (brushC32[x + (y * brush.width)].a > 0f)
                {
                    tPos = xPos + (texture.width * yPos);
                    if (brushC32[x + (y * brush.width)].r < texPixels[tPos].r)
                    {
                        texPixels[tPos] = brushC32[x + (y * brush.width)];
                    }
                }
            }
        }
        texture.SetPixels32(texPixels);
        texture.Apply();
    }
}
