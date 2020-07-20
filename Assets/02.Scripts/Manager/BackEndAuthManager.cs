using Firebase.Auth;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackEndAuthManager
{
    static FirebaseAuth auth;

    public static string user_id = "";

    public static void init()
    {
        auth = FirebaseAuth.DefaultInstance;


    }

    public static string Get_UserId()
    {
        Debug.Log("Get_UserId" + auth.CurrentUser.UserId);

        return auth.CurrentUser.UserId;
    }


    public static bool Get_Join_User()
    {
        return auth.CurrentUser != null;
    }

    public static void GoogleFireBaseLogin()
    {
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
                BackEndDataManager.instance.Get_First_Game();
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
            BackEndDataManager.instance.Get_First_Game();

        }

    }
}
