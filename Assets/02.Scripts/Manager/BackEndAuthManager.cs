using Firebase.Auth;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackEndAuthManager
{
    static FirebaseAuth auth;

    public static string user_id = "";

    public static void Init()
    {
        auth = FirebaseAuth.DefaultInstance;


    }

    public static string Get_UserId()
    {
        return auth.CurrentUser.UserId;
    }


    public static bool Get_Join_User()
    {

        return auth.CurrentUser != null;
    }

    public static bool Get_User_Type()
    {
        return auth.CurrentUser.IsAnonymous;
    }

    /// <summary>
    /// 구글 로그인
    /// </summary>
    public static void GoogleFireBaseLogin()
    {

        PopupManager.Close_Popup();

        if (auth.CurrentUser == null)
        {
            Debug.Log("로그인 안 되어 있음");

            Firebase.Auth.Credential credential =
            Firebase.Auth.GoogleAuthProvider.GetCredential(SocalManager.GetTokens(), null);
            auth.SignInWithCredentialAsync(credential).ContinueWith(task =>
            {
                if (task.IsCanceled)
                {
                    return;
                }
                if (task.IsFaulted)
                {
                    return;
                }

                user_id = auth.CurrentUser.UserId;
                BackEndDataManager.instance.Get_First_Data();

            });

        }
        else
        {

            //Set_State("로그인 되어 있음 " + auth.CurrentUser.UserId);
            Debug.Log("로그인 되어 있음 " + auth.CurrentUser.DisplayName + " \n "
                + auth.CurrentUser.Email + " \n "
                + auth.CurrentUser.IsAnonymous + " \n "
                + auth.CurrentUser.IsEmailVerified + " \n "
                + auth.CurrentUser.ProviderId + " \n "
                + auth.CurrentUser.UserId + " \n ");

            user_id = auth.CurrentUser.UserId;
            BackEndDataManager.instance.Get_First_Data();

        }

    }

    /// <summary>
    /// 익명로그인
    /// </summary>
    public static void GoogleFireAnonymousLogin()
    {
        PopupManager.Close_Popup();

        if (auth.CurrentUser == null)
        {
            Debug.Log("로그인 안 되어 있음");

            auth.SignInAnonymouslyAsync().ContinueWith(task =>
            {
                if (task.IsCanceled)
                {
                    return;
                }
                if (task.IsFaulted)
                {
                    return;
                }

                user_id = auth.CurrentUser.UserId;
                Debug.Log("익명 아이디 " + user_id);
                BackEndDataManager.instance.Get_First_Data();
            });

        }
        else
        {

            //Set_State("로그인 되어 있음 " + auth.CurrentUser.UserId);
            Debug.Log("로그인 되어 있음 " + auth.CurrentUser.DisplayName + " \n "
                + auth.CurrentUser.Email + " \n "
                + auth.CurrentUser.IsAnonymous + " \n "
                + auth.CurrentUser.IsEmailVerified + " \n "
                + auth.CurrentUser.ProviderId + " \n "
                + auth.CurrentUser.UserId + " \n ");

            user_id = auth.CurrentUser.UserId;
            BackEndDataManager.instance.Get_First_Data();

        }

    }

    public static void Firebase_Logout()
    {
        auth.SignOut();
    }
}