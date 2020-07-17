# MSA API+DATABASE MODULE.

To access my Swagger UI with my working Back-end API please click [here](https://kenny-student.azurewebsites.net/index.html)

## Create an API method that **adds** new address for a student using his/her StudentID
My back-end does a sanity check to see if the student is actually in the table, otherwise it throws a NotFound().
Student is then able to provide details ( `StudentId`, `Street Number`, `Street`, `Suburb`, `City`, `Postcode` and `Country` ) in the request. The back-end will then auto-generate a new PK to the `addressID` and this will automatically be associated with the student using the FK `StudentId`


## Create an API method that **changes** the address of a student using his/her StudentID
I assumed here that it meant that given a Student's ID they are able to update their address (singular) assuming that they have the addressID of the address he/she want to update.
I used the endpoint `/api/StudentAddress/{id}` to differ from updating a normal address using `/api/Address/{id}`.

## Images showing the Address and Student tables in Azure.

![address_azure](/StudentSIMS/images/addressAzureSQL.PNG?raw=true)

![student_azure](/StudentSIMS/images/studentAzureSQL.PNG?raw=true)

## Images showing the API Endpoints hosted on Azure using the Swagger UI.
![Swagger_UI](/StudentSIMS/images/SwaggerAPI.PNG?raw=true)
