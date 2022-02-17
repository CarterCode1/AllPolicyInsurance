# All-Policy Insurance
# Readme File


# All-Policy Insurance Rest WebAPI Service

In order to display customer's insurance policies to our website and mobile application we have stood up a WebAPI service to handle requests.

The key features of this WebAPI application include lightweight payload, straightforward verification and testing. 

## Download the application
$ git clone https://github.com/CarterCode1/AllPolicyInsurance.git


## Requirements and Dependencies

    A list of technologies used within the project:
* .NetCore 5.0
* Local instance of Microsoft SQL Server
* Microsoft Entity Framework Core 5.0
* Automapper 11.0
* Polly 7.2.3
* Swagger

## Set up the Database

The database connection string is located within the 'appsettings.json' file. 
    
    "DefaultConnection": "Persist Security Info=False; Integrated Security=true; Initial Catalog=AllPolicyInsuranceDB;server=(local); Connection Timeout=100000;"
    
For development purposes we have been using Windows Authentication and a '(local)' server value. 
This will need to ne improved upon as we move to an intergration environment.

## Installing the Database

Once the application has been downloaded and all dependent package dependencies have been installed, we are ready to install the database.
For testing purposing, a seeding method has been established, details can be found within the 'ModelBuilderExtension.cs' file.
From the Package Manager Console run the command
    
    PM> update-database

This will utilize Code-First technologies to build all required tables and relations needed to the application to run.  

# Running and Verifying of the Application

Once we build and run the solution, this test version will launch a browser window with the Swagger Application running
    

    https://localhost:44311/swagger/index.html

This will be our testing client used to verify the PolicyAPI



The REST API to the Policy API is described below.

## Get list of all policies

### Request

` GET /api/v1/Policy/`

    curl -X GET "https://localhost:44311/api/v1/Policy" -H  "accept: */*"

### Response

    Status: 200 OK
    content-type: application/json; charset=utf-8 
    date: Thu17 Feb 2022 00:07:06 GMT 
    server: Microsoft-IIS/10.0 
    x-powered-by: ASP.NET 

    [
      {
        "PolicyId": 158000,
        "EffectiveDate": "2014-02-16T14:00:28.5560073",
        "ExpirationDate": "2020-06-16T14:00:28.5560075",
        "FirstName": "Andrew",
        "LastName": "Wiggins",
        "DriversLicenseNumber": "80950036",
        "PremiumPrice": 225,
        "Vehicles": [
          {
            "Year": "2020",
            "Model": "G.T. 350",
            "Make": "Shelby"
          }
        ],
        "Address": {
          "Street": "570 Pharcyde Lane",
          "City": "Oakland",
          "State": "CA",
          "PostalCode": "94604"
        }
      },
      {
        "PolicyId": 277347,
        "EffectiveDate": "2014-02-16T14:00:28.5560049",
        "ExpirationDate": "2018-02-16T14:00:28.5560052",
        "FirstName": "Mark",
        "LastName": "Stone",
        "DriversLicenseNumber": "62157047",
        "PremiumPrice": 145,
        "Vehicles": [
          {
            "Year": "1966",
            "Model": "Mustang",
            "Make": "Ford"
          }
        ],
        "Address": {
          "Street": "702 Flamingo Rd",
          "City": "Las Vegas",
          "State": "NV",
          "PostalCode": "89105"
        }
      }
    ]
  
## Create a new policy

### Request

`POST /api/v1/Policy`

    curl -X POST "https://localhost:44311/api/v1/Policy" -H  "accept: */*" -H  "Content-Type: application/json" -d "{\"EffectiveDate\":\"2022-04-        15T20:21:23.422Z\",\"ExpirationDate\":\"2022-02-15T20:21:23.422Z\",\"FirstName\":\"Bad\",\"LastName\":\"Request\",\"DriversLicenseNumber\":\"11111110\",\"PremiumPrice\":300,\"Vehicles\":[{\"Year\":\"1909\",\"Model\":\"Ford\",\"Make\":\"Edge\"}],\"Address\":{\"Street\":\"123 Main St\",\"City\":\"Las Vegas\",\"State\":\"NV\",\"PostalCode\":\"89110\"}}"

