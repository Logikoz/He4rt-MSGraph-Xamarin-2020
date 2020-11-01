# He4rt And Microsoft Graph Event
#### A simple application to send contact invitations to the best developer community

## Screenshots
<img src="https://user-images.githubusercontent.com/37851168/97809441-d9a3be80-1c3a-11eb-8d0a-4e518009a75b.png" width="400" height="300"/>
<img src="https://user-images.githubusercontent.com/37851168/97809470-1374c500-1c3b-11eb-87b8-4b327555fe2a.png" width="400" height="300"/>
<img src="https://user-images.githubusercontent.com/37851168/97809473-17a0e280-1c3b-11eb-9020-25e71518c256.png" width="400" height="300"/>

## Prerequisites to run this project

To run the completed project in this folder, you need the following:

- [Visual Studio](https://visualstudio.microsoft.com/vs/) installed on your development machine. (**Note:** This tutorial was written with Visual Studio 2019 version 16.7.6.
The steps in this guide may work with other versions, but that has not been tested.)
- Xamarin installed as part of your Visual Studio installation. See [Installing Xamarin](https://docs.microsoft.com/xamarin/cross-platform/get-started/installation) for instructions on installing and configuring Xamarin.
- Either a personal Microsoft account with a mailbox on Outlook.com, or a Microsoft work or school account.

If you don't have a Microsoft account, there are a couple of options to get a free account:

- You can [sign up for a new personal Microsoft account](https://signup.live.com/signup?wa=wsignin1.0&rpsnv=12&ct=1454618383&rver=6.4.6456.0&wp=MBI_SSL_SHARED&wreply=https://mail.live.com/default.aspx&id=64855&cbcxt=mai&bk=1454618383&uiflavor=web&uaid=b213a65b4fdc484382b6622b3ecaa547&mkt=E-US&lc=1033&lic=1).
- You can [sign up for the Office 365 Developer Program](https://developer.microsoft.com/office/dev-program) to get a free Office 365 subscription.

## Register an application with the Azure Portal

1. Open a browser and navigate to the [Azure Active Directory admin center](https://aad.portal.azure.com). Login using a **personal account** (aka: Microsoft Account) or **Work or School Account**.

1. Select **New registration**. On the **Register an application** page, set the values as follows.

    - Set **Name** to `He4rt.MSGraph`.
    - Set **Supported account types** to **Accounts in any organizational directory and personal Microsoft accounts**.
    - Under **Redirect URI (optional)**, change the dropdown to **Public client (mobile & desktop)**, and set the value to `msauth://He4rt.MSGraphh`.

1. Choose **Register**. On the **He4rt.MSGraph** page, copy the value of the **Application (client) ID** and save it, you will need it in the next step.


## Configure the sample

1. Edit the `Helpers/AuthSettings.cs` file and make the following changes.
    1. Replace `YOUR_APP_ID_HERE` with the **Application Id** you got from the Azure portal.

## Run the sample

In Visual Studio, press **F5** or choose **Debug > Start Debugging**.

## Version history

| Version |       Date       |              Comments              |       Download       |
| ------- | ---------------- | ---------------------------------- | -------------------- |
| 1.0     | 11/2020          | Published                          |        [apk](https://github.com/Logikoz/He4rt-MSGraph-Xamarin-2020/releases/download/v1.0/He4rt.MSGraph.apk)      |

## He4rt Developers

Made by [He4rt Developers](https://twitter.com/He4rtDevs)
