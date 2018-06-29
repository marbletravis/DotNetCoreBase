# DotNet Core (2.0) and Angular CLI base application

The purpose of this repo is to have a quick starting point for projects using above technologies.

### What does it do?
 * DotNet Core
 * ASP.Net Identity
 * Angular CLI
 * Sends Emails (see below)
 * DB access

 ### How to use
 * The app was setup using the name zaAbXTwb to be easily replaced with whatever name you choose, simply find and replace. There are some files/paths that need to be fixed, I tried to keep this at a minimum.

 ### Usage Notes
 * This uses sendgrid for emails, to use you will need a sendgrid account and a secret file. Instructions can be found here.

    https://docs.microsoft.com/en-us/aspnet/core/security/authentication/accconfirm?tabs=aspnetcore2x
    https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?tabs=visual-studio

 * Uses (localdb)\\mssqllocaldb for the DB server.
 * Most the apsnet endpoints are still mvc, but some have been converted over to the AccountApiController. More will be converted as needed.
 

 