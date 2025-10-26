 Shader "Hidden/GLLine"
{
    Properties
    {
        _Color ("Color", Color) = (0,1,0,1)
    }
    SubShader
    {
        Pass
        {
            ZTest Always       // Рисуем поверх всего
            ZWrite Off         // Не пишем в буфер глубины
            Cull Off           // Отображаем обе стороны
            Fog { Mode Off }   // Отключаем туман
            Blend SrcAlpha OneMinusSrcAlpha // Прозрачность

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
            };

            fixed4 _Color;

            v2f vert(appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                return _Color; // Цвет линии
            }
            ENDCG
        }
    }
}
