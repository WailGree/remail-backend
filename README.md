# Remail-backend

Backend of project "Remail". ASP.NET Core based. API Controller, makes use of [RemailCore](https://github.com/WailGree/remailcore) Class Library.


Controllers:
1. [ApiController](#apicontroller)

## ApiController
Route:"api"
Endpoints:
 1. [login](#login)
 2. [log-out](#log-out)
 3. [get-mails](#get-mails)
 4. [send-email](#send-email)

### Login
Method: POST
Consumes: application/x-www-form-urlencoded
Required key-value pairs: username, password

Checks whether given username-password pair is correct. Returns status 200 "Success" if correct.

### Log-out
Method: POST
Consumes: application/x-www-form-urlencoded

Deletes temporary credentials from API server. Returns status 200 "Success" once done.

### Get-mails
Method: POST

Returns emails of account given by login endpoint.

### Send-email
Method: POST
Consumes: application/x-www-form-urlencoded
Required key-value pairs: body, subject, to(target email address)

Sends email given by key-value pairs, and by saved credentials on server.