### Response
    
    Status: 201 Created
    content-length: 344 
    content-type: application/json; charset=utf-8 
    date: Thu17 Feb 2022 00:12:51 GMT 
    location: https://localhost:44311/api/v1/Policy/978373 
    server: Microsoft-IIS/10.0 
    x-powered-by: ASP.NET 

    {
      "PolicyId": 978373,
      "EffectiveDate": "2022-04-15T20:21:23.422Z",
      "ExpirationDate": "2022-02-15T20:21:23.422Z",
      "FirstName": "Bad",
      "LastName": "Request",
      "DriversLicenseNumber": "11111110",
      "PremiumPrice": 300,
      "Vehicles": [
        {
          "Year": "1909",
          "Model": "Ford",
          "Make": "Edge"
        }
      ],
      "Address": {
        "Street": "123 Main St",
        "City": "Las Vegas",
        "State": "NV",
        "PostalCode": "89110"
      }
    }

## Get a single Insurance Policy by Policy ID and Driver’s License number

### Request

`GET /api/v1/Policy/id/{id}/license/{license}`

    curl -X GET "https://localhost:44311/api/v1/Policy/id/158000/license/80950036" -H  "accept: */*"

### Response

    HTTP/1.1 200 OK
    Date: Thu, 24 Feb 2011 12:36:30 GMT
    Status: 200 OK
    Connection: close
    Content-Type: application/json
    Content-Length: 36

        {
        "PolicyId": 158000,
          "EffectiveDate": "2014-02-16T14:00:28.5560073",
          "ExpirationDate": "2020-06-16T14:00:28.5560075",
          "FirstName": "Andrew",
          "LastName": "Wiggins",
          "DriversLicenseNumber": "80950036",
          "PremiumPrice": 225,
          "Vehicles": [
            {
              "Year": "2020",
              "Model": "G.T. 350",
              "Make": "Shelby"
            }
          ],
          "Address": {
            "Street": "570 Pharcyde Lane",
            "City": "Oakland",
            "State": "CA",
            "PostalCode": "94604"
          }
        }

## Get a non-existent Policy

### Request

`GET /api/v1/Policy/id/{id}/license/{license}`

    curl -X GET "https://localhost:44311/api/v1/Policy/id/112234/license/89053345" -H  "accept: */*"

### Response

    Status: 404 Not Found
    content-type: text/plain; charset=utf-8 
    date: Thu17 Feb 2022 00:24:16 GMT 
    server: Microsoft-IIS/10.0 
    x-powered-by: ASP.NET 

    'Policy with Id: 112234 was not found.'

## Get a policies by Driver’s License number

### Request

`GET /api/v1/Policy/license/{license}`

    curl -X GET "https://localhost:44311/api/v1/Policy/license/97786428" -H  "accept: */*"

### Response
    
     Status: 200 OK
     content-length: 415 
     content-type: application/json; charset=utf-8 
     date: Thu17 Feb 2022 00:30:12 GMT 
     server: Microsoft-IIS/10.0 
     x-powered-by: ASP.NET 

    [{
    "PolicyId": 318823,
    "EffectiveDate": "2021-02-16T14:00:28.5560062",
    "ExpirationDate": "2025-02-16T14:00:28.5560064",
    "FirstName": "Steph",
    "LastName": "Curry",
    "DriversLicenseNumber": "97786428",
    "PremiumPrice": 315,
    "Vehicles": [
      {
        "Year": "2019",
        "Model": "SL-63",
        "Make": "Mercedes-benz"
      },
      {
        "Year": "1990",
        "Model": "NSX",
        "Make": "Acura"
      }
    ],
    "Address": {
      "Street": "88 Haight St",
      "City": "San Fransisco",
      "State": "CA",
      "PostalCode": "94117"
    }
    }]
    
