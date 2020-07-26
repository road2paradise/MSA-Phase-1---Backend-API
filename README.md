# Microsoft Student Accelerator Phase 1 - Backend API

# Basic Overview

Created as a module to complete Microsoft Student Accelerator Phase 1 - Backend Pathway.

To access my Swagger UI with my solution please click [here.](https://kenny-student.azurewebsites.net/index.html)

## Tasks:
- Database
  - Create an additional Address with attributes:  `StudentId`, `Street Number`, `Street`, `Suburb`, `City`, `Postcode` and `Country` and assign appropriate datatype for each of     the attributes.
  - Show SQL Database through the Query Editor (**screenshots**) for both tables with rows of example instances.
- API
  - Create basic CRUD requests for the **Student** and **Address** table.
  - Create an API method that **adds** new address for a student using his/her StudentId.
  - Create an API method that **changes** the address of a student using his/her Student Id.
  - **Screenshot** of Swagger UI showing all API Endpoints.


# Database

```json 
[
  {
    "addressID": 0,
    "streetNumber": 0,
    "street": "string",
    "suburb": "string",
    "city": "string",
    "country": "string",
    "postcode": 0,
    "studentId": 0,
    "student": {
      "studentId": 0,
      "firstName": "string",
      "middleName": "string",
      "lastName": "string",
      "emailAddress": "string",
      "phoneNumber": 0
    }
  }
]


```





## Create an API method that **adds** new address for a student using his/her StudentID
My back-end does a sanity check to see if the student is actually in the table, otherwise it throws a NotFound().
Student is then able to provide details ( `StudentId`, `Street Number`, `Street`, `Suburb`, `City`, `Postcode` and `Country` ) in the request. The back-end will then auto-generate a new PK (`addressID`) and this will automatically be associated with the student using the FK (`StudentId`).

Below shows the user adding to `studentId` #62 the address. I have not given an `addressID` as this is allocated automatically.

![addressAPI1](/StudentSIMS/images/addressAPI1.PNG?raw=true)

Below is an image of the response from the Backend showing the address with the new PK `addressID` and the associated `studentId` and student.

![addressAPI2](/StudentSIMS/images/addressAPI2.PNG?raw=true)

## Create an API method that **changes** the address of a student using his/her StudentID
I assumed here that it meant that given a Student's ID they are able to update their address (singular) assuming that they have the addressID of the address he/she want to update.
I used the endpoint `/api/StudentAddress/{id}` to differ from updating a normal address using `/api/Address/{id}`.

Below shows the user updating their address using their `studentId` as the input. `addressID` needs to be entered as there can be multiple addressses associated with one student.

![studentaddressAPI1](/StudentSIMS/images/studentAPI1.PNG?raw=true)

Below shows the response from the Backend showing 204 meaning no content to show.

![studentaddressAPI2](/StudentSIMS/images/studentAPI2.PNG?raw=true)

Below is the `GET` request on all addresses which shows the address has been updated successfully.


![studentaddressAPI3](/StudentSIMS/images/studentAPI3.PNG?raw=true)




## Images showing the Address and Student tables in Azure.

![address_azure](/StudentSIMS/images/addressAzureSQL..PNG?raw=true)


In the above picture you can see that the `studentId` is associated with the following photo's student entry in `studentId` number 62.




![student_azure](/StudentSIMS/images/studentAzureSQL..PNG?raw=true)

## Images showing the API Endpoints hosted on Azure using the Swagger UI.
![Swagger_UI](/StudentSIMS/images/SwaggerAPI.PNG?raw=true)


The above picture shows my two new API methods.
1. `POST` /api/Addresses/{id}
2. `PUT` /api/StudentAddress/{id}.
