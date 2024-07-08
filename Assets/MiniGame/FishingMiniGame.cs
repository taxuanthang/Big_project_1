﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FishingMiniGame : MonoBehaviour
{
    [SerializeField] Transform topPivot;
    [SerializeField] Transform bottomPivot;

    [SerializeField] Transform fish;

    float fishPosition;
    float fishDestination;
    float fishTimer;

    [SerializeField] float timerMultiplicator = 3f;
    float fishSpeed;
    [SerializeField] float smoothMotion = 1f;

    [SerializeField] Transform hook;
    float hookPosition;
    [SerializeField] float hookSize = 1.0f;
    [SerializeField] float hookPower = 5f;
    float hookProgress;
    float hookPullVelocity;
    [SerializeField] float hookPullPower = 0.01f;
     [SerializeField] float hookGravityPower = 0.005f;
    [SerializeField] float hookProgressDegradationPower =  0.1f;

    [SerializeField] SpriteRenderer hookSpriteRenderer;
    [SerializeField] Transform progressBarContainer;

    bool pause = false; //hay à nha

    [SerializeField] float failTimer = 10f;
    void Fish()
    {
        fishTimer -= Time.deltaTime;
        if (fishTimer < 0) 
        {
            fishTimer = UnityEngine.Random.value*timerMultiplicator;

            fishDestination = UnityEngine.Random.value;
        }
        fishPosition = Mathf.SmoothDamp(fishPosition,fishDestination,ref fishSpeed,smoothMotion);
        fish.position = Vector3.Lerp(bottomPivot.position, topPivot.position, fishPosition);

    }

    void Hook()
    {
        if (Input.GetMouseButton(0))
        {
            hookPullVelocity += hookPullPower * Time.deltaTime;
            
        }
        hookPullVelocity -= hookGravityPower * Time.deltaTime;
/*        Debug.Log(hookPullVelocity);*/
        hookPosition += hookPullVelocity;

        if (hookPosition - hookSize / 2 < 0f && hookPullVelocity< 0f) 
        {
            hookPullVelocity = 0f;
        }

        if (hookPosition + hookSize / 2>1f && hookPullVelocity > 0f)
        {
            hookPullVelocity = 0f;
        }

        hookPosition = Mathf.Clamp(hookPosition, hookSize/2, 1 - hookSize/2);
        hook.position = Vector3.Lerp(bottomPivot.position,topPivot.position, hookPosition);
        
    }

    private void ProgressCheck()
    {
        Vector3 ls = progressBarContainer.localScale;
        ls.y = hookProgress;
        progressBarContainer.localScale = ls;

        float min = hookPosition - hookSize / 2;
        float max = hookPosition + hookSize / 2;
        if (min < fishPosition && fishPosition <max) 
        {
            hookProgress += hookPower * Time.deltaTime;
        }
        else
        {
            hookProgress -= hookProgressDegradationPower * Time.deltaTime;

            failTimer -= Time.deltaTime;
            if(failTimer < 0)
            {
                Lose();
                SceneManager.UnloadSceneAsync("Minigame");
            }
        }
        if(hookProgress >= 1f) 
        {
            pause = true;
            Debug.Log("YOU WIN! YOU CAUGHT THE FISH!");
            SceneManager.UnloadSceneAsync("Minigame");

            LakeControl.isFished = true; 
        }

        hookProgress = Mathf.Clamp(hookProgress, 0f, 1f);

    }
    private void Lose()
    {
        pause = true;
        Debug.Log("YOU LOSE! FISH SWIM AWAY FROM YOU!");

    }
     private void Start()
    {
        Resize();
    }
    private void Update()
    {
        if (pause) 
        { 
            return; 
        }

        Fish();
        Hook();
        ProgressCheck();
    }
    private void Resize()
    {
        Bounds b = hookSpriteRenderer.bounds;
        float ySize = b.size.y;
        Vector3 ls = hook.localScale;
        float distance = Vector3.Distance(topPivot.position, bottomPivot.position);
        ls.y = (distance / ySize * hookSize);
        hook.localScale = ls;

    }




}

