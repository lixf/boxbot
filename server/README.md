# API Interface

API requests are to be made via HTTP request to port 8080. 

The format of the request body is JSON. Remember to set Content-Type to 'application/json'.

API will always repsond with one of the following HTTP status codes in the event of error:
  - 400: Invalid arguments
  - 500: Server Error

## POST /api/getRegionItems
- Sample Request:

```
{
  "lat": 40.5,
  "lng": -78.5
}
```

- Sample Response:

```
{
  "region": {
    "rid": 1,
    "name": "Pittsburgh",
    "start_lat": 40,
    "end_lat": 41,
    "start_lng": -79,
    "end_lng": -78
  },
  "items": [
    {
      "name": "Basic Armour",
      "defense": 1,
      "probability": 0.8,
      "type": "armour",
      "pvalue": 1,
      "lat": 0.826971530681476,
      "lng": 0.47178891161456704,
      "iid": "ee6c0591-8f66-4cde-85e9-818923526101"
    },
    {
      "name": "Advanced Armour",
      "defense": 2,
      "probability": 0.2,
      "type": "armour",
      "pvalue": 0.2,
      "lat": 0.5312756646890193,
      "lng": 0.08691834332421422,
      "iid": "60f0c28b-8302-4fae-824e-a769de359f53"
    }
  ]
}
```

- Error HTTP Response Code:
  - 400: Invalid arguments
  - 500: Server Error

## POST /api/claimItem

- Sample Request:

```
{
  "iid": "07141bf1-fd13-4b6e-a62f-825b767dfee3",
  "rid": 1,
  "uid": 12345
}
```

- Sample Response:
  - HTTP 200 Status Code: Item claimed by the user successfully
  - HTTP 410 Status Code: The item has been claimed by another user.


# Data Types

## User
```
{
  "uid": 12345,
  "firstname": Bob,
  "lastname": Chen,
  "join_date": 1235
}
```

## Bot
```
{
  "bid": 1234,
  "uid": 12345,
  "hp": 123,
  "armour": [
  ],
  "weapon1": {},
  "weapon2": {},
  "inventory": {
  }
}
```

## Prototypes
```
{
  "name": "Basic Armour",
  "type": "armour"
  // type specific fields
}
```

## Items
Items are prototypes instantiated with longitude, lattitude, iid
```
{
  "iid": "32a4fbed-676d-47f9-a321-cb2f267e2918",
  "name": "Basic Armour",
  "type": "armour",
  "lat": 79.3
  "lng": 32.4093
  // type specific fields
}
```
