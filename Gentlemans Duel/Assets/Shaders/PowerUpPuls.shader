// Shader created with Shader Forge v1.02 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.02;sub:START;pass:START;ps:flbk:,lico:1,lgpr:1,nrmq:1,limd:0,uamb:True,mssp:True,lmpd:False,lprd:False,rprd:False,enco:False,frtr:True,vitr:True,dbil:False,rmgx:True,rpth:0,hqsc:True,hqlp:False,tesm:0,blpr:0,bsrc:0,bdst:1,culm:0,dpts:2,wrdp:True,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:4043,x:32899,y:32699,varname:node_4043,prsc:2|emission-9197-OUT,custl-4270-OUT;n:type:ShaderForge.SFN_Tex2d,id:8595,x:31926,y:32869,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:_MainTex,prsc:2,ntxv:0,isnm:False|UVIN-9646-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:9646,x:31717,y:32839,varname:node_9646,prsc:2,uv:0;n:type:ShaderForge.SFN_Tex2d,id:759,x:31929,y:32381,ptovrint:False,ptlb:FlowTexture,ptin:_FlowTexture,varname:_FlowTexture,prsc:2,tex:49465d24082ca0d42bb65153522384cf,ntxv:0,isnm:False|UVIN-1991-OUT;n:type:ShaderForge.SFN_TexCoord,id:2797,x:31044,y:32373,varname:node_2797,prsc:2,uv:1;n:type:ShaderForge.SFN_Frac,id:6508,x:31551,y:32230,varname:node_6508,prsc:2|IN-1100-OUT;n:type:ShaderForge.SFN_Append,id:1991,x:31677,y:32381,varname:node_1991,prsc:2|A-6508-OUT,B-2797-V;n:type:ShaderForge.SFN_Time,id:5946,x:30799,y:32214,varname:Time,prsc:2;n:type:ShaderForge.SFN_Add,id:1100,x:31344,y:32230,varname:node_1100,prsc:2|A-6569-OUT,B-2797-U;n:type:ShaderForge.SFN_Color,id:3531,x:31929,y:32612,ptovrint:False,ptlb:FlowColor,ptin:_FlowColor,varname:node_3531,prsc:2,glob:False,c1:0.6137931,c2:1,c3:0,c4:1;n:type:ShaderForge.SFN_Multiply,id:9197,x:32166,y:32464,varname:node_9197,prsc:2|A-759-RGB,B-3531-RGB;n:type:ShaderForge.SFN_LightVector,id:3007,x:31362,y:32962,varname:node_3007,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:5164,x:31362,y:33139,prsc:2,pt:False;n:type:ShaderForge.SFN_Dot,id:4355,x:31540,y:33071,varname:node_4355,prsc:2,dt:0|A-3007-OUT,B-5164-OUT;n:type:ShaderForge.SFN_Multiply,id:7420,x:31717,y:33071,varname:node_7420,prsc:2|A-2111-OUT,B-4355-OUT;n:type:ShaderForge.SFN_Vector1,id:2111,x:31717,y:33004,varname:node_2111,prsc:2,v1:0.4;n:type:ShaderForge.SFN_Add,id:29,x:31926,y:33071,varname:node_29,prsc:2|A-2111-OUT,B-7420-OUT;n:type:ShaderForge.SFN_Multiply,id:4270,x:32114,y:33071,varname:node_4270,prsc:2|A-8595-RGB,B-29-OUT;n:type:ShaderForge.SFN_Divide,id:6569,x:31044,y:32231,varname:node_6569,prsc:2|A-5946-T,B-6914-OUT;n:type:ShaderForge.SFN_Vector1,id:6914,x:30731,y:32397,varname:node_6914,prsc:2,v1:1.3;proporder:8595-759-3531;pass:END;sub:END;*/

Shader "Shader Forge/PowerUpPuls" {
    Properties {
        _MainTex ("MainTex", 2D) = "white" {}
        _FlowTexture ("FlowTexture", 2D) = "white" {}
        _FlowColor ("FlowColor", Color) = (0.6137931,1,0,1)
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "ForwardBase"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _FlowTexture; uniform float4 _FlowTexture_ST;
            uniform float4 _FlowColor;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float4 posWorld : TEXCOORD2;
                float3 normalDir : TEXCOORD3;
                LIGHTING_COORDS(4,5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.normalDir = mul(_Object2World, float4(v.normal,0)).xyz;
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
/////// Vectors:
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
////// Lighting:
////// Emissive:
                float4 Time = _Time + _TimeEditor;
                float2 node_1991 = float2(frac(((Time.g/1.3)+i.uv1.r)),i.uv1.g);
                float4 _FlowTexture_var = tex2D(_FlowTexture,TRANSFORM_TEX(node_1991, _FlowTexture));
                float3 emissive = (_FlowTexture_var.rgb*_FlowColor.rgb);
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float node_2111 = 0.4;
                float3 finalColor = emissive + (_MainTex_var.rgb*(node_2111+(node_2111*dot(lightDirection,i.normalDir))));
                return fixed4(finalColor,1);
            }
            ENDCG
        }
        Pass {
            Name "ForwardAdd"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            Fog { Color (0,0,0,0) }
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _FlowTexture; uniform float4 _FlowTexture_ST;
            uniform float4 _FlowColor;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float4 posWorld : TEXCOORD2;
                float3 normalDir : TEXCOORD3;
                LIGHTING_COORDS(4,5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.normalDir = mul(_Object2World, float4(v.normal,0)).xyz;
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
/////// Vectors:
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
////// Lighting:
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float node_2111 = 0.4;
                float3 finalColor = (_MainTex_var.rgb*(node_2111+(node_2111*dot(lightDirection,i.normalDir))));
                return fixed4(finalColor * 1,0);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