## Optional Parameters on Get Policies by Driver's License

### Sort Vehicles 
    `GET /api/v1/Policy/license/{license}`

#### Sort Order Values
##### Ascending  ‘asc'
    curl -X GET "https://localhost:44311/api/v1/Policy/license/97786428?sortOrder=asc" -H  "accept: */*"

##### Descending 'desc'
    curl -X GET "https://localhost:44311/api/v1/Policy/license/97786428?sortOrder=desc" -H  "accept: */*"
 
### Include Expired Insurance Policies
This value is false by default, therefore expired policies with not return on a standard request.  
To demonstrate its functionality we send two request using the same license number

##### IsExpired  'false'

    curl -X GET "https://localhost:44311/api/v1/Policy/license/97786428?isExpired=false" -H  "accept: */*"
         
         Status: 404 Not Found
         Policy with Drivers License 80950036 was not found.
    
##### IsExpired  'true'

        curl -X GET "https://localhost:44311/api/v1/Policy/license/80950036?isExpired=true" -H  "accept: */*"
        
            [{
                "PolicyId": 158000,
                "EffectiveDate": "2014-02-16T14:00:28.5560073",
                "ExpirationDate": "2020-06-16T14:00:28.5560075",
                "FirstName": "Andrew",
                "LastName": "Wiggins",
                "DriversLicenseNumber": "80950036",
                "PremiumPrice": 225,
                "Vehicles": [
                  {
                    "Year": "2020",
                    "Model": "G.T. 350",
                    "Make": "Shelby"
                  }
                ],
                "Address": {
                  "Street": "570 Pharcyde Lane",
                  "City": "Oakland",
                  "State": "CA",
                  "PostalCode": "94604"
                }
              }]
 
 
 #### Include both optional parameters
 
        curl -X GET "https://localhost:44311/api/v1/Policy/license/42787182?sortOrder=asc&isExpired=true" -H  "accept: */*"
        
            [{
                "PolicyId": 324822,
                "EffectiveDate": "2022-01-17T14:00:28.5535404",
                "ExpirationDate": "2024-02-16T14:00:28.5558504",
                "FirstName": "Joe",
                "LastName": "Burrow",
                "DriversLicenseNumber": "42787182",
                "PremiumPrice": 350,
                "Vehicles": [
                  {
                    "Year": "2008",
                    "Model": "Z4",
                    "Make": "BMW"
                  },
                  {
                    "Year": "2014",
                    "Model": "Suburban",
                    "Make": "GMC"
                  },
                  {
                    "Year": "2020",
                    "Model": "Model X",
                    "Make": "Tesla"
                  }
                ],
                "Address": {
                  "Street": "123 Main St",
                  "City": "Cincinatti",
                  "State": "OH",
                  "PostalCode": "45215"
                }
              }]

    curl -X GET "https://localhost:44311/api/v1/Policy/license/42787182?sortOrder=desc&isExpired=true" -H  "accept: */*"
    
          [{
            "PolicyId": 324822,
            "EffectiveDate": "2022-01-17T14:00:28.5535404",
            "ExpirationDate": "2024-02-16T14:00:28.5558504",
            "FirstName": "Joe",
            "LastName": "Burrow",
            "DriversLicenseNumber": "42787182",
            "PremiumPrice": 350,
            "Vehicles": [
              {
                "Year": "2020",
                "Model": "Model X",
                "Make": "Tesla"
              },
              {
                "Year": "2014",
                "Model": "Suburban",
                "Make": "GMC"
              },
              {
                "Year": "2008",
                "Model": "Z4",
                "Make": "BMW"
              }
            ],
            "Address": {
              "Street": "123 Main St",
              "City": "Cincinatti",
              "State": "OH",
              "PostalCode": "45215"
            }
          }]
