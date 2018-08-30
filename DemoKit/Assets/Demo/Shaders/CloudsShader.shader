// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.02 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.02;sub:START;pass:START;ps:flbk:,lico:1,lgpr:1,nrmq:1,limd:1,uamb:True,mssp:True,lmpd:False,lprd:False,rprd:False,enco:False,frtr:True,vitr:True,dbil:False,rmgx:True,rpth:0,hqsc:True,hqlp:False,tesm:0,blpr:1,bsrc:3,bdst:7,culm:0,dpts:2,wrdp:False,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:5419,x:32342,y:32701,varname:node_5419,prsc:2|diff-6501-RGB,spec-3161-OUT,emission-3226-OUT,alpha-6501-A;n:type:ShaderForge.SFN_Tex2d,id:6501,x:31639,y:32520,ptovrint:False,ptlb:Texture,ptin:_Texture,varname:node_6501,prsc:2,tex:5b41efb743011ba469e5f79dfb11e5b4,ntxv:0,isnm:False|UVIN-3228-UVOUT;n:type:ShaderForge.SFN_Slider,id:3889,x:31304,y:32190,ptovrint:False,ptlb:Specular Level,ptin:_SpecularLevel,varname:node_3889,prsc:2,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Multiply,id:3161,x:31813,y:32282,varname:node_3161,prsc:2|A-6501-RGB,B-3889-OUT;n:type:ShaderForge.SFN_Panner,id:3228,x:30771,y:32355,varname:node_3228,prsc:2,spu:-0.001,spv:0;n:type:ShaderForge.SFN_LightVector,id:7605,x:31261,y:32888,varname:node_7605,prsc:2;n:type:ShaderForge.SFN_Tex2d,id:6734,x:30991,y:32512,ptovrint:False,ptlb:Night Texture,ptin:_NightTexture,varname:node_6734,prsc:2,tex:5b41efb743011ba469e5f79dfb11e5b4,ntxv:2,isnm:False|UVIN-3228-UVOUT;n:type:ShaderForge.SFN_Dot,id:4735,x:31522,y:32917,varname:node_4735,prsc:2,dt:0|A-7605-OUT,B-6824-OUT;n:type:ShaderForge.SFN_Multiply,id:3226,x:31837,y:32768,varname:node_3226,prsc:2|A-3267-OUT,B-2435-OUT;n:type:ShaderForge.SFN_NormalVector,id:6824,x:31261,y:33021,prsc:2,pt:False;n:type:ShaderForge.SFN_Vector1,id:8346,x:31426,y:33065,varname:node_8346,prsc:2,v1:1;n:type:ShaderForge.SFN_Subtract,id:2435,x:31792,y:32934,varname:node_2435,prsc:2|A-8346-OUT,B-4735-OUT;n:type:ShaderForge.SFN_Multiply,id:3267,x:31457,y:32722,varname:node_3267,prsc:2|A-5156-OUT,B-8586-OUT;n:type:ShaderForge.SFN_Vector1,id:8586,x:31238,y:32803,varname:node_8586,prsc:2,v1:0.15;n:type:ShaderForge.SFN_Color,id:5207,x:30966,y:32704,ptovrint:False,ptlb:node_5207,ptin:_node_5207,varname:node_5207,prsc:2,glob:False,c1:0.1825144,c2:0.190365,c3:0.2705882,c4:1;n:type:ShaderForge.SFN_Multiply,id:5156,x:31153,y:32639,varname:node_5156,prsc:2|A-6734-RGB,B-5207-RGB;proporder:6501-3889-6734-5207;pass:END;sub:END;*/

Shader "Shader Forge/CloudsShader" {
    Properties {
        _Texture ("Texture", 2D) = "white" {}
        _SpecularLevel ("Specular Level", Range(0, 1)) = 0
        _NightTexture ("Night Texture", 2D) = "black" {}
        _node_5207 ("node_5207", Color) = (0.1825144,0.190365,0.2705882,1)
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "ForwardBase"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            uniform sampler2D _Texture; uniform float4 _Texture_ST;
            uniform float _SpecularLevel;
            uniform sampler2D _NightTexture; uniform float4 _NightTexture_ST;
            uniform float4 _node_5207;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o;
                o.uv0 = v.texcoord0;
                o.normalDir = mul(unity_ObjectToWorld, float4(v.normal,0)).xyz;
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos(v.vertex);
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = 1;
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = 0.5;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float4 node_3438 = _Time + _TimeEditor;
                float2 node_3228 = (i.uv0+node_3438.g*float2(-0.001,0));
                float4 _Texture_var = tex2D(_Texture,TRANSFORM_TEX(node_3228, _Texture));
                float3 specularColor = (_Texture_var.rgb*_SpecularLevel);
                float3 directSpecular = (floor(attenuation) * _LightColor0.xyz) * pow(max(0,dot(halfDirection,normalDirection)),specPow);
                float3 specular = directSpecular * specularColor;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 indirectDiffuse = float3(0,0,0);
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float3 diffuse = (directDiffuse + indirectDiffuse) * _Texture_var.rgb;
////// Emissive:
                float4 _NightTexture_var = tex2D(_NightTexture,TRANSFORM_TEX(node_3228, _NightTexture));
                float3 emissive = (((_NightTexture_var.rgb*_node_5207.rgb)*0.15)*(1.0-dot(lightDirection,i.normalDir)));
/// Final Color:
                float3 finalColor = diffuse + specular + emissive;
                return fixed4(finalColor,_Texture_var.a);
            }
            ENDCG
        }
        Pass {
            Name "ForwardAdd"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            ZWrite Off
            
            Fog { Color (0,0,0,0) }
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            uniform sampler2D _Texture; uniform float4 _Texture_ST;
            uniform float _SpecularLevel;
            uniform sampler2D _NightTexture; uniform float4 _NightTexture_ST;
            uniform float4 _node_5207;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o;
                o.uv0 = v.texcoord0;
                o.normalDir = mul(unity_ObjectToWorld, float4(v.normal,0)).xyz;
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos(v.vertex);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = 0.5;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float4 node_8424 = _Time + _TimeEditor;
                float2 node_3228 = (i.uv0+node_8424.g*float2(-0.001,0));
                float4 _Texture_var = tex2D(_Texture,TRANSFORM_TEX(node_3228, _Texture));
                float3 specularColor = (_Texture_var.rgb*_SpecularLevel);
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow);
                float3 specular = directSpecular * specularColor;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 diffuse = directDiffuse * _Texture_var.rgb;
/// Final Color:
                float3 finalColor = diffuse + specular;
                return fixed4(finalColor * _Texture_var.a,0);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
