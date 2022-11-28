﻿using Platinum.Player;
using System.Collections;
using System.Collections.Generic;
using Unity.FPS.Game;
using UnityEngine;
using UnityEngine.UI;

namespace Unity.FPS.UI
{
    public class NotificationHUDManager : MonoBehaviour
    {
        public Color DefaultColor;
        [Tooltip("UI panel containing the layoutGroup for displaying notifications")]
        public RectTransform NotificationPanel;

        [Tooltip("Prefab for the notifications")]
        public GameObject NotificationPrefab;

        private List<Notification> NotificationsList;

        void OnDestroy()
        {
            EventManager.RemoveListener<ObjectiveUpdateEvent>(OnObjectiveUpdateEvent);
            EventManager.RemoveListener<EndSpawnEvent>(OnPlayerSpawnEvent);
        }


        void Awake()
        {
            NotificationsList = new List<Notification>();
            EventManager.AddListener<ObjectiveUpdateEvent>(OnObjectiveUpdateEvent);
            EventManager.AddListener<EndSpawnEvent>(OnPlayerSpawnEvent);
        }

        private void OnPlayerSpawnEvent(EndSpawnEvent evt)
        {
            PlayerWeaponsManager playerWeaponsManager = evt.LoadManager.PlayerWeaponsManager;
            playerWeaponsManager.OnAddedWeapon += OnPickupWeapon;
        }
        void OnObjectiveUpdateEvent(ObjectiveUpdateEvent evt)
        {
            //CreateNotification(evt.NotificationText, DefaultColor);
            if (!string.IsNullOrEmpty(evt.NotificationText))
                CreateNotification(evt.NotificationText, DefaultColor);
        }

        public void OnTeamsKill(string killMissage, Color KillColor)
        {
            CreateNotification(killMissage, KillColor);
        }

        void OnPickupWeapon(WeaponController weaponController, int index)
        {
            if (index != 0)
                CreateNotification("Equeped up weapon : " + weaponController.WeaponName, DefaultColor);
        }

        void OnUnlockJetpack(bool unlock)
        {
            CreateNotification("Jetpack unlocked", DefaultColor);
        }

        private bool CheckActive() => gameObject.activeSelf;

        IEnumerator RefreshPrefab(string text, Color notificationColor)
        {
            yield return new WaitUntil(CheckActive);

        }

        private void Update()
        {
            if (gameObject.activeSelf && NotificationsList.Count > 0)
            {
                for (int i = 0; i < NotificationsList.Count; i++)
                {
                    InitNotification(NotificationsList[i]);
                    NotificationsList.RemoveAt(i);
                }
            }
        }

        private void InitNotification(Notification notification)
        {
            GameObject notificationInstance = Instantiate(NotificationPrefab, NotificationPanel);
            Image notificationImage = notificationInstance.GetComponentInChildren<Image>();
            notificationImage.color = notification.NotificationColor;
            notificationInstance.transform.SetSiblingIndex(0);

            NotificationToast toast = notificationInstance.GetComponent<NotificationToast>();
            if (toast)
            {
                toast.Initialize(notification.Text);
            }
        }

        public void CreateNotification(string text, Color notificationColor)
        {
            Notification notification = new Notification(text, notificationColor);
            NotificationsList.Add(notification);
            //StartCoroutine(RefreshPrefab(text, notificationColor));
        }
    }

    struct Notification
    {
        public string Text;
        public Color NotificationColor;
        public Notification(string text, Color notificationColor)
        {
            this.Text = text;
            this.NotificationColor = notificationColor;
        }
    }
}